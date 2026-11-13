using KBCore.Refs;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.Input
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField, Self] private PlayerInput _playerInput;
        [SerializeField] private string _keyboardMouseControlScheme = "Keyboard&Mouse";
        // stays on while gameplay input is off, so the pause menu can still be closed
        [SerializeField] private string _pauseActionName = "Pause";
        public Vector2 MoveDirection { get; private set; }
        public Vector2 LookDirection { get; private set; }
        public event Action OnAttack;
        public event Action<bool> OnJump;
        public event Action OnInteract;
        public event Action<bool> OnInteractHeldChanged;
        public event Action OnSpectateNext;
        public event Action OnSpectatePrevious;
        public event Action OnAbility;
        public event Action OnToggleMenu;
        public event Action OnPause;
        public event Action<bool> OnWalkHeldChanged;

        public event Action OnStartButtonKeyPressed;
        public bool IsUsingMouse => _playerInput.currentControlScheme == _keyboardMouseControlScheme;
        public bool IsWalkHeld { get; private set; }
        public InputActionAsset Actions => _playerInput.actions;

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

        public void Attack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnAttack?.Invoke();
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
                OnInteractHeldChanged?.Invoke(true);
            }
            else if (context.canceled)
            {
                OnInteractHeldChanged?.Invoke(false);
            }
        }

        public void Walk(InputAction.CallbackContext context)
        {
            if (context.performed) ToggleWalkHeld(true);
            else if (context.canceled) ToggleWalkHeld(false);
        }

        private void ToggleWalkHeld(bool isHeld)
        {
            if (IsWalkHeld == isHeld) return;

            IsWalkHeld = isHeld;
            OnWalkHeldChanged?.Invoke(isHeld);
        }

        public void ToggleMenu(InputAction.CallbackContext context)
        {
            if (context.performed) OnToggleMenu?.Invoke();
        }

        public void Pause(InputAction.CallbackContext context)
        {
            if (context.performed) OnPause?.Invoke();
        }

        // Off while a menu takes over: disabling cancels held actions (walk, interact, move), so nothing stays pressed
        public void ToggleGameplayActions(bool isEnabled)
        {
            if (_playerInput.currentActionMap == null) return;

            foreach (var action in _playerInput.currentActionMap.actions)
            {
                if (action.name == _pauseActionName) continue;

                if (isEnabled) action.Enable();
                else action.Disable();
            }
        }

        public void Ability(InputAction.CallbackContext context)
        {
            if (context.performed) OnAbility?.Invoke();
        }

        public void SpectateNext(InputAction.CallbackContext context)
        {
            if (context.performed) OnSpectateNext?.Invoke();
        }

        public void SpectatePrevious(InputAction.CallbackContext context)
        {
            if (context.performed) OnSpectatePrevious?.Invoke();
        }

        // Lets dev tools and bots drive the player through the same events as real input
        public void SimulateMove(Vector2 direction) => MoveDirection = direction;

        public void SimulateInteractHeld(bool isHeld)
        {
            if (isHeld) OnInteract?.Invoke();
            OnInteractHeldChanged?.Invoke(isHeld);
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
