using KBCore.Refs;
using Project.Assets._Project._Scripts.Player.Abilities;
using Project.Assets._Project._Scripts.Player.Drops;
using Project.Assets._Project._Scripts.Player.Stations;
using Project.Assets._Project._Scripts.UI.HUD;
using Reflex.Attributes;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Owner only: pushes the round's runner and catcher counts and this player's bleed-out, rescue progress, ability cooldown and drop effect
    // into the gameplay HUD, plus, for catchers, where revealed runners are on screen and the lunge charge, for runners the catchers
    // ghosts pinged, knocked teammates and the rescue in reach, for ghosts their ping and view, and for everyone the objective
    // stations, the round phase, whether the crosshair is wanted, whether this player spectates and the drops they take
    [RequireComponent(typeof(PlayerLifeState), typeof(PlayerRescue), typeof(PlayerAbility))]
    [RequireComponent(typeof(PlayerTeam), typeof(PlayerDropEffects), typeof(PlayerCameraBinder))]
    [RequireComponent(typeof(PlayerCombat), typeof(PlayerGhost), typeof(PlayerSpectator))]
    public class PlayerHUDFeed : NetworkBehaviour
    {
        private const float ViewportCenter = 0.5f;

        [Inject] private readonly GameHUDState _hudState;
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [Inject] private readonly RunnerStats _runnerStats;
        [Inject] private readonly SpawnedPlayerDirectory _spawnedPlayers;
        [Inject] private readonly StationDirectory _stations;
        [Inject] private readonly HidePhase _hidePhase;
        [Inject] private readonly HuntPhase _huntPhase;
        [Inject] private readonly GhostPingDirectory _ghostPings;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private PlayerRescue _rescue;
        [SerializeField, Self] private PlayerAbility _ability;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerDropEffects _dropEffects;
        [SerializeField, Self] private PlayerCameraBinder _cameraBinder;
        [SerializeField, Self] private PlayerCombat _combat;
        [SerializeField, Self] private PlayerGhost _ghost;
        [SerializeField, Self] private PlayerSpectator _spectator;
        // the marker sits this far above the revealed runner's feet
        [SerializeField] private float _revealMarkerHeightInMeters = 2.2f;
        // off-screen runners get a marker pinned this far (viewport units) inside the screen edge, pointing their way
        [SerializeField, Range(0f, 0.5f)] private float _revealMarkerEdgeMargin = 0.05f;
        // station markers sit this far above the station's pivot and share the reveal markers' edge margin
        [SerializeField] private float _stationMarkerHeightInMeters = 2.5f;
        // knocked runners lie low, so their marker sits closer to the ground
        [SerializeField] private float _knockedMarkerHeightInMeters = 1.2f;

        // reused every frame so the markers don't allocate
        private readonly List<Vector2> _revealViewportPositions = new();
        private readonly List<Vector2> _stationViewportPositions = new();
        private readonly List<Vector2> _knockedViewportPositions = new();
        private readonly List<int> _knockedSecondsLeft = new();
        // each player's last life state, to spot the moment a teammate gets knocked
        private readonly Dictionary<ulong, LifeState> _lastLifeStates = new();

        private bool _hasBleedOutStarted;
        // FixedString to string allocates, so the rescue hint's name is converted once per target
        private ulong _rescueHintClientId;
        private string _rescueHintName;
        // formatting the ability's description allocates, so it is done once per ability
        private AbilityData _describedAbility;
        private string _abilityDescription;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            if (!IsOwner) return;

            _sessionDirectory.OnSessionChanged += HandleSessionChanged;
            _sessionDirectory.OnSessionRemoved += HandleSessionRemoved;
            _lifeState.OnLifeStateChanged += HandleLifeStateChanged;
            _stations.OnStationCompleted += HandleStationCompleted;
            _cameraBinder.OnCameraUpdated += RefreshScreenMarkers;
            _dropEffects.OnEffectTaken += HandleEffectTaken;
            foreach (var session in _sessionDirectory.Sessions) _lastLifeStates[session.ClientId] = session.LifeState;
            RefreshRunnerCounts();
        }

        private void Update()
        {
            if (!IsSpawned || !IsOwner) return;

            RefreshBleedOut();
            RefreshRescue();
            RefreshAbility();
            RefreshDropEffect();
            RefreshStationCounts();
            RefreshLunge();
            RefreshGhost();
            RefreshRoundPhase();
            RefreshCrosshair();
            RefreshSpectating();
            // no camera means no update event, so clear here
            if (_cameraBinder.Camera == null) RefreshScreenMarkers();
        }

        // markers are placed once the camera has moved for the frame, so they don't trail it
        private void RefreshScreenMarkers()
        {
            RefreshRevealMarkers();
            RefreshStationMarkers();
            RefreshKnockedMarkers();
        }

        private void HandleSessionChanged(PlayerSession session)
        {
            RefreshRunnerCounts();
            if (session.ClientId == _rescueHintClientId) _rescueHintName = null;
            NotifyIfTeammateKnocked(session);
        }

        // a runner who leaves mid-round no longer counts
        private void HandleSessionRemoved(ulong clientId)
        {
            RefreshRunnerCounts();
            _lastLifeStates.Remove(clientId);
        }

        // runners still in the round hear about a teammate going down during the hunt
        private void NotifyIfTeammateKnocked(PlayerSession session)
        {
            bool wasKnocked = _lastLifeStates.TryGetValue(session.ClientId, out var previous) && previous == LifeState.Knocked;
            _lastLifeStates[session.ClientId] = session.LifeState;
            if (wasKnocked || session.LifeState != LifeState.Knocked) return;
            if (session.ClientId == OwnerClientId || session.Team != Team.Runner || !IsRunnerInRound() || !_huntPhase.IsActive) return;

            _hudState.NotifyTeammateKnocked(session.DisplayName.ToString());
        }

        private void HandleLifeStateChanged(LifeState _) => _hasBleedOutStarted = false;

        private void HandleEffectTaken(DropEffectData effect) =>
            _hudState.NotifyDropTaken(effect.DisplayName, effect.FormatDescription(), effect.IsGood);

        private void HandleStationCompleted(Station _, float appliedCutInSeconds) => _hudState.NotifyStationCompleted(appliedCutInSeconds);

        private void RefreshRunnerCounts()
        {
            var counts = RunnerCounts.From(_sessionDirectory.Sessions);
            _hudState.SetRunnerCounts(counts.Up, counts.Knocked, counts.Eliminated, counts.Catchers);
        }

        // The knocked state and the bleed-out end time come from different network objects, so right after a knock
        // the new end time may not have arrived yet. The server clears the end time when a bleed-out ends,
        // so until then it reads zero and the bar waits for a value above zero.
        private void RefreshBleedOut()
        {
            float remaining = _lifeState.BleedOutRemainingInSeconds;
            if (_lifeState.IsKnocked && remaining > 0f) _hasBleedOutStarted = true;

            float durationInSeconds = _lifeState.BleedOutDurationInSeconds;
            bool isShown = _lifeState.IsKnocked && _hasBleedOutStarted;
            float progress = isShown && durationInSeconds > 0f ? Mathf.Clamp01(remaining / durationInSeconds) : 0f;
            _hudState.SetBleedOut(isShown, isShown ? remaining : 0f, progress, isShown && _lifeState.IsBleedOutPaused);
        }

        // Rescue progress is synced on both the rescuer and the knocked runner, and drops to zero when the rescue stops.
        // A rescue comes first, then the hint for a knocked teammate in reach; otherwise the ring shows the station this runner
        // is holding Interact at, or a hint when they could.
        private void RefreshRescue()
        {
            float progress = _rescue.RescueProgress;
            if (progress > 0f)
            {
                _hudState.SetRescue(true, progress);
                _hudState.SetRescueHint(false, null);
                _hudState.SetStationHint(false);
                return;
            }

            // while Interact is held the server is about to start the rescue, so the ring waits at zero instead of showing a station
            bool hasRescueTarget = TryGetRescueTargetName(out string teammateName);
            bool isRescueHintShown = hasRescueTarget && !_rescue.IsLocalInteractHeld;
            _hudState.SetRescueHint(isRescueHintShown, isRescueHintShown ? teammateName : null);
            if (hasRescueTarget)
            {
                _hudState.SetRescue(_rescue.IsLocalInteractHeld, 0f);
                _hudState.SetStationHint(false);
                return;
            }

            bool isNearStation = TryGetWorkableStation(out var station);
            bool isWorkingStation = isNearStation && _rescue.IsLocalInteractHeld;
            _hudState.SetRescue(isWorkingStation, isWorkingStation ? station.Progress : 0f);
            _hudState.SetStationHint(isNearStation && !isWorkingStation);
        }

        // the hold hint shows during the hunt whenever the catcher's attack is ready; the ring fills while charging
        private void RefreshLunge()
        {
            bool isCharging = _combat.IsCharging;
            bool isHintShown = _huntPhase.IsActive && _combat.IsAttackReady && !isCharging;
            _hudState.SetLunge(isHintShown, isCharging, _combat.ChargeProgress);
        }

        private void RefreshGhost()
        {
            if (!_ghost.IsGhost)
            {
                _hudState.SetGhost(false, false, false, 0f, 0f);
                return;
            }

            // the ping and its cooldown only matter during the hunt
            bool isHuntActive = _huntPhase.IsActive;
            _hudState.SetGhost(true, _ghost.IsFlying, _ghost.CanPing,
                isHuntActive ? _ghost.PingCooldownRemainingInSeconds : 0f, isHuntActive ? _ghost.PingCooldownProgress : 0f);
        }

        // the same pick PlayerRescue makes on the server: the nearest knocked runner within the rescue range that nobody is reviving yet
        private bool TryGetRescueTargetName(out string teammateName)
        {
            teammateName = null;
            if (_team.Team != Team.Runner || !_lifeState.IsUp) return false;

            PlayerController target = null;
            float closestSqrDistance = _runnerStats.RescueRange * _runnerStats.RescueRange;
            foreach (var player in _spawnedPlayers.Players)
            {
                if (player == null || player.OwnerClientId == OwnerClientId) continue;
                if (player.Team != Team.Runner || !player.LifeState.IsKnocked) continue;
                // rescue progress is synced on the knocked runner too, so above zero means someone else is already on it
                if (player.TryGetComponent(out PlayerRescue rescue) && rescue.RescueProgress > 0f) continue;

                float sqrDistance = (player.transform.position - transform.position).sqrMagnitude;
                if (sqrDistance > closestSqrDistance) continue;

                closestSqrDistance = sqrDistance;
                target = player;
            }

            if (target == null) return false;

            if (_rescueHintName == null || _rescueHintClientId != target.OwnerClientId)
            {
                _rescueHintClientId = target.OwnerClientId;
                _rescueHintName = _sessionDirectory.TryGetSession(target.OwnerClientId, out var session) ? session.DisplayName.ToString() : string.Empty;
            }

            teammateName = _rescueHintName;
            return true;
        }

        private void RefreshRoundPhase()
        {
            var phase = _hidePhase.IsActive ? RoundPhase.Hide : _huntPhase.IsActive ? RoundPhase.Hunt : RoundPhase.None;
            _hudState.SetRoundPhase(phase, _team.Team == Team.Catcher);
        }

        // wanted during the hide phase and the hunt, unless this player only watches through the spectator camera
        private void RefreshCrosshair()
        {
            bool isInRound = _hidePhase.IsActive || _huntPhase.IsActive;
            bool isAiming = !_lifeState.IsEliminated || (_ghost.IsGhost && _ghost.IsFlying);
            _hudState.SetCrosshair(isInRound && isAiming);
        }

        private void RefreshSpectating() => _hudState.SetSpectating(_spectator.IsSpectating);

        private bool IsRunnerInRound() => _team.Team == Team.Runner && !_lifeState.IsEliminated;

        // runners still in the round see knocked teammates through walls with their bleed-out seconds; catchers never do
        private void RefreshKnockedMarkers()
        {
            _knockedViewportPositions.Clear();
            _knockedSecondsLeft.Clear();
            var camera = _cameraBinder.Camera;
            if (_huntPhase.IsActive && camera != null && IsRunnerInRound())
            {
                foreach (var player in _spawnedPlayers.Players)
                {
                    if (player == null || player.OwnerClientId == OwnerClientId) continue;
                    if (player.Team != Team.Runner || !player.LifeState.IsKnocked) continue;

                    Vector3 viewportPoint = camera.WorldToViewportPoint(player.transform.position + Vector3.up * _knockedMarkerHeightInMeters);
                    _knockedViewportPositions.Add(ClampToScreenEdge(viewportPoint));
                    _knockedSecondsLeft.Add(Mathf.CeilToInt(player.LifeState.BleedOutRemainingInSeconds));
                }
            }

            _hudState.SetKnockedMarkers(_knockedViewportPositions, _knockedSecondsLeft);
        }

        private bool TryGetWorkableStation(out Station station)
        {
            station = null;
            return _team.Team == Team.Runner && _lifeState.IsUp && _stations.TryGetWorkableInRange(transform.position, out station);
        }

        // everyone sees how many stations are done during the hunt
        private void RefreshStationCounts()
        {
            bool isShown = _huntPhase.IsActive && _stations.TotalCount > 0;
            _hudState.SetStationCounts(isShown, _stations.CompletedCount, _stations.TotalCount);
        }

        // both teams see where unfinished stations are during the hunt, pinned to the screen edge when off screen
        private void RefreshStationMarkers()
        {
            _stationViewportPositions.Clear();
            var camera = _cameraBinder.Camera;
            if (_huntPhase.IsActive && camera != null)
            {
                var stations = _stations.Stations;
                for (int i = 0; i < stations.Count; i++)
                {
                    if (stations[i].IsCompleted) continue;

                    Vector3 viewportPoint = camera.WorldToViewportPoint(stations[i].transform.position + Vector3.up * _stationMarkerHeightInMeters);
                    _stationViewportPositions.Add(ClampToScreenEdge(viewportPoint));
                }
            }

            _hudState.SetStationMarkers(_stationViewportPositions);
        }

        // only runners have an ability, so catchers, the lobby and eliminated players show no slot
        private void RefreshAbility()
        {
            var ability = _ability.Ability;
            // knocked runners keep the slot (a rescue brings them back); eliminated ones are out of the round
            if (ability == null || _lifeState.IsEliminated)
            {
                _hudState.SetAbility(false, null, null, null, 0f, 0f);
                return;
            }

            float remaining = _ability.CooldownRemainingInSeconds;
            float progress = ability.CooldownInSeconds > 0f ? remaining / ability.CooldownInSeconds : 0f;
            if (ability != _describedAbility)
            {
                _describedAbility = ability;
                _abilityDescription = ability.FormatDescription();
            }

            _hudState.SetAbility(true, ability.DisplayName, ability.ReadyHint, _abilityDescription, remaining, progress);
        }

        // ActiveEffect is already null once the runner isn't Up, so knocked and eliminated runners show no effect
        private void RefreshDropEffect()
        {
            var effect = _dropEffects.ActiveEffect;
            if (effect == null)
            {
                _hudState.SetDropEffect(false, null, false, 0f, 0f);
                return;
            }

            float remaining = _dropEffects.RemainingInSeconds;
            float progress = effect.DurationInSeconds > 0f ? remaining / effect.DurationInSeconds : 0f;
            _hudState.SetDropEffect(true, effect.DisplayName, effect.IsGood, remaining, progress);
        }

        // Catchers see revealed runners through walls; a runner with Sixth Sense active sees every catcher,
        // and runners still in the round (and ghosts) see the catchers ghosts pinged. One marker per player whatever marks them.
        // Players off screen or behind the camera are pinned to the screen edge.
        private void RefreshRevealMarkers()
        {
            _revealViewportPositions.Clear();
            float now = Time.time;
            _ghostPings.RemoveExpired(now);
            var camera = _cameraBinder.Camera;
            bool isCatcher = _team.Team == Team.Catcher;
            bool isSensing = !isCatcher && IsSensingCatchers();
            bool seesPings = IsSeeingGhostPings();
            if ((isCatcher || isSensing || seesPings) && camera != null)
            {
                foreach (var player in _spawnedPlayers.Players)
                {
                    if (player == null || player.OwnerClientId == OwnerClientId) continue;

                    bool isMarked = isCatcher
                        ? IsRevealedToCatchers(player)
                        : player.Team == Team.Catcher && (isSensing || (seesPings && _ghostPings.IsPinged(player.OwnerClientId, now)));
                    if (!isMarked) continue;

                    Vector3 viewportPoint = camera.WorldToViewportPoint(player.transform.position + Vector3.up * _revealMarkerHeightInMeters);
                    _revealViewportPositions.Add(ClampToScreenEdge(viewportPoint));
                }
            }

            _hudState.SetRevealMarkers(_revealViewportPositions);
        }

        private bool IsRevealedToCatchers(PlayerController player) =>
            player.DropEffects.Has(DropStatus.Revealed);

        private bool IsSeeingGhostPings() =>
            _ghostPings.CatcherIds.Count > 0 && _team.Team == Team.Runner && (!_lifeState.IsEliminated || _ghost.IsGhost);

        private bool IsSensingCatchers()
        {
            var ability = _ability.Ability;
            return ability != null && ability.RevealsCatchersWhileActive && _lifeState.IsUp && _ability.ActiveRemainingInSeconds > 0f;
        }

        private Vector2 ClampToScreenEdge(Vector3 viewportPoint)
        {
            var center = new Vector2(ViewportCenter, ViewportCenter);
            Vector2 offset = (Vector2)viewportPoint - center;
            // behind the camera the projection is mirrored, so flip it to point the right way
            if (viewportPoint.z < 0f) offset = -offset;

            float limit = ViewportCenter - _revealMarkerEdgeMargin;
            float largest = Mathf.Max(Mathf.Abs(offset.x), Mathf.Abs(offset.y));
            if (viewportPoint.z >= 0f && largest <= limit) return center + offset;
            if (largest <= 0f) return center + Vector2.down * limit;

            return center + offset * (limit / largest);
        }

        public override void OnNetworkDespawn()
        {
            if (!IsOwner) return;

            _sessionDirectory.OnSessionChanged -= HandleSessionChanged;
            _sessionDirectory.OnSessionRemoved -= HandleSessionRemoved;
            _lifeState.OnLifeStateChanged -= HandleLifeStateChanged;
            _stations.OnStationCompleted -= HandleStationCompleted;
            _cameraBinder.OnCameraUpdated -= RefreshScreenMarkers;
            _dropEffects.OnEffectTaken -= HandleEffectTaken;
            _hudState.SetBleedOut(false, 0f, 0f, false);
            _hudState.SetRescue(false, 0f);
            _hudState.SetAbility(false, null, null, null, 0f, 0f);
            _hudState.SetDropEffect(false, null, false, 0f, 0f);
            _revealViewportPositions.Clear();
            _hudState.SetRevealMarkers(_revealViewportPositions);
            _hudState.SetStationCounts(false, 0, 0);
            _hudState.SetStationHint(false);
            _hudState.SetLunge(false, false, 0f);
            _hudState.SetGhost(false, false, false, 0f, 0f);
            _stationViewportPositions.Clear();
            _hudState.SetStationMarkers(_stationViewportPositions);
            _hudState.SetRoundPhase(RoundPhase.None, false);
            _hudState.SetCrosshair(false);
            _hudState.SetRescueHint(false, null);
            _knockedViewportPositions.Clear();
            _knockedSecondsLeft.Clear();
            _hudState.SetKnockedMarkers(_knockedViewportPositions, _knockedSecondsLeft);
            _lastLifeStates.Clear();
            _rescueHintName = null;
            _hudState.SetSpectating(false);
            _describedAbility = null;
        }
    }
}
