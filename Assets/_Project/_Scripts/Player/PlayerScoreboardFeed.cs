using Cysharp.Threading.Tasks;
using KBCore.Refs;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.UI.HUD;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Owner only: while the scoreboard key is held, lists every player's team, state and round stats on this player's HUD.
    // Refreshed on a short interval instead of per session event, because ghost state is synced apart from the session.
    // Never shown while a menu is open: the lobby menu shares the key and leaves the gameplay actions on.
    [RequireComponent(typeof(InputReader))]
    public class PlayerScoreboardFeed : NetworkBehaviour
    {
        [Inject] private readonly GameHUDState _hudState;
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [Inject] private readonly SpawnedPlayerDirectory _spawnedPlayers;
        [Inject] private readonly LobbyMenuState _lobbyMenuState;
        [Inject] private readonly PauseMenuState _pauseMenuState;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField] private float _refreshIntervalInSeconds = 0.5f;

        private readonly List<ScoreboardEntry> _entries = new();
        private CancellationTokenSource _refreshCTS;

        private bool IsAnyMenuOpen => _lobbyMenuState.IsOpen || _pauseMenuState.IsOpen;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            if (!IsOwner) return;

            _inputReader.OnScoreboardHeldChanged += HandleScoreboardHeldChanged;
            _lobbyMenuState.OnOpenChanged += HandleMenuOpenChanged;
            _pauseMenuState.OnOpenChanged += HandleMenuOpenChanged;
        }

        private void HandleMenuOpenChanged(bool isOpen)
        {
            if (isOpen) Hide();
        }

        private void HandleScoreboardHeldChanged(bool isHeld)
        {
            if (isHeld && !IsAnyMenuOpen)
            {
                RestartCTS(ref _refreshCTS);
                RefreshAsync(_refreshCTS.Token).Forget();
            }
            else
            {
                Hide();
            }
        }

        private async UniTaskVoid RefreshAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                BuildEntries();
                _hudState.SetScoreboard(true, _entries);
                await UniTask.WaitForSeconds(_refreshIntervalInSeconds, ignoreTimeScale: true, cancellationToken: token);
            }
        }

        private void BuildEntries()
        {
            _entries.Clear();
            foreach (var session in _sessionDirectory.Sessions)
            {
                _entries.Add(new ScoreboardEntry(
                    session.ClientId,
                    session.DisplayName.ToString(),
                    ToScoreboardTeam(session.Team),
                    GetStatus(session),
                    session.Catches,
                    session.Rescues,
                    session.ClientId == OwnerClientId));
            }

            // in team order (ScoreboardTeam), by name inside each team
            _entries.Sort((a, b) =>
            {
                int byTeam = a.Team.CompareTo(b.Team);
                return byTeam != 0 ? byTeam : string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase);
            });
        }

        private ScoreboardStatus GetStatus(PlayerSession session)
        {
            if (session.IsSittingOut) return ScoreboardStatus.Spectating;
            if (_spawnedPlayers.TryGetPlayer(session.ClientId, out var player) && player.IsGhost) return ScoreboardStatus.Ghost;

            return session.LifeState switch
            {
                LifeState.Knocked => ScoreboardStatus.Knocked,
                LifeState.Eliminated => ScoreboardStatus.Out,
                _ => ScoreboardStatus.Up
            };
        }

        private static ScoreboardTeam ToScoreboardTeam(Team team) => team switch
        {
            Team.Catcher => ScoreboardTeam.Catcher,
            Team.Runner => ScoreboardTeam.Runner,
            _ => ScoreboardTeam.None
        };

        private void Hide()
        {
            DisposeCTS(ref _refreshCTS);
            _entries.Clear();
            _hudState.SetScoreboard(false, _entries);
        }

        private static void RestartCTS(ref CancellationTokenSource cts)
        {
            DisposeCTS(ref cts);
            cts = new();
        }

        private static void DisposeCTS(ref CancellationTokenSource cts)
        {
            cts?.Cancel();
            cts?.Dispose();
            cts = null;
        }

        public override void OnNetworkDespawn()
        {
            if (!IsOwner) return;

            _inputReader.OnScoreboardHeldChanged -= HandleScoreboardHeldChanged;
            _lobbyMenuState.OnOpenChanged -= HandleMenuOpenChanged;
            _pauseMenuState.OnOpenChanged -= HandleMenuOpenChanged;
            Hide();
        }

        public override void OnDestroy()
        {
            DisposeCTS(ref _refreshCTS);
            base.OnDestroy();
        }
    }
}
