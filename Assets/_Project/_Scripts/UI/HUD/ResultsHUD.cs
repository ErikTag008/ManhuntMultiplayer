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

        private void Start()
        {
            _uiManager.OnResultsShown += HandleResultsShown;
            _uiManager.OnRoundHighlightsShown += HandleRoundHighlightsShown;
            _uiManager.OnRoundPointsShown += HandleRoundPointsShown;
            // hidden until the round flow says what this player earned
            HandleRoundPointsShown(string.Empty);
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

        private void OnDestroy()
        {
            _uiManager.OnResultsShown -= HandleResultsShown;
            _uiManager.OnRoundHighlightsShown -= HandleRoundHighlightsShown;
            _uiManager.OnRoundPointsShown -= HandleRoundPointsShown;
        }
    }
}
