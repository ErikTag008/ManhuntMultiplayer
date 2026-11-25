using TMPro;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // One line of the hold scoreboard: name, team, state, catches and rescues; the local player's name is tinted
    public class ScoreboardRow : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _teamText;
        [SerializeField] private TMP_Text _statusText;
        [SerializeField] private TMP_Text _catchesText;
        [SerializeField] private TMP_Text _rescuesText;
        [SerializeField] private Color _nameColor = Color.white;
        [SerializeField] private Color _localNameColor = Color.yellow;

        public void Show(string playerName, string team, string status, int catches, int rescues, bool isLocal)
        {
            _nameText.text = playerName;
            _nameText.color = isLocal ? _localNameColor : _nameColor;
            _teamText.text = team;
            _statusText.text = status;
            _catchesText.SetText("{0}", catches);
            _rescuesText.SetText("{0}", rescues);
        }
    }
}
