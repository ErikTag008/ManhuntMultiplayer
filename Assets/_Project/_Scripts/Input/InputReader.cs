using KBCore.Refs;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.Player
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField, Self] private PlayerInput _playerInput;
        public Vector2 MoveDirection { get; private set; }
        public Vector2 LookDirection { get; private set; }
        public event Action<bool> OnShoot;
        public event Action<bool> OnJump;
        public event Action OnInteract;
        public event Action OnReload;
        public event Action PrimaryWeaponSwitch;
        public event Action SecondaryWeaponSwitch;
        public event Action OnHealthPotionUsed;

        public event Action OnStartButtonKeyPressed;
        public bool IsUsingMouse => _playerInput.currentControlScheme == "Keyboard&Mouse";

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void Move(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                MoveDirection = context.ReadValue<Vector2>();
            }
            else if (context.canceled)
            {
                MoveDirection = Vector2.zero;
            }
        }

        public void Look(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                LookDirection = context.ReadValue<Vector2>();
            }
            else if (context.canceled)
            {
                LookDirection = Vector2.zero;
            }
        }

        public void Shoot(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnShoot?.Invoke(true);
            }
            else if (context.canceled)
            {
                OnShoot?.Invoke(false);
            }
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnJump?.Invoke(true);
            }
            else if (context.canceled)
            {
                OnJump?.Invoke(false);
            }
        }

        public void Interact(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnInteract?.Invoke();
            }
        }

        public void Reload(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnReload?.Invoke();
            }

        }

        public void PrimaryWeapon(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                PrimaryWeaponSwitch?.Invoke();
            }
        }

        public void SecondaryWeapon(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                SecondaryWeaponSwitch?.Invoke();
            }

        }

        public void HealthPotion(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnHealthPotionUsed?.Invoke();
            }
        }

        public void StartButton(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnStartButtonKeyPressed?.Invoke();
            }
        }
    }
}
