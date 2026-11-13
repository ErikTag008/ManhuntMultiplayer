using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Settings
{
    // Holds the player's settings, saves them to PlayerPrefs and tells listeners which category changed.
    // Changes apply at once; Save writes them only when something changed.
    public class GameSettingsService
    {
        private readonly SettingsData _data;
        private readonly GameSettingsValues _values;
        private bool _isDirty;

        public event Action<SettingsCategory> OnChanged;

        public SettingsData Data => _data;
        // Read here; write through Change so listeners hear about it
        public GameSettingsValues Values => _values;

        public GameSettingsService(SettingsData data)
        {
            _data = data;
            _values = Load();
        }

        public void Change(SettingsCategory category, Action<GameSettingsValues> change)
        {
            change(_values);
            _data.Clamp(_values);
            _isDirty = true;
            OnChanged?.Invoke(category);
        }

        public void ResetCategory(SettingsCategory category)
        {
            _values.CopyCategoryFrom(_data.CreateDefaults(), category);
            _isDirty = true;
            OnChanged?.Invoke(category);
        }

        public void Save()
        {
            if (!_isDirty) return;

            PlayerPrefs.SetString(_data.SaveKey, JsonUtility.ToJson(_values));
            PlayerPrefs.Save();
            _isDirty = false;
        }

        private GameSettingsValues Load()
        {
            var values = _data.CreateDefaults();
            if (!PlayerPrefs.HasKey(_data.SaveKey)) return values;

            try
            {
                JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(_data.SaveKey), values);
            }
            catch (ArgumentException exception)
            {
                EUtils.Logger.LogWarning($"[GameSettingsService] Saved settings could not be read, using defaults. {exception.Message}");
                values = _data.CreateDefaults();
            }

            _data.Clamp(values);
            return values;
        }
    }
}
