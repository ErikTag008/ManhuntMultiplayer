using DG.Tweening;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Objective stations on the gameplay HUD: the done/total count and a short message when one completes, for everyone;
    // markers over unfinished stations; and the local runner's hold hint when one is in reach.
    // The hold progress itself shows on GameHUD's rescue ring.
    public class StationHUD : MonoBehaviour
    {
        [Inject] private readonly GameHUDState _state;
        [SerializeField] private FadePanel _countPanel;
        [SerializeField] private TMP_Text _countText;
        [SerializeField] private string _countFormat = "Stations {0}/{1}";
        [SerializeField] private FadePanel _completedPanel;
        [SerializeField] private TMP_Text _completedText;
        // {0} is the whole seconds taken off the round
        [SerializeField] private string _completedFormat = "Station done  -{0}";
        // when the round was already at its minimum and nothing was taken off
        [SerializeField] private string _completedWithoutCutText = "Station done";
        [SerializeField, Min(0f)] private float _completedShownDurationInSeconds = 2.5f;
        // holds a KeyHintText, so the key follows the live binding
        [SerializeField] private FadePanel _hintPanel;
        [SerializeField] private RevealMarkerLayer _markers;

        private Tween _completedHideTween;

        private void Start()
        {
            _state.OnStationCountsChanged += HandleStationCountsChanged;
            _state.OnStationHintChanged += HandleStationHintChanged;
            _state.OnStationMarkersChanged += HandleStationMarkersChanged;
            _state.OnStationCompleted += HandleStationCompleted;
            // values set before this scene's UI started
            HandleStationCountsChanged();
            HandleStationHintChanged();
            HandleStationMarkersChanged();
        }

        private void HandleStationCountsChanged()
        {
            TogglePanel(_countPanel, _state.IsStationCountShown);
            if (_state.IsStationCountShown) _countText.text = string.Format(_countFormat, _state.StationsCompleted, _state.StationsTotal);
        }

        private void HandleStationHintChanged() => TogglePanel(_hintPanel, _state.IsStationHintShown);

        private void HandleStationMarkersChanged() => _markers.ShowMarkers(_state.StationMarkerPositions);

        private void HandleStationCompleted(float appliedCutInSeconds)
        {
            int seconds = Mathf.RoundToInt(appliedCutInSeconds);
            _completedText.text = seconds > 0 ? string.Format(_completedFormat, seconds) : _completedWithoutCutText;
            _completedPanel.Show();

            _completedHideTween?.Kill();
            _completedHideTween = DOVirtual.DelayedCall(_completedShownDurationInSeconds, _completedPanel.Hide);
        }

        private static void TogglePanel(FadePanel panel, bool isShown)
        {
            if (panel.IsShown == isShown) return;

            if (isShown) panel.Show();
            else panel.Hide();
        }

        private void OnDestroy()
        {
            _state.OnStationCountsChanged -= HandleStationCountsChanged;
            _state.OnStationHintChanged -= HandleStationHintChanged;
            _state.OnStationMarkersChanged -= HandleStationMarkersChanged;
            _state.OnStationCompleted -= HandleStationCompleted;
            _completedHideTween?.Kill();
        }
    }
}
