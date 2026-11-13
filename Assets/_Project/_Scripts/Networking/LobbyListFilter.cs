using System;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Networking
{
    // The lobby browser's filters; an empty region or map name and a MinLobbySize of 0 mean "any"
    public struct LobbyListFilter
    {
        public string Region;
        public string MapName;
        // lobbies that allow at least this many players
        public int MinLobbySize;
        public bool IsHidingFull;
        public bool IsHidingInProgress;
        public LobbyVisibilityFilter Visibility;

        // cached comparers, so sorting allocates nothing
        private static readonly IComparer<LobbyListing> ByName = Comparer<LobbyListing>.Create(CompareNames);
        private static readonly IComparer<LobbyListing> ByPlayers = Comparer<LobbyListing>.Create((a, b) =>
        {
            int byPlayers = b.PlayerCount.CompareTo(a.PlayerCount);
            return byPlayers != 0 ? byPlayers : CompareNames(a, b);
        });
        private static readonly IComparer<LobbyListing> ByPing = Comparer<LobbyListing>.Create((a, b) =>
        {
            if (a.HasPing != b.HasPing) return a.HasPing ? -1 : 1;
            int byPing = a.PingInMilliseconds.CompareTo(b.PingInMilliseconds);
            return byPing != 0 ? byPing : CompareNames(a, b);
        });

        public readonly bool Matches(LobbyListing listing)
        {
            if (listing == null) return false;
            if (!string.IsNullOrEmpty(Region) && !string.Equals(Region, listing.Region, StringComparison.OrdinalIgnoreCase)) return false;
            if (!string.IsNullOrEmpty(MapName) && !string.Equals(MapName, listing.MapName, StringComparison.OrdinalIgnoreCase)) return false;
            if (MinLobbySize > 0 && listing.MaxPlayers < MinLobbySize) return false;
            if (IsHidingFull && listing.IsFull) return false;
            if (IsHidingInProgress && listing.IsInProgress) return false;

            return Visibility switch
            {
                LobbyVisibilityFilter.Public => listing.Visibility == LobbyVisibility.Public,
                LobbyVisibilityFilter.FriendsOnly => listing.Visibility == LobbyVisibility.FriendsOnly,
                _ => true
            };
        }

        // Fills results with the matching lobbies in the given order; allocates nothing beyond results
        public static void Apply(IReadOnlyList<LobbyListing> source, in LobbyListFilter filter, LobbySortOrder sortOrder, List<LobbyListing> results)
        {
            results.Clear();
            for (int i = 0; i < source.Count; i++)
            {
                if (filter.Matches(source[i])) results.Add(source[i]);
            }

            results.Sort(sortOrder switch
            {
                LobbySortOrder.Players => ByPlayers,
                LobbySortOrder.Ping => ByPing,
                _ => ByName
            });
        }

        // List.Sort isn't stable, so ties fall back to the id and the order never flickers between refreshes
        private static int CompareNames(LobbyListing a, LobbyListing b)
        {
            int byName = string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase);
            return byName != 0 ? byName : string.CompareOrdinal(a.Id, b.Id);
        }
    }

    public enum LobbyVisibilityFilter
    {
        Any,
        Public,
        FriendsOnly
    }

    public enum LobbySortOrder
    {
        Name,
        // most players first
        Players,
        // unknown ping last
        Ping
    }
}
