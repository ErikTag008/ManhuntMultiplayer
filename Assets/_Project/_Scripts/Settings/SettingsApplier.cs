using Reflex.Attributes;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Settings
{
    // Applies the saved video and audio settings at start and whenever they change. Lives on the persistent objects,
    // and applies in Start because an Audio Mixer ignores SetFloat during the first scene's Awake.
    public class SettingsApplier : MonoBehaviour
    {
        private const int NoFrameCap = -1;
        private const int VSyncEveryFrame = 1;

        [Inject] private readonly GameSettingsService _settings;

        private int _appliedWidth;
        private int _appliedHeight;
        private FullScreenMode _appliedWindowMode;
        private bool _hasAppliedResolution;

        private void Start()
        {
            _settings.OnChanged += HandleSettingsChanged;
            ApplyVideo(_settings.Values);
            ApplyAudio(_settings.Values);
        }

        private void HandleSettingsChanged(SettingsCategory category)
        {
            switch (category)
            {
                case SettingsCategory.Video:
                    ApplyVideo(_settings.Values);
                    break;
                case SettingsCategory.Audio:
                    ApplyAudio(_settings.Values);
                    break;
            }
        }

        private void ApplyVideo(GameSettingsValues values)
        {
            if (values.QualityLevel >= 0 && values.QualityLevel < QualitySettings.count) QualitySettings.SetQualityLevel(values.QualityLevel, true);
            // after the quality level, which carries its own VSync value
            QualitySettings.vSyncCount = values.IsVSyncOn ? VSyncEveryFrame : 0;
            Application.targetFrameRate = values.FrameCap > 0 ? values.FrameCap : NoFrameCap;
            ApplyResolution(values);
        }

        // only on a real change, so dragging the FOV slider doesn't reset the window every frame
        private void ApplyResolution(GameSettingsValues values)
        {
            var native = Screen.currentResolution;
            int width = values.HasNativeResolution ? native.width : values.ResolutionWidth;
            int height = values.HasNativeResolution ? native.height : values.ResolutionHeight;
            if (_hasAppliedResolution && width == _appliedWidth && height == _appliedHeight && values.WindowMode == _appliedWindowMode) return;

            _hasAppliedResolution = true;
            _appliedWidth = width;
            _appliedHeight = height;
            _appliedWindowMode = values.WindowMode;
            Screen.SetResolution(width, height, values.WindowMode);
        }

        private void ApplyAudio(GameSettingsValues values)
        {
            var data = _settings.Data;
            if (data.Mixer == null) return;

            SetVolume(data.MasterVolumeParameter, values.MasterVolume);
            SetVolume(data.MusicVolumeParameter, values.MusicVolume);
            SetVolume(data.SfxVolumeParameter, values.SfxVolume);
            SetVolume(data.UiVolumeParameter, values.UiVolume);
        }

        private void SetVolume(string parameter, float linear)
        {
            var data = _settings.Data;
            if (!data.Mixer.SetFloat(parameter, EUtils.Math.LinearToDecibels(linear, data.MinVolumeInDecibels)))
            {
                EUtils.Logger.LogWarning($"[SettingsApplier] The mixer has no exposed parameter '{parameter}'.");
            }
        }

        private void OnApplicationQuit() => _settings.Save();

        private void OnDestroy() => _settings.OnChanged -= HandleSettingsChanged;
    }
}
