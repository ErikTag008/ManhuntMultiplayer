using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Join Lobby screen: a filtered, sorted list of the lobbies the directory finds (refreshed while open) and a join-by-address field
    public class JoinLobbyHUD : MonoBehaviour
    {
        [Inject] private readonly MainMenuState _state;
        [Inject] private readonly ILobbyDirectory _lobbyDirectory;
        [Inject] private readonly IMapCatalog _mapCatalog;
        [Inject] private readonly LobbyConfigData _lobbyConfigData;
        [Inject] private readonly ConnectionSettings _connectionSettings;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private Transform _filterContainer;
        [SerializeField] private Transform _listContainer;
        [SerializeField] private ChoiceRow _choiceRowPrefab;
        [SerializeField] private ToggleRow _toggleRowPrefab;
        [SerializeField] private LobbyListRow _lobbyRowPrefab;
        [SerializeField] private TextInputRow _addressRow;
        [SerializeField] private Button _joinButton;
        [SerializeField] private Button _refreshButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private TMP_Text _listStatusText;
        [SerializeField, Min(0.5f)] private float _autoRefreshIntervalInSeconds = 5f;
        [SerializeField, Min(1)] private int _addressCharacterLimit = 64;
        [SerializeField] private string _regionLabel = "Region";
        [SerializeField] private string _mapLabel = "Map";
        [SerializeField] private string _minLobbySizeLabel = "Lobby size";
        [SerializeField] private string _visibilityLabel = "Visibility";
        [SerializeField] private string _sortLabel = "Sort by";
        [SerializeField] private string _hideFullLabel = "Hide full lobbies";
        [SerializeField] private string _hideInProgressLabel = "Hide games in progress";
        [SerializeField] private string _anyLabel = "Any";
        [SerializeField] private string _publicLabel = "Public";
        [SerializeField] private string _friendsOnlyLabel = "Friends only";
        [SerializeField] private string _sortByNameLabel = "Name";
        [SerializeField] private string _sortByPlayersLabel = "Players";
        [SerializeField] private string _sortByPingLabel = "Ping";
        // {0} is the max players
        [SerializeField] private string _minLobbySizeFormat = "{0}+ players";
        [SerializeField] private string _addressLabel = "Address or code";
        // {0} players, {1} max players
        [SerializeField] private string _playersFormat = "{0}/{1}";
        // {0} is the map name
        [SerializeField] private string _inProgressMapFormat = "{0} (in progress)";
        // {0} ping in ms, {1} region
        [SerializeField] private string _pingFormat = "{0} ms · {1}";
        // {0} region, for lobbies without a ping
        [SerializeField] private string _unknownPingFormat = "{0}";
        [SerializeField] private string _searchingText = "Searching for lobbies...";
        [SerializeField] private string _noLobbiesText = "No lobbies found";
        // {0} shown lobbies, {1} found lobbies
        [SerializeField] private string _lobbyCountFormat = "{0} of {1} lobbies shown";

        private readonly List<LobbyListing> _foundLobbies = new();
        private readonly List<LobbyListing> _shownLobbies = new();
        private readonly List<LobbyListRow> _rows = new();
        private readonly List<string> _regionOptions = new();
        private readonly List<string> _mapOptions = new();
        private readonly List<int> _minLobbySizeOptions = new();
        private readonly List<string> _labelBuffer = new();
        private readonly List<List<Selectable>> _navigationRows = new();
        private ChoiceRow _regionRow;
        private ChoiceRow _mapRow;
        private ChoiceRow _minLobbySizeRow;
        private ChoiceRow _visibilityRow;
        private ChoiceRow _sortRow;
        private ToggleRow _hideFullRow;
        private ToggleRow _hideInProgressRow;
        private LobbyListFilter _filter;
        private LobbySortOrder _sortOrder;
        private CancellationTokenSource _refreshCTS;
        private bool _isBuilt;
        private bool _hasFetched;

        private void Start()
        {
            _state.OnScreenChanged += HandleScreenChanged;
            _joinButton.onClick.AddListener(JoinByAddress);
            _refreshButton.onClick.AddListener(StartRefreshing);
            _backButton.onClick.AddListener(Back);
            // an empty field joins the default address, so that is the hint
            _addressRow.Setup(_addressLabel, _connectionSettings.Address, _addressCharacterLimit);
            HandleScreenChanged(_state.CurrentScreen, _state.CurrentScreen);
        }

        private void HandleScreenChanged(MainMenuScreen previous, MainMenuScreen current)
        {
            bool isOpen = current == MainMenuScreen.JoinLobby;
            if (isOpen == _panel.IsShown) return;

            if (isOpen) Open();
            else Close();
        }

        private void Open()
        {
            if (!_isBuilt) Build();
            _panel.Show();
            _hasFetched = false;
            ShowLobbies();
            // a gamepad has no cursor, so navigation needs a focused row to start from
            _regionRow.Selectable.Select();
            StartRefreshing();
        }

        private void Close()
        {
            StopRefreshing();
            _panel.Hide();
        }

        private void Build()
        {
            _isBuilt = true;

            _regionOptions.Clear();
            _regionOptions.Add(null);
            _regionRow = CreateChoiceRow(_regionLabel, BuildRegionLabels());
            _regionRow.OnIndexChanged += index => ChangeFilter((ref LobbyListFilter filter) => filter.Region = _regionOptions[index]);

            _mapOptions.Clear();
            _mapOptions.Add(null);
            for (int i = 0; i < _mapCatalog.MapCount; i++) _mapOptions.Add(_mapCatalog.GetMapDisplayName(i));
            _labelBuffer.Clear();
            foreach (var mapName in _mapOptions) _labelBuffer.Add(mapName ?? _anyLabel);
            _mapRow = CreateChoiceRow(_mapLabel, _labelBuffer);
            _mapRow.OnIndexChanged += index => ChangeFilter((ref LobbyListFilter filter) => filter.MapName = _mapOptions[index]);

            _lobbyConfigData.GetMaxPlayerOptions(_minLobbySizeOptions);
            _minLobbySizeOptions.Insert(0, 0);
            _labelBuffer.Clear();
            foreach (var size in _minLobbySizeOptions) _labelBuffer.Add(size > 0 ? string.Format(_minLobbySizeFormat, size) : _anyLabel);
            _minLobbySizeRow = CreateChoiceRow(_minLobbySizeLabel, _labelBuffer);
            _minLobbySizeRow.OnIndexChanged += index => ChangeFilter((ref LobbyListFilter filter) => filter.MinLobbySize = _minLobbySizeOptions[index]);

            // in LobbyVisibilityFilter order
            _labelBuffer.Clear();
            _labelBuffer.Add(_anyLabel);
            _labelBuffer.Add(_publicLabel);
            _labelBuffer.Add(_friendsOnlyLabel);
            _visibilityRow = CreateChoiceRow(_visibilityLabel, _labelBuffer);
            _visibilityRow.OnIndexChanged += index => ChangeFilter((ref LobbyListFilter filter) => filter.Visibility = (LobbyVisibilityFilter)index);

            // in LobbySortOrder order
            _labelBuffer.Clear();
            _labelBuffer.Add(_sortByNameLabel);
            _labelBuffer.Add(_sortByPlayersLabel);
            _labelBuffer.Add(_sortByPingLabel);
            _sortRow = CreateChoiceRow(_sortLabel, _labelBuffer);
            _sortRow.OnIndexChanged += ChangeSortOrder;

            _hideFullRow = CreateToggleRow(_hideFullLabel);
            _hideFullRow.OnToggled += isOn => ChangeFilter((ref LobbyListFilter filter) => filter.IsHidingFull = isOn);
            _hideInProgressRow = CreateToggleRow(_hideInProgressLabel);
            _hideInProgressRow.OnToggled += isOn => ChangeFilter((ref LobbyListFilter filter) => filter.IsHidingInProgress = isOn);
        }

        private ChoiceRow CreateChoiceRow(string label, IReadOnlyList<string> options)
        {
            var row = Instantiate(_choiceRowPrefab, _filterContainer);
            row.Setup(label, options);
            return row;
        }

        private ToggleRow CreateToggleRow(string label)
        {
            var row = Instantiate(_toggleRowPrefab, _filterContainer);
            row.Setup(label);
            row.SetIsOnWithoutNotify(false);
            return row;
        }

        private delegate void FilterChange(ref LobbyListFilter filter);

        private void ChangeFilter(FilterChange change)
        {
            change(ref _filter);
            ShowLobbies();
        }

        private void ChangeSortOrder(int index)
        {
            _sortOrder = (LobbySortOrder)index;
            ShowLobbies();
        }

        private void StartRefreshing()
        {
            StopRefreshing();
            _refreshCTS = new();
            RefreshLoop(_refreshCTS.Token).Forget();
        }

        private void StopRefreshing()
        {
            _refreshCTS?.Cancel();
            _refreshCTS?.Dispose();
            _refreshCTS = null;
        }

        // the menu runs in real time
        private async UniTaskVoid RefreshLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await _lobbyDirectory.FetchLobbies(_foundLobbies, token);
                _hasFetched = true;
                RefreshRegionOptions();
                ShowLobbies();
                await UniTask.WaitForSeconds(_autoRefreshIntervalInSeconds, ignoreTimeScale: true, cancellationToken: token);
            }
        }

        // Any, then every region seen; the picked one stays listed while no lobby reports it, so the filter never changes by itself
        private void RefreshRegionOptions()
        {
            var selectedRegion = _regionOptions[_regionRow.Index];
            _regionOptions.Clear();
            _regionOptions.Add(null);
            foreach (var lobby in _foundLobbies)
            {
                if (!string.IsNullOrEmpty(lobby.Region) && !_regionOptions.Contains(lobby.Region)) _regionOptions.Add(lobby.Region);
            }
            if (selectedRegion != null && !_regionOptions.Contains(selectedRegion)) _regionOptions.Add(selectedRegion);

            _regionRow.Setup(_regionLabel, BuildRegionLabels());
            _regionRow.SetIndexWithoutNotify(_regionOptions.IndexOf(selectedRegion));
        }

        private List<string> BuildRegionLabels()
        {
            _labelBuffer.Clear();
            foreach (var region in _regionOptions) _labelBuffer.Add(region ?? _anyLabel);
            return _labelBuffer;
        }

        private void ShowLobbies()
        {
            LobbyListFilter.Apply(_foundLobbies, _filter, _sortOrder, _shownLobbies);
            for (int i = 0; i < _shownLobbies.Count; i++)
            {
                var row = i < _rows.Count ? _rows[i] : CreateLobbyRow();
                ShowLobby(row, i, _shownLobbies[i]);
            }
            for (int i = _shownLobbies.Count; i < _rows.Count; i++) _rows[i].gameObject.SetActive(false);

            _listStatusText.text = GetListStatus();
            LinkNavigation();
        }

        private LobbyListRow CreateLobbyRow()
        {
            var row = Instantiate(_lobbyRowPrefab, _listContainer);
            row.OnClicked += JoinListedLobby;
            _rows.Add(row);
            return row;
        }

        // full lobbies stay visible unless filtered, but can't be picked
        private void ShowLobby(LobbyListRow row, int index, LobbyListing lobby)
        {
            var mapName = lobby.IsInProgress ? string.Format(_inProgressMapFormat, lobby.MapName) : lobby.MapName;
            var ping = lobby.HasPing ? string.Format(_pingFormat, lobby.PingInMilliseconds, lobby.Region) : string.Format(_unknownPingFormat, lobby.Region);
            row.gameObject.SetActive(true);
            row.Setup(index, lobby.Name, lobby.HostName, mapName, string.Format(_playersFormat, lobby.PlayerCount, lobby.MaxPlayers), ping);
            row.ToggleInteractable(!lobby.IsFull);
        }

        private string GetListStatus()
        {
            if (!_hasFetched) return _searchingText;
            if (_shownLobbies.Count == 0) return _noLobbiesText;
            return string.Format(_lobbyCountFormat, _shownLobbies.Count, _foundLobbies.Count);
        }

        // filters, then the lobby list, then the address row, then refresh and back
        private void LinkNavigation()
        {
            _navigationRows.Clear();
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_filterContainer);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_listContainer);
            NavigationGrid.AddRows(_filterContainer, _navigationRows);
            NavigationGrid.AddRows(_listContainer, _navigationRows);
            _navigationRows.Add(new List<Selectable> { _addressRow.Selectable, _joinButton });
            _navigationRows.Add(new List<Selectable> { _refreshButton, _backButton });
            NavigationGrid.Link(_navigationRows);
        }

        private void JoinListedLobby(int index)
        {
            if (index < 0 || index >= _shownLobbies.Count) return;
            _state.RequestJoin(_shownLobbies[index].Address);
        }

        private void JoinByAddress() => _state.RequestJoin(_addressRow.Text);

        private void Back() => _state.ShowScreen(MainMenuScreen.Main);

        private void OnDestroy()
        {
            StopRefreshing();
            _state.OnScreenChanged -= HandleScreenChanged;
            _joinButton.onClick.RemoveListener(JoinByAddress);
            _refreshButton.onClick.RemoveListener(StartRefreshing);
            _backButton.onClick.RemoveListener(Back);
            foreach (var row in _rows) row.OnClicked -= JoinListedLobby;
        }
    }
}
