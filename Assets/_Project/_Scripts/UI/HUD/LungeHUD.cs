using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // The catcher's charged lunge on the gameplay HUD: a hold hint while the attack is ready and a ring that fills while charging
    public class LungeHUD : MonoBehaviour
    {
        [Inject] private readonly GameHUDState _state;
        // holds a KeyHintText, so the key follows the live binding
        [SerializeField] private FadePanel _hintPanel;
        [SerializeField] private FadePanel _chargePanel;
        [SerializeField] private FillMeter _chargeMeter;

        private void Start()
        {
            _state.OnLungeChanged += HandleLungeChanged;
            // values set before this scene's UI started
            HandleLungeChanged();
        }

        private void HandleLungeChanged()
        {
            TogglePanel(_hintPanel, _state.IsLungeHintShown);
            TogglePanel(_chargePanel, _state.IsLungeChargeShown);
            _chargeMeter.SetValue(_state.LungeChargeProgress);
        }

        private static void TogglePanel(FadePanel panel, bool isShown)
        {
            if (panel.IsShown == isShown) return;

            if (isShown) panel.Show();
            else panel.Hide();
        }

        private void OnDestroy() => _state.OnLungeChanged -= HandleLungeChanged;
    }
}
