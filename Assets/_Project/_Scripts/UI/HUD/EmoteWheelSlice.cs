using KBCore.Refs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // One emote on the wheel: a background, an optional icon and the name. The aimed slice grows and changes colour.
    public class EmoteWheelSlice : ValidatedMonoBehaviour
    {
        [SerializeField, Self] private RectTransform _rectTransform;
        [SerializeField] private Image _background;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Color _normalColor = new(0f, 0f, 0f, 0.6f);
        [SerializeField] private Color _highlightColor = new(1f, 0.8f, 0.25f, 0.9f);
        [SerializeField] private float _highlightScale = 1.15f;

        public RectTransform RectTransform => _rectTransform;

        public void Show(EmoteWheelOption option)
        {
            _label.text = option.Label;
            _icon.sprite = option.Icon;
            _icon.gameObject.SetActive(option.Icon != null);
            ToggleHighlight(false);
        }

        public void ToggleHighlight(bool isHighlighted)
        {
            _background.color = isHighlighted ? _highlightColor : _normalColor;
            _rectTransform.localScale = Vector3.one * (isHighlighted ? _highlightScale : 1f);
        }
    }
}
