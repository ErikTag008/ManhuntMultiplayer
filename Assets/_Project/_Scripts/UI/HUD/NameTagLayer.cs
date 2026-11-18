using Reflex.Attributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Draws the name tags the local player's feed puts in GameHUDState over a stretched area. Labels are pooled copies
    // of an inactive template; extras are hidden.
    public class NameTagLayer : MonoBehaviour
    {
        [Inject] private readonly GameHUDState _state;
        [SerializeField] private RectTransform _area;
        [SerializeField] private TMP_Text _labelTemplate;
        [SerializeField] private Color _neutralColor = Color.white;
        [SerializeField] private Color _runnerColor = new(0.45f, 0.8f, 1f);
        [SerializeField] private Color _catcherColor = new(1f, 0.4f, 0.35f);
        [SerializeField] private Color _knockedColor = new(1f, 0.75f, 0.2f);

        private readonly List<TMP_Text> _labels = new();

        private void Start()
        {
            _state.OnNameTagsChanged += HandleNameTagsChanged;
            // tags set before this scene's UI started
            HandleNameTagsChanged();
        }

        private void HandleNameTagsChanged()
        {
            var tags = _state.NameTags;
            for (int i = 0; i < tags.Count; i++)
            {
                if (i == _labels.Count) _labels.Add(Instantiate(_labelTemplate, _area));

                ShowTag(_labels[i], tags[i]);
            }

            for (int i = tags.Count; i < _labels.Count; i++)
            {
                if (_labels[i].gameObject.activeSelf) _labels[i].gameObject.SetActive(false);
            }
        }

        private void ShowTag(TMP_Text label, NameTag tag)
        {
            var rect = label.rectTransform;
            // anchoring both corners to the point pins the label there whatever the area's size
            rect.anchorMin = tag.ViewportPosition;
            rect.anchorMax = tag.ViewportPosition;
            rect.anchoredPosition = Vector2.zero;
            // a pooled label may move to another player, so only rewrite the text when it differs
            if (label.text != tag.Name) label.text = tag.Name;

            var color = GetColor(tag.Tone);
            color.a *= tag.Alpha;
            label.color = color;
            if (!label.gameObject.activeSelf) label.gameObject.SetActive(true);
        }

        private Color GetColor(NameTagTone tone) => tone switch
        {
            NameTagTone.Runner => _runnerColor,
            NameTagTone.Catcher => _catcherColor,
            NameTagTone.Knocked => _knockedColor,
            _ => _neutralColor
        };

        private void OnDestroy() => _state.OnNameTagsChanged -= HandleNameTagsChanged;
    }
}
