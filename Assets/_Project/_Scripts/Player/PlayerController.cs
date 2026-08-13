using Alchemy.Inspector;
using KBCore.Refs;
using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.DI;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Managers;
using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using Reflex.Core;
using Reflex.Extensions;
using Reflex.Injectors;
using System;
using System.Diagnostics.CodeAnalysis;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Project.Assets._Project._Scripts.Player
{
    public enum Team
    {
        None,
        Catcher,
        Runner
    }

    [RequireComponent(typeof(PlayerInput), typeof(InputReader), typeof(Rigidbody))]
    public class PlayerController : NetworkBehaviour, ISceneInitialized
    {
        [SerializeField, Self] private PlayerInput _playerInput;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField, Self] private Rigidbody _rb;
        [SerializeField, Self] private NetworkRigidbody _networkRb;
        [SerializeField] private Transform _model;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Transform _cameraRoot;
        [SerializeField] private NetworkVariable<Team> _team = new();
        [Inject] private readonly PlayerStats _playerStats;
        [Inject] private readonly SceneLifecycleManager _sceneLifecycleManager;
        [Inject] private readonly GameScenes _gameScenes;
        private ILobbyUI _lobbyUI;
        [Inject] private readonly IPlayerRegistry _playerRegistry;
        private Camera _gameplayCamera;
        private FPCameraInstaller _fpCameraInstaller;
        public Team Team => _team.Value;
        private IPlayerMovement _movement;
        public Transform CameraRoot => _cameraRoot;
        public InputReader InputReader => _inputReader;

        private void Awake()
        {
            _playerInput.enabled = false;
        }

        public override void OnNetworkSpawn()
        {
            InjectGlobalDependencies();
            Debug.Assert(_sceneLifecycleManager != null, "SceneLifecycleManager wasn't injected!");
            _sceneLifecycleManager.Register(this);
            if (IsOwner)
            {
                _playerInput.enabled = true;
            }
        }

        [Rpc(SendTo.Owner)]
        public void TeleportRpc(Vector3 position, Quaternion rotation)
        {
            _movement?.ToggleMovement(false);
            _networkRb.SetPosition(position);
            _networkRb.SetRotation(rotation);
            _movement?.ToggleMovement(true);
        }

        private void InjectGlobalDependencies()
        {
            var container = SceneManager.GetActiveScene().GetSceneContainer();
            if (container == null)
            {
                Debug.LogWarning("[PlayerController] Scene container not found during global injection. Retrying in next frame...");
                return;
            }
            GameObjectInjector.InjectObject(gameObject, container);
        }

        private void InjectLobbyDependencies()
        {
            
            var container = SceneManager.GetSceneByName(_gameScenes.LobbySceneName).GetSceneContainer();
            if (container == null) return;
            try
            {
                _gameplayCamera = container.Resolve<Camera>();
                _fpCameraInstaller = container.Resolve<FPCameraInstaller>();
                _lobbyUI = container.Resolve<ILobbyUI>();
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[PlayerController] Could not resolve ILobbyUI: {e.Message}");
            }
        }

        private void InjectGameDependencies()
        {
            var container = SceneManager.GetSceneByName(_gameScenes.GameSceneName).GetSceneContainer();
            if (container == null) return;

            try
            {
                _gameplayCamera = container.Resolve<Camera>();
                _fpCameraInstaller = container.Resolve<FPCameraInstaller>();
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[PlayerController] Could not resolve Gameplay dependencies: {e.Message}");
            }
        }

        public void InitializeSceneReferences(SceneType scene)
        {
            switch (scene)
            {
                case SceneType.Lobby:
                    if (IsOwner)
                    {
                        InjectLobbyDependencies();
                        Debug.Log("Creating movement");
                        if (_fpCameraInstaller != null)
                        {
                            _fpCameraInstaller.BindCameraToPlayer(this);
                        }
                        else
                        {
                            Debug.LogError("[PlayerController] FPCameraInstaller is NULL! Dependency resolution failed.");
                        }

                        if(_movement == null)
                        {
                            if (_playerStats == null || _gameplayCamera == null)
                            {
                                Debug.LogError($"[PlayerController] Missing dependencies for Movement! Stats: {_playerStats == null}, Camera: {_gameplayCamera == null}");
                            }
                            else
                            {
                                _movement = new PlayerMovement(_rb, _playerStats, _groundCheck, _gameplayCamera, _model);
                            }
                        }
                        else
                        {
                            if (_gameplayCamera != null)
                            {
                                _movement.ChangeCamera(_gameplayCamera);
                            }
                        }

                        if (_movement != null)
                        {
                            _inputReader.OnJump += _movement.HandleJump;
                        }

                        if (IsHost)
                        {
                            if (_lobbyUI != null)
                            {
                                _inputReader.OnStartButtonKeyPressed += _lobbyUI.InvokeGameStartButtonPress;
                            }
                            else
                            {
                                Debug.LogError("[PlayerController] LobbyUI is NULL! Cannot bind Start Button.");
                            }
                        }
                    }
                    if (IsServer)
                    {
                        _playerRegistry?.RegisterPlayer(this);
                    }
                    break;
                case SceneType.Gameplay:
                    if (IsOwner)
                    {
                        InjectGameDependencies();
                        if (_fpCameraInstaller != null)
                        {
                            _fpCameraInstaller.BindCameraToPlayer(this);
                        }
                        if (_movement != null && _gameplayCamera != null)
                        {
                            _movement.ChangeCamera(_gameplayCamera);
                        }
                    }
                    break;
            }
        }

        public void ClearSceneReferences(SceneType scene)
        {
            switch (scene)
            {
                case SceneType.Lobby:
                    if (IsOwner)
                    {
                        if (IsHost)
                        {
                            _inputReader.OnStartButtonKeyPressed -= _lobbyUI.InvokeGameStartButtonPress;
                        }
                    }
                    break;
            }
        }

        public override void OnNetworkDespawn()
        {
            _sceneLifecycleManager.Unregister(this);
            if (!IsOwner) return;
            if(_movement != null)
                _inputReader.OnJump -= _movement.HandleJump;
        }

        public void SetTeam(Team team)
        {
            if (!IsServer)
                return;

            _team.Value = team;
        }

        private void FixedUpdate()
        {
            if (!IsOwner) return;
            if (_movement == null)
            {
                Debug.LogWarning("Movement Is NULL!!!");
                return;
            }
            _movement.HandleFixedMovement(_inputReader.MoveDirection);
        }

        private void OnDrawGizmos()
        {
            if(!IsOwner) return;
            _movement?.DrawGizmos();
        }
    }
}
