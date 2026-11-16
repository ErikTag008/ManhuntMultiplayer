using Project.Assets._Project._Scripts.Networking;
using System;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // The lobby menu's state and the player's requests from it. The local player writes what to show and reads the requests;
    // it lives in the UI assembly because UI can't reference Player. Values are kept so a menu that starts later can catch up.
    public class LobbyMenuState
    {
        private readonly List<LobbyOption> _abilityOptions = new();
        private bool _isOpen;
        private int _selectedAbilityId;
        private bool _isReady;
        private bool _canEditLobbySettings;

        public event Action<bool> OnOpenChanged;
        public event Action OnAbilityOptionsChanged;
        public event Action OnChoiceChanged;
        public event Action<int> OnAbilityPickRequested;
        public event Action OnReadyToggleRequested;
        public event Action<bool> OnCanEditLobbySettingsChanged;
        public event Action<LobbyConfig> OnLobbyConfigChangeRequested;

        public bool IsOpen => _isOpen;
        public IReadOnlyList<LobbyOption> AbilityOptions => _abilityOptions;
        public int SelectedAbilityId => _selectedAbilityId;
        public bool IsReady => _isReady;
        // only the host, and only before the countdown starts
        public bool CanEditLobbySettings => _canEditLobbySettings;

        public void ToggleOpen(bool isOpen)
        {
            if (_isOpen == isOpen) return;

            _isOpen = isOpen;
            OnOpenChanged?.Invoke(isOpen);
        }

        public void SetAbilityOptions(IEnumerable<LobbyOption> options)
        {
            _abilityOptions.Clear();
            _abilityOptions.AddRange(options);
            OnAbilityOptionsChanged?.Invoke();
        }

        public void SetChoice(int selectedAbilityId, bool isReady)
        {
            if (_selectedAbilityId == selectedAbilityId && _isReady == isReady) return;

            _selectedAbilityId = selectedAbilityId;
            _isReady = isReady;
            OnChoiceChanged?.Invoke();
        }

        public void RequestAbilityPick(int abilityId) => OnAbilityPickRequested?.Invoke(abilityId);

        public void RequestReadyToggle() => OnReadyToggleRequested?.Invoke();

        public void ToggleCanEditLobbySettings(bool canEdit)
        {
            if (_canEditLobbySettings == canEdit) return;

            _canEditLobbySettings = canEdit;
            OnCanEditLobbySettingsChanged?.Invoke(canEdit);
        }

        public void RequestLobbyConfigChange(LobbyConfig config)
        {
            if (!_canEditLobbySettings) return;
            OnLobbyConfigChangeRequested?.Invoke(config);
        }
    }

    public readonly struct LobbyOption
    {
        public readonly int Id;
        public readonly string Label;

        public LobbyOption(int id, string label)
        {
            Id = id;
            Label = label;
        }
    }
}
