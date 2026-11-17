using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // The ghost's controls on the gameplay HUD: a ping hint while a ping is ready, the ping cooldown,
    // and which view Interact switches to
    public class GhostHUD : MonoBehaviour
    {
        [Inject] private readonly GameHUDState _state;
        // the hint panels each hold a KeyHintText, so the key follows the live binding
        [SerializeField] private FadePanel _pingHintPanel;
        [SerializeField] private FadePanel _cooldownPanel;
        [SerializeField] private FillMeter _cooldownMeter;
        [SerializeField] private string _cooldownLabelFormat = "{0:0}";
        // shown while flying, e.g. "{0} spectate"
        [SerializeField] private FadePanel _spectateHintPanel;
        // shown while spectating, e.g. "{0} fly"
        [SerializeField] private FadePanel _flyHintPanel;

        private int _shownCooldownSeconds = -1;

        private void Start()
        {
            _state.OnGhostChanged += HandleGhostChanged;
            // values set before this scene's UI started
            HandleGhostChanged();
        }

        private void HandleGhostChanged()
        {
            bool isGhost = _state.IsGhost;
            bool isCooldownShown = isGhost && _state.GhostPingCooldownRemainingInSeconds > 0f;
            TogglePanel(_pingHintPanel, isGhost && _state.IsGhostFlying && _state.IsGhostPingReady);
            TogglePanel(_cooldownPanel, isCooldownShown);
            TogglePanel(_spectateHintPanel, isGhost && _state.IsGhostFlying);
            TogglePanel(_flyHintPanel, isGhost && !_state.IsGhostFlying);
            if (!isCooldownShown) return;

            _cooldownMeter.SetValue(_state.GhostPingCooldownProgress);
            // the remaining time changes every frame; the label only needs a new string each whole second
            int seconds = Mathf.CeilToInt(_state.GhostPingCooldownRemainingInSeconds);
            if (seconds == _shownCooldownSeconds) return;

            _shownCooldownSeconds = seconds;
            _cooldownMeter.SetLabel(string.Format(_cooldownLabelFormat, seconds));
        }

        private static void TogglePanel(FadePanel panel, bool isShown)
        {
            if (panel.IsShown == isShown) return;

            if (isShown) panel.Show();
            else panel.Hide();
        }

        private void OnDestroy() => _state.OnGhostChanged -= HandleGhostChanged;
    }
}
