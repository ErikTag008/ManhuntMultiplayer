using KBCore.Refs;
using Project.Assets._Project._Scripts.Settings;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Keeps one pick that mouse, keyboard and gamepad share, so the selection outline never sits on one button while the mouse points at another:
    // moving the mouse onto a selectable focuses it, and a navigate or submit press brings back the last usable focus when it was lost
    // (e.g. after a click on empty space). Menus still choose their own first selection.
    // Stays out of the way while a key is being rebound: that clears the focus on purpose, so the bound key can't also press a button.
    [RequireComponent(typeof(EventSystem), typeof(InputSystemUIInputModule))]
    public class SelectionKeeper : ValidatedMonoBehaviour
    {
        [Inject] private readonly KeybindService _keybinds;
        [SerializeField, Self] private EventSystem _eventSystem;
        [SerializeField, Self] private InputSystemUIInputModule _inputModule;
        [SerializeField] private bool _isFocusFollowingMouse = true;

        private InputAction _navigateAction;
        private InputAction _submitAction;
        private GameObject _lastSelected;
        private bool _isRestorePending;

        private void OnEnable()
        {
            _navigateAction = _inputModule.move != null ? _inputModule.move.action : null;
            _submitAction = _inputModule.submit != null ? _inputModule.submit.action : null;
            if (_navigateAction != null) _navigateAction.performed += HandleRestorePressed;
            if (_submitAction != null) _submitAction.performed += HandleRestorePressed;
        }

        private void Update()
        {
            var selected = _eventSystem.currentSelectedGameObject;
            if (IsUsable(selected)) _lastSelected = selected;
        }

        // after the input module ran this frame, so the press that brings focus back doesn't also move or click it
        private void LateUpdate()
        {
            if (_isFocusFollowingMouse) FocusHovered();
            if (!_isRestorePending) return;

            _isRestorePending = false;
            if (CanRestore()) _eventSystem.SetSelectedGameObject(_lastSelected);
        }

        private void HandleRestorePressed(InputAction.CallbackContext _) => _isRestorePending = CanRestore();

        // only a moving mouse takes the focus, so a mouse resting on a button doesn't fight a gamepad moving it elsewhere;
        // a held button is a drag (slider, scroll list), which keeps the focus on the dragged control
        private void FocusHovered()
        {
            var mouse = Mouse.current;
            if (mouse == null || Cursor.lockState == CursorLockMode.Locked || _keybinds.IsRebinding) return;
            if (mouse.delta.ReadValue() == Vector2.zero || mouse.leftButton.isPressed || IsTyping()) return;

            var hit = _inputModule.GetLastRaycastResult(mouse.deviceId).gameObject;
            if (hit == null) return;

            var selectable = hit.GetComponentInParent<Selectable>();
            if (!CanTakeHoverFocus(selectable) || selectable.gameObject == _eventSystem.currentSelectedGameObject) return;

            _eventSystem.SetSelectedGameObject(selectable.gameObject);
        }

        // a text field starts typing when focused, and scrollbars (no navigation) are never a pick
        private static bool CanTakeHoverFocus(Selectable selectable) =>
            selectable != null && selectable.IsInteractable() && selectable.navigation.mode != Navigation.Mode.None &&
            selectable is not TMP_InputField && selectable is not InputField;

        // a text field being typed in keeps the focus, so pointing at a button can't end the typing
        private bool IsTyping()
        {
            var selected = _eventSystem.currentSelectedGameObject;
            if (selected == null) return false;
            if (selected.TryGetComponent(out TMP_InputField tmpField)) return tmpField.isFocused;

            return selected.TryGetComponent(out InputField field) && field.isFocused;
        }

        private bool CanRestore() =>
            !_keybinds.IsRebinding && !IsUsable(_eventSystem.currentSelectedGameObject) && IsUsable(_lastSelected);

        private static bool IsUsable(GameObject target) =>
            target != null && target.activeInHierarchy && (!target.TryGetComponent(out Selectable selectable) || selectable.IsInteractable());

        private void OnDisable()
        {
            if (_navigateAction != null) _navigateAction.performed -= HandleRestorePressed;
            if (_submitAction != null) _submitAction.performed -= HandleRestorePressed;
            _navigateAction = null;
            _submitAction = null;
            _isRestorePending = false;
        }
    }
}
