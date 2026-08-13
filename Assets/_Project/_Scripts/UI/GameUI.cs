using Project.Assets._Project._Scripts.Managers;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerTeamText;
        [Inject] private readonly IUIManager _uiManager;

        private void Start()
        {
            var uiManager = _uiManager;
            uiManager.OnPlayerTeamTextChanged += HandlePlayerTeamTextChange;
            uiManager.RequestGameUIInitialization();
        }

        private void HandlePlayerTeamTextChange(string text)
        {
            _playerTeamText.text = text;
        }

        private void OnDestroy()
        {
            var uiManager = _uiManager;
            uiManager.OnPlayerTeamTextChanged -= HandlePlayerTeamTextChange;
        }

    }
}
