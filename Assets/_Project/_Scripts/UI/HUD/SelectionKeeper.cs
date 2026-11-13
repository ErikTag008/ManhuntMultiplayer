using Project.Assets._Project._Scripts.Settings;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Gives focus back when it was lost, e.g. after a mouse click on empty space, so a gamepad can always navigate again.
    // Menus still choose their own first selection; this only restores the last usable one on a navigate press.
    // Stays out of the way while a key is being rebound: that clears the focus on purpose, so the bound key can't also press a button.
    [RequireComponent(typeof(EventSystem), typeof(InputSystemUIInputModule))]
    public class SelectionKeeper : MonoBehaviour
    {
        [Inject] private readonly KeybindService _keybinds;
        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private InputSystemUIInputModule _inputModule;

        private InputAction _navigateAction;
        private GameObject _lastSelected;
        private bool _isRestorePending;

        private void Reset()
        {
            _eventSystem = GetComponent<EventSystem>();
            _inputModule = GetComponent<InputSystemUIInputModule>();
        }

        private void OnEnable()
        {
            _navigateAction = _inputModule.move != null ? _inputModule.move.action : null;
            if (_navigateAction != null) _navigateAction.performed += HandleNavigatePerformed;
        }

        private void Update()
        {
            var selected = _eventSystem.currentSelectedGameObject;
            if (IsUsable(selected)) _lastSelected = selected;
        }

        // after the input module ran this frame, so the press that brings focus back doesn't also move it a step
        private void LateUpdate()
        {
            if (!_isRestorePending) return;

            _isRestorePending = false;
            if (CanRestore()) _eventSystem.SetSelectedGameObject(_lastSelected);
        }

        private void HandleNavigatePerformed(InputAction.CallbackContext _) => _isRestorePending = CanRestore();

        private bool CanRestore() =>
            !_keybinds.IsRebinding && !IsUsable(_eventSystem.currentSelectedGameObject) && IsUsable(_lastSelected);

        private static bool IsUsable(GameObject target) =>
            target != null && target.activeInHierarchy && (!target.TryGetComponent(out Selectable selectable) || selectable.IsInteractable());

        private void OnDisable()
        {
            if (_navigateAction != null) _navigateAction.performed -= HandleNavigatePerformed;
            _navigateAction = null;
            _isRestorePending = false;
        }
    }
}
