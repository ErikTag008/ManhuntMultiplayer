using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Hold-key overlay listing every player; rows are kept and reused, so holding the key doesn't instantiate each refresh
    public class ScoreboardHUD : MonoBehaviour
    {
        [Inject] private readonly GameHUDState _state;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private Transform _rowContainer;
        [SerializeField] private ScoreboardRow _rowPrefab;
        [SerializeField] private string _catcherTeamText = "Catcher";
        [SerializeField] private string _runnerTeamText = "Runner";
        [SerializeField] private string _noTeamText = "-";
        [SerializeField] private string _upText = "Up";
        [SerializeField] private string _knockedText = "Knocked";
        [SerializeField] private string _outText = "Out";
        [SerializeField] private string _ghostText = "Ghost";
        [SerializeField] private string _spectatingText = "Spectating";

        private readonly List<ScoreboardRow> _rows = new();

        private void Start()
        {
            _state.OnScoreboardChanged += HandleScoreboardChanged;
            HandleScoreboardChanged();
        }

        private void HandleScoreboardChanged()
        {
            if (_state.IsScoreboardShown) ShowRows(_state.ScoreboardEntries);
            if (_state.IsScoreboardShown == _panel.IsShown) return;

            if (_state.IsScoreboardShown) _panel.Show();
            else _panel.Hide();
        }

        private void ShowRows(IReadOnlyList<ScoreboardEntry> entries)
        {
            while (_rows.Count < entries.Count) _rows.Add(Instantiate(_rowPrefab, _rowContainer));

            for (int i = 0; i < _rows.Count; i++)
            {
                bool isUsed = i < entries.Count;
                if (_rows[i].gameObject.activeSelf != isUsed) _rows[i].gameObject.SetActive(isUsed);
                if (!isUsed) continue;

                var entry = entries[i];
                _rows[i].Show(entry.Name, GetTeamText(entry.Team), GetStatusText(entry.Status), entry.Catches, entry.Rescues, entry.IsLocal);
            }
        }

        private string GetTeamText(ScoreboardTeam team) => team switch
        {
            ScoreboardTeam.Catcher => _catcherTeamText,
            ScoreboardTeam.Runner => _runnerTeamText,
            _ => _noTeamText
        };

        private string GetStatusText(ScoreboardStatus status) => status switch
        {
            ScoreboardStatus.Knocked => _knockedText,
            ScoreboardStatus.Out => _outText,
            ScoreboardStatus.Ghost => _ghostText,
            ScoreboardStatus.Spectating => _spectatingText,
            _ => _upText
        };

        private void OnDestroy() => _state.OnScoreboardChanged -= HandleScoreboardChanged;
    }
}
