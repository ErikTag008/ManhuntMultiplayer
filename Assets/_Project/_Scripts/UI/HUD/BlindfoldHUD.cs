using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Full-screen cover the local player sees while blinded (a catcher during the hide phase)
    public class BlindfoldHUD : MonoBehaviour
    {
        [Inject] private readonly IUIManager _uiManager;
        [SerializeField] private FadePanel _panel;

        private void Start()
        {
            _uiManager.OnBlindfoldToggled += HandleBlindfoldToggled;
            // the blindfold may have been switched on before this scene's UI started
            HandleBlindfoldToggled(_uiManager.IsBlindfolded);
        }

        private void HandleBlindfoldToggled(bool isBlindfolded)
        {
            if (isBlindfolded == _panel.IsShown) return;

            if (isBlindfolded) _panel.Show();
            else _panel.Hide();
        }

        private void OnDestroy()
        {
            _uiManager.OnBlindfoldToggled -= HandleBlindfoldToggled;
        }
    }
}
