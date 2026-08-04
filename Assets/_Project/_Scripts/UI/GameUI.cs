using Project.Assets._Project._Scripts.Managers;
using TMPro;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerTeamText;

        private void Start()
        {
            var uiManager = UIManager.Instance;
            uiManager.OnPlayerTeamTextChanged += HandlePlayerTeamTextChange;
            uiManager.RequestGameUIInitialization();
        }

        private void HandlePlayerTeamTextChange(string text)
        {
            _playerTeamText.text = text;
        }

        private void OnDestroy()
        {
            var uiManager = UIManager.Instance;
            uiManager.OnPlayerTeamTextChanged -= HandlePlayerTeamTextChange;
        }

    }
}
