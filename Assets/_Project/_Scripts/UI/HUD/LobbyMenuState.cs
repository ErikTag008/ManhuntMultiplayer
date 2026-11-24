using Project.Assets._Project._Scripts.Networking;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // The lobby menu's state and the player's requests from it. The local player writes what to show and reads the requests;
    // it lives in the UI assembly because UI can't reference Player. Values are kept so a menu that starts later can catch up.
    public class LobbyMenuState
    {
        public const int NoMapVote = -1;

        private readonly List<LobbyOption> _abilityOptions = new();
        private readonly List<LobbyOption> _mapOptions = new();
        private readonly List<int> _mapVoteCounts = new();
        private bool _isOpen;
        private bool _isCustomizeOpen;
        private int _selectedAbilityId;
        private bool _isReady;
        private bool _canEditLobbySettings;
        private int _mapVote = NoMapVote;

        public event Action<bool> OnOpenChanged;
        // the Customize screen covers the lobby menu while it is open; the lobby menu itself stays open underneath
        public event Action<bool> OnCustomizeOpenChanged;
        public event Action OnAbilityOptionsChanged;
        public event Action OnChoiceChanged;
        public event Action<int> OnAbilityPickRequested;
        public event Action OnReadyToggleRequested;
        public event Action<bool> OnCanEditLobbySettingsChanged;
        public event Action<LobbyConfig> OnLobbyConfigChangeRequested;
        public event Action OnMapOptionsChanged;
        public event Action OnMapVotesChanged;
        // the map index voted for, or NoMapVote to take the vote back
        public event Action<int> OnMapVoteRequested;

        public bool IsOpen => _isOpen;
        public bool IsCustomizeOpen => _isCustomizeOpen;
        public IReadOnlyList<LobbyOption> AbilityOptions => _abilityOptions;
        public int SelectedAbilityId => _selectedAbilityId;
        public bool IsReady => _isReady;
        // only the host, and only before the countdown starts
        public bool CanEditLobbySettings => _canEditLobbySettings;
        public IReadOnlyList<LobbyOption> MapOptions => _mapOptions;
        // votes per map, in MapOptions order
        public IReadOnlyList<int> MapVoteCounts => _mapVoteCounts;
        public int MapVote => _mapVote;

        public void ToggleOpen(bool isOpen)
        {
            if (_isOpen == isOpen) return;

            _isOpen = isOpen;
            // closing the lobby menu closes what covers it, so it opens again on the menu itself
            if (!isOpen) ToggleCustomizeOpen(false);
            OnOpenChanged?.Invoke(isOpen);
        }

        public void ToggleCustomizeOpen(bool isOpen)
        {
            if (_isCustomizeOpen == isOpen || (isOpen && !_isOpen)) return;

            _isCustomizeOpen = isOpen;
            OnCustomizeOpenChanged?.Invoke(isOpen);
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

        public void SetMapOptions(IEnumerable<LobbyOption> options)
        {
            _mapOptions.Clear();
            _mapOptions.AddRange(options);
            OnMapOptionsChanged?.Invoke();
        }

        public void SetMapVotes(IEnumerable<int> voteCounts, int mapVote)
        {
            _mapVoteCounts.Clear();
            _mapVoteCounts.AddRange(voteCounts);
            _mapVote = mapVote;
            OnMapVotesChanged?.Invoke();
        }

        public void RequestAbilityPick(int abilityId) => OnAbilityPickRequested?.Invoke(abilityId);

        // voting for the map already voted for takes the vote back
        public void RequestMapVote(int mapIndex) => OnMapVoteRequested?.Invoke(mapIndex == _mapVote ? NoMapVote : mapIndex);

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
        // optional picture of the option, e.g. a map preview
        public readonly Texture Preview;
        // optional line on what the option does, e.g. an ability's description
        public readonly string Description;

        public LobbyOption(int id, string label, Texture preview = null, string description = null)
        {
            Id = id;
            Label = label;
            Preview = preview;
            Description = description;
        }
    }
}
