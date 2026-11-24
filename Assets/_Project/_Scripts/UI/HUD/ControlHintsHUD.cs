using DG.Tweening;
using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Role control hints on the gameplay HUD, in a bottom-centre stack: what the runner's ability does during the hide phase,
    // what a knocked runner can do, the spectator's switch keys, and the emote key for a moment when the hunt starts
    public class ControlHintsHUD : MonoBehaviour
    {
        [Inject] private readonly GameHUDState _state;
        [Inject] private readonly KeybindService _keybinds;
        [Inject] private readonly GameSettingsService _settings;
        [Inject] private readonly ControlSchemeState _controlScheme;
        [SerializeField] private FadePanel _abilityHintPanel;
        [SerializeField] private TMP_Text _abilityHintText;
        // {0} is the ability's name, {1} its description
        [SerializeField] private string _abilityHintFormat = "{0}: {1}";
        [SerializeField] private FadePanel _knockedHintPanel;
        [SerializeField] private TMP_Text _knockedHintText;
        [SerializeField] private string _knockedHint = "Crawl to cover, a teammate can revive you";
        [SerializeField] private FadePanel _spectateHintPanel;
        [SerializeField] private TMP_Text _spectateHintText;
        // {0} is the previous key, {1} the next key
        [SerializeField] private string _spectateHintFormat = "{0} / {1} switch player";
        [SerializeField] private InputActionReference _spectatePreviousAction;
        [SerializeField] private InputActionReference _spectateNextAction;
        // holds a KeyHintText, so the key follows the live binding
        [SerializeField] private FadePanel _emoteHintPanel;
        [SerializeField, Min(0f)] private float _emoteHintShownDurationInSeconds = 5f;

        private RoundPhase _shownPhase;
        private Tween _emoteHintHideTween;
        private string _shownAbilityName;

        private void Start()
        {
            _state.OnAbilityChanged += RefreshAbilityHint;
            _state.OnRoundPhaseChanged += HandleRoundPhaseChanged;
            _state.OnBleedOutChanged += HandleBleedOutChanged;
            _state.OnSpectatingChanged += HandleSpectatingChanged;
            _state.OnGhostChanged += HideEmoteHintIfUnavailable;
            _settings.OnChanged += HandleSettingsChanged;
            _controlScheme.OnChanged += HandleControlSchemeChanged;
            _knockedHintText.text = _knockedHint;
            RefreshSpectateHintText();
            // values set before this scene's UI started; a hunt already running doesn't replay the emote hint
            _shownPhase = _state.RoundPhase;
            RefreshAbilityHint();
            RefreshKnockedHint();
            HandleSpectatingChanged();
        }

        private void HandleRoundPhaseChanged()
        {
            RefreshAbilityHint();
            var phase = _state.RoundPhase;
            if (phase == _shownPhase) return;

            _shownPhase = phase;
            if (phase == RoundPhase.Hunt) ShowEmoteHint();
            else HideEmoteHint();
        }

        // the ability is explained while there is time to read it, before the hunt; the slot keeps its name and key after
        private void RefreshAbilityHint()
        {
            bool isShown = _state.IsAbilityShown && _state.RoundPhase == RoundPhase.Hide && !_state.IsBleedOutShown
                && !string.IsNullOrEmpty(_state.AbilityDescription);
            // the ability updates every frame while it cools down; the text only needs a new string for a new ability
            if (isShown && _shownAbilityName != _state.AbilityName)
            {
                _shownAbilityName = _state.AbilityName;
                _abilityHintText.text = string.Format(_abilityHintFormat, _state.AbilityName, _state.AbilityDescription);
            }

            TogglePanel(_abilityHintPanel, isShown);
        }

        private void HandleBleedOutChanged()
        {
            RefreshKnockedHint();
            RefreshAbilityHint();
        }

        private void RefreshKnockedHint() => TogglePanel(_knockedHintPanel, _state.IsBleedOutShown);

        private void HandleSpectatingChanged()
        {
            TogglePanel(_spectateHintPanel, _state.IsSpectating);
            HideEmoteHintIfUnavailable();
        }

        private void ShowEmoteHint()
        {
            if (!CanEmote()) return;

            _emoteHintPanel.Show();
            _emoteHintHideTween?.Kill();
            _emoteHintHideTween = DOVirtual.DelayedCall(_emoteHintShownDurationInSeconds, HideEmoteHint);
        }

        private void HideEmoteHint()
        {
            _emoteHintHideTween?.Kill();
            if (_emoteHintPanel.IsShown) _emoteHintPanel.Hide();
        }

        // a player who turns ghost or starts spectating while the emote hint shows loses it
        private void HideEmoteHintIfUnavailable()
        {
            if (!CanEmote()) HideEmoteHint();
        }

        private bool CanEmote() => !_state.IsGhost && !_state.IsSpectating;

        private void RefreshSpectateHintText()
        {
            bool isGamepad = _controlScheme.IsGamepad;
            _spectateHintText.text = string.Format(_spectateHintFormat,
                _keybinds.GetDisplayText(_spectatePreviousAction, isGamepad), _keybinds.GetDisplayText(_spectateNextAction, isGamepad));
        }

        private void HandleSettingsChanged(SettingsCategory category)
        {
            if (category == SettingsCategory.Controls) RefreshSpectateHintText();
        }

        private void HandleControlSchemeChanged(bool _) => RefreshSpectateHintText();

        private static void TogglePanel(FadePanel panel, bool isShown)
        {
            if (panel.IsShown == isShown) return;

            if (isShown) panel.Show();
            else panel.Hide();
        }

        private void OnDestroy()
        {
            _state.OnAbilityChanged -= RefreshAbilityHint;
            _state.OnRoundPhaseChanged -= HandleRoundPhaseChanged;
            _state.OnBleedOutChanged -= HandleBleedOutChanged;
            _state.OnSpectatingChanged -= HandleSpectatingChanged;
            _state.OnGhostChanged -= HideEmoteHintIfUnavailable;
            _settings.OnChanged -= HandleSettingsChanged;
            _controlScheme.OnChanged -= HandleControlSchemeChanged;
            _emoteHintHideTween?.Kill();
        }
    }
}
