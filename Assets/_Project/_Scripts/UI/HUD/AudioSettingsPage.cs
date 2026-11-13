using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Audio tab: master, music, SFX and UI volume, shown in percent
    public class AudioSettingsPage : MonoBehaviour
    {
        private const float PercentScale = 100f;

        [Inject] private readonly GameSettingsService _settings;
        [SerializeField] private Transform _container;
        [SerializeField] private SliderRow _sliderRowPrefab;
        [SerializeField] private string _masterLabel = "Master";
        [SerializeField] private string _musicLabel = "Music";
        [SerializeField] private string _sfxLabel = "Effects";
        [SerializeField] private string _uiLabel = "Interface";
        [SerializeField] private string _percentFormat = "{0:0}%";

        private SliderRow _masterRow;
        private SliderRow _musicRow;
        private SliderRow _sfxRow;
        private SliderRow _uiRow;
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
            _masterRow = CreateRow(_masterLabel, (values, volume) => values.MasterVolume = volume);
            _musicRow = CreateRow(_musicLabel, (values, volume) => values.MusicVolume = volume);
            _sfxRow = CreateRow(_sfxLabel, (values, volume) => values.SfxVolume = volume);
            _uiRow = CreateRow(_uiLabel, (values, volume) => values.UiVolume = volume);
        }

        private SliderRow CreateRow(string label, Action<GameSettingsValues, float> apply)
        {
            var row = Instantiate(_sliderRowPrefab, _container);
            row.Setup(label, 0f, 1f, false, volume => string.Format(_percentFormat, volume * PercentScale));
            row.OnValueChanged += volume => _settings.Change(SettingsCategory.Audio, values => apply(values, volume));
            return row;
        }

        private void HandleSettingsChanged(SettingsCategory category)
        {
            if (category == SettingsCategory.Audio) Refresh();
        }

        private void Refresh()
        {
            var values = _settings.Values;
            _masterRow.SetValueWithoutNotify(values.MasterVolume);
            _musicRow.SetValueWithoutNotify(values.MusicVolume);
            _sfxRow.SetValueWithoutNotify(values.SfxVolume);
            _uiRow.SetValueWithoutNotify(values.UiVolume);
        }

        private void OnDisable() => _settings.OnChanged -= HandleSettingsChanged;
    }
}
