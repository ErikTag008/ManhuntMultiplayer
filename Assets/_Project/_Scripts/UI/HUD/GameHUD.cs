using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Gameplay HUD: runner counts for everyone, plus the local player's bleed-out bar and rescue ring
    public class GameHUD : MonoBehaviour
    {
        [Inject] private readonly GameHUDState _state;
        [SerializeField] private TMP_Text _runnerCountsText;
        [SerializeField] private string _runnerCountsFormat = "Up {0}  ·  Knocked {1}  ·  Out {2}";
        [SerializeField] private FadePanel _bleedOutPanel;
        [SerializeField] private FillMeter _bleedOutMeter;
        [SerializeField] private string _bleedOutLabelFormat = "{0:0}s";
        [SerializeField] private FadePanel _rescuePanel;
        [SerializeField] private FillMeter _rescueMeter;
        [SerializeField] private FadePanel _abilityPanel;
        [SerializeField] private TMP_Text _abilityNameText;
        // the shade drains as the cooldown runs; the label shows the seconds left, or the ability's ready hint
        [SerializeField] private FillMeter _abilityCooldownMeter;
        [SerializeField] private string _abilityCooldownLabelFormat = "{0}";

        private int _shownBleedOutSeconds = -1;
        private int _shownAbilitySeconds = -1;

        private void Start()
        {
            _state.OnRunnerCountsChanged += HandleRunnerCountsChanged;
            _state.OnBleedOutChanged += HandleBleedOutChanged;
            _state.OnRescueChanged += HandleRescueChanged;
            _state.OnAbilityChanged += HandleAbilityChanged;
            // values set before this scene's UI started
            HandleRunnerCountsChanged();
            HandleBleedOutChanged();
            HandleRescueChanged();
            HandleAbilityChanged();
        }

        private void HandleRunnerCountsChanged() =>
            _runnerCountsText.text = string.Format(_runnerCountsFormat, _state.RunnersUp, _state.RunnersKnocked, _state.RunnersOut);

        private void HandleBleedOutChanged()
        {
            TogglePanel(_bleedOutPanel, _state.IsBleedOutShown);
            if (!_state.IsBleedOutShown) return;

            _bleedOutMeter.SetValue(_state.BleedOutProgress);
            // the remaining time changes every frame; the label only needs a new string each whole second
            int seconds = Mathf.CeilToInt(_state.BleedOutRemainingInSeconds);
            if (seconds == _shownBleedOutSeconds) return;

            _shownBleedOutSeconds = seconds;
            _bleedOutMeter.SetLabel(string.Format(_bleedOutLabelFormat, seconds));
        }

        private void HandleRescueChanged()
        {
            TogglePanel(_rescuePanel, _state.IsRescueShown);
            if (_state.IsRescueShown) _rescueMeter.SetValue(_state.RescueProgress);
        }

        private void HandleAbilityChanged()
        {
            TogglePanel(_abilityPanel, _state.IsAbilityShown);
            if (!_state.IsAbilityShown) return;

            _abilityCooldownMeter.SetValue(_state.AbilityCooldownProgress);
            // the remaining time changes every frame; the labels only need new strings when they actually change
            bool isNewAbility = _abilityNameText.text != _state.AbilityName;
            if (isNewAbility) _abilityNameText.text = _state.AbilityName;

            int seconds = Mathf.CeilToInt(_state.AbilityCooldownRemainingInSeconds);
            if (seconds == _shownAbilitySeconds && !isNewAbility) return;

            _shownAbilitySeconds = seconds;
            _abilityCooldownMeter.SetLabel(seconds > 0 ? string.Format(_abilityCooldownLabelFormat, seconds) : _state.AbilityReadyHint);
        }

        private static void TogglePanel(FadePanel panel, bool isShown)
        {
            if (panel.IsShown == isShown) return;

            if (isShown) panel.Show();
            else panel.Hide();
        }

        private void OnDestroy()
        {
            _state.OnRunnerCountsChanged -= HandleRunnerCountsChanged;
            _state.OnBleedOutChanged -= HandleBleedOutChanged;
            _state.OnRescueChanged -= HandleRescueChanged;
            _state.OnAbilityChanged -= HandleAbilityChanged;
        }
    }
}
