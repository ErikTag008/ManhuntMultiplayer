using DG.Tweening;
using KBCore.Refs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Scrolls a vertical ScrollRect so the focused selectable inside its content stays in view, for keyboard and gamepad navigation.
    // Expects the content anchored and pivoted at the top, as Unity's default scroll view sets it up.
    [RequireComponent(typeof(ScrollRect))]
    public class ScrollToSelected : ValidatedMonoBehaviour
    {
        [SerializeField, Self] private ScrollRect _scrollRect;
        // keeps a little of the next row visible past the focused one
        [SerializeField] private float _edgePadding = 12f;
        [SerializeField] private float _scrollDuration = 0.15f;
        [SerializeField] private Ease _scrollEase = Ease.OutCubic;

        private readonly Vector3[] _corners = new Vector3[4];
        private GameObject _lastSelected;
        private Tween _scrollTween;

        private void LateUpdate()
        {
            var eventSystem = EventSystem.current;
            var selected = eventSystem != null ? eventSystem.currentSelectedGameObject : null;
            if (selected == _lastSelected) return;

            _lastSelected = selected;
            if (selected == null || !selected.transform.IsChildOf(_scrollRect.content)) return;
            if (IsUnderMouse(eventSystem, selected)) return;

            ScrollIntoView((RectTransform)selected.transform);
        }

        // focus follows a moving mouse, and a row the mouse points at is already in view; scrolling it would slide the list under the cursor.
        // A resting mouse means the keyboard or gamepad picked the row, so it still scrolls fully into view.
        private static bool IsUnderMouse(EventSystem eventSystem, GameObject selected)
        {
            var mouse = Mouse.current;
            if (mouse == null || Cursor.lockState == CursorLockMode.Locked || mouse.delta.ReadValue() == Vector2.zero) return false;
            if (eventSystem.currentInputModule is not InputSystemUIInputModule inputModule) return false;

            var hit = inputModule.GetLastRaycastResult(mouse.deviceId).gameObject;
            return hit != null && hit.transform.IsChildOf(selected.transform);
        }

        private void ScrollIntoView(RectTransform target)
        {
            var viewport = _scrollRect.viewport;
            GetVerticalBounds(target, viewport, out float targetBottom, out float targetTop);
            var viewportRect = viewport.rect;
            float bottomLimit = viewportRect.yMin + _edgePadding;
            float topLimit = viewportRect.yMax - _edgePadding;

            float offset = 0f;
            if (targetTop > topLimit) offset = targetTop - topLimit;
            else if (targetBottom < bottomLimit) offset = targetBottom - bottomLimit;
            if (Mathf.Approximately(offset, 0f)) return;

            var content = _scrollRect.content;
            float maxScroll = Mathf.Max(0f, content.rect.height - viewportRect.height);
            float targetY = Mathf.Clamp(content.anchoredPosition.y - offset, 0f, maxScroll);

            _scrollRect.StopMovement();
            _scrollTween?.Kill();
            _scrollTween = DOTween.To(() => content.anchoredPosition.y, SetContentY, targetY, _scrollDuration)
                .SetEase(_scrollEase)
                .SetUpdate(true)
                .SetLink(gameObject);
        }

        private void SetContentY(float y)
        {
            var content = _scrollRect.content;
            content.anchoredPosition = new Vector2(content.anchoredPosition.x, y);
        }

        private void GetVerticalBounds(RectTransform target, RectTransform space, out float bottom, out float top)
        {
            target.GetWorldCorners(_corners);
            bottom = float.MaxValue;
            top = float.MinValue;
            foreach (var corner in _corners)
            {
                float y = space.InverseTransformPoint(corner).y;
                bottom = Mathf.Min(bottom, y);
                top = Mathf.Max(top, y);
            }
        }

        private void OnDisable()
        {
            _scrollTween?.Kill();
            _lastSelected = null;
        }
    }
}
