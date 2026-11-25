using KBCore.Refs;
using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Player.Abilities;
using Project.Assets._Project._Scripts.Player.Emotes;
using Project.Assets._Project._Scripts.UI.HUD;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Holding the emote key opens the wheel; releasing on a slice asks the server, which plays the emote on every instance.
    // Each instance ends it by itself when the time is up or the player moves, jumps, crouches, attacks, uses an ability
    // or goes down, so no stop message is needed. The owner watches itself in third person while it plays.
    [RequireComponent(typeof(InputReader), typeof(PlayerTeam), typeof(PlayerLifeState))]
    [RequireComponent(typeof(PlayerMotion), typeof(PlayerPosture), typeof(PlayerAbility))]
    [RequireComponent(typeof(PlayerCombat))]
    public class PlayerEmote : NetworkBehaviour
    {
        [Inject] private readonly EmoteCatalog _catalog;
        [Inject] private readonly EmoteWheelState _wheelState;
        [Inject] private readonly LobbyMenuState _lobbyMenuState;
        [Inject] private readonly PauseMenuState _pauseMenuState;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private PlayerMotion _motion;
        [SerializeField, Self] private PlayerPosture _posture;
        [SerializeField, Self] private PlayerAbility _ability;
        [SerializeField, Self] private PlayerCombat _combat;
        // mouse movement adds up into a virtual stick; this many pixels of travel per unit of aim
        [SerializeField, Min(0f)] private float _mouseAimScale = 0.01f;
        // the Look binding scales the right stick up for turning (x50), so this brings it back to stick travel
        [SerializeField, Min(0f)] private float _stickAimScale = 0.02f;
        [SerializeField, Range(0f, 1f)] private float _aimDeadZone = 0.35f;
        // a stick that left the slice this recently before the release sprang back with it, so the slice still plays
        [SerializeField, Min(0f)] private float _stickReleaseGraceInSeconds = 0.15f;
        // normalized planar speed; above it the emote stops, and it can't start
        [SerializeField, Range(0f, 1f)] private float _maxEmoteSpeed = 0.15f;
        // remote copies see movement through interpolation, which still trails off right after the player stopped
        [SerializeField, Min(0f)] private float _movementGraceInSeconds = 0.3f;
        // the third-person view starts in front of the player, so the owner sees its own emote
        [SerializeField] private float _viewHeadingOffsetInDegrees = 180f;

        // Every instance
        public event Action<EmoteData> OnEmoteStarted;
        public event Action OnEmoteEnded;
        // Owner only: the view switched between first person and the emote's third person
        public event Action<bool> OnThirdPersonChanged;

        private readonly List<EmoteWheelOption> _wheelOptions = new();
        private EmoteData _currentEmote;
        private float _emoteEndTime;
        private float _movementCheckTime;
        private Vector2 _aim;
        private float _lastOffCentreTime;
        // Owner only
        private SpectatorCamera _thirdPersonCamera;
        private bool _isInThirdPerson;
        private float _nextRequestTime;
        // Server only
        private double _serverNextEmoteTime;

        public bool IsEmoting => _currentEmote != null;
        public EmoteData CurrentEmote => _currentEmote;
        public bool IsInThirdPerson => _isInThirdPerson;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            _lifeState.OnLifeStateChanged += HandleLifeStateChanged;
            _team.OnModelChanged += HandleModelChanged;
            _ability.OnAbilityUsed += HandleAbilityUsed;
            _combat.OnAttackStarted += EndEmote;
            _combat.OnLungeStarted += EndEmote;
            if (!IsOwner) return;

            _inputReader.OnEmoteHeldChanged += HandleEmoteHeldChanged;
            _inputReader.OnEmoteCanceled += CloseWheel;
        }

        private void Update()
        {
            if (IsOwner && _wheelState.IsOpen) AimWheel();
            if (IsEmoting && ShouldEnd()) EndEmote();
        }

        // Owner only; null when the scene has no third-person camera (the lobby), so the emote plays unseen by its owner
        public void ChangeThirdPersonCamera(SpectatorCamera thirdPersonCamera)
        {
            if (!IsOwner) return;

            ToggleThirdPerson(false);
            _thirdPersonCamera = thirdPersonCamera;
        }

        // Owner only: closes the wheel without playing anything (a menu opened over it)
        public void CloseWheel()
        {
            if (IsOwner) _wheelState.Close();
        }

        private void HandleEmoteHeldChanged(bool isHeld)
        {
            if (isHeld) OpenWheel();
            else PickFromWheel();
        }

        private void OpenWheel()
        {
            if (!_lifeState.IsUp || _catalog.Emotes.Count == 0) return;
            // a menu owns the look input and the screen
            if (_lobbyMenuState.IsOpen || _pauseMenuState.IsOpen) return;

            _wheelOptions.Clear();
            foreach (var emote in _catalog.Emotes)
            {
                _wheelOptions.Add(emote != null ? new EmoteWheelOption(emote.DisplayName, emote.Icon) : default);
            }

            _aim = Vector2.zero;
            _wheelState.Open(_wheelOptions);
        }

        private void AimWheel()
        {
            var look = _inputReader.LookDirection;
            _aim = _inputReader.IsUsingMouse ? _aim + look * _mouseAimScale : look * _stickAimScale;
            _aim = Vector2.ClampMagnitude(_aim, 1f);
            if (_aim.magnitude >= _aimDeadZone) _lastOffCentreTime = Time.time;
            _wheelState.Aim(_aim, _aimDeadZone);
        }

        private void PickFromWheel()
        {
            if (!_wheelState.IsOpen) return;

            // the mouse aim stays where it was left, so a mouse at the centre always means cancel
            bool isStickSpringingBack = !_inputReader.IsUsingMouse && Time.time - _lastOffCentreTime <= _stickReleaseGraceInSeconds;
            int index = _wheelState.Close(isStickSpringingBack);
            if (index == EmoteWheelState.NoSelection || !CanStartEmote() || Time.time < _nextRequestTime) return;

            _nextRequestTime = Time.time + _catalog.CooldownInSeconds;
            PlayEmoteServerRpc(index);
        }

        [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Owner)]
        private void PlayEmoteServerRpc(int index)
        {
            if (!_catalog.TryGet(index, out _) || !_lifeState.IsUp) return;

            double now = NetworkManager.ServerTime.Time;
            if (now < _serverNextEmoteTime) return;

            _serverNextEmoteTime = now + _catalog.CooldownInSeconds;
            PlayEmoteRpc(index);
        }

        [Rpc(SendTo.ClientsAndHost, InvokePermission = RpcInvokePermission.Server)]
        private void PlayEmoteRpc(int index)
        {
            // only the owner knows its movement first-hand (it may have started moving while the request travelled);
            // remote copies trust the server and let ShouldEnd stop it once their copy really moves
            if (!_catalog.TryGet(index, out var emote) || !_lifeState.IsUp) return;
            if (IsOwner && IsMoving()) return;

            EndEmote();
            _currentEmote = emote;
            _emoteEndTime = Time.time + emote.DurationInSeconds;
            _movementCheckTime = IsOwner ? Time.time : Time.time + _movementGraceInSeconds;
            OnEmoteStarted?.Invoke(emote);
            if (IsOwner) ToggleThirdPerson(true);
        }

        private bool CanStartEmote() => _lifeState.IsUp && !IsMoving();

        private bool ShouldEnd() =>
            Time.time >= _emoteEndTime || !_lifeState.IsUp || (Time.time >= _movementCheckTime && IsMoving());

        private bool IsMoving() =>
            _posture.Posture != Posture.Standing || !_motion.IsGrounded || _motion.NormalizedPlanarSpeed > _maxEmoteSpeed;

        private void EndEmote()
        {
            if (!IsEmoting) return;

            _currentEmote = null;
            OnEmoteEnded?.Invoke();
            if (IsOwner) ToggleThirdPerson(false);
        }

        private void ToggleThirdPerson(bool isOn)
        {
            if (isOn && (_thirdPersonCamera == null || _thirdPersonCamera.IsWatching)) return;
            if (isOn == _isInThirdPerson) return;

            _isInThirdPerson = isOn;
            if (isOn)
            {
                float headingInDegrees = _team.Model != null ? _team.Model.eulerAngles.y : transform.eulerAngles.y;
                _thirdPersonCamera.Watch(transform, headingInDegrees + _viewHeadingOffsetInDegrees, _inputReader);
            }
            // the spectator may already be using the same camera to watch someone else (this player was just eliminated)
            else if (_thirdPersonCamera != null && _thirdPersonCamera.Target == transform)
            {
                _thirdPersonCamera.Stop();
            }

            _team.ToggleOwnModelShown(isOn);
            OnThirdPersonChanged?.Invoke(isOn);
        }

        private void HandleLifeStateChanged(LifeState state)
        {
            if (state == LifeState.Up) return;

            EndEmote();
            CloseWheel();
        }

        // the new model starts hidden from its owner and has its own Animator, so the emote doesn't carry over
        private void HandleModelChanged(Transform _) => EndEmote();

        private void HandleAbilityUsed(AbilityData _) => EndEmote();

        public override void OnNetworkDespawn()
        {
            _lifeState.OnLifeStateChanged -= HandleLifeStateChanged;
            _team.OnModelChanged -= HandleModelChanged;
            _ability.OnAbilityUsed -= HandleAbilityUsed;
            _combat.OnAttackStarted -= EndEmote;
            _combat.OnLungeStarted -= EndEmote;
            if (!IsOwner) return;

            _inputReader.OnEmoteHeldChanged -= HandleEmoteHeldChanged;
            _inputReader.OnEmoteCanceled -= CloseWheel;
            CloseWheel();
            EndEmote();
            ToggleThirdPerson(false);
        }
    }
}
