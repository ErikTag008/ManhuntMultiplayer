using DG.Tweening;
using KBCore.Refs;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Grows the button under the mouse, or else the focused one, so the current pick feels alive with mouse, keyboard and gamepad.
    // Sits next to the canvas's SelectionFrame; the outline follows the grown corners, so it grows along with the button.
    [RequireComponent(typeof(SelectionFrame))]
    public class SelectionPop : ValidatedMonoBehaviour
    {
        [SerializeField, Self] private SelectionFrame _selectionFrame;
        [SerializeField] private float _popScale = 1.08f;
        [SerializeField] private float _popInDuration = 0.15f;
        [SerializeField] private float _popOutDuration = 0.1f;
        [SerializeField] private Ease _popInEase = Ease.OutBack;
        [SerializeField] private Ease _popOutEase = Ease.OutCubic;
        // the mouse pops what it points at, even while the keyboard or gamepad focus sits somewhere else
        [SerializeField] private bool _isHoverPopped = true;

        private readonly Dictionary<Transform, Vector3> _baseScales = new();
        private readonly Dictionary<Transform, Tween> _scaleTweens = new();
        private Transform _canvasRoot;
        private Transform _poppedTarget;
        private Transform _lastFocused;
        private bool _isHoverActive;

        private void Awake() => _canvasRoot = GetComponentInParent<Canvas>().rootCanvas.transform;

        private void LateUpdate()
        {
            RefreshHoverActive();
            var target = GetPopTarget();
            if (target == _poppedTarget) return;

            if (_poppedTarget != null) ScaleTo(_poppedTarget, false);
            _poppedTarget = target;
            if (_poppedTarget != null) ScaleTo(_poppedTarget, true);
        }

        // a still mouse resting on a button would otherwise keep it popped while a gamepad moves the focus elsewhere,
        // so a focus change hands the pop to the focus until the mouse moves again
        private void RefreshHoverActive()
        {
            Transform focused = _selectionFrame.GetFocusedTarget();
            if (focused != _lastFocused)
            {
                _lastFocused = focused;
                _isHoverActive = false;
            }

            var mouse = Mouse.current;
            if (mouse != null && mouse.delta.ReadValue() != Vector2.zero) _isHoverActive = true;
        }

        private Transform GetPopTarget()
        {
            if (_isHoverPopped && _isHoverActive && TryGetHoveredTarget(out var hovered)) return hovered;
            if (_lastFocused == null || !_lastFocused.TryGetComponent(out Selectable selectable)) return null;

            return IsPoppable(selectable) ? _lastFocused : null;
        }

        // the input module's last raycast is what the pointer is over; hidden panels block no raycasts, so they never show up here
        private bool TryGetHoveredTarget(out Transform hovered)
        {
            hovered = null;
            var mouse = Mouse.current;
            if (mouse == null || Cursor.lockState == CursorLockMode.Locked) return false;
            if (EventSystem.current == null || EventSystem.current.currentInputModule is not InputSystemUIInputModule inputModule) return false;

            var hit = inputModule.GetLastRaycastResult(mouse.deviceId).gameObject;
            if (hit == null || !hit.transform.IsChildOf(_canvasRoot)) return false;

            var selectable = hit.GetComponentInParent<Selectable>();
            if (selectable == null || !IsPoppable(selectable)) return false;

            hovered = selectable.transform;
            return true;
        }

        // only buttons and toggles: wide sliders and text fields would grow too far past their rows
        private static bool IsPoppable(Selectable selectable) =>
            (selectable is Button || selectable is Toggle) && selectable.IsInteractable();

        private void ScaleTo(Transform target, bool isPopped)
        {
            var baseScale = GetBaseScale(target);
            if (_scaleTweens.TryGetValue(target, out var running)) running?.Kill();

            _scaleTweens[target] = target.DOScale(isPopped ? baseScale * _popScale : baseScale, isPopped ? _popInDuration : _popOutDuration)
                .SetEase(isPopped ? _popInEase : _popOutEase)
                .SetUpdate(true)
                .SetLink(target.gameObject);
        }

        // read before the first pop, so a button with its own scale returns to that instead of to one
        private Vector3 GetBaseScale(Transform target)
        {
            if (_baseScales.TryGetValue(target, out var baseScale)) return baseScale;

            baseScale = target.localScale;
            _baseScales[target] = baseScale;
            return baseScale;
        }

        private void OnDisable()
        {
            foreach (var pair in _scaleTweens) pair.Value?.Kill();
            _scaleTweens.Clear();
            foreach (var pair in _baseScales)
            {
                if (pair.Key != null) pair.Key.localScale = pair.Value;
            }

            _poppedTarget = null;
            _lastFocused = null;
            _isHoverActive = false;
        }
    }
}
