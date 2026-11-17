using Cysharp.Threading.Tasks;
using Steamworks;
using Steamworks.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Networking
{
    // Steam lobbies as the browser's directory. Public lobbies come from a lobby search filtered to this game and build;
    // friends-only ones aren't searchable, so friends playing this game are asked for theirs.
    // Hosting itself is SteamConnectionService's: publishing only keeps the hosted lobby's live data current.
    public class SteamLobbyDirectory : ILobbyDirectory
    {
        private readonly ConnectionSettings _settings;
        private readonly SteamPlatform _steamPlatform;
        private readonly IMapCatalog _mapCatalog;
        private readonly List<Lobby> _friendLobbies = new();
        private readonly HashSet<ulong> _foundLobbyIds = new();

        public SteamLobbyDirectory(ConnectionSettings settings, SteamPlatform steamPlatform, IMapCatalog mapCatalog)
        {
            _settings = settings;
            _steamPlatform = steamPlatform;
            _mapCatalog = mapCatalog;
        }

        public bool HasSearchDistance => true;

        // the lobby's name, map, size and visibility are written by SteamConnectionService as they change
        public void Publish(LobbyListing listing)
        {
            var lobby = _steamPlatform.CurrentLobby;
            if (!_steamPlatform.IsReady || !lobby.HasValue || lobby.Value.Owner.Id.Value != _steamPlatform.LocalSteamId) return;

            SetDataIfChanged(lobby.Value, SteamLobbyData.InProgressKey, listing.IsInProgress ? SteamLobbyData.TrueValue : SteamLobbyData.FalseValue);
            // only known once Steam has measured its relays, which can take a few seconds after start
            var pingLocation = SteamNetworkingUtils.LocalPingLocation;
            if (pingLocation.HasValue) SetDataIfChanged(lobby.Value, SteamLobbyData.PingLocationKey, pingLocation.Value.ToString());
        }

        // private lobbies are hidden by their Steam lobby type, and invites need the lobby to stay
        public void Unpublish() { }

        public async UniTask FetchLobbies(LobbySearchDistance distance, List<LobbyListing> results, CancellationToken token)
        {
            results.Clear();
            _foundLobbyIds.Clear();
            if (!_steamPlatform.IsReady) return;

            var searchedLobbies = await CreateQuery(distance).RequestAsync().AsUniTask().AttachExternalCancellation(token);
            token.ThrowIfCancellationRequested();
            if (searchedLobbies != null)
            {
                foreach (var lobby in searchedLobbies) TryAddListing(lobby, results);
            }

            await FetchFriendLobbies(token);
            foreach (var lobby in _friendLobbies) TryAddListing(lobby, results);
        }

        private LobbyQuery CreateQuery(LobbySearchDistance distance)
        {
            var query = SteamMatchmaking.LobbyList
                .WithKeyValue(SteamLobbyData.GameKey, _settings.SteamLobbyGameId)
                .WithKeyValue(SteamLobbyData.VersionKey, Application.version)
                .WithMaxResults(_settings.SteamLobbySearchMaxResults);

            return distance switch
            {
                LobbySearchDistance.Close => query.FilterDistanceClose(),
                LobbySearchDistance.Far => query.FilterDistanceFar(),
                LobbySearchDistance.Worldwide => query.FilterDistanceWorldwide(),
                _ => query
            };
        }

        // a lobby's data is only sent to non-members on request; it arrives through the callbacks SteamPlatform pumps
        private async UniTask FetchFriendLobbies(CancellationToken token)
        {
            _friendLobbies.Clear();
            foreach (var friend in SteamFriends.GetFriends())
            {
                if (!friend.IsPlayingThisGame) continue;

                var lobby = friend.GameInfo?.Lobby;
                if (!lobby.HasValue || _foundLobbyIds.Contains(lobby.Value.Id.Value)) continue;
                if (_friendLobbies.Exists(found => found.Id.Value == lobby.Value.Id.Value)) continue;

                lobby.Value.Refresh();
                _friendLobbies.Add(lobby.Value);
            }
            if (_friendLobbies.Count == 0) return;

            float deadline = Time.realtimeSinceStartup + _settings.FriendLobbyDataTimeoutInSeconds;
            while (!HasAllFriendLobbyData() && Time.realtimeSinceStartup < deadline)
            {
                await UniTask.Yield(token);
            }
        }

        private bool HasAllFriendLobbyData()
        {
            foreach (var lobby in _friendLobbies)
            {
                if (!HasAnyData(lobby)) return false;
            }

            return true;
        }

        // any key at all, not this game's key: a friend may sit in another game's lobby on the shared test app id
        private static bool HasAnyData(Lobby lobby)
        {
            foreach (var _ in lobby.Data) return true;
            return false;
        }

        // other games and other builds share the test app id, and a friend may sit in one of them
        private void TryAddListing(Lobby lobby, List<LobbyListing> results)
        {
            if (!_foundLobbyIds.Add(lobby.Id.Value)) return;
            if (lobby.GetData(SteamLobbyData.GameKey) != _settings.SteamLobbyGameId) return;
            if (lobby.GetData(SteamLobbyData.VersionKey) != Application.version) return;

            // private lobbies are for invites and codes only, even when a friend's game info points at one
            var visibility = Enum.TryParse(lobby.GetData(SteamLobbyData.VisibilityKey), out LobbyVisibility parsedVisibility) ? parsedVisibility : LobbyVisibility.Public;
            if (visibility == LobbyVisibility.Private) return;

            var id = SteamLobbyId.Format(lobby.Id.Value);
            results.Add(new LobbyListing
            {
                Id = id,
                JoinTarget = id,
                Name = lobby.GetData(SteamLobbyData.NameKey),
                HostName = lobby.GetData(SteamLobbyData.HostNameKey),
                MapName = GetMapName(lobby),
                PlayerCount = lobby.MemberCount,
                MaxPlayers = lobby.MaxMembers,
                IsInProgress = lobby.GetData(SteamLobbyData.InProgressKey) == SteamLobbyData.TrueValue,
                Visibility = visibility,
                Region = lobby.GetData(SteamLobbyData.CountryKey),
                PingInMilliseconds = EstimatePing(lobby)
            });
        }

        private string GetMapName(Lobby lobby) =>
            int.TryParse(lobby.GetData(SteamLobbyData.MapIndexKey), NumberStyles.None, CultureInfo.InvariantCulture, out int mapIndex)
                ? _mapCatalog.GetMapDisplayName(mapIndex)
                : string.Empty;

        private static int EstimatePing(Lobby lobby)
        {
            var text = lobby.GetData(SteamLobbyData.PingLocationKey);
            if (string.IsNullOrEmpty(text)) return LobbyListing.UnknownPing;

            var location = NetPingLocation.TryParseFromString(text);
            if (!location.HasValue) return LobbyListing.UnknownPing;

            // negative until this PC has measured its own relays too
            int ping = SteamNetworkingUtils.EstimatePingTo(location.Value);
            return ping >= 0 ? ping : LobbyListing.UnknownPing;
        }

        // every SetData is sent to all members, so the heartbeat only writes what changed
        private static void SetDataIfChanged(Lobby lobby, string key, string value)
        {
            if (lobby.GetData(key) == value) return;
            lobby.SetData(key, value);
        }
    }
}
