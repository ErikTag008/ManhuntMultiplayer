using DG.Tweening;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Helps runners rescue each other: a hold hint naming the knocked teammate in reach, markers with the bleed-out seconds
    // over knocked teammates, and a short line when a teammate gets knocked. The rescue progress itself shows on GameHUD's ring.
    public class RescueHUD : MonoBehaviour
    {
        [Inject] private readonly GameHUDState _state;
        [SerializeField] private FadePanel _hintPanel;
        [SerializeField] private KeyHintText _hintText;
        // {0} is the Interact key, {1} the teammate's name
        [SerializeField] private string _hintFormat = "Hold {0} to revive {1}";
        [SerializeField] private RevealMarkerLayer _markers;
        [SerializeField] private string _markerLabelFormat = "{0}";
        [SerializeField] private FadePanel _knockedPanel;
        [SerializeField] private TMP_Text _knockedText;
        [SerializeField] private string _knockedFormat = "{0} was knocked";
        [SerializeField, Min(0f)] private float _knockedShownDurationInSeconds = 3f;

        // the seconds each marker's label shows, so labels are only rewritten when they change
        private readonly List<int> _shownMarkerSeconds = new();
        private Tween _knockedHideTween;

        private void Start()
        {
            _state.OnRescueHintChanged += HandleRescueHintChanged;
            _state.OnKnockedMarkersChanged += HandleKnockedMarkersChanged;
            _state.OnTeammateKnocked += HandleTeammateKnocked;
            // values set before this scene's UI started
            HandleRescueHintChanged();
            HandleKnockedMarkersChanged();
        }

        private void HandleRescueHintChanged()
        {
            bool isShown = _state.IsRescueHintShown;
            if (isShown) _hintText.ChangeFormat(_hintFormat.Replace("{1}", EscapeFormat(_state.RescueHintName)));
            TogglePanel(_hintPanel, isShown);
        }

        private void HandleKnockedMarkersChanged()
        {
            _markers.ShowMarkers(_state.KnockedMarkerPositions);
            var seconds = _state.KnockedMarkerSeconds;
            for (int i = 0; i < seconds.Count; i++)
            {
                if (i == _shownMarkerSeconds.Count) _shownMarkerSeconds.Add(-1);
                if (_shownMarkerSeconds[i] == seconds[i]) continue;

                _shownMarkerSeconds[i] = seconds[i];
                _markers.SetLabel(i, seconds[i] > 0 ? string.Format(_markerLabelFormat, seconds[i]) : string.Empty);
            }
        }

        private void HandleTeammateKnocked(string teammateName)
        {
            _knockedText.text = string.Format(_knockedFormat, teammateName);
            _knockedPanel.Show();
            _knockedHideTween?.Kill();
            _knockedHideTween = DOVirtual.DelayedCall(_knockedShownDurationInSeconds, _knockedPanel.Hide);
        }

        // a name with braces would otherwise break the key hint's format
        private static string EscapeFormat(string text) => string.IsNullOrEmpty(text) ? string.Empty : text.Replace("{", "{{").Replace("}", "}}");

        private static void TogglePanel(FadePanel panel, bool isShown)
        {
            if (panel.IsShown == isShown) return;

            if (isShown) panel.Show();
            else panel.Hide();
        }

        private void OnDestroy()
        {
            _state.OnRescueHintChanged -= HandleRescueHintChanged;
            _state.OnKnockedMarkersChanged -= HandleKnockedMarkersChanged;
            _state.OnTeammateKnocked -= HandleTeammateKnocked;
            _knockedHideTween?.Kill();
        }
    }
}
