using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.Settings
{
    // Defaults, ranges and asset links for the settings menu
    [CreateAssetMenu(fileName = "SettingsData", menuName = "ScriptableObjects/SettingsData", order = 1)]
    public class SettingsData : ScriptableObject
    {
        [field: SerializeField] public string SaveKey { get; private set; } = "GameSettings";

        [field: Header("Video")]
        [field: SerializeField] public FullScreenMode DefaultWindowMode { get; private set; } = FullScreenMode.FullScreenWindow;
        [field: SerializeField] public bool DefaultIsVSyncOn { get; private set; } = true;
        [field: SerializeField] public int DefaultQualityLevel { get; private set; } = 1;
        [field: SerializeField] public int DefaultFrameCap { get; private set; } = 0;
        [field: SerializeField] public int[] FrameCapOptions { get; private set; } = { 0, 30, 60, 120, 144, 165, 240 };
        [field: SerializeField] public float DefaultFieldOfView { get; private set; } = 70f;
        [field: SerializeField] public float MinFieldOfView { get; private set; } = 60f;
        [field: SerializeField] public float MaxFieldOfView { get; private set; } = 100f;

        [field: Header("Audio")]
        [field: SerializeField] public AudioMixer Mixer { get; private set; }
        [field: SerializeField] public string MasterVolumeParameter { get; private set; } = "MasterVolume";
        [field: SerializeField] public string MusicVolumeParameter { get; private set; } = "MusicVolume";
        [field: SerializeField] public string SfxVolumeParameter { get; private set; } = "SfxVolume";
        [field: SerializeField] public string UiVolumeParameter { get; private set; } = "UiVolume";
        [field: SerializeField] public float MinVolumeInDecibels { get; private set; } = -80f;
        [field: SerializeField, Range(0f, 1f)] public float DefaultMasterVolume { get; private set; } = 1f;
        [field: SerializeField, Range(0f, 1f)] public float DefaultMusicVolume { get; private set; } = 0.7f;
        [field: SerializeField, Range(0f, 1f)] public float DefaultSfxVolume { get; private set; } = 1f;
        [field: SerializeField, Range(0f, 1f)] public float DefaultUiVolume { get; private set; } = 1f;

        [field: Header("Game")]
        [field: SerializeField] public float DefaultSensitivity { get; private set; } = 1f;
        [field: SerializeField] public float MinSensitivity { get; private set; } = 0.1f;
        [field: SerializeField] public float MaxSensitivity { get; private set; } = 3f;

        [field: Header("Controls")]
        [field: SerializeField] public InputActionAsset InputActions { get; private set; }
        [field: SerializeField] public List<KeybindEntry> Keybinds { get; private set; } = new();
        [field: SerializeField] public string KeyboardMouseGroup { get; private set; } = "Keyboard&Mouse";
        [field: SerializeField] public string GamepadGroup { get; private set; } = "Gamepad";
        [field: SerializeField] public string[] KeyboardMouseRebindPaths { get; private set; } = { "<Keyboard>", "<Mouse>" };
        [field: SerializeField] public string[] GamepadRebindPaths { get; private set; } = { "<Gamepad>" };
        // pointer movement would bind on the first mouse twitch
        [field: SerializeField] public string[] ExcludedRebindPaths { get; private set; } = { "<Pointer>/position", "<Pointer>/delta", "<Mouse>/scroll", "<Keyboard>/anyKey" };
        [field: SerializeField] public string RebindCancelPath { get; private set; } = "<Keyboard>/escape";
        [field: SerializeField] public float RebindTimeoutInSeconds { get; private set; } = 6f;

        public GameSettingsValues CreateDefaults() => new()
        {
            WindowMode = DefaultWindowMode,
            IsVSyncOn = DefaultIsVSyncOn,
            QualityLevel = DefaultQualityLevel,
            FrameCap = DefaultFrameCap,
            FieldOfView = DefaultFieldOfView,
            MasterVolume = DefaultMasterVolume,
            MusicVolume = DefaultMusicVolume,
            SfxVolume = DefaultSfxVolume,
            UiVolume = DefaultUiVolume,
            MouseSensitivityX = DefaultSensitivity,
            MouseSensitivityY = DefaultSensitivity,
            GamepadSensitivityX = DefaultSensitivity,
            GamepadSensitivityY = DefaultSensitivity,
            BindingOverridesJson = string.Empty
        };

        // Keeps loaded or edited values inside the ranges the menu offers
        public void Clamp(GameSettingsValues values)
        {
            values.FieldOfView = Mathf.Clamp(values.FieldOfView, MinFieldOfView, MaxFieldOfView);
            values.FrameCap = Mathf.Max(0, values.FrameCap);
            values.QualityLevel = Mathf.Clamp(values.QualityLevel, 0, QualitySettings.count - 1);
            values.MasterVolume = Mathf.Clamp01(values.MasterVolume);
            values.MusicVolume = Mathf.Clamp01(values.MusicVolume);
            values.SfxVolume = Mathf.Clamp01(values.SfxVolume);
            values.UiVolume = Mathf.Clamp01(values.UiVolume);
            values.MouseSensitivityX = Mathf.Clamp(values.MouseSensitivityX, MinSensitivity, MaxSensitivity);
            values.MouseSensitivityY = Mathf.Clamp(values.MouseSensitivityY, MinSensitivity, MaxSensitivity);
            values.GamepadSensitivityX = Mathf.Clamp(values.GamepadSensitivityX, MinSensitivity, MaxSensitivity);
            values.GamepadSensitivityY = Mathf.Clamp(values.GamepadSensitivityY, MinSensitivity, MaxSensitivity);
            values.BindingOverridesJson ??= string.Empty;
        }
    }
}
