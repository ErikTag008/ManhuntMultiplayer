using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Gameplay HUD: runner counts for everyone, plus the local player's bleed-out bar, rescue ring, ability, drop effect
    // and, for catchers, markers over revealed runners
    public class GameHUD : MonoBehaviour
    {
        [Inject] private readonly GameHUDState _state;
        [Inject] private readonly KeybindService _keybinds;
        [Inject] private readonly GameSettingsService _settings;
        [Inject] private readonly ControlSchemeState _controlScheme;
        [SerializeField] private TMP_Text _runnerCountsText;
        [SerializeField] private string _runnerCountsFormat = "Up {0}  ·  Knocked {1}  ·  Out {2}";
        [SerializeField] private FadePanel _bleedOutPanel;
        [SerializeField] private FillMeter _bleedOutMeter;
        [SerializeField] private string _bleedOutLabelFormat = "{0:0}";
        [SerializeField] private FadePanel _rescuePanel;
        [SerializeField] private FillMeter _rescueMeter;
        [SerializeField] private FadePanel _abilityPanel;
        [SerializeField] private TMP_Text _abilityNameText;
        // the shade drains as the cooldown runs; the label shows the seconds left, or the ability's ready hint
        [SerializeField] private FillMeter _abilityCooldownMeter;
        [SerializeField] private string _abilityCooldownLabelFormat = "{0}";
        // fills the ready hint's {0}, so the slot names the key as currently bound on the device in use
        [SerializeField] private InputActionReference _abilityAction;
        [SerializeField] private FadePanel _dropPanel;
        [SerializeField] private TMP_Text _dropNameText;
        [SerializeField] private FillMeter _dropMeter;
        [SerializeField] private string _dropLabelFormat = "{0:0}";
        [SerializeField] private Color _goodDropColor = Color.green;
        [SerializeField] private Color _badDropColor = Color.red;
        [SerializeField] private RevealMarkerLayer _revealMarkers;

        private int _shownBleedOutSeconds = -1;
        private int _shownAbilitySeconds = -1;
        private int _shownDropSeconds = -1;

        private void Start()
        {
            _state.OnRunnerCountsChanged += HandleRunnerCountsChanged;
            _state.OnBleedOutChanged += HandleBleedOutChanged;
            _state.OnRescueChanged += HandleRescueChanged;
            _state.OnAbilityChanged += HandleAbilityChanged;
            _state.OnDropEffectChanged += HandleDropEffectChanged;
            _state.OnRevealMarkersChanged += HandleRevealMarkersChanged;
            _settings.OnChanged += HandleSettingsChanged;
            _controlScheme.OnChanged += HandleControlSchemeChanged;
            // values set before this scene's UI started
            HandleRunnerCountsChanged();
            HandleBleedOutChanged();
            HandleRescueChanged();
            HandleAbilityChanged();
            HandleDropEffectChanged();
            HandleRevealMarkersChanged();
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
            _abilityCooldownMeter.SetLabel(seconds > 0 ? string.Format(_abilityCooldownLabelFormat, seconds) : GetAbilityReadyHint());
        }

        private void HandleDropEffectChanged()
        {
            TogglePanel(_dropPanel, _state.IsDropEffectShown);
            if (!_state.IsDropEffectShown) return;

            _dropMeter.SetValue(_state.DropEffectProgress);
            // the remaining time changes every frame; the labels only need new strings when they actually change
            bool isNewEffect = _dropNameText.text != _state.DropEffectName;
            if (isNewEffect)
            {
                _dropNameText.text = _state.DropEffectName;
                _dropNameText.color = _state.IsDropEffectGood ? _goodDropColor : _badDropColor;
            }

            int seconds = Mathf.CeilToInt(_state.DropEffectRemainingInSeconds);
            if (seconds == _shownDropSeconds && !isNewEffect) return;

            _shownDropSeconds = seconds;
            _dropMeter.SetLabel(string.Format(_dropLabelFormat, seconds));
        }

        private void HandleRevealMarkersChanged() => _revealMarkers.ShowMarkers(_state.RevealMarkerPositions);

        private string GetAbilityReadyHint() =>
            string.Format(_state.AbilityReadyHint ?? string.Empty, _keybinds.GetDisplayText(_abilityAction, _controlScheme.IsGamepad));

        private void HandleSettingsChanged(SettingsCategory category)
        {
            if (category == SettingsCategory.Controls) RefreshAbilityLabel();
        }

        private void HandleControlSchemeChanged(bool _) => RefreshAbilityLabel();

        // forgets the shown seconds so the next update rewrites the label with the new key
        private void RefreshAbilityLabel()
        {
            _shownAbilitySeconds = -1;
            HandleAbilityChanged();
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
            _state.OnDropEffectChanged -= HandleDropEffectChanged;
            _state.OnRevealMarkersChanged -= HandleRevealMarkersChanged;
            _settings.OnChanged -= HandleSettingsChanged;
            _controlScheme.OnChanged -= HandleControlSchemeChanged;
        }
    }
}
