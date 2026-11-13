using Project.Assets._Project._Scripts.Settings;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // A text that names an action's current key, e.g. "{0}: walk around"; follows rebinds and keyboard/gamepad switches
    public class KeyHintText : MonoBehaviour
    {
        [Inject] private readonly KeybindService _keybinds;
        [Inject] private readonly GameSettingsService _settings;
        [Inject] private readonly ControlSchemeState _controlScheme;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private InputActionReference _action;
        // {0} is the key
        [SerializeField] private string _format = "{0}";

        private void Start()
        {
            _settings.OnChanged += HandleSettingsChanged;
            _controlScheme.OnChanged += HandleControlSchemeChanged;
            Refresh();
        }

        private void HandleSettingsChanged(SettingsCategory category)
        {
            if (category == SettingsCategory.Controls) Refresh();
        }

        private void HandleControlSchemeChanged(bool _) => Refresh();

        private void Refresh() => _text.text = string.Format(_format, _keybinds.GetDisplayText(_action, _controlScheme.IsGamepad));

        private void OnDestroy()
        {
            _settings.OnChanged -= HandleSettingsChanged;
            _controlScheme.OnChanged -= HandleControlSchemeChanged;
        }
    }
}
