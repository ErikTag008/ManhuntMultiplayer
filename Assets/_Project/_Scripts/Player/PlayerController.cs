using KBCore.Refs;
using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Player.Drops;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI;
using Project.Assets._Project._Scripts.UI.HUD;
using Reflex.Attributes;
using Reflex.Extensions;
using Reflex.Injectors;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Project.Assets._Project._Scripts.Player
{
    // Thin coordinator: wires input, movement and the scene's camera to the focused player components
    [RequireComponent(typeof(PlayerInput), typeof(InputReader), typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerTeam), typeof(PlayerLifeState), typeof(PlayerCombat))]
    [RequireComponent(typeof(PlayerNetworkSync), typeof(PlayerCameraBinder), typeof(PlayerRescue))]
    [RequireComponent(typeof(PlayerSpectator), typeof(PlayerHideHold), typeof(PlayerLobbyChoices))]
    [RequireComponent(typeof(PlayerPosture), typeof(PlayerDropEffects))]
    public class PlayerController : NetworkBehaviour, ISceneInitialized, IFirstPersonCameraTarget
    {
        [Inject] private readonly SceneLifecycleManager _sceneLifecycleManager;
        [Inject] private readonly SceneContextProvider _sceneContextProvider;
        [Inject] private readonly IPlayerRegistry _playerRegistry;
        [Inject] private readonly RunnerStats _runnerStats;
        [Inject] private readonly SpawnedPlayerDirectory _spawnedPlayers;
        [Inject] private readonly LobbyMenuState _lobbyMenuState;
        [Inject] private readonly PauseMenuState _pauseMenuState;
        [Inject] private readonly GameSettingsService _settings;
        [Inject] private readonly KeybindService _keybinds;
        [Inject] private readonly ControlSchemeState _controlScheme;
        [SerializeField, Self] private PlayerInput _playerInput;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField, Self] private Rigidbody _rb;
        [SerializeField, Self] private NetworkRigidbody _networkRb;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private PlayerNetworkSync _networkSync;
        [SerializeField, Self] private PlayerCameraBinder _cameraBinder;
        [SerializeField, Self] private PlayerSpectator _spectator;
        [SerializeField, Self] private PlayerHideHold _hideHold;
        [SerializeField, Self] private PlayerLobbyChoices _lobbyChoices;
        [SerializeField, Self] private PlayerPosture _posture;
        [SerializeField, Self] private PlayerDropEffects _dropEffects;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Transform _cameraTarget;
        [SerializeField] private Transform _cameraFollower;

        private readonly StatModifierStack _statModifiers = new();
        private ModifiedMovementStats _movementStats;
        private IPlayerMovement _movement;
        private ILobbyUI _lobbyUI;
        private bool _isKnockedCrawlApplied;
        // the exact instance added, since the stack removes modifiers by reference
        private StatModifier _appliedWalkModifier;

        public Team Team => _team.Team;
        public PlayerLifeState LifeState => _lifeState;
        public Transform CameraTarget => _cameraTarget;
        public InputReader InputReader => _inputReader;
        public PlayerDropEffects DropEffects => _dropEffects;
        // Where the player faces; the model's yaw is synced to every instance
        public float HeadingInDegrees => _team.Model != null ? _team.Model.eulerAngles.y : transform.eulerAngles.y;
        // Owner side: movement runs on the owner, so features that change movement stats add their modifiers here
        public StatModifierStack StatModifiers => _statModifiers;
        // Owner only, and null until the first scene gives the player a camera
        public IPlayerMovement Movement => _movement;
        // Eliminated players, catchers held during the hide phase and anyone with a menu open stand still
        private bool CanMove => _lifeState.CanMove && !_hideHold.IsHeld && !(IsOwner && IsAnyMenuOpen);
        private bool IsAnyMenuOpen => _lobbyMenuState.IsOpen || _pauseMenuState.IsOpen;

        private void OnValidate() => this.ValidateRefs();

        // Network-spawned, so Reflex never injects it at scene load. Injecting in Awake covers every component
        // on the player before any of their OnNetworkSpawn calls run.
        private void Awake()
        {
            _playerInput.enabled = false;
            GameObjectInjector.InjectObject(gameObject, SceneManager.GetActiveScene().GetSceneContainer());
        }

        public override void OnNetworkSpawn()
        {
            _spawnedPlayers.Add(OwnerClientId, this);
            _team.OnStatsChanged += HandleStatsChanged;
            _team.OnModelChanged += HandleModelChanged;
            _lifeState.OnLifeStateChanged += HandleLifeStateChanged;
            _hideHold.OnHeldChanged += HandleHeldChanged;
            if (!IsOwner) return;

            _playerInput.enabled = true;
            ApplyKeybinds();
            _lobbyMenuState.OnOpenChanged += HandleMenuOpenChanged;
            _pauseMenuState.OnOpenChanged += HandleMenuOpenChanged;
            _pauseMenuState.ChangeDoesLeavingEndSession(IsHost);
            _settings.OnChanged += HandleSettingsChanged;
            _inputReader.OnPause += HandlePausePressed;
            _inputReader.OnWalkHeldChanged += HandleWalkHeldChanged;
            _inputReader.OnCrouchHeldChanged += HandleCrouchHeldChanged;
            // PlayerInput invokes Unity events, so its C# onControlsChanged never fires
            _playerInput.controlsChangedEvent.AddListener(HandleControlsChanged);
            HandleControlsChanged(_playerInput);
            HandleMenuOpenChanged(IsAnyMenuOpen);
        }

        // After every component's OnNetworkSpawn, so team stats and model are applied before movement is built.
        // Registering calls InitializeSceneReferences right away when a scene is already active.
        protected override void OnNetworkPostSpawn() => _sceneLifecycleManager.Register(this);

        private void FixedUpdate()
        {
            if (!IsOwner || _movement == null) return;
            // the inverted controls drop flips both axes
            Vector2 moveDirection = _inputReader.MoveDirection;
            if (_dropEffects.Has(DropStatus.InvertedControls)) moveDirection = -moveDirection;
            _movement.HandleFixedMovement(moveDirection);
        }

        [Rpc(SendTo.Owner)]
        public void TeleportRpc(Vector3 position, Quaternion rotation)
        {
            _movement?.ToggleMovement(false);
            // momentum from before the teleport (falling, sliding) must not carry over to the new spot
            _networkRb.SetLinearVelocity(Vector3.zero);
            _networkRb.SetAngularVelocity(Vector3.zero);
            _networkRb.SetPosition(position);
            _networkRb.SetRotation(rotation);
            _movement?.ToggleMovement(CanMove);
        }

        public void InitializeSceneReferences(SceneType sceneType)
        {
            if (sceneType == SceneType.MainMenu) return;
            if (IsServer && sceneType == SceneType.Lobby) _playerRegistry?.RegisterPlayer(this);
            if (!IsOwner) return;

            if (!_sceneContextProvider.TryGetCurrent(sceneType, out var sceneContext))
            {
                EUtils.Logger.LogError($"[PlayerController] No {sceneType} scene context registered.");
                _cameraBinder.Unbind();
                _spectator.ChangeSpectatorCamera(null);
                return;
            }

            _cameraBinder.Bind(sceneContext, this);
            _spectator.ChangeSpectatorCamera(sceneContext.SpectatorCamera);
            CreateMovementIfNeeded();
            if (_movement != null && _cameraBinder.Camera != null) _movement.ChangeCamera(_cameraBinder.Camera);
            // a menu can stay open across the load (pause is project-wide), and the new scene's rig starts with look on
            HandleMenuOpenChanged(IsAnyMenuOpen);

            if (sceneType == SceneType.Lobby)
            {
                BindLobbyInput(sceneContext.LobbyUI);
                _lobbyChoices.EnterLobby();
            }
        }

        public void ClearSceneReferences(SceneType sceneType)
        {
            if (!IsOwner) return;

            _spectator.ChangeSpectatorCamera(null);
            if (sceneType != SceneType.Lobby) return;

            UnbindLobbyInput();
            _lobbyChoices.ExitLobby();
        }

        private void CreateMovementIfNeeded()
        {
            if (_movement != null) return;

            var camera = _cameraBinder.Camera;
            if (camera == null || _team.CurrentStats == null)
            {
                EUtils.Logger.LogError($"[PlayerController] Missing dependencies for movement! Stats: {_team.CurrentStats != null}, Camera: {camera != null}");
                return;
            }

            _movementStats = new ModifiedMovementStats(_team.CurrentStats, _statModifiers);
            _movement = new PlayerMovement(_rb, _movementStats, _groundCheck, camera, _team.Model, _cameraFollower, _posture);
            _movement.ModelRotationChanged += _networkSync.SendModelYaw;
            _movement.CameraFollowerRotationChanged += _networkSync.SendCameraFollowerRotation;
            _movement.ToggleMovement(CanMove);
            _movement.ToggleParkour(_lifeState.IsUp);
            _movement.ToggleCrouchHeld(_inputReader.IsCrouchHeld);
            RefreshKnockedCrawl();
            _cameraBinder.OnCameraRotationChanged += _movement.HandleRotation;
            _inputReader.OnJump += _movement.HandleJump;
        }

        // Only the host can start the game from the lobby
        private void BindLobbyInput(ILobbyUI lobbyUI)
        {
            UnbindLobbyInput();
            if (!IsHost) return;

            if (lobbyUI == null)
            {
                EUtils.Logger.LogError("[PlayerController] LobbyUI is missing! Cannot bind the start button.");
                return;
            }

            _lobbyUI = lobbyUI;
            _inputReader.OnStartButtonKeyPressed += _lobbyUI.InvokeGameStartButtonPress;
        }

        private void UnbindLobbyInput()
        {
            if (_lobbyUI == null) return;

            _inputReader.OnStartButtonKeyPressed -= _lobbyUI.InvokeGameStartButtonPress;
            _lobbyUI = null;
        }

        // A team change starts a new round or returns to the lobby, so effects from the last round end here
        private void HandleStatsChanged(PlayerStats stats)
        {
            _statModifiers.Clear();
            _isKnockedCrawlApplied = false;
            _appliedWalkModifier = null;
            _movementStats?.ChangeBaseStats(stats);
            if (IsOwner) HandleWalkHeldChanged(_inputReader.IsWalkHeld);
        }

        // Owner only: holding walk caps the speed below the footstep threshold, so the player moves silently
        private void HandleWalkHeldChanged(bool isHeld)
        {
            if (_appliedWalkModifier != null)
            {
                _statModifiers.Remove(_appliedWalkModifier);
                _appliedWalkModifier = null;
            }

            if (!isHeld || _team.CurrentStats == null) return;

            _appliedWalkModifier = _team.CurrentStats.WalkModifier;
            _statModifiers.Add(_appliedWalkModifier);
        }

        private void HandleCrouchHeldChanged(bool isHeld) => _movement?.ToggleCrouchHeld(isHeld);

        private void HandleModelChanged(Transform model) => _movement?.ChangeModel(model);

        private void HandleLifeStateChanged(LifeState _)
        {
            if (!IsOwner) return;

            _movement?.ToggleMovement(CanMove);
            _movement?.ToggleParkour(_lifeState.IsUp);
            RefreshKnockedCrawl();
        }

        private void HandleHeldChanged(bool _)
        {
            if (IsOwner) _movement?.ToggleMovement(CanMove);
        }

        // Owner only: an open menu frees the cursor and stops walking and looking; the pause menu also stops every other action
        private void HandleMenuOpenChanged(bool _)
        {
            bool isAnyMenuOpen = IsAnyMenuOpen;
            ToggleCursorFree(isAnyMenuOpen);
            _cameraBinder.ToggleLook(!isAnyMenuOpen);
            _inputReader.ToggleGameplayActions(!_pauseMenuState.IsOpen);
            _movement?.ToggleMovement(CanMove);
        }

        // Owner only: the pause key opens the menu, and while it is open steps back out of it
        private void HandlePausePressed()
        {
            if (_pauseMenuState.IsOpen)
            {
                _pauseMenuState.RequestBack();
                return;
            }

            // one menu at a time; the lobby menu opens again with its own key
            _lobbyMenuState.ToggleOpen(false);
            _pauseMenuState.ToggleOpen(true);
        }

        // Owner only: key hints follow the device this player last switched to
        private void HandleControlsChanged(PlayerInput _) => _controlScheme.ChangeIsGamepad(!_inputReader.IsUsingMouse);

        private void HandleSettingsChanged(SettingsCategory category)
        {
            if (category == SettingsCategory.Controls) ApplyKeybinds();
        }

        // A lone local PlayerInput uses the rebound asset itself; a copy of it needs the overrides loaded
        private void ApplyKeybinds()
        {
            if (_inputReader.Actions != _settings.Data.InputActions) _keybinds.ApplyTo(_inputReader.Actions);
        }

        // Owner only; other players' objects must never touch the local cursor
        private static void ToggleCursorFree(bool isFree)
        {
            Cursor.lockState = isFree ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isFree;
        }

        // Owner only: the session's life state reaches every instance, so the owner applies the crawl itself
        private void RefreshKnockedCrawl()
        {
            if (_isKnockedCrawlApplied == _lifeState.IsKnocked) return;

            _isKnockedCrawlApplied = _lifeState.IsKnocked;
            foreach (var modifier in _runnerStats.KnockedModifiers)
            {
                if (_isKnockedCrawlApplied) _statModifiers.Add(modifier);
                else _statModifiers.Remove(modifier);
            }
        }

        public override void OnNetworkDespawn()
        {
            if (IsServer) _playerRegistry?.UnregisterPlayer(this);
            _spawnedPlayers.Remove(OwnerClientId, this);
            _sceneLifecycleManager.Unregister(this);
            _team.OnStatsChanged -= HandleStatsChanged;
            _team.OnModelChanged -= HandleModelChanged;
            _lifeState.OnLifeStateChanged -= HandleLifeStateChanged;
            _hideHold.OnHeldChanged -= HandleHeldChanged;
            if (!IsOwner) return;

            _lobbyMenuState.OnOpenChanged -= HandleMenuOpenChanged;
            _pauseMenuState.OnOpenChanged -= HandleMenuOpenChanged;
            _settings.OnChanged -= HandleSettingsChanged;
            _inputReader.OnPause -= HandlePausePressed;
            _inputReader.OnWalkHeldChanged -= HandleWalkHeldChanged;
            _inputReader.OnCrouchHeldChanged -= HandleCrouchHeldChanged;
            _playerInput.controlsChangedEvent.RemoveListener(HandleControlsChanged);
            // the menu belongs to this session
            _pauseMenuState.ToggleOpen(false);
            // the session is over (back to the main menu), so its buttons need the cursor
            ToggleCursorFree(true);

            UnbindLobbyInput();
            _cameraBinder.Unbind();
            if (_movement == null) return;

            _movement.ModelRotationChanged -= _networkSync.SendModelYaw;
            _movement.CameraFollowerRotationChanged -= _networkSync.SendCameraFollowerRotation;
            _cameraBinder.OnCameraRotationChanged -= _movement.HandleRotation;
            _inputReader.OnJump -= _movement.HandleJump;
        }

        private void OnDrawGizmos()
        {
            if (!IsOwner) return;
            _movement?.DrawGizmos();
        }
    }
}
