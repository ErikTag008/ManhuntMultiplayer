using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Settings
{
    // The player's saved settings. Public fields so JsonUtility can save them; fields missing from an older save keep their defaults.
    [Serializable]
    public class GameSettingsValues
    {
        // 0 means the display's native resolution
        public int ResolutionWidth;
        public int ResolutionHeight;
        public FullScreenMode WindowMode;
        public bool IsVSyncOn;
        public int QualityLevel;
        // 0 means no cap
        public int FrameCap;
        public float FieldOfView;

        public float MasterVolume;
        public float MusicVolume;
        public float SfxVolume;
        public float UiVolume;

        // multipliers on the player stats' base sensitivities
        public float MouseSensitivityX;
        public float MouseSensitivityY;
        public float GamepadSensitivityX;
        public float GamepadSensitivityY;
        public bool IsLookYInverted;

        public string BindingOverridesJson;

        public bool HasNativeResolution => ResolutionWidth <= 0 || ResolutionHeight <= 0;

        public GameSettingsValues Clone() => (GameSettingsValues)MemberwiseClone();

        // Copies only the fields of one category, so resetting a tab leaves the others alone
        public void CopyCategoryFrom(GameSettingsValues source, SettingsCategory category)
        {
            switch (category)
            {
                case SettingsCategory.Video:
                    ResolutionWidth = source.ResolutionWidth;
                    ResolutionHeight = source.ResolutionHeight;
                    WindowMode = source.WindowMode;
                    IsVSyncOn = source.IsVSyncOn;
                    QualityLevel = source.QualityLevel;
                    FrameCap = source.FrameCap;
                    FieldOfView = source.FieldOfView;
                    break;
                case SettingsCategory.Audio:
                    MasterVolume = source.MasterVolume;
                    MusicVolume = source.MusicVolume;
                    SfxVolume = source.SfxVolume;
                    UiVolume = source.UiVolume;
                    break;
                case SettingsCategory.Game:
                    MouseSensitivityX = source.MouseSensitivityX;
                    MouseSensitivityY = source.MouseSensitivityY;
                    GamepadSensitivityX = source.GamepadSensitivityX;
                    GamepadSensitivityY = source.GamepadSensitivityY;
                    IsLookYInverted = source.IsLookYInverted;
                    break;
                case SettingsCategory.Controls:
                    BindingOverridesJson = source.BindingOverridesJson;
                    break;
            }
        }
    }
}
