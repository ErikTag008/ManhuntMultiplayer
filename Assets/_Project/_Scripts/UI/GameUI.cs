using Project.Assets._Project._Scripts.Managers;
using Reflex.Attributes;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerTeamText;
        [SerializeField] private TMP_Text _hideTimeCountdownText;
        Button button;
        [Inject] private readonly IUIManager _uiManager;

        private void Start()
        {
            _uiManager.OnPlayerTeamTextChanged += HandlePlayerTeamTextChange;
            _uiManager.OnCountdownTextChanged += HandleCountdownChange;
            _uiManager.RequestGameUIInitialization();
        }


        private void HandleUITextChange(TMP_Text uiText, string text)
        {
            if (uiText.text == text) return;
            uiText.text = text;
        }

        private void HandleCountdownChange(string text) => HandleUITextChange(_hideTimeCountdownText, text);

        private void HandlePlayerTeamTextChange(string text) => HandleUITextChange(_playerTeamText, text);
        

        private void OnDestroy()
        {
            _uiManager.OnPlayerTeamTextChanged -= HandlePlayerTeamTextChange;
            _uiManager.OnCountdownTextChanged -= HandleCountdownChange;
        }

    }
}
