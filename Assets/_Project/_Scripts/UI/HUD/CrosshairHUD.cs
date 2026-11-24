using Project.Assets._Project._Scripts.Settings;
using Reflex.Attributes;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // A centre dot while the local player aims in a round; hidden in menus, the emote wheel, spectating, the results
    // and when turned off in the Game settings
    public class CrosshairHUD : MonoBehaviour
    {
        [Inject] private readonly GameHUDState _state;
        [Inject] private readonly GameSettingsService _settings;
        [Inject] private readonly PauseMenuState _pauseMenu;
        [Inject] private readonly EmoteWheelState _emoteWheel;
        [SerializeField] private GameObject _crosshair;

        private void Start()
        {
            _state.OnCrosshairChanged += Refresh;
            _settings.OnChanged += HandleSettingsChanged;
            _pauseMenu.OnOpenChanged += HandleMenuOpenChanged;
            _emoteWheel.OnOpenChanged += HandleMenuOpenChanged;
            Refresh();
        }

        private void HandleSettingsChanged(SettingsCategory category)
        {
            if (category == SettingsCategory.Game) Refresh();
        }

        private void HandleMenuOpenChanged(bool _) => Refresh();

        private void Refresh()
        {
            bool isShown = _state.IsCrosshairWanted && _settings.Values.IsCrosshairShown && !_pauseMenu.IsOpen && !_emoteWheel.IsOpen;
            if (_crosshair.activeSelf != isShown) _crosshair.SetActive(isShown);
        }

        private void OnDestroy()
        {
            _state.OnCrosshairChanged -= Refresh;
            _settings.OnChanged -= HandleSettingsChanged;
            _pauseMenu.OnOpenChanged -= HandleMenuOpenChanged;
            _emoteWheel.OnOpenChanged -= HandleMenuOpenChanged;
        }
    }
}
