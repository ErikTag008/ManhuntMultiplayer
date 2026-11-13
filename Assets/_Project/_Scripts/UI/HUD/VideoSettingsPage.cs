using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Video tab: resolution, window mode, VSync, quality, frame cap and field of view
    public class VideoSettingsPage : MonoBehaviour
    {
        private const int NativeResolutionIndex = 0;

        [Inject] private readonly GameSettingsService _settings;
        [SerializeField] private Transform _container;
        [SerializeField] private ChoiceRow _choiceRowPrefab;
        [SerializeField] private ToggleRow _toggleRowPrefab;
        [SerializeField] private SliderRow _sliderRowPrefab;
        [SerializeField] private string _resolutionLabel = "Resolution";
        [SerializeField] private string _nativeResolutionFormat = "Native ({0} x {1})";
        [SerializeField] private string _resolutionFormat = "{0} x {1}";
        [SerializeField] private string _windowModeLabel = "Window mode";
        [SerializeField] private List<WindowModeOption> _windowModes = new()
        {
            new(FullScreenMode.ExclusiveFullScreen, "Fullscreen"),
            new(FullScreenMode.FullScreenWindow, "Borderless"),
            new(FullScreenMode.Windowed, "Windowed")
        };
        [SerializeField] private string _vSyncLabel = "VSync";
        [SerializeField] private string _qualityLabel = "Quality";
        [SerializeField] private string _frameCapLabel = "Frame cap";
        [SerializeField] private string _unlimitedFrameCapText = "Unlimited";
        [SerializeField] private string _frameCapFormat = "{0} FPS";
        [SerializeField] private string _fieldOfViewLabel = "Field of view";
        [SerializeField] private string _fieldOfViewFormat = "{0:0}°";

        private readonly List<Vector2Int> _resolutions = new();
        private readonly List<string> _optionBuffer = new();
        private ChoiceRow _resolutionRow;
        private ChoiceRow _windowModeRow;
        private ToggleRow _vSyncRow;
        private ChoiceRow _qualityRow;
        private ChoiceRow _frameCapRow;
        private SliderRow _fieldOfViewRow;
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
            var data = _settings.Data;

            _resolutionRow = Instantiate(_choiceRowPrefab, _container);
            _resolutionRow.Setup(_resolutionLabel, BuildResolutionOptions());
            _resolutionRow.OnIndexChanged += HandleResolutionChanged;

            _windowModeRow = Instantiate(_choiceRowPrefab, _container);
            _optionBuffer.Clear();
            foreach (var option in _windowModes) _optionBuffer.Add(option.Label);
            _windowModeRow.Setup(_windowModeLabel, _optionBuffer);
            _windowModeRow.OnIndexChanged += index => _settings.Change(SettingsCategory.Video, values => values.WindowMode = _windowModes[index].Mode);

            _vSyncRow = Instantiate(_toggleRowPrefab, _container);
            _vSyncRow.Setup(_vSyncLabel);
            _vSyncRow.OnToggled += isOn => _settings.Change(SettingsCategory.Video, values => values.IsVSyncOn = isOn);

            _qualityRow = Instantiate(_choiceRowPrefab, _container);
            _qualityRow.Setup(_qualityLabel, QualitySettings.names);
            _qualityRow.OnIndexChanged += index => _settings.Change(SettingsCategory.Video, values => values.QualityLevel = index);

            _frameCapRow = Instantiate(_choiceRowPrefab, _container);
            _optionBuffer.Clear();
            foreach (int cap in data.FrameCapOptions) _optionBuffer.Add(cap > 0 ? string.Format(_frameCapFormat, cap) : _unlimitedFrameCapText);
            _frameCapRow.Setup(_frameCapLabel, _optionBuffer);
            _frameCapRow.OnIndexChanged += index => _settings.Change(SettingsCategory.Video, values => values.FrameCap = data.FrameCapOptions[index]);

            _fieldOfViewRow = Instantiate(_sliderRowPrefab, _container);
            _fieldOfViewRow.Setup(_fieldOfViewLabel, data.MinFieldOfView, data.MaxFieldOfView, true, value => string.Format(_fieldOfViewFormat, value));
            _fieldOfViewRow.OnValueChanged += value => _settings.Change(SettingsCategory.Video, values => values.FieldOfView = value);
        }

        // the first option keeps the display's own resolution; the rest are the distinct sizes the display supports
        private List<string> BuildResolutionOptions()
        {
            _resolutions.Clear();
            foreach (var resolution in Screen.resolutions)
            {
                var size = new Vector2Int(resolution.width, resolution.height);
                if (!_resolutions.Contains(size)) _resolutions.Add(size);
            }

            var native = Screen.currentResolution;
            var options = new List<string> { string.Format(_nativeResolutionFormat, native.width, native.height) };
            foreach (var size in _resolutions) options.Add(string.Format(_resolutionFormat, size.x, size.y));
            return options;
        }

        private void HandleResolutionChanged(int index)
        {
            bool isNative = index == NativeResolutionIndex;
            var size = isNative ? Vector2Int.zero : _resolutions[index - 1];
            _settings.Change(SettingsCategory.Video, values =>
            {
                values.ResolutionWidth = size.x;
                values.ResolutionHeight = size.y;
            });
        }

        private void HandleSettingsChanged(SettingsCategory category)
        {
            if (category == SettingsCategory.Video) Refresh();
        }

        private void Refresh()
        {
            var values = _settings.Values;
            int resolutionIndex = values.HasNativeResolution ? NativeResolutionIndex : _resolutions.IndexOf(new Vector2Int(values.ResolutionWidth, values.ResolutionHeight)) + 1;
            _resolutionRow.SetIndexWithoutNotify(resolutionIndex);
            _windowModeRow.SetIndexWithoutNotify(Mathf.Max(0, _windowModes.FindIndex(option => option.Mode == values.WindowMode)));
            _vSyncRow.SetIsOnWithoutNotify(values.IsVSyncOn);
            _qualityRow.SetIndexWithoutNotify(values.QualityLevel);
            _frameCapRow.SetIndexWithoutNotify(Mathf.Max(0, Array.IndexOf(_settings.Data.FrameCapOptions, values.FrameCap)));
            _fieldOfViewRow.SetValueWithoutNotify(values.FieldOfView);
        }

        private void OnDisable() => _settings.OnChanged -= HandleSettingsChanged;

        [Serializable]
        private class WindowModeOption
        {
            [field: SerializeField] public FullScreenMode Mode { get; private set; }
            [field: SerializeField] public string Label { get; private set; }

            public WindowModeOption(FullScreenMode mode, string label)
            {
                Mode = mode;
                Label = label;
            }
        }
    }
}
