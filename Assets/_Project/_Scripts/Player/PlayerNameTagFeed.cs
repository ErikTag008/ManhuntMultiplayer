using KBCore.Refs;
using Project.Assets._Project._Scripts.Player.Drops;
using Project.Assets._Project._Scripts.Player.Voice;
using Project.Assets._Project._Scripts.UI.HUD;
using Reflex.Attributes;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Owner only: puts the other players' name tags on this player's screen. Teammates show through walls at any range;
    // the other team only shows in line of sight, within range and while not invisible, so hiding still works.
    // Knocked players get the knocked tone; eliminated players and ghosts have no tag. In the lobby each tag also shows
    // whether that player is ready, and any tag shows a speaker icon while this client plays that player's voice.
    [RequireComponent(typeof(PlayerTeam), typeof(PlayerCameraBinder), typeof(PlayerSpectator))]
    public class PlayerNameTagFeed : NetworkBehaviour
    {
        private const int SightHitCapacity = 8;

        [Inject] private readonly GameHUDState _hudState;
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [Inject] private readonly SpawnedPlayerDirectory _spawnedPlayers;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerCameraBinder _cameraBinder;
        [SerializeField, Self] private PlayerSpectator _spectator;
        // the tag sits this far above the model's head bone, or this player's feet plus the fallback height without one
        [SerializeField] private float _headClearanceInMeters = 0.45f;
        [SerializeField] private float _fallbackHeightInMeters = 2f;
        [SerializeField] private float _enemyRangeInMeters = 25f;
        // the other team's tags fade out over this last stretch of their range
        [SerializeField] private float _enemyFadeDistanceInMeters = 5f;
        // a tag this close to the camera is too close to read
        [SerializeField] private float _minCameraDistanceInMeters = 1f;
        [SerializeField] private LayerMask _sightBlockers = ~0;

        // reused every frame so the tags don't allocate
        private readonly List<NameTag> _nameTags = new();
        // FixedString to string allocates, so each name is converted once per change
        private readonly Dictionary<ulong, (FixedString64Bytes Raw, string Text)> _names = new();
        private readonly Dictionary<ulong, (Transform Model, Transform Head)> _heads = new();
        private readonly Dictionary<ulong, PlayerVoice> _voices = new();
        private readonly RaycastHit[] _sightHits = new RaycastHit[SightHitCapacity];

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            if (!IsOwner) return;

            _sessionDirectory.OnSessionChanged += HandleSessionChanged;
            _sessionDirectory.OnSessionRemoved += HandleSessionRemoved;
            _cameraBinder.OnCameraUpdated += RefreshNameTags;
            foreach (var session in _sessionDirectory.Sessions) HandleSessionChanged(session);
        }

        // tags are placed once the camera has moved for the frame; without a camera no update arrives, so they are cleared here
        private void Update()
        {
            if (!IsSpawned || !IsOwner) return;

            if (_cameraBinder.Camera == null) RefreshNameTags();
        }

        private void HandleSessionChanged(PlayerSession session)
        {
            if (_names.TryGetValue(session.ClientId, out var name) && name.Raw.Equals(session.DisplayName)) return;

            _names[session.ClientId] = (session.DisplayName, session.DisplayName.ToString());
        }

        private void HandleSessionRemoved(ulong clientId)
        {
            _names.Remove(clientId);
            _heads.Remove(clientId);
            _voices.Remove(clientId);
        }

        private void RefreshNameTags()
        {
            _nameTags.Clear();
            var camera = _cameraBinder.Camera;
            if (camera != null)
            {
                // the spectator camera orbits the watched player, whose tag would sit in the middle of the view
                bool isSpectating = _spectator.TryGetTarget(out ulong spectatedId);
                foreach (var player in _spawnedPlayers.Players)
                {
                    if (player == null || player.OwnerClientId == OwnerClientId) continue;
                    if (isSpectating && player.OwnerClientId == spectatedId) continue;
                    if (TryGetNameTag(camera, player, out var tag)) _nameTags.Add(tag);
                }
            }

            _hudState.SetNameTags(_nameTags);
        }

        private bool TryGetNameTag(Camera camera, PlayerController player, out NameTag tag)
        {
            tag = default;
            if (player.LifeState.IsEliminated || player.IsAwaitingPlacement) return false;
            if (!_names.TryGetValue(player.OwnerClientId, out var name)) return false;

            Vector3 anchor = GetAnchor(player);
            Vector3 viewportPoint = camera.WorldToViewportPoint(anchor);
            if (!IsOnScreen(viewportPoint)) return false;

            if (viewportPoint.z < _minCameraDistanceInMeters) return false;

            float alpha = 1f;
            // in the lobby nobody has a team yet, so everyone counts as a teammate
            bool isTeammate = player.Team == _team.Team;
            if (!isTeammate)
            {
                float distance = Vector3.Distance(camera.transform.position, anchor);
                if (distance > _enemyRangeInMeters) return false;
                if (player.DropEffects.Has(DropStatus.Invisible)) return false;
                if (!IsInSight(camera.transform.position, anchor, player)) return false;

                alpha = GetEnemyAlpha(distance);
            }

            tag = new NameTag(viewportPoint, name.Text, GetTone(player), alpha, GetReadiness(player), IsSpeaking(player));
            return true;
        }

        private static bool IsOnScreen(Vector3 viewportPoint) =>
            viewportPoint.z > 0f && viewportPoint.x >= 0f && viewportPoint.x <= 1f && viewportPoint.y >= 0f && viewportPoint.y <= 1f;

        // the target's and this player's own colliders don't block; anything else on the way does
        private bool IsInSight(Vector3 from, Vector3 to, PlayerController player)
        {
            Vector3 direction = to - from;
            int hitCount = Physics.RaycastNonAlloc(from, direction, _sightHits, direction.magnitude, _sightBlockers, QueryTriggerInteraction.Ignore);
            for (int i = 0; i < hitCount; i++)
            {
                var hitTransform = _sightHits[i].transform;
                if (!hitTransform.IsChildOf(player.transform) && !hitTransform.IsChildOf(transform)) return false;
            }

            return true;
        }

        private float GetEnemyAlpha(float distance)
        {
            if (_enemyFadeDistanceInMeters <= 0f) return 1f;

            return Mathf.Clamp01((_enemyRangeInMeters - distance) / _enemyFadeDistanceInMeters);
        }

        private Vector3 GetAnchor(PlayerController player)
        {
            var head = GetHead(player);
            return head != null
                ? head.position + Vector3.up * _headClearanceInMeters
                : player.transform.position + Vector3.up * _fallbackHeightInMeters;
        }

        // the model is swapped when the team changes, so the head is looked up again for a new model
        private Transform GetHead(PlayerController player)
        {
            var model = player.Model;
            if (_heads.TryGetValue(player.OwnerClientId, out var cached) && cached.Model == model) return cached.Head;

            var rig = model != null ? model.GetComponentInChildren<CharacterRig>() : null;
            var head = rig != null ? rig.Head : null;
            _heads[player.OwnerClientId] = (model, head);
            return head;
        }

        // only the lobby has players without a team (sitting-out players are eliminated and have no tag)
        private NameTagReadiness GetReadiness(PlayerController player)
        {
            if (player.Team != Team.None) return NameTagReadiness.None;
            if (!_sessionDirectory.TryGetSession(player.OwnerClientId, out var session)) return NameTagReadiness.None;

            return session.IsReady ? NameTagReadiness.Ready : NameTagReadiness.NotReady;
        }

        // the voice only plays here when this client may hear it, so a muted or dead speaker shows no icon
        private bool IsSpeaking(PlayerController player)
        {
            // a respawn brings a new player object, so a cached voice of another object is looked up again
            if (!_voices.TryGetValue(player.OwnerClientId, out var voice) || voice == null || voice.gameObject != player.gameObject)
            {
                if (!player.TryGetComponent(out voice)) return false;

                _voices[player.OwnerClientId] = voice;
            }

            return voice.IsSpeaking;
        }

        private static NameTagTone GetTone(PlayerController player)
        {
            if (player.LifeState.IsKnocked) return NameTagTone.Knocked;

            return player.Team switch
            {
                Team.Runner => NameTagTone.Runner,
                Team.Catcher => NameTagTone.Catcher,
                _ => NameTagTone.Neutral
            };
        }

        public override void OnNetworkDespawn()
        {
            if (!IsOwner) return;

            _sessionDirectory.OnSessionChanged -= HandleSessionChanged;
            _sessionDirectory.OnSessionRemoved -= HandleSessionRemoved;
            _cameraBinder.OnCameraUpdated -= RefreshNameTags;
            _nameTags.Clear();
            _hudState.SetNameTags(_nameTags);
        }
    }
}
