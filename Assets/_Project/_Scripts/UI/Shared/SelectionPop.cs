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
    // Tilts the button under the mouse, or else the focused one, left then right around its centre when it becomes the current pick,
    // so the pick feels alive with mouse, keyboard and gamepad. Only rotates, so the button never grows past its panel.
    // Sits next to the canvas's SelectionFrame, which tilts along with the button.
    [RequireComponent(typeof(SelectionFrame))]
    public class SelectionPop : ValidatedMonoBehaviour
    {
        private const float CentrePivot = 0.5f;

        [SerializeField, Self] private SelectionFrame _selectionFrame;
        [SerializeField] private float _tiltAngle = 5f;
        [SerializeField] private float _tiltLeftDuration = 0.08f;
        [SerializeField] private float _tiltRightDuration = 0.14f;
        [SerializeField] private float _settleDuration = 0.08f;
        [SerializeField] private Ease _tiltEase = Ease.InOutSine;
        // the mouse jiggles what it points at, even while the keyboard or gamepad focus sits somewhere else
        [SerializeField] private bool _isHoverJiggled = true;

        private readonly Dictionary<RectTransform, Quaternion> _baseRotations = new();
        private readonly Dictionary<RectTransform, Vector2> _basePivots = new();
        private readonly Dictionary<RectTransform, Tween> _jiggleTweens = new();
        private RectTransform _canvasRoot;
        private RectTransform _jiggledTarget;
        private Transform _lastFocused;
        private bool _isHoverActive;

        private void Awake() => _canvasRoot = (RectTransform)GetComponentInParent<Canvas>().rootCanvas.transform;

        // the focused button tilts only when the focus moves onto it, not when the mouse leaves another button and the pick falls back to it
        private void LateUpdate()
        {
            bool isFocusChanged = RefreshHoverActive();
            var target = GetJiggleTarget(out bool isHovered);
            if (target == _jiggledTarget) return;

            _jiggledTarget = target;
            if (_jiggledTarget != null && (isHovered || isFocusChanged)) Jiggle(_jiggledTarget);
        }

        // a still mouse resting on a button would otherwise keep it picked while a gamepad moves the focus elsewhere,
        // so a focus change hands the pick to the focus until the mouse moves again
        private bool RefreshHoverActive()
        {
            Transform focused = _selectionFrame.GetFocusedTarget();
            bool isFocusChanged = focused != _lastFocused;
            if (isFocusChanged)
            {
                _lastFocused = focused;
                _isHoverActive = false;
            }

            var mouse = Mouse.current;
            if (mouse != null && mouse.delta.ReadValue() != Vector2.zero) _isHoverActive = true;
            return isFocusChanged;
        }

        private RectTransform GetJiggleTarget(out bool isHovered)
        {
            RectTransform hovered = null;
            isHovered = _isHoverJiggled && _isHoverActive && TryGetHoveredTarget(out hovered);
            if (isHovered) return hovered;
            if (_lastFocused == null || !_lastFocused.TryGetComponent(out Selectable selectable)) return null;

            return IsJigglable(selectable) ? _lastFocused as RectTransform : null;
        }

        // the input module's last raycast is what the pointer is over; hidden panels block no raycasts, so they never show up here
        private bool TryGetHoveredTarget(out RectTransform hovered)
        {
            hovered = null;
            var mouse = Mouse.current;
            if (mouse == null || Cursor.lockState == CursorLockMode.Locked) return false;
            if (EventSystem.current == null || EventSystem.current.currentInputModule is not InputSystemUIInputModule inputModule) return false;

            var hit = inputModule.GetLastRaycastResult(mouse.deviceId).gameObject;
            if (hit == null || !hit.transform.IsChildOf(_canvasRoot)) return false;

            var selectable = hit.GetComponentInParent<Selectable>();
            if (selectable == null || !IsJigglable(selectable)) return false;

            hovered = selectable.transform as RectTransform;
            return hovered != null;
        }

        // only buttons and toggles: wide sliders and text fields would swing too far at their ends
        private static bool IsJigglable(Selectable selectable) =>
            (selectable is Button || selectable is Toggle) && selectable.IsInteractable();

        // the button turns around its centre whatever pivot it has; the pivot goes back once the tilt ends
        private void Jiggle(RectTransform target)
        {
            var baseRotation = GetBaseRotation(target);
            var basePivot = GetBasePivot(target);
            if (_jiggleTweens.TryGetValue(target, out var running)) running?.Kill();

            target.localRotation = baseRotation;
            SetPivotInPlace(target, new Vector2(CentrePivot, CentrePivot));
            _jiggleTweens[target] = DOTween.Sequence()
                .Append(target.DOLocalRotateQuaternion(baseRotation * Quaternion.Euler(0f, 0f, _tiltAngle), _tiltLeftDuration).SetEase(_tiltEase))
                .Append(target.DOLocalRotateQuaternion(baseRotation * Quaternion.Euler(0f, 0f, -_tiltAngle), _tiltRightDuration).SetEase(_tiltEase))
                .Append(target.DOLocalRotateQuaternion(baseRotation, _settleDuration).SetEase(_tiltEase))
                .SetUpdate(true)
                .SetLink(target.gameObject)
                .OnKill(() => ResetTilt(target, baseRotation, basePivot));
        }

        // also runs when the tilt finishes and when the linked button is destroyed mid-tilt
        private static void ResetTilt(RectTransform target, Quaternion baseRotation, Vector2 basePivot)
        {
            if (target == null) return;

            target.localRotation = baseRotation;
            SetPivotInPlace(target, basePivot);
        }

        // moves the pivot without moving the rect, so layout groups and anchors keep placing the button where it was
        private static void SetPivotInPlace(RectTransform target, Vector2 pivot)
        {
            if (target.pivot == pivot) return;

            Vector2 shift = Vector2.Scale(pivot - target.pivot, target.rect.size);
            target.pivot = pivot;
            target.localPosition += target.localRotation * Vector3.Scale(shift, target.localScale);
        }

        private Vector2 GetBasePivot(RectTransform target)
        {
            if (_basePivots.TryGetValue(target, out var basePivot)) return basePivot;

            basePivot = target.pivot;
            _basePivots[target] = basePivot;
            return basePivot;
        }

        // read before the first jiggle, so a button with its own tilt settles back to that instead of to upright
        private Quaternion GetBaseRotation(RectTransform target)
        {
            if (_baseRotations.TryGetValue(target, out var baseRotation)) return baseRotation;

            baseRotation = target.localRotation;
            _baseRotations[target] = baseRotation;
            return baseRotation;
        }

        private void OnDisable()
        {
            foreach (var pair in _jiggleTweens) pair.Value?.Kill();
            _jiggleTweens.Clear();
            foreach (var pair in _baseRotations)
            {
                if (pair.Key != null) pair.Key.localRotation = pair.Value;
            }

            _baseRotations.Clear();
            _basePivots.Clear();
            _jiggledTarget = null;
            _lastFocused = null;
            _isHoverActive = false;
        }
    }
}
