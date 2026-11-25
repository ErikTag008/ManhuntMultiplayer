using KBCore.Refs;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.SceneFlow;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // The one place that decides who is a ghost: in Classic, a runner eliminated during the hunt, until they're back up;
    // in any mode, a player sitting the round out after joining it mid-way (they can't ping, having no team).
    // The server decides and syncs it, so every instance agrees whatever order the hunt and life state arrive in.
    // Every instance hides the ghost's body and turns its colliders off; the owner flies it around inside the map bounds,
    // toggles to the third-person spectator with Interact and pings the catcher it aims at with Attack,
    // which marks that catcher for the runners for a moment.
    [RequireComponent(typeof(PlayerLifeState), typeof(PlayerTeam), typeof(Rigidbody))]
    [RequireComponent(typeof(InputReader), typeof(PlayerCameraBinder))]
    public class PlayerGhost : NetworkBehaviour
    {
        [Inject] private readonly ActiveLobbyConfig _activeLobbyConfig;
        [Inject] private readonly GhostSettings _settings;
        [Inject] private readonly GhostPingDirectory _pings;
        [Inject] private readonly SpawnedPlayerDirectory _spawnedPlayers;
        [Inject] private readonly HuntPhase _huntPhase;
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private Rigidbody _rb;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField, Self] private PlayerCameraBinder _cameraBinder;
        [SerializeField, Self] private PlayerSpectator _spectator;

        public event Action<bool> OnGhostChanged;
        // Owner only: true while the ghost watches through the spectator camera instead of flying
        public event Action<bool> OnViewChanged;

        private readonly NetworkVariable<bool> _isGhostSynced = new(false, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
        // written by the server, read by the owner for the HUD
        private readonly NetworkVariable<double> _pingCooldownEndTime = new(0d, NetworkVariableReadPermission.Owner, NetworkVariableWritePermission.Server);
        // exactly what this component switched off, so restoring leaves anything another system changed alone
        private readonly List<Renderer> _hiddenRenderers = new();
        private readonly List<Collider> _disabledColliders = new();
        private readonly List<Renderer> _rendererBuffer = new();
        private readonly List<Collider> _colliderBuffer = new();
        private bool _isGhost;
        private bool _isInSpectatorView;
        // Owner only
        private MapBounds _mapBounds;
        private bool _isWaitingForTeleport;
        private float _teleportWaitEndTime;

        public bool IsGhost => _isGhost;
        // Owner only
        public bool IsInSpectatorView => _isGhost && _isInSpectatorView;
        // Owner only
        public bool IsFlying => IsOwner && _isGhost && !_isInSpectatorView;
        // Owner only
        public float PingCooldownRemainingInSeconds => Mathf.Max(0f, (float)(_pingCooldownEndTime.Value - NetworkManager.ServerTime.Time));
        // Owner only: 1 right after a ping, 0 when ready
        public float PingCooldownProgress => _settings.PingCooldownInSeconds > 0f ? PingCooldownRemainingInSeconds / _settings.PingCooldownInSeconds : 0f;
        // Owner only: pings are for the hunt, and only from free-fly, where Attack isn't the spectator's next-target key
        public bool CanPing => IsFlying && _team.Team == Team.Runner && _huntPhase.IsActive && PingCooldownRemainingInSeconds <= 0f;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            _isGhostSynced.OnValueChanged += HandleGhostSyncedChanged;
            _team.OnModelChanged += HandleModelChanged;
            if (IsServer)
            {
                _lifeState.OnLifeStateChanged += HandleLifeStateChanged;
                _team.OnStatsChanged += HandleStatsChanged;
                _activeLobbyConfig.OnChanged += HandleLobbyConfigChanged;
            }

            if (!IsOwner) return;

            _inputReader.OnInteract += ToggleView;
            _inputReader.OnAttack += TryPing;
        }

        // the life state is read on spawn without raising its event, so the first check waits for every component's spawn
        protected override void OnNetworkPostSpawn()
        {
            if (IsServer) RefreshGhost();
            ApplyGhost(_isGhostSynced.Value);
        }

        // Owner only: moves the body directly, since PlayerMovement is off for eliminated players
        private void FixedUpdate()
        {
            if (!IsSpawned || !IsOwner) return;

            if (_isWaitingForTeleport)
            {
                HoldForTeleport();
                return;
            }

            if (!_isGhost) return;

            // a cancelled mantle turns gravity back on, so it's kept off on every step
            _rb.useGravity = false;
            _rb.linearDamping = 0f;
            _rb.linearVelocity = _isInSpectatorView ? Vector3.zero : GetBoundedFlyVelocity();
        }

        // Pure rule, kept apart for tests: becoming a runner ghost needs the hunt; staying one only needs to stay out of the round.
        // A sitting-out spectator is one for as long as the round lasts
        public static bool ShouldBeGhost(PlayerSession session, GameMode mode, bool isAlreadyGhost, bool isHuntActive) =>
            session.IsSittingOut
            || (session.LifeState == LifeState.Eliminated && session.Team == Team.Runner && mode == GameMode.Classic && (isAlreadyGhost || isHuntActive));

        // A visual added to the body after it was hidden (an outfit dressed late) hides with it and comes back with it
        public void MatchGhostVisibility(Transform visual)
        {
            if (!_isGhost || visual == null) return;

            HideRenderers(visual);
        }

        // Owner only; null in scenes without bounds
        public void ChangeMapBounds(MapBounds mapBounds) => _mapBounds = mapBounds;

        // Owner only: the teleport put the body somewhere safe, so gravity can come back
        public void HandleTeleported()
        {
            if (!_isWaitingForTeleport) return;
            StopWaitingForTeleport();
        }

        private void HandleLifeStateChanged(LifeState _) => RefreshGhost();

        private void HandleStatsChanged(PlayerStats _) => RefreshGhost();

        private void HandleLobbyConfigChanged(LobbyConfig _) => RefreshGhost();

        // the new model arrives visible and solid, so a ghost hides it again
        private void HandleModelChanged(Transform _)
        {
            if (_isGhost)
            {
                RestoreBody();
                HideBody();
            }

            if (IsServer) RefreshGhost();
        }

        private void HandleGhostSyncedChanged(bool _, bool isGhost) => ApplyGhost(isGhost);

        // Server only: team and life state are read from one session snapshot, since their components update one after the other
        // and the lobby reset changes both at once (a half-applied Team.None + Eliminated would look like a spectator)
        private void RefreshGhost()
        {
            bool isGhost = _sessionDirectory.TryGetSession(OwnerClientId, out var session)
                && ShouldBeGhost(session, _activeLobbyConfig.Config.Mode, _isGhostSynced.Value, _huntPhase.IsActive);
            if (isGhost == _isGhostSynced.Value) return;

            if (!isGhost) _pingCooldownEndTime.Value = 0d;
            _isGhostSynced.Value = isGhost;
            // the server's own change event isn't relied on; applying twice does nothing
            ApplyGhost(isGhost);
        }

        private void ApplyGhost(bool isGhost)
        {
            if (isGhost == _isGhost) return;

            _isGhost = isGhost;
            // ghosts start in free-fly
            _isInSpectatorView = false;
            if (isGhost) HideBody();
            else RestoreBody();

            if (IsOwner)
            {
                if (isGhost) StartFlying();
                else StartWaitingForTeleport();
            }

            OnGhostChanged?.Invoke(isGhost);
        }

        private void HideBody()
        {
            if (_team.Model != null) HideRenderers(_team.Model);

            GetComponentsInChildren(true, _colliderBuffer);
            foreach (var collider in _colliderBuffer)
            {
                if (!collider.enabled || collider.isTrigger) continue;

                collider.enabled = false;
                _disabledColliders.Add(collider);
            }
        }

        private void HideRenderers(Transform visual)
        {
            visual.GetComponentsInChildren(true, _rendererBuffer);
            foreach (var renderer in _rendererBuffer)
            {
                if (renderer.forceRenderingOff) continue;

                renderer.forceRenderingOff = true;
                _hiddenRenderers.Add(renderer);
            }
        }

        // a swapped-out model may already be destroyed
        private void RestoreBody()
        {
            foreach (var renderer in _hiddenRenderers)
            {
                if (renderer != null) renderer.forceRenderingOff = false;
            }

            foreach (var collider in _disabledColliders)
            {
                if (collider != null) collider.enabled = true;
            }

            _hiddenRenderers.Clear();
            _disabledColliders.Clear();
        }

        // Owner only
        private void StartFlying()
        {
            _isWaitingForTeleport = false;
            WarnIfUnbounded();
        }

        // Owner only: the ghost may end inside a wall or high in the air, so the body floats still until the next teleport
        // (the lobby spawn) moves it; if none comes it lets go after a while
        private void StartWaitingForTeleport()
        {
            _isWaitingForTeleport = true;
            _teleportWaitEndTime = Time.time + _settings.TeleportWaitMaxInSeconds;
            HoldForTeleport();
        }

        private void HoldForTeleport()
        {
            if (Time.time >= _teleportWaitEndTime)
            {
                StopWaitingForTeleport();
                return;
            }

            _rb.useGravity = false;
            _rb.linearVelocity = Vector3.zero;
        }

        // gravity is the body's normal state outside a mantle, and a mantle never survives elimination
        private void StopWaitingForTeleport()
        {
            _isWaitingForTeleport = false;
            _rb.useGravity = true;
        }

        // once per ghost, when it starts flying
        private void WarnIfUnbounded()
        {
            if (_mapBounds == null) EUtils.Logger.LogWarning("[PlayerGhost] This scene has no MapBounds; the ghost can fly anywhere.");
        }

        // the box only stops movement out of it, so a ghost that started outside is pulled back in on the next step
        private Vector3 GetBoundedFlyVelocity()
        {
            Vector3 velocity = GetFlyVelocity();
            if (_mapBounds == null) return velocity;

            if (MapBounds.TryClamp(_mapBounds.Bounds, _rb.position, velocity, out Vector3 clampedPosition, out Vector3 clampedVelocity))
            {
                _rb.position = clampedPosition;
                velocity = clampedVelocity;
            }

            return velocity;
        }

        // camera-relative on all three axes, plus straight up or down from Jump and Crouch
        private Vector3 GetFlyVelocity()
        {
            var camera = _cameraBinder.Camera;
            if (camera == null) return Vector3.zero;

            Vector2 moveDirection = _inputReader.MoveDirection;
            Transform view = camera.transform;
            Vector3 velocity = (view.forward * moveDirection.y + view.right * moveDirection.x) * _settings.FlySpeed;

            int verticalInput = (_inputReader.IsJumpHeld ? 1 : 0) - (_inputReader.IsCrouchHeld ? 1 : 0);
            return velocity + Vector3.up * (verticalInput * _settings.VerticalSpeed);
        }

        // Owner only: Interact switches between flying and watching another player; with nobody to watch it keeps flying
        private void ToggleView()
        {
            if (!_isGhost) return;
            if (!_isInSpectatorView && !_spectator.HasWatchableTarget()) return;

            _isInSpectatorView = !_isInSpectatorView;
            OnViewChanged?.Invoke(_isInSpectatorView);
        }

        // Owner only: no line of sight needed, ghosts see through walls anyway
        private void TryPing()
        {
            if (!CanPing || !TryFindAimedCatcher(out ulong catcherId)) return;
            RequestPingServerRpc(catcherId);
        }

        // the catcher nearest the centre of the screen, within the aim cone and range
        private bool TryFindAimedCatcher(out ulong catcherId)
        {
            catcherId = 0;
            var camera = _cameraBinder.Camera;
            if (camera == null) return false;

            Vector3 origin = camera.transform.position;
            Vector3 forward = camera.transform.forward;
            float sqrRange = _settings.PingMaxRangeInMeters * _settings.PingMaxRangeInMeters;
            float closestAngle = _settings.PingAimAngleInDegrees;
            bool hasFound = false;
            foreach (var player in _spawnedPlayers.Players)
            {
                if (player == null || player.Team != Team.Catcher) continue;

                Vector3 toCatcher = player.transform.position + Vector3.up * _settings.PingAimHeightInMeters - origin;
                if (toCatcher.sqrMagnitude > sqrRange) continue;

                float angle = Vector3.Angle(forward, toCatcher);
                if (angle > closestAngle) continue;

                closestAngle = angle;
                catcherId = player.OwnerClientId;
                hasFound = true;
            }

            return hasFound;
        }

        [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Owner)]
        private void RequestPingServerRpc(ulong catcherId)
        {
            double now = NetworkManager.ServerTime.Time;
            if (!_isGhost || _team.Team != Team.Runner || !_huntPhase.IsActive || now < _pingCooldownEndTime.Value) return;
            if (!_spawnedPlayers.TryGetPlayer(catcherId, out var catcher) || catcher == null || !catcher.IsSpawned || catcher.Team != Team.Catcher) return;

            // the aim cone stays the owner's call; the range is checked here, written as "not within" so a NaN position is rejected too
            float maxDistance = _settings.PingMaxRangeInMeters + _settings.PingRangeToleranceInMeters;
            if (!(Vector3.Distance(catcher.transform.position, transform.position) <= maxDistance)) return;

            _pingCooldownEndTime.Value = now + _settings.PingCooldownInSeconds;
            ShowPingRpc(catcherId, _settings.PingMarkerDurationInSeconds);
        }

        // each instance times the marker on its own clock
        [Rpc(SendTo.Everyone, InvokePermission = RpcInvokePermission.Server)]
        private void ShowPingRpc(ulong catcherId, float durationInSeconds) => _pings.Add(catcherId, Time.time + durationInSeconds);

        public override void OnNetworkDespawn()
        {
            _isGhostSynced.OnValueChanged -= HandleGhostSyncedChanged;
            _team.OnModelChanged -= HandleModelChanged;
            _lifeState.OnLifeStateChanged -= HandleLifeStateChanged;
            _team.OnStatsChanged -= HandleStatsChanged;
            _activeLobbyConfig.OnChanged -= HandleLobbyConfigChanged;
            RestoreBody();
            bool wasHoldingBody = _isGhost || _isWaitingForTeleport;
            _isGhost = false;
            _isInSpectatorView = false;
            _mapBounds = null;
            if (!IsOwner) return;

            _inputReader.OnInteract -= ToggleView;
            _inputReader.OnAttack -= TryPing;
            if (!wasHoldingBody) return;

            _rb.linearVelocity = Vector3.zero;
            StopWaitingForTeleport();
        }
    }
}
