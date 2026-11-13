using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Host Lobby screen: the lobby options, then Create and Join hosts with them
    public class HostLobbyHUD : MonoBehaviour
    {
        [Inject] private readonly MainMenuState _state;
        [Inject] private readonly LobbyConfigData _lobbyConfigData;
        [Inject] private readonly IMapCatalog _mapCatalog;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private Transform _container;
        [SerializeField] private TextInputRow _textInputRowPrefab;
        [SerializeField] private ChoiceRow _choiceRowPrefab;
        [SerializeField] private Button _createButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private string _nameLabel = "Lobby name";
        [SerializeField] private string _visibilityLabel = "Visibility";
        [SerializeField] private string _maxPlayersLabel = "Max players";
        [SerializeField] private string _mapLabel = "Map";
        [SerializeField] private string _roundLengthLabel = "Round length";
        [SerializeField] private string _hideTimeLabel = "Hide time";
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
        private TextInputRow _nameRow;
        private ChoiceRow _visibilityRow;
        private ChoiceRow _maxPlayersRow;
        private ChoiceRow _mapRow;
        private ChoiceRow _roundLengthRow;
        private ChoiceRow _hideTimeRow;
        private bool _isBuilt;

        private void Start()
        {
            _state.OnScreenChanged += HandleScreenChanged;
            _createButton.onClick.AddListener(Create);
            _backButton.onClick.AddListener(Back);
            HandleScreenChanged(_state.CurrentScreen, _state.CurrentScreen);
        }

        private void HandleScreenChanged(MainMenuScreen previous, MainMenuScreen current)
        {
            bool isOpen = current == MainMenuScreen.HostLobby;
            if (isOpen == _panel.IsShown) return;

            if (isOpen) Open();
            else _panel.Hide();
        }

        private void Open()
        {
            if (!_isBuilt) Build();
            _panel.Show();
            LinkNavigation();
            // a gamepad has no cursor, so navigation needs a focused row to start from
            _nameRow.Selectable.Select();
        }

        // Rows are built once, so edits stay while the player goes back and forth
        private void Build()
        {
            _isBuilt = true;
            var defaults = _lobbyConfigData.CreateDefault();
            _lobbyConfigData.GetMaxPlayerOptions(_maxPlayerOptions);
            _lobbyConfigData.GetRoundDurationOptions(_roundDurationOptions);
            _lobbyConfigData.GetHideDurationOptions(_hideDurationOptions);

            _nameRow = Instantiate(_textInputRowPrefab, _container);
            _nameRow.Setup(_nameLabel, _lobbyConfigData.DefaultName, _lobbyConfigData.MaxNameLength);
            _nameRow.SetTextWithoutNotify(_lobbyConfigData.DefaultName);

            _labelBuffer.Clear();
            foreach (var visibility in _visibilityOptions) _labelBuffer.Add(GetVisibilityLabel(visibility));
            _visibilityRow = CreateChoiceRow(_visibilityLabel, _visibilityOptions.IndexOf(defaults.Visibility));

            _labelBuffer.Clear();
            foreach (var maxPlayers in _maxPlayerOptions) _labelBuffer.Add(string.Format(_maxPlayersFormat, maxPlayers));
            _maxPlayersRow = CreateChoiceRow(_maxPlayersLabel, LobbyConfigData.FindClosestIndex(_maxPlayerOptions, defaults.MaxPlayers));

            _labelBuffer.Clear();
            for (int i = 0; i < _mapCatalog.MapCount; i++) _labelBuffer.Add(_mapCatalog.GetMapDisplayName(i));
            _mapRow = CreateChoiceRow(_mapLabel, defaults.MapIndex);

            _roundLengthRow = CreateDurationRow(_roundLengthLabel, _roundDurationOptions, defaults.RoundDurationInSeconds);
            _hideTimeRow = CreateDurationRow(_hideTimeLabel, _hideDurationOptions, defaults.HideDurationInSeconds);
        }

        private ChoiceRow CreateChoiceRow(string label, int index)
        {
            var row = Instantiate(_choiceRowPrefab, _container);
            row.Setup(label, _labelBuffer);
            row.SetIndexWithoutNotify(index);
            return row;
        }

        private ChoiceRow CreateDurationRow(string label, List<float> options, float durationInSeconds)
        {
            _labelBuffer.Clear();
            foreach (var option in options) _labelBuffer.Add(string.Format(_durationFormat, EUtils.Format.MinutesSeconds(option)));
            return CreateChoiceRow(label, LobbyConfigData.FindClosestIndex(options, durationInSeconds));
        }

        private string GetVisibilityLabel(LobbyVisibility visibility) => visibility switch
        {
            LobbyVisibility.FriendsOnly => _friendsOnlyLabel,
            LobbyVisibility.Private => _privateLabel,
            _ => _publicLabel
        };

        // the option rows, then create and back
        private void LinkNavigation()
        {
            _navigationRows.Clear();
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_container);
            NavigationGrid.AddRows(_container, _navigationRows);
            _navigationRows.Add(new List<Selectable> { _createButton, _backButton });
            NavigationGrid.Link(_navigationRows);
        }

        // The option lists are never empty (a range always holds its min), so the row indices are valid
        private void Create()
        {
            var config = new LobbyConfig
            {
                Name = LobbyConfig.ToName(_lobbyConfigData.SanitizeName(_nameRow.Text)),
                Visibility = _visibilityOptions[_visibilityRow.Index],
                MaxPlayers = _maxPlayerOptions[_maxPlayersRow.Index],
                MapIndex = _mapRow.Index,
                RoundDurationInSeconds = _roundDurationOptions[_roundLengthRow.Index],
                HideDurationInSeconds = _hideDurationOptions[_hideTimeRow.Index]
            };
            _state.RequestHost(config);
        }

        private void Back() => _state.ShowScreen(MainMenuScreen.Main);

        private void OnDestroy()
        {
            _state.OnScreenChanged -= HandleScreenChanged;
            _createButton.onClick.RemoveListener(Create);
            _backButton.onClick.RemoveListener(Back);
        }
    }
}
