using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Turns something shown in this rect: a horizontal pointer drag, or the turn axis while input is on.
    // Needs a raycast target graphic on the same object to receive drags.
    public class DragRotateArea : MonoBehaviour, IDragHandler
    {
        [SerializeField] private float _degreesPerPixel = 0.4f;
        [SerializeField] private float _axisDegreesPerSecond = 180f;
        // a float axis, positive turning like a drag to the right. Bound here, so it works while the gameplay actions are
        // off. The triggers by default: the sticks and the d-pad already move UI focus
        // the defaults are set in Reset/Awake, not a field initializer: that runs off the main thread during a domain
        // reload, where building a composite binding throws
        [SerializeField] private InputAction _turnAction;
        [SerializeField, Range(0f, 1f)] private float _axisDeadZone = 0.2f;

        // degrees of yaw; a drag to the right gives negative
        public event Action<float> OnRotated;

        private CancellationTokenSource _axisCTS;
        private bool _isInputOn;

        // the turn axis' bindings as the player sees them, e.g. "LT/RT"; every binding is listed, so it stays gamepad-only,
        // and as it isn't rebindable the text never changes at runtime
        public string TurnBindingText => _turnAction.GetBindingDisplayString();

        private void Reset() => _turnAction = CreateDefaultTurnAction();

        // a component added from code has no serialized action
        private void Awake()
        {
            if (_turnAction == null || _turnAction.bindings.Count == 0) _turnAction = CreateDefaultTurnAction();
        }

        public void ToggleInput(bool isOn)
        {
            if (isOn == _isInputOn) return;

            _isInputOn = isOn;
            StopAxis();
            if (!isOn) return;

            _turnAction.Enable();
            _axisCTS = new();
            ReadAxisAsync(_axisCTS.Token).Forget();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_isInputOn) return;

            OnRotated?.Invoke(-eventData.delta.x * _degreesPerPixel);
        }

        private static InputAction CreateDefaultTurnAction()
        {
            var action = new InputAction("Turn", InputActionType.Value, expectedControlType: "Axis");
            action.AddCompositeBinding("1DAxis")
                .With("Negative", "<Gamepad>/leftTrigger")
                .With("Positive", "<Gamepad>/rightTrigger");
            return action;
        }

        // UI time: the menu may sit over a paused game
        private async UniTaskVoid ReadAxisAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                float axis = _turnAction.ReadValue<float>();
                if (Mathf.Abs(axis) > _axisDeadZone) OnRotated?.Invoke(-axis * _axisDegreesPerSecond * Time.unscaledDeltaTime);
                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }
        }

        private void StopAxis()
        {
            _turnAction.Disable();
            _axisCTS?.Cancel();
            _axisCTS?.Dispose();
            _axisCTS = null;
        }

        private void OnDestroy()
        {
            StopAxis();
            _turnAction.Dispose();
        }
    }
}
