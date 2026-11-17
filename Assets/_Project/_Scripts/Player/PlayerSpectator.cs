using KBCore.Refs;
using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.Input;
using Reflex.Attributes;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Owner only: while this player is eliminated, the scene's spectator camera orbits another player still in the round.
    // Next/previous cycle through those players in client id order; nothing to watch keeps the last view.
    // A ghost flies instead and only watches after switching to this view.
    [RequireComponent(typeof(PlayerLifeState), typeof(InputReader), typeof(PlayerGhost))]
    public class PlayerSpectator : NetworkBehaviour
    {
        [Inject] private readonly SpawnedPlayerDirectory _spawnedPlayers;
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField, Self] private PlayerGhost _ghost;

        private readonly List<ulong> _candidateIds = new();
        private SpectatorCamera _spectatorCamera;
        private ulong? _targetId;

        public bool IsSpectating => _spectatorCamera != null && _spectatorCamera.IsWatching;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            if (!IsOwner) return;

            _lifeState.OnLifeStateChanged += HandleLifeStateChanged;
            _ghost.OnGhostChanged += HandleGhostViewChanged;
            _ghost.OnViewChanged += HandleGhostViewChanged;
            _sessionDirectory.OnSessionChanged += HandleSessionChanged;
            _spawnedPlayers.OnPlayerRemoved += HandlePlayerRemoved;
            _inputReader.OnSpectateNext += SpectateNext;
            _inputReader.OnSpectatePrevious += SpectatePrevious;
        }

        // Owner only; null when the scene has no spectator camera (lobby, scene unloading)
        public void ChangeSpectatorCamera(SpectatorCamera spectatorCamera)
        {
            if (!IsOwner) return;

            StopSpectating();
            _spectatorCamera = spectatorCamera;
            RefreshTarget();
        }

        // Owner only: whether there is a camera and anyone still in the round to watch
        public bool HasWatchableTarget()
        {
            if (!IsOwner || _spectatorCamera == null) return false;

            CollectCandidates();
            return _candidateIds.Count > 0;
        }

        private void SpectateNext() => CycleTarget(true);

        private void SpectatePrevious() => CycleTarget(false);

        private void HandleLifeStateChanged(LifeState _) => RefreshTarget();

        private void HandleGhostViewChanged(bool _) => RefreshTarget();

        private void HandleSessionChanged(PlayerSession session)
        {
            if (session.ClientId != _targetId) return;
            RefreshTarget();
        }

        private void HandlePlayerRemoved(ulong clientId)
        {
            if (clientId != _targetId) return;

            // the watched player object is gone, so its transform can't stay the camera target;
            // with nobody else to watch the camera holds its last pose
            _targetId = null;
            if (!CycleTarget(true, clientId) && _spectatorCamera != null) _spectatorCamera.HoldLastView();
        }

        // keeps a still-valid target, otherwise moves on to the next player in the round
        private void RefreshTarget()
        {
            if (!CanSpectate())
            {
                StopSpectating();
                return;
            }

            if (_targetId.HasValue && IsWatchable(_targetId.Value)) return;
            CycleTarget(true);
        }

        private void CycleTarget(bool isForward) => CycleTarget(isForward, _targetId);

        private bool CycleTarget(bool isForward, ulong? fromId)
        {
            if (!CanSpectate()) return false;

            CollectCandidates();
            if (!SpectatorTargets.TryPick(_candidateIds, fromId, isForward, out ulong id)) return false;

            return TryWatch(id);
        }

        private bool TryWatch(ulong clientId)
        {
            if (!_spawnedPlayers.TryGetPlayer(clientId, out var player)) return false;

            _targetId = clientId;
            _spectatorCamera.Watch(player.transform, player.HeadingInDegrees, _inputReader);
            return true;
        }

        private void StopSpectating()
        {
            _targetId = null;
            if (_spectatorCamera != null) _spectatorCamera.Stop();
        }

        private bool CanSpectate() => IsOwner && _lifeState.IsEliminated && _spectatorCamera != null && (!_ghost.IsGhost || _ghost.IsInSpectatorView);

        private bool IsWatchable(ulong clientId) =>
            clientId != OwnerClientId
            && _spawnedPlayers.TryGetPlayer(clientId, out _)
            && _sessionDirectory.TryGetSession(clientId, out var session)
            && session.LifeState != LifeState.Eliminated;

        private void CollectCandidates()
        {
            _candidateIds.Clear();
            foreach (ulong clientId in _spawnedPlayers.ClientIds)
            {
                if (IsWatchable(clientId)) _candidateIds.Add(clientId);
            }

            _candidateIds.Sort();
        }

        public override void OnNetworkDespawn()
        {
            if (!IsOwner) return;

            _lifeState.OnLifeStateChanged -= HandleLifeStateChanged;
            _ghost.OnGhostChanged -= HandleGhostViewChanged;
            _ghost.OnViewChanged -= HandleGhostViewChanged;
            _sessionDirectory.OnSessionChanged -= HandleSessionChanged;
            _spawnedPlayers.OnPlayerRemoved -= HandlePlayerRemoved;
            _inputReader.OnSpectateNext -= SpectateNext;
            _inputReader.OnSpectatePrevious -= SpectatePrevious;
            StopSpectating();
        }
    }
}
