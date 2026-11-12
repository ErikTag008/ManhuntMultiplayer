using KBCore.Refs;
using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.UI;
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
    public class PlayerController : NetworkBehaviour, ISceneInitialized, IFirstPersonCameraTarget
    {
        [Inject] private readonly SceneLifecycleManager _sceneLifecycleManager;
        [Inject] private readonly SceneContextProvider _sceneContextProvider;
        [Inject] private readonly IPlayerRegistry _playerRegistry;
        [Inject] private readonly RunnerStats _runnerStats;
        [SerializeField, Self] private PlayerInput _playerInput;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField, Self] private Rigidbody _rb;
        [SerializeField, Self] private NetworkRigidbody _networkRb;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private PlayerNetworkSync _networkSync;
        [SerializeField, Self] private PlayerCameraBinder _cameraBinder;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Transform _cameraTarget;
        [SerializeField] private Transform _cameraFollower;

        private readonly StatModifierStack _statModifiers = new();
        private ModifiedMovementStats _movementStats;
        private IPlayerMovement _movement;
        private ILobbyUI _lobbyUI;
        private bool _isKnockedCrawlApplied;

        public Team Team => _team.Team;
        public PlayerLifeState LifeState => _lifeState;
        public Transform CameraTarget => _cameraTarget;
        public InputReader InputReader => _inputReader;
        // Owner side: movement runs on the owner, so features that change movement stats add their modifiers here
        public StatModifierStack StatModifiers => _statModifiers;

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
            _team.OnStatsChanged += HandleStatsChanged;
            _team.OnModelChanged += HandleModelChanged;
            _lifeState.OnLifeStateChanged += HandleLifeStateChanged;
            if (IsOwner) _playerInput.enabled = true;
        }

        // After every component's OnNetworkSpawn, so team stats and model are applied before movement is built.
        // Registering calls InitializeSceneReferences right away when a scene is already active.
        protected override void OnNetworkPostSpawn() => _sceneLifecycleManager.Register(this);

        private void FixedUpdate()
        {
            if (!IsOwner || _movement == null) return;
            _movement.HandleFixedMovement(_inputReader.MoveDirection);
        }

        [Rpc(SendTo.Owner)]
        public void TeleportRpc(Vector3 position, Quaternion rotation)
        {
            _movement?.ToggleMovement(false);
            _networkRb.SetPosition(position);
            _networkRb.SetRotation(rotation);
            _movement?.ToggleMovement(_lifeState.CanMove);
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
                return;
            }

            _cameraBinder.Bind(sceneContext, this);
            CreateMovementIfNeeded();
            if (_movement != null && _cameraBinder.Camera != null) _movement.ChangeCamera(_cameraBinder.Camera);

            if (sceneType == SceneType.Lobby) BindLobbyInput(sceneContext.LobbyUI);
        }

        public void ClearSceneReferences(SceneType sceneType)
        {
            if (!IsOwner) return;
            if (sceneType == SceneType.Lobby) UnbindLobbyInput();
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
            _movement = new PlayerMovement(_rb, _movementStats, _groundCheck, camera, _team.Model, _cameraFollower);
            _movement.ModelRotationChanged += _networkSync.SendModelYaw;
            _movement.CameraFollowerRotationChanged += _networkSync.SendCameraFollowerRotation;
            _movement.ToggleMovement(_lifeState.CanMove);
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
            _movementStats?.ChangeBaseStats(stats);
        }

        private void HandleModelChanged(Transform model) => _movement?.ChangeModel(model);

        private void HandleLifeStateChanged(LifeState _)
        {
            if (!IsOwner) return;

            _movement?.ToggleMovement(_lifeState.CanMove);
            RefreshKnockedCrawl();
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
            _sceneLifecycleManager.Unregister(this);
            _team.OnStatsChanged -= HandleStatsChanged;
            _team.OnModelChanged -= HandleModelChanged;
            _lifeState.OnLifeStateChanged -= HandleLifeStateChanged;
            if (!IsOwner) return;

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
