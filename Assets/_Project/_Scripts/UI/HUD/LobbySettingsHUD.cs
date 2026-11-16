using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Lobby menu: the session's LobbyConfig for everyone; the host can step the values while the lobby is still waiting
    public class LobbySettingsHUD : MonoBehaviour
    {
        [Inject] private readonly LobbyMenuState _state;
        [Inject] private readonly ActiveLobbyConfig _activeLobbyConfig;
        [Inject] private readonly LobbyConfigData _lobbyConfigData;
        [Inject] private readonly IMapCatalog _mapCatalog;
        [SerializeField] private Transform _container;
        [SerializeField] private ChoiceRow _choiceRowPrefab;
        [SerializeField] private TMP_Text _lobbyNameText;
        // a gamepad steps left out of the rows into the ability list
        [SerializeField] private OptionList _leftNeighbourList;
        [SerializeField] private string _mapLabel = "Map";
        [SerializeField] private string _maxPlayersLabel = "Max players";
        [SerializeField] private string _roundLengthLabel = "Round length";
        [SerializeField] private string _hideTimeLabel = "Hide time";
        [SerializeField] private string _visibilityLabel = "Visibility";
        [SerializeField] private string _publicLabel = "Public";
        [SerializeField] private string _friendsOnlyLabel = "Friends only";
        [SerializeField] private string _privateLabel = "Private";
        [SerializeField] private string _maxPlayersFormat = "{0} players";
        // {0} is minutes:seconds
        [SerializeField] private string _durationFormat = "{0}";

        private readonly List<LobbyVisibility> _visibilityOptions = new() { LobbyVisibility.Public, LobbyVisibility.FriendsOnly, LobbyVisibility.Private };
        private readonly List<int> _maxPlayerOptions = new();
        private readonly List<float> _hideDurationOptions = new();
        private readonly List<float> _roundDurationOptions = new();
        private readonly List<string> _labelBuffer = new();
        private readonly List<List<Selectable>> _navigationRows = new();
        private ChoiceRow _mapRow;
        private ChoiceRow _maxPlayersRow;
        private ChoiceRow _roundLengthRow;
        private ChoiceRow _hideTimeRow;
        private ChoiceRow _visibilityRow;
        private bool _isNavigationDirty;

        private void Start()
        {
            Build();
            _activeLobbyConfig.OnChanged += HandleConfigChanged;
            _state.OnCanEditLobbySettingsChanged += HandleCanEditChanged;
            _state.OnOpenChanged += HandleOpenChanged;
            _state.OnChoiceChanged += MarkNavigationDirty;
            _state.OnAbilityOptionsChanged += MarkNavigationDirty;
            ShowConfig(_activeLobbyConfig.Config);
            HandleCanEditChanged(_state.CanEditLobbySettings);
        }

        private void Build()
        {
            _lobbyConfigData.GetMaxPlayerOptions(_maxPlayerOptions);
            _lobbyConfigData.GetRoundDurationOptions(_roundDurationOptions);
            _lobbyConfigData.GetHideDurationOptions(_hideDurationOptions);

            _labelBuffer.Clear();
            for (int i = 0; i < _mapCatalog.MapCount; i++) _labelBuffer.Add(_mapCatalog.GetMapDisplayName(i));
            _mapRow = CreateChoiceRow(_mapLabel);

            _labelBuffer.Clear();
            foreach (var maxPlayers in _maxPlayerOptions) _labelBuffer.Add(string.Format(_maxPlayersFormat, maxPlayers));
            _maxPlayersRow = CreateChoiceRow(_maxPlayersLabel);

            _roundLengthRow = CreateDurationRow(_roundLengthLabel, _roundDurationOptions);
            _hideTimeRow = CreateDurationRow(_hideTimeLabel, _hideDurationOptions);

            _labelBuffer.Clear();
            foreach (var visibility in _visibilityOptions) _labelBuffer.Add(GetVisibilityLabel(visibility));
            _visibilityRow = CreateChoiceRow(_visibilityLabel);
        }

        private ChoiceRow CreateChoiceRow(string label)
        {
            var row = Instantiate(_choiceRowPrefab, _container);
            row.Setup(label, _labelBuffer);
            row.OnIndexChanged += HandleRowChanged;
            return row;
        }

        private ChoiceRow CreateDurationRow(string label, List<float> options)
        {
            _labelBuffer.Clear();
            foreach (var option in options) _labelBuffer.Add(string.Format(_durationFormat, EUtils.Format.MinutesSeconds(option)));
            return CreateChoiceRow(label);
        }

        private string GetVisibilityLabel(LobbyVisibility visibility) => visibility switch
        {
            LobbyVisibility.FriendsOnly => _friendsOnlyLabel,
            LobbyVisibility.Private => _privateLabel,
            _ => _publicLabel
        };

        private void HandleConfigChanged(LobbyConfig config) => ShowConfig(config);

        private void ShowConfig(LobbyConfig config)
        {
            _lobbyNameText.text = config.Name.ToString();
            _mapRow.SetIndexWithoutNotify(config.MapIndex);
            _maxPlayersRow.SetIndexWithoutNotify(LobbyConfigData.FindClosestIndex(_maxPlayerOptions, config.MaxPlayers));
            _roundLengthRow.SetIndexWithoutNotify(LobbyConfigData.FindClosestIndex(_roundDurationOptions, config.RoundDurationInSeconds));
            _hideTimeRow.SetIndexWithoutNotify(LobbyConfigData.FindClosestIndex(_hideDurationOptions, config.HideDurationInSeconds));
            _visibilityRow.SetIndexWithoutNotify(Mathf.Max(0, _visibilityOptions.IndexOf(config.Visibility)));
        }

        // The host applies the change at once; a rejected one (e.g. fewer max players than joined) leaves the config as it was
        private void HandleRowChanged(int _)
        {
            var config = _activeLobbyConfig.Config;
            config.MapIndex = _mapRow.Index;
            config.MaxPlayers = _maxPlayerOptions[_maxPlayersRow.Index];
            config.RoundDurationInSeconds = _roundDurationOptions[_roundLengthRow.Index];
            config.HideDurationInSeconds = _hideDurationOptions[_hideTimeRow.Index];
            config.Visibility = _visibilityOptions[_visibilityRow.Index];
            _state.RequestLobbyConfigChange(config);
            ShowConfig(_activeLobbyConfig.Config);
        }

        private void HandleCanEditChanged(bool canEdit)
        {
            _mapRow.ToggleEditable(canEdit);
            _maxPlayersRow.ToggleEditable(canEdit);
            _roundLengthRow.ToggleEditable(canEdit);
            _hideTimeRow.ToggleEditable(canEdit);
            _visibilityRow.ToggleEditable(canEdit);
            if (!canEdit) FocusAbilityListIfInRows();
            MarkNavigationDirty();
        }

        // the arrows the host had focused just disappeared, so a gamepad needs a target again
        private void FocusAbilityListIfInRows()
        {
            var eventSystem = EventSystem.current;
            if (eventSystem == null || eventSystem.currentSelectedGameObject == null) return;
            if (eventSystem.currentSelectedGameObject.transform.IsChildOf(_container)) _leftNeighbourList.FocusSelected();
        }

        private void HandleOpenChanged(bool isOpen)
        {
            if (isOpen) MarkNavigationDirty();
        }

        private void MarkNavigationDirty() => _isNavigationDirty = true;

        // after every handler of the frame ran, so the ability list has already rebuilt or reselected its buttons
        private void LateUpdate()
        {
            if (!_isNavigationDirty) return;

            _isNavigationDirty = false;
            LinkNavigation();
        }

        private void LinkNavigation()
        {
            _navigationRows.Clear();
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_container);
            NavigationGrid.AddRows(_container, _navigationRows);
            NavigationGrid.Link(_navigationRows);

            var leftTarget = _leftNeighbourList.GetSelectedSelectable();
            foreach (var row in _navigationRows)
            {
                var navigation = row[0].navigation;
                navigation.selectOnLeft = leftTarget;
                row[0].navigation = navigation;
            }
        }

        private void OnDestroy()
        {
            _activeLobbyConfig.OnChanged -= HandleConfigChanged;
            _state.OnCanEditLobbySettingsChanged -= HandleCanEditChanged;
            _state.OnOpenChanged -= HandleOpenChanged;
            _state.OnChoiceChanged -= MarkNavigationDirty;
            _state.OnAbilityOptionsChanged -= MarkNavigationDirty;
            if (_mapRow != null) _mapRow.OnIndexChanged -= HandleRowChanged;
            if (_maxPlayersRow != null) _maxPlayersRow.OnIndexChanged -= HandleRowChanged;
            if (_roundLengthRow != null) _roundLengthRow.OnIndexChanged -= HandleRowChanged;
            if (_hideTimeRow != null) _hideTimeRow.OnIndexChanged -= HandleRowChanged;
            if (_visibilityRow != null) _visibilityRow.OnIndexChanged -= HandleRowChanged;
        }
    }
}
