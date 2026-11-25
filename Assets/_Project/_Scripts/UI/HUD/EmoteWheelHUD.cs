using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Draws the emote wheel while EmoteWheelState is open: one slice per emote around the centre, the aimed one highlighted,
    // and a centre label saying what letting go does.
    // Slices are pooled copies of an inactive template; extras are hidden.
    public class EmoteWheelHUD : MonoBehaviour
    {
        [Inject] private readonly EmoteWheelState _state;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private RectTransform _sliceArea;
        [SerializeField] private EmoteWheelSlice _sliceTemplate;
        [SerializeField] private float _radiusInPixels = 170f;
        [SerializeField] private TMP_Text _centreText;
        // {0} is the aimed emote's name
        [SerializeField] private string _aimedFormat = "{0}\n<size=70%>Release to play</size>";
        [SerializeField] private string _cancelLabel = "<size=70%>Aim at an emote\nRelease to cancel</size>";

        private readonly List<EmoteWheelSlice> _slices = new();

        private void Start()
        {
            _state.OnOpenChanged += HandleOpenChanged;
            _state.OnHighlightChanged += HandleHighlightChanged;
            HandleOpenChanged(_state.IsOpen);
        }

        private void HandleOpenChanged(bool isOpen)
        {
            if (!isOpen)
            {
                _panel.Hide();
                return;
            }

            BuildSlices();
            HandleHighlightChanged(_state.HighlightedIndex);
            _panel.Show();
        }

        private void BuildSlices()
        {
            var options = _state.Options;
            for (int i = 0; i < options.Count; i++)
            {
                if (i == _slices.Count) _slices.Add(Instantiate(_sliceTemplate, _sliceArea));

                var slice = _slices[i];
                slice.gameObject.SetActive(true);
                slice.Show(options[i]);
                slice.RectTransform.anchoredPosition = EmoteWheelState.SliceDirection(i, options.Count) * _radiusInPixels;
            }

            for (int i = options.Count; i < _slices.Count; i++)
            {
                _slices[i].gameObject.SetActive(false);
            }
        }

        private void HandleHighlightChanged(int index)
        {
            for (int i = 0; i < _slices.Count; i++)
            {
                _slices[i].ToggleHighlight(i == index);
            }

            var options = _state.Options;
            bool isAimed = index >= 0 && index < options.Count;
            _centreText.text = isAimed ? string.Format(_aimedFormat, options[index].Label) : _cancelLabel;
        }

        private void OnDestroy()
        {
            _state.OnOpenChanged -= HandleOpenChanged;
            _state.OnHighlightChanged -= HandleHighlightChanged;
        }
    }
}
