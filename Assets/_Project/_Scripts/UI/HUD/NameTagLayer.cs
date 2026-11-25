using Reflex.Attributes;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Draws the name tags the local player's feed puts in GameHUDState over a stretched area. Tags are pooled copies
    // of an inactive template; extras are hidden.
    public class NameTagLayer : MonoBehaviour
    {
        [Inject] private readonly GameHUDState _state;
        [SerializeField] private RectTransform _area;
        [SerializeField] private NameTagView _tagTemplate;
        [SerializeField] private Color _neutralColor = Color.white;
        [SerializeField] private Color _runnerColor = new(0.45f, 0.8f, 1f);
        [SerializeField] private Color _catcherColor = new(1f, 0.4f, 0.35f);
        [SerializeField] private Color _knockedColor = new(1f, 0.75f, 0.2f);

        private readonly List<NameTagView> _views = new();

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
                if (i == _views.Count) _views.Add(Instantiate(_tagTemplate, _area));

                _views[i].Show(tags[i], GetColor(tags[i].Tone));
            }

            for (int i = tags.Count; i < _views.Count; i++) _views[i].Hide();
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
