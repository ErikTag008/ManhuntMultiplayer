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

        private void Start()
        {
            _uiManager.OnResultsShown += HandleResultsShown;
        }

        private void HandleResultsShown(string title, string subtitle)
        {
            _titleText.text = title;
            _subtitleText.text = subtitle;
            _panel.Show();
        }

        private void OnDestroy()
        {
            _uiManager.OnResultsShown -= HandleResultsShown;
        }
    }
}
