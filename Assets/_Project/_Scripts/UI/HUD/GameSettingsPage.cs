using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Game tab: mouse and gamepad look sensitivity per axis, and invert Y
    public class GameSettingsPage : MonoBehaviour
    {
        [Inject] private readonly GameSettingsService _settings;
        [SerializeField] private Transform _container;
        [SerializeField] private SliderRow _sliderRowPrefab;
        [SerializeField] private ToggleRow _toggleRowPrefab;
        [SerializeField] private string _mouseXLabel = "Mouse sensitivity X";
        [SerializeField] private string _mouseYLabel = "Mouse sensitivity Y";
        [SerializeField] private string _gamepadXLabel = "Gamepad sensitivity X";
        [SerializeField] private string _gamepadYLabel = "Gamepad sensitivity Y";
        [SerializeField] private string _invertYLabel = "Invert look Y";
        [SerializeField] private string _sensitivityFormat = "{0:0.00}x";

        private SliderRow _mouseXRow;
        private SliderRow _mouseYRow;
        private SliderRow _gamepadXRow;
        private SliderRow _gamepadYRow;
        private ToggleRow _invertYRow;
        private bool _isBuilt;

        private void OnEnable()
        {
            if (!_isBuilt) Build();
            _settings.OnChanged += HandleSettingsChanged;
            Refresh();
        }

        private void Build()
        {
            _isBuilt = true;
            _mouseXRow = CreateSensitivityRow(_mouseXLabel, (values, sensitivity) => values.MouseSensitivityX = sensitivity);
            _mouseYRow = CreateSensitivityRow(_mouseYLabel, (values, sensitivity) => values.MouseSensitivityY = sensitivity);
            _gamepadXRow = CreateSensitivityRow(_gamepadXLabel, (values, sensitivity) => values.GamepadSensitivityX = sensitivity);
            _gamepadYRow = CreateSensitivityRow(_gamepadYLabel, (values, sensitivity) => values.GamepadSensitivityY = sensitivity);

            _invertYRow = Instantiate(_toggleRowPrefab, _container);
            _invertYRow.Setup(_invertYLabel);
            _invertYRow.OnToggled += isOn => _settings.Change(SettingsCategory.Game, values => values.IsLookYInverted = isOn);
        }

        private SliderRow CreateSensitivityRow(string label, Action<GameSettingsValues, float> apply)
        {
            var data = _settings.Data;
            var row = Instantiate(_sliderRowPrefab, _container);
            row.Setup(label, data.MinSensitivity, data.MaxSensitivity, false, sensitivity => string.Format(_sensitivityFormat, sensitivity));
            row.OnValueChanged += sensitivity => _settings.Change(SettingsCategory.Game, values => apply(values, sensitivity));
            return row;
        }

        private void HandleSettingsChanged(SettingsCategory category)
        {
            if (category == SettingsCategory.Game) Refresh();
        }

        private void Refresh()
        {
            var values = _settings.Values;
            _mouseXRow.SetValueWithoutNotify(values.MouseSensitivityX);
            _mouseYRow.SetValueWithoutNotify(values.MouseSensitivityY);
            _gamepadXRow.SetValueWithoutNotify(values.GamepadSensitivityX);
            _gamepadYRow.SetValueWithoutNotify(values.GamepadSensitivityY);
            _invertYRow.SetIsOnWithoutNotify(values.IsLookYInverted);
        }

        private void OnDisable() => _settings.OnChanged -= HandleSettingsChanged;
    }
}
