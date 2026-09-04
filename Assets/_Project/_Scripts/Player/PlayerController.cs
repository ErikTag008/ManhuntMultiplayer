using Alchemy.Inspector;
using KBCore.Refs;
using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.DI;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Managers;
using Project.Assets._Project._Scripts.UI;
using Project.Assets._Project._Scripts.Weapons;
using Reflex.Attributes;
using Reflex.Core;
using Reflex.Extensions;
using Reflex.Injectors;
using System;
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
        [SerializeField, Self] private Health _health;
        public Health Health => _health;

        [SerializeField] private Transform _model;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Transform _cameraTarget;
        [SerializeField] private Transform _weaponPivot;
        [SerializeField] private Transform _cameraFollower;
        [SerializeField] private NetworkVariable<Team> _team = new();

        public Team Team => _team.Value;
        public Transform CameraTarget => _cameraTarget;
        public InputReader InputReader => _inputReader;

        [Inject] private PlayerStats _playerStats;
        [Inject] private readonly SceneLifecycleManager _sceneLifecycleManager;
        [Inject] private readonly GameScenes _gameScenes;
        [Inject] private readonly IPlayerRegistry _playerRegistry;

        private NetworkVariable<float> _modelRotation = new(0f, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
        private NetworkVariable<Quaternion> _cameraFollowerRotation = new(Quaternion.identity, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
        private NetworkVariable<Vector3> _weaponPosition = new(Vector3.zero, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner); 
        private NetworkVariable<Quaternion> _weaponRotation = new(Quaternion.identity, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

        private Camera _gameplayCamera;
        private FPCameraInstaller _fpCameraInstaller;
        private MeleeWeaponBase _currentWeapon;
        private ILobbyUI _lobbyUI;
        private IPlayerMovement _movement;

        private float _targetModelRotation;
        private Quaternion _targetCameraFollowerRotation;
        private Vector3 _targetWeaponPosition;
        private Quaternion _targetWeaponRotation;

        private readonly Collider[] _damagables = new Collider[3];

        private void Awake()
        {
            _playerInput.enabled = false;
        }

        

        public override void OnNetworkSpawn()
        {
            InjectGlobalDependencies();
            Debug.Assert(_sceneLifecycleManager != null, "SceneLifecycleManager wasn't injected!");
            UpdateModelRpc();
            BindNetworkVariable(_modelRotation, OnModelRotationNetworkVarChanged);
            BindNetworkVariable(_cameraFollowerRotation, OnCameraFollowerRotationNetworkVarChanged);
            BindNetworkVariable(_weaponPosition, OnWeaponPositionNetworkVarChanged);
            BindNetworkVariable(_weaponRotation, OnWeaponRotationNetworkVarChanged);
            _sceneLifecycleManager.Register(this);
            if (IsOwner)
            {
                _playerInput.enabled = true;
            }
            if (IsServer)
            {
                _health.OnDowned += HandleGettingDownedRpc;

            }
        }

        [Rpc(SendTo.Owner)]
        private void HandleGettingDownedRpc()
        {

            _movement?.ToggleMovement(false);
        }

        [Rpc(SendTo.Owner)]
        private void HandleGettingResurrectedRpc()
        {
            _movement?.ToggleMovement(true);
        }

        private void Update()
        {
            if (!IsOwner)
            {
                SmoothOutNetworkSyncedObjects();
                return;
            }
            //_movement.HandleUpdate();
        }

        private void SmoothOutNetworkSyncedObjects()
        {
            _model.rotation = EUtils.Math.Slerp(_model.rotation, Quaternion.Euler(0f, _targetModelRotation, 0f), Time.deltaTime * _playerStats.NetworkVariableSmoothingSpeed);
            _cameraFollower.rotation = EUtils.Math.Slerp(_cameraFollower.rotation, _targetCameraFollowerRotation, Time.deltaTime * _playerStats.NetworkVariableSmoothingSpeed);
            if(_currentWeapon != null)
            {
                _currentWeapon.transform.SetLocalPositionAndRotation(
                    EUtils.Math.Lerp(_currentWeapon.transform.localPosition, _targetWeaponPosition, Time.deltaTime * _playerStats.NetworkVariableSmoothingSpeed),
                    EUtils.Math.Slerp(_currentWeapon.transform.localRotation, _targetWeaponRotation, Time.deltaTime * _playerStats.NetworkVariableSmoothingSpeed));
            }
            
        }

        private void FixedUpdate()
        {
            if (!IsOwner) return;
            if (_movement == null)
            {
                EUtils.Logger.LogWarning("Movement is NULL");
                return;
            }
            _movement.HandleFixedMovement(_inputReader.MoveDirection);
        }

        private void BindNetworkVariable<T>(NetworkVariable<T> networkVar, Action<T, T> onChangedCallback)
        {
            networkVar.OnValueChanged += (oldValue, newValue) =>
            {
                if (!IsOwner)
                {
                    onChangedCallback?.Invoke(oldValue, newValue);
                }
            };
        }

        private void OnModelRotationNetworkVarChanged(float oldValue, float newValue)
        {
            _model.rotation = Quaternion.Euler(0f, newValue, 0f);
        }

        private void OnCameraFollowerRotationNetworkVarChanged(Quaternion oldValue, Quaternion newValue)
        {
            _cameraFollower.rotation = newValue;
        }

        private void OnWeaponPositionNetworkVarChanged(Vector3 oldValue, Vector3 newValue)
        {
            if(_currentWeapon != null)
                _currentWeapon.transform.position = newValue;
        }

        private void OnWeaponRotationNetworkVarChanged(Quaternion oldValue, Quaternion newValue)
        {
            if (_currentWeapon != null)
                _currentWeapon.transform.rotation = newValue;
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
                EUtils.Logger.LogWarning("[PlayerController] Scene container not found during global injection. Retrying in next frame...");
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
                _lobbyUI = container.Resolve<ILobbyUI>();
                _fpCameraInstaller = container.Resolve<FPCameraInstaller>();
            }
            catch (Exception e)
            {
                EUtils.Logger.LogWarning($"[PlayerController] Could not resolve Lobby Dependencies: {e.Message}");
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
                EUtils.Logger.LogWarning($"[PlayerController] Could not resolve Gameplay dependencies: {e.Message}");
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
                        EUtils.Logger.Log("Creating movement");
                        if (_fpCameraInstaller != null)
                        {
                            _fpCameraInstaller.BindCameraToPlayer(this);
                        }
                        else
                        {
                            EUtils.Logger.LogError("[PlayerController] FPCameraInstaller is NULL! Dependency resolution failed.");
                        }

                        if(_movement == null)
                        {
                            if (_playerStats && _gameplayCamera)
                            {
                                _movement = new PlayerMovement(_rb, _playerStats, _groundCheck, _gameplayCamera, _model, _cameraFollower);
                                _fpCameraInstaller.OnCameraRotationChanged -= _movement.HandleRotation;
                                _fpCameraInstaller.OnCameraRotationChanged += _movement.HandleRotation;
                                _movement.ModelRotationChanged += val => OnVariableChanged(_modelRotation, val);
                                _movement.CameraFollowerRotationChanged += val => OnVariableChanged(_cameraFollowerRotation, val);
                            }
                            else
                            {
                                EUtils.Logger.LogError($"[PlayerController] Missing dependencies for Movement! Stats: {_playerStats == null}, Camera: {_gameplayCamera == null}");
                            }
                        }
                        else
                        {
                            if (_gameplayCamera != null)
                            {
                                _movement.ChangeCamera(_gameplayCamera);
                                _fpCameraInstaller.OnCameraRotationChanged -= _movement.HandleRotation;
                                _fpCameraInstaller.OnCameraRotationChanged += _movement.HandleRotation;
                            }
                        }
                        _inputReader.OnJump += _movement.HandleJump;


                        if (IsHost)
                        {
                            if (_lobbyUI != null)
                            {
                                _inputReader.OnStartButtonKeyPressed += _lobbyUI.InvokeGameStartButtonPress;
                            }
                            else
                            {
                                EUtils.Logger.LogError("[PlayerController] LobbyUI is NULL! Cannot bind Start Button.");
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
                            _fpCameraInstaller.OnCameraRotationChanged -= _movement.HandleRotation;
                            _fpCameraInstaller.OnCameraRotationChanged += _movement.HandleRotation;
                        }
                    }
                    break;
            }
        }

        private void OnVariableChanged<T>(NetworkVariable<T> networkVar, T value)
        {
            if(!IsOwner) return;
            networkVar.Value = value;
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
                case SceneType.Gameplay:
                    if (IsOwner)
                    {
                        _inputReader.OnJump -= _movement.HandleJump;
                    }
                    break;
            }
        }

        public override void OnNetworkDespawn()
        {
            _sceneLifecycleManager.Unregister(this);
            _modelRotation.OnValueChanged -= OnModelRotationNetworkVarChanged;
            if (!IsOwner) return;
            if(_movement != null)
                _inputReader.OnJump -= _movement.HandleJump;
        }

        public void SetTeam(Team team)
        {
            if (!IsServer)
                return;

            _team.Value = team;
           
            
            UpdateGlobalRpc(team);
            UpdateLocalRpc(team);
        }

        private void PerformAttack()
        {
            print(EUtils.Logger.Colorize($"[PlayerController] Performing attack for player {OwnerClientId} on team {Team}", "red"));
            if(_currentWeapon != null)
                _currentWeapon.Attack();
        }

        [Rpc(SendTo.Server)]
        private void CheckDamageServerRpc(Vector3 hitOrigin, float radius)
        {
            int damaged = Physics.OverlapSphereNonAlloc(hitOrigin, radius, _damagables, _playerStats.AttackRaycastLayer);
            for (int i = 0; i < damaged; i++)
            {
                var damagedItem = _damagables[i];
                if (damagedItem == null) continue;
                damagedItem.GetComponentInParent<Health>()?.TakeDamage(1);
                print(EUtils.Logger.Colorize($"{damagedItem} received Damager", "red"));

            }
        }

        [Rpc(SendTo.Everyone)]
        private void UpdateGlobalRpc(Team team)
        {
            var container = SceneManager.GetActiveScene().GetSceneContainer();
            PlayerStats stats = null;
            if (team == Team.Catcher)
            {
                stats = container.Resolve<CatcherStats>();
                GetWeapon(stats.WeaponPrefab);
            }
            else if (team == Team.Runner)
            {
                stats = container.Resolve<RunnerStats>();
                DestroyWeapon();
            }
            if (stats == null) return;
            _playerStats = stats;
            _movement?.ChangeStats(stats);
            ChangeModel(stats.Model);

        }

        private void GetWeapon(MeleeWeaponBase weaponPrefab)
        {
            if (weaponPrefab == null) return;

            _currentWeapon = Instantiate(weaponPrefab, _weaponPivot);
            _currentWeapon.OnWeaponPositionChanged += val => OnVariableChanged(_weaponPosition, val);
            _currentWeapon.OnWeaponRotationChanged += val => OnVariableChanged(_weaponRotation, val);
            _currentWeapon.OnCheckDamageRequested += CheckDamageServerRpc;
        }

        private void DestroyWeapon()
        {
            if(_currentWeapon != null)
            {
                Destroy(_currentWeapon.gameObject);
                _currentWeapon = null;
            }
        }

        [Rpc(SendTo.Owner)]
        private void UpdateLocalRpc(Team team)
        {
            if (team == Team.Catcher)
            {
                _inputReader.OnAttack += PerformAttack;
            }
            else
            {
                _inputReader.OnAttack -= PerformAttack;
            }
        }

        [Rpc(SendTo.Everyone)]
        private void UpdateModelRpc()
        {
            ChangeModel(_playerStats.Model);
        }

        private void ChangeModel(Transform model)
        {
            Destroy(_model.gameObject);
            _model = Instantiate(model, transform);
            _movement?.ChangeModel(_model);
        }

        private void OnDrawGizmos()
        {
            if(!IsOwner) return;
            _movement?.DrawGizmos();
        }
    }
}
