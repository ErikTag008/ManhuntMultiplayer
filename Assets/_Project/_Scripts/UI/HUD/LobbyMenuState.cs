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

        public event Action<bool> OnOpenChanged;
        public event Action OnAbilityOptionsChanged;
        public event Action OnChoiceChanged;
        public event Action<int> OnAbilityPickRequested;
        public event Action OnReadyToggleRequested;

        public bool IsOpen => _isOpen;
        public IReadOnlyList<LobbyOption> AbilityOptions => _abilityOptions;
        public int SelectedAbilityId => _selectedAbilityId;
        public bool IsReady => _isReady;

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
