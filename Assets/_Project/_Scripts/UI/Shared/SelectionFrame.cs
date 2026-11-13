using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Outline around the focused selectable of this frame's canvas, so keyboard and gamepad players see where they are.
    // Keep it the canvas's last child so it draws on top; it fades with the panels the focused selectable sits in.
    [RequireComponent(typeof(CanvasGroup))]
    public class SelectionFrame : MonoBehaviour
    {
        [SerializeField] private RectTransform _frame;
        [SerializeField] private CanvasGroup _canvasGroup;
        // space between the selectable's edge and the outline
        [SerializeField] private float _padding = 6f;

        private readonly Vector3[] _corners = new Vector3[4];
        private readonly List<CanvasGroup> _parentGroups = new();
        private Transform _canvasRoot;
        private RectTransform _frameParent;

        private void Reset()
        {
            _frame = transform as RectTransform;
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Awake()
        {
            _canvasRoot = GetComponentInParent<Canvas>().rootCanvas.transform;
            _frameParent = _frame.parent as RectTransform;
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        private void LateUpdate()
        {
            var target = GetFocusedTarget();
            if (target == null)
            {
                ChangeAlpha(0f);
                return;
            }

            FollowTarget(target);
            ChangeAlpha(GetVisibleAlpha(target));
        }

        // unchanged values aren't written, so a still frame doesn't make the canvas rebuild every frame
        private void ChangeAlpha(float alpha)
        {
            if (!Mathf.Approximately(_canvasGroup.alpha, alpha)) _canvasGroup.alpha = alpha;
        }

        // a hidden panel's CanvasGroup turns its selectables non-interactable, so a focus left behind there shows nothing
        private RectTransform GetFocusedTarget()
        {
            var eventSystem = EventSystem.current;
            var selected = eventSystem != null ? eventSystem.currentSelectedGameObject : null;
            if (selected == null || !selected.activeInHierarchy || !selected.transform.IsChildOf(_canvasRoot)) return null;
            if (selected.TryGetComponent(out Selectable selectable) && !selectable.IsInteractable()) return null;

            return selected.transform as RectTransform;
        }

        // the frame's anchors and pivot sit at its parent's centre, so the corners map straight to a position and size
        private void FollowTarget(RectTransform target)
        {
            target.GetWorldCorners(_corners);
            Vector2 bottomLeft = _frameParent.InverseTransformPoint(_corners[0]);
            Vector2 topRight = _frameParent.InverseTransformPoint(_corners[2]);
            Vector3 position = (bottomLeft + topRight) * 0.5f;
            var size = topRight - bottomLeft + Vector2.one * (_padding * 2f);
            if (_frame.localPosition != position) _frame.localPosition = position;
            if (_frame.sizeDelta != size) _frame.sizeDelta = size;
        }

        // matches the fade of the panels around the target, so the outline doesn't pop in before its panel
        private float GetVisibleAlpha(RectTransform target)
        {
            target.GetComponentsInParent(false, _parentGroups);
            float alpha = 1f;
            foreach (var group in _parentGroups)
            {
                alpha *= group.alpha;
                if (group.ignoreParentGroups) break;
            }

            return alpha;
        }
    }
}
