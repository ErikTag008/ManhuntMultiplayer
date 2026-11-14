using KBCore.Refs;
using Project.Assets._Project._Scripts.Player.Drops;
using Project.Assets._Project._Scripts.UI.HUD;
using Reflex.Attributes;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Owner only: pushes the round's runner counts and this player's bleed-out, rescue progress, ability cooldown and drop effect
    // into the gameplay HUD, plus, for catchers, where revealed runners are on screen
    [RequireComponent(typeof(PlayerLifeState), typeof(PlayerRescue), typeof(PlayerAbility))]
    [RequireComponent(typeof(PlayerTeam), typeof(PlayerDropEffects), typeof(PlayerCameraBinder))]
    public class PlayerHUDFeed : NetworkBehaviour
    {
        private const float ViewportCenter = 0.5f;

        [Inject] private readonly GameHUDState _hudState;
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [Inject] private readonly RunnerStats _runnerStats;
        [Inject] private readonly SpawnedPlayerDirectory _spawnedPlayers;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private PlayerRescue _rescue;
        [SerializeField, Self] private PlayerAbility _ability;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerDropEffects _dropEffects;
        [SerializeField, Self] private PlayerCameraBinder _cameraBinder;
        // the marker sits this far above the revealed runner's feet
        [SerializeField] private float _revealMarkerHeightInMeters = 2.2f;
        // off-screen runners get a marker pinned this far (viewport units) inside the screen edge, pointing their way
        [SerializeField, Range(0f, 0.5f)] private float _revealMarkerEdgeMargin = 0.05f;

        // reused every frame so the markers don't allocate
        private readonly List<Vector2> _revealViewportPositions = new();

        private bool _hasBleedOutStarted;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            if (!IsOwner) return;

            _sessionDirectory.OnSessionChanged += HandleSessionChanged;
            _sessionDirectory.OnSessionRemoved += HandleSessionRemoved;
            _lifeState.OnLifeStateChanged += HandleLifeStateChanged;
            RefreshRunnerCounts();
        }

        private void Update()
        {
            if (!IsSpawned || !IsOwner) return;

            RefreshBleedOut();
            RefreshRescue();
            RefreshAbility();
            RefreshDropEffect();
            RefreshRevealMarkers();
        }

        private void HandleSessionChanged(PlayerSession _) => RefreshRunnerCounts();

        // a runner who leaves mid-round no longer counts
        private void HandleSessionRemoved(ulong _) => RefreshRunnerCounts();

        private void HandleLifeStateChanged(LifeState _) => _hasBleedOutStarted = false;

        private void RefreshRunnerCounts()
        {
            var counts = RunnerCounts.From(_sessionDirectory.Sessions);
            _hudState.SetRunnerCounts(counts.Up, counts.Knocked, counts.Eliminated);
        }

        // The knocked state and the bleed-out end time come from different network objects, so right after a knock
        // the new end time may not have arrived yet. The server clears the end time when a bleed-out ends,
        // so until then it reads zero and the bar waits for a value above zero.
        private void RefreshBleedOut()
        {
            float remaining = _lifeState.BleedOutRemainingInSeconds;
            if (_lifeState.IsKnocked && remaining > 0f) _hasBleedOutStarted = true;

            bool isShown = _lifeState.IsKnocked && _hasBleedOutStarted;
            float progress = isShown ? remaining / _runnerStats.BleedOutDurationInSeconds : 0f;
            _hudState.SetBleedOut(isShown, isShown ? remaining : 0f, progress);
        }

        // progress is synced on both the rescuer and the knocked runner, and drops to zero when the rescue stops
        private void RefreshRescue()
        {
            float progress = _rescue.RescueProgress;
            _hudState.SetRescue(progress > 0f, progress);
        }

        // only runners have an ability, so catchers, the lobby and eliminated players show no slot
        private void RefreshAbility()
        {
            var ability = _ability.Ability;
            // knocked runners keep the slot (a rescue brings them back); eliminated ones are out of the round
            if (ability == null || _lifeState.IsEliminated)
            {
                _hudState.SetAbility(false, null, null, 0f, 0f);
                return;
            }

            float remaining = _ability.CooldownRemainingInSeconds;
            float progress = ability.CooldownInSeconds > 0f ? remaining / ability.CooldownInSeconds : 0f;
            _hudState.SetAbility(true, ability.DisplayName, ability.ReadyHint, remaining, progress);
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

        // only catchers see revealed runners, through walls; runners off screen or behind the camera are pinned to the screen edge
        private void RefreshRevealMarkers()
        {
            _revealViewportPositions.Clear();
            var camera = _cameraBinder.Camera;
            if (_team.Team == Team.Catcher && camera != null)
            {
                foreach (var player in _spawnedPlayers.Players)
                {
                    if (player == null || player.OwnerClientId == OwnerClientId || !player.DropEffects.Has(DropStatus.Revealed)) continue;

                    Vector3 viewportPoint = camera.WorldToViewportPoint(player.transform.position + Vector3.up * _revealMarkerHeightInMeters);
                    _revealViewportPositions.Add(ClampToScreenEdge(viewportPoint));
                }
            }

            _hudState.SetRevealMarkers(_revealViewportPositions);
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
            _hudState.SetBleedOut(false, 0f, 0f);
            _hudState.SetRescue(false, 0f);
            _hudState.SetAbility(false, null, null, 0f, 0f);
            _hudState.SetDropEffect(false, null, false, 0f, 0f);
            _revealViewportPositions.Clear();
            _hudState.SetRevealMarkers(_revealViewportPositions);
        }
    }
}
