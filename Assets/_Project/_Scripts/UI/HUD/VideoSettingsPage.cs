using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Video tab: resolution, window mode, VSync, quality, frame cap and field of view. Resolution and window mode wait until
    // the arrows settle, apply, then ask to keep them and go back to the old ones unless kept in time, so a size the
    // display can't show undoes itself. The question is the menus canvas' shared dialog.
    public class VideoSettingsPage : MonoBehaviour
    {
        private const int NativeResolutionIndex = 0;

        [Inject] private readonly GameSettingsService _settings;
        [Inject] private readonly SettingsMenuState _menuState;
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
        [SerializeField] private ConfirmDialog _confirmDialog;
        // stepping through several sizes applies only the one the arrows stop on
        [SerializeField] private float _displayApplyDelayInSeconds = 0.75f;
        [SerializeField] private float _keepTimeoutInSeconds = 15f;
        // {0} is the whole seconds left before the old display settings come back
        [SerializeField] private string _keepMessageFormat = "Keep these display settings?\nReverting in {0}";
        [SerializeField] private string _keepLabel = "Keep";
        [SerializeField] private string _revertLabel = "Revert";

        private readonly List<Vector2Int> _resolutions = new();
        private readonly List<string> _optionBuffer = new();
        private ChoiceRow _resolutionRow;
        private ChoiceRow _windowModeRow;
        private ToggleRow _vSyncRow;
        private ChoiceRow _qualityRow;
        private ChoiceRow _frameCapRow;
        private SliderRow _fieldOfViewRow;
        private bool _isBuilt;
        // what the arrows show but isn't applied yet
        private DisplayChoice _pendingDisplay;
        private bool _hasPendingDisplay;
        // what to go back to while the keep question is open
        private DisplayChoice _previousDisplay;
        private bool _isAskingToKeep;
        private Selectable _changedSelectable;
        private CancellationTokenSource _applyCTS;
        private CancellationTokenSource _keepCTS;

        private void OnEnable()
        {
            if (!_isBuilt) Build();
            _settings.OnChanged += HandleSettingsChanged;
            _menuState.OnOpenChanged += HandleMenuOpenChanged;
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
            _windowModeRow.OnIndexChanged += HandleWindowModeChanged;

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
            StartPendingDisplay();
            _pendingDisplay.Width = size.x;
            _pendingDisplay.Height = size.y;
            QueueDisplayApply(_resolutionRow.Selectable);
        }

        private void HandleWindowModeChanged(int index)
        {
            StartPendingDisplay();
            _pendingDisplay.WindowMode = _windowModes[index].Mode;
            QueueDisplayApply(_windowModeRow.Selectable);
        }

        // the row not being changed keeps its applied value
        private void StartPendingDisplay()
        {
            if (_hasPendingDisplay) return;

            _hasPendingDisplay = true;
            _pendingDisplay = DisplayChoice.From(_settings.Values);
        }

        private void QueueDisplayApply(Selectable changedSelectable)
        {
            _changedSelectable = changedSelectable;
            RestartCTS(ref _applyCTS);
            ApplyDisplayAfterDelayAsync(_applyCTS.Token).Forget();
        }

        private async UniTaskVoid ApplyDisplayAfterDelayAsync(CancellationToken token)
        {
            await UniTask.WaitForSeconds(_displayApplyDelayInSeconds, ignoreTimeScale: true, cancellationToken: token);
            ApplyPendingDisplay();
        }

        private void ApplyPendingDisplay()
        {
            // another question (reset) or the keep question is already open: drop the choice rather than replace it,
            // so the open question keeps its callbacks and the display to go back to
            if (_confirmDialog.IsOpen)
            {
                CancelPendingDisplay();
                return;
            }

            _hasPendingDisplay = false;
            var current = DisplayChoice.From(_settings.Values);
            // stepped back round to what was already applied
            if (_pendingDisplay.Equals(current)) return;

            _previousDisplay = current;
            ChangeDisplay(_pendingDisplay);
            _isAskingToKeep = true;
            _confirmDialog.Open(FormatKeepMessage(_keepTimeoutInSeconds), KeepDisplay, _keepLabel, _revertLabel, RevertDisplay);
            RestartCTS(ref _keepCTS);
            CountDownToRevertAsync(_keepCTS.Token).Forget();
        }

        private async UniTaskVoid CountDownToRevertAsync(CancellationToken token)
        {
            float endTime = Time.unscaledTime + _keepTimeoutInSeconds;
            int shownSeconds = Mathf.CeilToInt(_keepTimeoutInSeconds);
            while (Time.unscaledTime < endTime)
            {
                await UniTask.Yield(token);
                int seconds = Mathf.CeilToInt(endTime - Time.unscaledTime);
                // 0 would only show while the dialog fades out
                if (seconds == shownSeconds || seconds <= 0) continue;

                shownSeconds = seconds;
                _confirmDialog.ChangeMessage(FormatKeepMessage(seconds));
            }

            // closing without a confirm reverts
            _confirmDialog.Close();
        }

        private string FormatKeepMessage(float seconds) => string.Format(_keepMessageFormat, Mathf.CeilToInt(seconds));

        private void KeepDisplay() => StopAskingToKeep();

        private void RevertDisplay()
        {
            StopAskingToKeep();
            ChangeDisplay(_previousDisplay);
        }

        private void StopAskingToKeep()
        {
            _isAskingToKeep = false;
            DisposeCTS(ref _keepCTS);
            if (_menuState.IsOpen && _changedSelectable != null && _changedSelectable.isActiveAndEnabled) _changedSelectable.Select();
        }

        private void ChangeDisplay(DisplayChoice display) =>
            _settings.Change(SettingsCategory.Video, values =>
            {
                values.ResolutionWidth = display.Width;
                values.ResolutionHeight = display.Height;
                values.WindowMode = display.WindowMode;
            });

        // a choice the arrows haven't settled on is dropped, and the rows show what is applied again
        private void CancelPendingDisplay()
        {
            DisposeCTS(ref _applyCTS);
            if (!_hasPendingDisplay) return;

            _hasPendingDisplay = false;
            Refresh();
        }

        private void HandleMenuOpenChanged(bool isOpen)
        {
            if (!isOpen) CancelPendingDisplay();
        }

        private void HandleSettingsChanged(SettingsCategory category)
        {
            if (category == SettingsCategory.Video) Refresh();
        }

        private void Refresh()
        {
            var values = _settings.Values;
            // rows still waiting to apply keep showing the choice
            if (!_hasPendingDisplay)
            {
                int resolutionIndex = values.HasNativeResolution ? NativeResolutionIndex : _resolutions.IndexOf(new Vector2Int(values.ResolutionWidth, values.ResolutionHeight)) + 1;
                _resolutionRow.SetIndexWithoutNotify(resolutionIndex);
                _windowModeRow.SetIndexWithoutNotify(Mathf.Max(0, _windowModes.FindIndex(option => option.Mode == values.WindowMode)));
            }
            _vSyncRow.SetIsOnWithoutNotify(values.IsVSyncOn);
            _qualityRow.SetIndexWithoutNotify(values.QualityLevel);
            _frameCapRow.SetIndexWithoutNotify(Mathf.Max(0, Array.IndexOf(_settings.Data.FrameCapOptions, values.FrameCap)));
            _fieldOfViewRow.SetValueWithoutNotify(values.FieldOfView);
        }

        private static void RestartCTS(ref CancellationTokenSource cts)
        {
            DisposeCTS(ref cts);
            cts = new();
        }

        private static void DisposeCTS(ref CancellationTokenSource cts)
        {
            cts?.Cancel();
            cts?.Dispose();
            cts = null;
        }

        // leaving the tab drops an unsettled choice and reverts an unkept one
        private void OnDisable()
        {
            _settings.OnChanged -= HandleSettingsChanged;
            _menuState.OnOpenChanged -= HandleMenuOpenChanged;
            CancelPendingDisplay();
            if (_isAskingToKeep && _confirmDialog != null) _confirmDialog.Close();
        }

        private void OnDestroy()
        {
            DisposeCTS(ref _applyCTS);
            DisposeCTS(ref _keepCTS);
        }

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

        private struct DisplayChoice : IEquatable<DisplayChoice>
        {
            public int Width;
            public int Height;
            public FullScreenMode WindowMode;

            public static DisplayChoice From(GameSettingsValues values) => new()
            {
                Width = values.ResolutionWidth,
                Height = values.ResolutionHeight,
                WindowMode = values.WindowMode
            };

            public readonly bool Equals(DisplayChoice other) => Width == other.Width && Height == other.Height && WindowMode == other.WindowMode;
        }
    }
}
