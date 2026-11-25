using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // End-of-round screen in the gameplay scene; the round flow decides when it shows and what it says
    public class ResultsHUD : MonoBehaviour
    {
        [Inject] private readonly IUIManager _uiManager;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _subtitleText;
        [SerializeField] private TMP_Text _highlightsText;
        [SerializeField] private TMP_Text _pointsText;
        [SerializeField] private TMP_Text _backToLobbyText;
        // {0} is the whole seconds left
        [SerializeField] private string _backToLobbyFormat = "Back to lobby in {0}";

        private void Start()
        {
            _uiManager.OnResultsShown += HandleResultsShown;
            _uiManager.OnRoundHighlightsShown += HandleRoundHighlightsShown;
            _uiManager.OnRoundPointsShown += HandleRoundPointsShown;
            _uiManager.OnResultsSecondsLeftChanged += HandleResultsSecondsLeftChanged;
            // hidden until the round flow says what this player earned and when the screen ends
            HandleRoundPointsShown(string.Empty);
            HandleResultsSecondsLeftChanged(IUIManager.NoResultsCountdown);
        }

        private void HandleResultsShown(string title, string subtitle)
        {
            _titleText.text = title;
            _subtitleText.text = subtitle;
            _panel.Show();
        }

        private void HandleRoundHighlightsShown(string highlights)
        {
            _highlightsText.text = highlights;
            _highlightsText.gameObject.SetActive(!string.IsNullOrEmpty(highlights));
        }

        private void HandleRoundPointsShown(string points)
        {
            _pointsText.text = points;
            _pointsText.gameObject.SetActive(!string.IsNullOrEmpty(points));
        }

        private void HandleResultsSecondsLeftChanged(int seconds)
        {
            bool isCounting = seconds != IUIManager.NoResultsCountdown;
            _backToLobbyText.gameObject.SetActive(isCounting);
            if (isCounting) _backToLobbyText.text = string.Format(_backToLobbyFormat, seconds);
        }

        private void OnDestroy()
        {
            _uiManager.OnResultsShown -= HandleResultsShown;
            _uiManager.OnRoundHighlightsShown -= HandleRoundHighlightsShown;
            _uiManager.OnRoundPointsShown -= HandleRoundPointsShown;
            _uiManager.OnResultsSecondsLeftChanged -= HandleResultsSecondsLeftChanged;
        }
    }
}
