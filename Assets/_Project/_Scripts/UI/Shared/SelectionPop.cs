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
    // The growth is centred whatever pivot the button has, and stays inside the nearest clipping viewport or panel backdrop (or the canvas):
    // a button by an edge grows away from it, and one with no room to spare grows only as far as fits.
    [RequireComponent(typeof(SelectionFrame))]
    public class SelectionPop : ValidatedMonoBehaviour
    {
        private const float CentrePivot = 0.5f;

        [SerializeField, Self] private SelectionFrame _selectionFrame;
        [SerializeField] private float _popScale = 1.08f;
        [SerializeField] private float _popInDuration = 0.15f;
        [SerializeField] private float _popOutDuration = 0.1f;
        [SerializeField] private Ease _popInEase = Ease.OutBack;
        [SerializeField] private Ease _popOutEase = Ease.OutCubic;
        // gap kept between a grown button and the edge of its panel, viewport or screen
        [SerializeField] private float _boundsPadding = 4f;
        // the mouse pops what it points at, even while the keyboard or gamepad focus sits somewhere else
        [SerializeField] private bool _isHoverPopped = true;

        private readonly Dictionary<RectTransform, Vector3> _baseScales = new();
        private readonly Dictionary<RectTransform, Vector2> _basePivots = new();
        private readonly Dictionary<RectTransform, Tween> _scaleTweens = new();
        private readonly Vector3[] _corners = new Vector3[4];
        private RectTransform _canvasRoot;
        private RectTransform _poppedTarget;
        private float _poppedScale;
        private Transform _lastFocused;
        private bool _isHoverActive;

        private void Awake() => _canvasRoot = (RectTransform)GetComponentInParent<Canvas>().rootCanvas.transform;

        private void LateUpdate()
        {
            RefreshHoverActive();
            var target = GetPopTarget();
            if (target != _poppedTarget)
            {
                if (_poppedTarget != null) PopOut(_poppedTarget);
                _poppedTarget = target;
                _poppedScale = 0f;
            }

            if (_poppedTarget != null) KeepPopFitting(_poppedTarget);
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

        private RectTransform GetPopTarget()
        {
            if (_isHoverPopped && _isHoverActive && TryGetHoveredTarget(out var hovered)) return hovered;
            if (_lastFocused == null || !_lastFocused.TryGetComponent(out Selectable selectable)) return null;

            return IsPoppable(selectable) ? _lastFocused as RectTransform : null;
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
            if (selectable == null || !IsPoppable(selectable)) return false;

            hovered = selectable.transform as RectTransform;
            return hovered != null;
        }

        // only buttons and toggles: wide sliders and text fields would grow too far past their rows
        private static bool IsPoppable(Selectable selectable) =>
            (selectable is Button || selectable is Toggle) && selectable.IsInteractable();

        // refitted every frame: a button spawned or moved this frame only gets its real layout rect later,
        // and the pivot and pop must follow that rect, not the one it had on the frame it was picked
        private void KeepPopFitting(RectTransform target)
        {
            var baseScale = GetBaseScale(target);
            RememberBasePivot(target);
            float popScale = GetFittingPop(target, baseScale, out Vector2 growPivot);
            SetPivotInPlace(target, growPivot, baseScale);
            if (Mathf.Approximately(popScale, _poppedScale)) return;

            _poppedScale = popScale;
            KillScaleTween(target);
            _scaleTweens[target] = target.DOScale(baseScale * popScale, _popInDuration)
                .SetEase(_popInEase)
                .SetUpdate(true)
                .SetLink(target.gameObject);
        }

        private void PopOut(RectTransform target)
        {
            var baseScale = GetBaseScale(target);
            var basePivot = RememberBasePivot(target);
            KillScaleTween(target);
            _scaleTweens[target] = target.DOScale(baseScale, _popOutDuration)
                .SetEase(_popOutEase)
                .SetUpdate(true)
                .SetLink(target.gameObject)
                .OnComplete(() => SetPivotInPlace(target, basePivot, baseScale));
        }

        private void KillScaleTween(RectTransform target)
        {
            if (_scaleTweens.TryGetValue(target, out var running)) running?.Kill();
        }

        // the largest pop up to _popScale that fits the bounds, and the pivot that keeps the grown rect inside them
        private float GetFittingPop(RectTransform target, Vector3 baseScale, out Vector2 growPivot)
        {
            growPivot = new Vector2(CentrePivot, CentrePivot);
            if (target.parent is not RectTransform parent) return _popScale;

            // the base-scale rect in parent space; the pivot point stays put whatever the current scale
            Vector2 pivotPosition = target.localPosition;
            Vector2 rectMin = pivotPosition + Vector2.Scale(target.rect.min, baseScale);
            Vector2 rectMax = pivotPosition + Vector2.Scale(target.rect.max, baseScale);
            Vector2 size = rectMax - rectMin;

            GetBoundsRect(target).GetWorldCorners(_corners);
            Vector2 boundsMin = (Vector2)parent.InverseTransformPoint(_corners[0]) + Vector2.one * _boundsPadding;
            Vector2 boundsMax = (Vector2)parent.InverseTransformPoint(_corners[2]) - Vector2.one * _boundsPadding;
            Vector2 roomMin = Vector2.Max(rectMin - boundsMin, Vector2.zero);
            Vector2 roomMax = Vector2.Max(boundsMax - rectMax, Vector2.zero);

            float popScale = Mathf.Min(_popScale, GetMaxPop(_popScale, size.x, roomMin.x, roomMax.x), GetMaxPop(_popScale, size.y, roomMin.y, roomMax.y));
            popScale = Mathf.Max(popScale, 1f);
            growPivot.x = GetGrowPivot((popScale - 1f) * size.x, roomMin.x, roomMax.x);
            growPivot.y = GetGrowPivot((popScale - 1f) * size.y, roomMin.y, roomMax.y);
            return popScale;
        }

        private static float GetMaxPop(float popScale, float size, float roomMin, float roomMax) =>
            size > 0f ? 1f + (roomMin + roomMax) / size : popScale;

        // the share of the growth that goes toward the min side: half when both sides have room, else pushed off the tight edge
        private static float GetGrowPivot(float growth, float roomMin, float roomMax)
        {
            if (growth <= 0f) return CentrePivot;

            float lowest = 1f - roomMax / growth;
            float highest = roomMin / growth;
            if (lowest > highest) return roomMin / (roomMin + roomMax);

            return Mathf.Clamp(CentrePivot, lowest, highest);
        }

        // the nearest edge the button would visibly cross: a scroll viewport that clips it, or the panel backdrop it sits on;
        // with neither it only has to stay on screen
        private RectTransform GetBoundsRect(RectTransform target)
        {
            for (var parent = target.parent; parent != null && parent != _canvasRoot; parent = parent.parent)
            {
                if (parent.TryGetComponent(out RectMask2D rectMask) && rectMask.enabled) return (RectTransform)parent;
                if (parent.TryGetComponent(out Mask mask) && mask.enabled) return (RectTransform)parent;
                if (parent.TryGetComponent(out Image backdrop) && backdrop.enabled && backdrop.color.a > 0f) return (RectTransform)parent;
            }

            return _canvasRoot;
        }

        // moves the pivot without moving the base-scale rect, so layout groups and anchors keep placing the button where it was;
        // measured at the base scale even mid-pop, so pivot changes while grown add up to no drift once it shrinks back
        private static void SetPivotInPlace(RectTransform target, Vector2 pivot, Vector3 baseScale)
        {
            if (target == null || target.pivot == pivot) return;

            Vector2 shift = Vector2.Scale(pivot - target.pivot, target.rect.size);
            target.pivot = pivot;
            target.localPosition += target.localRotation * Vector3.Scale(shift, baseScale);
        }

        // read before the first pop, so a button with its own scale returns to that instead of to one
        private Vector3 GetBaseScale(RectTransform target)
        {
            if (_baseScales.TryGetValue(target, out var baseScale)) return baseScale;

            baseScale = target.localScale;
            _baseScales[target] = baseScale;
            return baseScale;
        }

        // read before the first pop, so the button goes back to its own pivot once it has shrunk again
        private Vector2 RememberBasePivot(RectTransform target)
        {
            if (_basePivots.TryGetValue(target, out var basePivot)) return basePivot;

            basePivot = target.pivot;
            _basePivots[target] = basePivot;
            return basePivot;
        }

        private void OnDisable()
        {
            foreach (var pair in _scaleTweens) pair.Value?.Kill();
            _scaleTweens.Clear();
            foreach (var pair in _baseScales)
            {
                if (pair.Key != null) pair.Key.localScale = pair.Value;
            }

            foreach (var pair in _basePivots) SetPivotInPlace(pair.Key, pair.Value, GetBaseScale(pair.Key));
            _basePivots.Clear();
            _baseScales.Clear();
            _poppedTarget = null;
            _poppedScale = 0f;
            _lastFocused = null;
            _isHoverActive = false;
        }
    }
}
