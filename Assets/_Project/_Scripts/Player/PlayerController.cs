using Alchemy.Inspector;
using KBCore.Refs;
using Project.Assets._Project._Scripts.DI;
using Project.Assets._Project._Scripts.Managers;
using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.Player
{
    public enum Team
    {
        Catcher,
        Runner
    }

    [RequireComponent(typeof(PlayerInput), typeof(InputReader), typeof(Rigidbody))]
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField, Self] private PlayerInput _playerInput;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField, Self] private Rigidbody _rb;
        [SerializeField] private Transform _model;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Transform _cameraRoot;
        [SerializeField] private NetworkVariable<Team> _team;
        public Team Team => _team.Value;
        private readonly PlayerStats _stats = InjectionHolder.Instance?.Stats;
        private readonly Camera _mainCamera = InjectionHolder.Instance?.MainCamera;
        private readonly GameplayCamera _gameplayCamera = InjectionHolder.Instance?.GameplayCamera;
        private readonly IPlayerRegistry _playerRegistry = InjectionHolder.Instance?.PlayerRegistry;    
        private IPlayerMovement _movement;
        public Transform CameraRoot => _cameraRoot;
        public InputReader InputReader => _inputReader;
        public static event Action<PlayerController> OnCameraBindingRequest;


        private void Awake()
        {
            _playerInput.enabled = false;
        }

        public override void OnNetworkSpawn()
        {
            
            _movement = new PlayerMovement(_rb, _stats, _groundCheck, _gameplayCamera , _model);
            if (IsOwner)
            {
                _playerInput.enabled = true;
                OnCameraBindingRequest?.Invoke(this);
                _inputReader.OnJump += _movement.HandleJump;
                ToggleCamera(true);
            }
            if (IsServer)
            {
                _playerRegistry?.RegisterPlayer(this);
            }

        }


        [Button]
        public void ToggleCamera(bool isGameplayCamera)
        {
            Camera gameplayCam = _gameplayCamera;
            if (isGameplayCamera)
            {
                _mainCamera.gameObject.SetActive(false);
                gameplayCam.gameObject.SetActive(true);
            }
            else
            {
                gameplayCam.gameObject.SetActive(false);
                _mainCamera.gameObject.SetActive(true);
            }
        }
        public override void OnNetworkDespawn()
        {
            if (!IsOwner) return;
            _inputReader.OnJump -= _movement.HandleJump;
            ToggleCamera(false);
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
            _movement.HandleFixedMovement(_inputReader.MoveDirection);
        }

        private void OnDrawGizmos()
        {
            if(!IsOwner) return;
            _movement.DrawGizmos();
        }



    }
}
