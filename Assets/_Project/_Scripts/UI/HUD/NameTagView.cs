using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // One pooled name tag: the name, a ready mark left of it (lobby only) and a speaker icon right of it while that
    // player's voice plays. The marks are placeholders until human-made icons are swapped into their Images.
    public class NameTagView : MonoBehaviour
    {
        [SerializeField] private RectTransform _rect;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private Image _readyMark;
        [SerializeField] private Image _speakingIcon;
        [SerializeField] private Color _readyColor = new(0.3f, 0.85f, 0.4f);
        [SerializeField] private Color _notReadyColor = new(0.9f, 0.3f, 0.3f);

        public void Show(NameTag tag, Color nameColor)
        {
            // anchoring both corners to the point pins the tag there whatever the area's size
            _rect.anchorMin = tag.ViewportPosition;
            _rect.anchorMax = tag.ViewportPosition;
            _rect.anchoredPosition = Vector2.zero;
            // a pooled tag may move to another player, so only rewrite the text when it differs
            if (_nameText.text != tag.Name) _nameText.text = tag.Name;

            _nameText.color = nameColor;
            _canvasGroup.alpha = tag.Alpha;
            ShowReadiness(tag.Readiness);
            ToggleActive(_speakingIcon.gameObject, tag.IsSpeaking);
            ToggleActive(gameObject, true);
        }

        public void Hide() => ToggleActive(gameObject, false);

        private void ShowReadiness(NameTagReadiness readiness)
        {
            bool isShown = readiness != NameTagReadiness.None;
            ToggleActive(_readyMark.gameObject, isShown);
            if (isShown) _readyMark.color = readiness == NameTagReadiness.Ready ? _readyColor : _notReadyColor;
        }

        // SetActive rebuilds the layout, so it only runs on a change
        private static void ToggleActive(GameObject target, bool isActive)
        {
            if (target.activeSelf != isActive) target.SetActive(isActive);
        }
    }
}
