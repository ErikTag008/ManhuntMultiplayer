using Alchemy.Inspector;
using KBCore.Refs;
using Project.Assets._Project._Scripts.DI;
using Project.Assets._Project._Scripts.Managers;
using Reflex.Attributes;
using Reflex.Extensions;
using Reflex.Injectors;
using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Project.Assets._Project._Scripts.Player
{
    public enum Team
    {
        Catcher,
        Runner
    }

    [RequireComponent(typeof(PlayerInput), typeof(InputReader), typeof(Rigidbody))]
    public class PlayerController : NetworkBehaviour, ISceneInitialized
    {
        [SerializeField, Self] private PlayerInput _playerInput;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField, Self] private Rigidbody _rb;
        [SerializeField] private Transform _model;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Transform _cameraRoot;
        [SerializeField] private NetworkVariable<Team> _team;
        [Inject] private readonly PlayerStats _playerStats;
        [Inject] private readonly SceneLifecycleManager _sceneLifecycleManager;
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
            InjectDependencies();
            Debug.Assert(_sceneLifecycleManager != null, "SceneLifecycleManager wasn't injected!");
            _sceneLifecycleManager.Register(this);
            if (IsOwner)
            {
                _playerInput.enabled = true;
            }
        }

        

        private void InjectDependencies() => GameObjectInjector.InjectObject(gameObject, SceneManager.GetActiveScene().GetSceneContainer());

        public void InitializeSceneReferences(SceneType scene)
        {
            switch (scene)
            {
                case SceneType.Lobby:
                    //InjectDependencies();
                    var lobbyRef = LobbyReferenceHolder.Instance;
                    Debug.Assert(lobbyRef != null);
                    if (IsOwner)
                    {
                        Debug.Log("Creating movement");
                        lobbyRef.FPCameraInstaller.BindCameraToPlayer(this);
                        if(_movement == null)
                        {
                            _movement = new PlayerMovement(_rb, _playerStats, _groundCheck, lobbyRef.GameplayCamera, _model);
                        }
                        else
                        {
                            _movement.ChangeCamera(lobbyRef.GameplayCamera);
                        }
                        _inputReader.OnJump += _movement.HandleJump;
                    }
                    if (IsServer)
                    {
                        GameManager.Instance?.RegisterPlayer(this);
                    }
                    break;
                case SceneType.Gameplay:
                    //InjectDependencies();
                    var gameplayRef = GameplayReferenceHolder.Instance;
                    Debug.Assert(gameplayRef != null);
                    if (IsOwner)
                    {
                        gameplayRef.FPCameraInstaller.BindCameraToPlayer(this);
                        _movement.ChangeCamera(gameplayRef.GameplayCamera);
                    }
                    break;
            }

        }

        public void ClearSceneReferences(SceneType scene)
        {
            //noop
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
