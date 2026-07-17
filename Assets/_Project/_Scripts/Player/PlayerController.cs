using KBCore.Refs;
using Project.Assets._Project._Scripts.DI;
using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.Player
{
    [RequireComponent(typeof(PlayerInput), typeof(InputReader), typeof(Rigidbody))]
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField, Self] private PlayerInput _playerInput;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField, Self] private Rigidbody _rb;
        [SerializeField] private Transform _model;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Transform _cameraRoot;
        private readonly PlayerStats _stats = InjectionHolder.Instance.Stats;
        private readonly Camera _mainCamera = InjectionHolder.Instance.MainCamera;
        private readonly GameplayCamera _gameplayCamera = InjectionHolder.Instance.GameplayCamera;
        private IPlayerMovement _movement;
        public Transform CameraRoot => _cameraRoot;
        public InputReader InputReader => _inputReader;
        public static event Action<PlayerController> OnPlayerSpawned;


        private void Awake()
        {
            _playerInput.enabled = false;
        }

        public override void OnNetworkSpawn()
        {
            _movement = new PlayerMovement(_rb, _stats, _groundCheck, _gameplayCamera , _model);
            if (!IsOwner) return;
            _playerInput.enabled = true;
            OnPlayerSpawned?.Invoke(this);
            _inputReader.OnJump += _movement.HandleJump;
        }

        public override void OnNetworkDespawn()
        {
            _inputReader.OnJump -= _movement.HandleJump;
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
