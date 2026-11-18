using KBCore.Refs;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.Player;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.UI;
using Project.Assets._Project._Scripts.UI.HUD;
using Reflex.Attributes;
using Reflex.Extensions;
using Reflex.Injectors;
using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Assets._Project._Scripts.Managers
{
    public class GameManager : NetworkBehaviour
    {
        [Inject] private readonly SceneLifecycleManager _sceneLifecycleManager;
        [Inject] private readonly IUIManager _uiManager;
        [Inject] private readonly ITeamAssignmentService _teamAssignmentService;
        [Inject] private readonly GameLobbySettings _gameLobbySettings;
        [Inject] private readonly GameScenes _gameScenes;
        [Inject] private readonly ActiveLobbyConfig _activeLobbyConfig;
        [Inject] private readonly IMapCatalog _mapCatalog;
        [Inject] private readonly IConnectionService _connectionService;
        [Inject] private readonly LobbyMenuState _lobbyMenuState;
        [SerializeField, Self] private PlayerRegistry _playerRegistry;
        [SerializeField, Self] private GameStateMachine _gameStateMachine;
        [SerializeField] private string _catchersWinTitle = "Catchers win!";
        [SerializeField] private string _runnersWinTitle = "Runners win!";
        [SerializeField] private string _localWinSubtitle = "You won";
        [SerializeField] private string _localLossSubtitle = "You lost";
        [SerializeField] private string _playerCountFormat = "{0}/{1} players joined  ·  {2} ready";
        [SerializeField] private string _nextCatchersFormat = "Next catcher: {0}";
        [SerializeField] private string _nextCatchersSeparator = ", ";
        [SerializeField] private string _mostCatchesFormat = "Most catches: {0} ({1})";
        [SerializeField] private string _mostRescuesFormat = "Most rescues: {0} ({1})";
        [SerializeField] private string _mostStationsFormat = "Most stations activated: {0} ({1})";
        [SerializeField] private string _longestChaseFormat = "Longest chase: {0} ({1:0} s)";
        [SerializeField] private string _highlightNamesSeparator = ", ";

        private readonly List<PlayerSession> _sessionBuffer = new();
        private readonly List<PlayerSession> _nextCatcherBuffer = new();
        private readonly List<string> _nextCatcherNameBuffer = new();
        private readonly List<PlayerSession> _highlightLeaderBuffer = new();
        private readonly List<string> _highlightNameBuffer = new();
        private readonly List<string> _highlightLineBuffer = new();

        private void OnValidate() => this.ValidateRefs();

        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) => _sceneLifecycleManager.InitializeScene(GetSceneType(scene));

        private void OnSceneUnloaded(Scene scene) => _sceneLifecycleManager.ClearScene(GetSceneType(scene));

        // Any scene that isn't the menu or lobby is a map, so maps don't need to be listed here
        private SceneType GetSceneType(Scene scene)
        {
            if (scene.name == _gameScenes.LobbySceneName) return SceneType.Lobby;
            if (scene.name == _gameScenes.MainMenuSceneName) return SceneType.MainMenu;
            return SceneType.Gameplay;
        }

        public override void OnNetworkSpawn()
        {
            // GameSystems' own scene may be DontDestroyOnLoad (no Reflex container) or a scene about to be replaced,
            // so every [Inject] dependency on GameSystems must stay project-scoped
            GameObjectInjector.InjectObject(gameObject, SceneManager.GetActiveScene().GetSceneContainer());
            EUtils.Logger.LogColorized($"[GameManager] Called OnNetworkSpawn for Client {NetworkManager.Singleton.LocalClientId}...", "yellow");
            EUtils.Logger.LogColorized($"[GameManager] IsHost = {IsHost}...", "yellow");
            EUtils.Logger.LogColorized($"[GameManager] IsClient = {IsClient}...", "yellow");
            // project-scoped events outlive this object, so every one is dropped again in OnNetworkDespawn
            _uiManager.OnRequestLobbyUIInitialization += HandleLobbyUIInitialization;
            _uiManager.OnRequestGameUIInitialization += HandleGameUIInitialization;
            _uiManager.OnRequestGameStart += HandleGameStartRequest;
            _lobbyMenuState.OnLobbyConfigChangeRequested += HandleLobbyConfigChangeRequested;
            SubscribeToServerChanges();
            EUtils.Logger.Log($"Spawn: State={_gameStateMachine.CurrentState}, PlayerCount={_playerRegistry.PlayerCount}");
            if (!IsServer) return;

            _gameStateMachine.StartGameLoop();
            EUtils.Logger.Log("[GameManager] Triggered Game Loop in State Machine");
        }

        private void HandleGameUIInitialization()
        {
            EUtils.Logger.LogColorized($"[GameManager] Initializing Game UI for Client {NetworkManager.Singleton.LocalClientId}...", "yellow");
            EUtils.Logger.LogColorized($"[GameManager] IsHost = {IsHost}...", "yellow");
            EUtils.Logger.LogColorized($"[GameManager] IsClient = {IsClient}...", "yellow");
            _uiManager.ChangePlayerTeamText(GetPlayerTeam(NetworkManager.Singleton.LocalClientId).ToString());
        }

        private Team GetPlayerTeam(ulong clientId)
        {
            if (_playerRegistry.TryGetSession(clientId, out var session)) return session.Team;

            EUtils.Logger.LogError($"[GameManager] No player session for client ID: {clientId}");
            return Team.None;
        }

        private void HandleLobbyUIInitialization()
        {
            EUtils.Logger.LogColorized($"[GameManager] Initializing Lobby UI for Client {NetworkManager.Singleton.LocalClientId}...", "yellow");
            EUtils.Logger.LogColorized($"[GameManager] IsHost = {IsHost}...", "yellow");
            EUtils.Logger.LogColorized($"[GameManager] IsClient = {IsClient}...", "yellow");

            RefreshLobbyUI();
        }

        private void HandleGameStartRequest()
        {
            if (!IsHost) return;
            _gameStateMachine.RequestGameStart();
        }

        // Host only: the lobby can still change the config until the countdown starts; the next round reads it
        private void HandleLobbyConfigChangeRequested(LobbyConfig config)
        {
            if (!IsHost || !IsLobbyConfigEditable(_gameStateMachine.CurrentState)) return;
            if (config.MapIndex < 0 || config.MapIndex >= _mapCatalog.MapCount) return;
            if (!Enum.IsDefined(typeof(GameMode), config.Mode)) return;
            if (config.MaxPlayers < Mathf.Max(NetworkManager.ConnectedClientsIds.Count, _connectionService.TakenSlotCount)) return;

            _activeLobbyConfig.Set(config);
            _connectionService.UpdateHostedLobby(config);
        }

        private static bool IsLobbyConfigEditable(GameState state) => state == GameState.Lobby || state == GameState.WaitingForPlayers;

        public override void OnNetworkDespawn()
        {
            UnsubscribeFromUI();
            UnsubscribeFromServerChanges();
            _lobbyMenuState.ToggleCanEditLobbySettings(false);
            if (IsServer)
            {
                _gameStateMachine.StopGameLoop();
            }
        }

        // the lobby UI is new on every lobby load, so it is filled from the current state
        private void RefreshLobbyUI()
        {
            EmptyLobbyUI();
            OnStateChanged(_gameStateMachine.CurrentState, _gameStateMachine.CurrentState);
            ShowPlayerCount();
        }

        // Kept for the whole spawn, so state changes (e.g. the results) reach every instance whichever scene is open
        private void SubscribeToServerChanges()
        {
            UnsubscribeFromServerChanges();
            _gameStateMachine.OnStateChanged += OnStateChanged;
            _gameStateMachine.OnLastRoundResultChanged += HandleLastRoundResultChanged;
            _playerRegistry.OnSessionsChanged += HandleSessionsChanged;
            _activeLobbyConfig.OnChanged += HandleLobbyConfigChanged;
        }

        private void UnsubscribeFromUI()
        {
            if (_uiManager != null)
            {
                _uiManager.OnRequestLobbyUIInitialization -= HandleLobbyUIInitialization;
                _uiManager.OnRequestGameUIInitialization -= HandleGameUIInitialization;
                _uiManager.OnRequestGameStart -= HandleGameStartRequest;
            }
            if (_lobbyMenuState != null) _lobbyMenuState.OnLobbyConfigChangeRequested -= HandleLobbyConfigChangeRequested;
        }

        private void UnsubscribeFromServerChanges()
        {
            _gameStateMachine.OnStateChanged -= OnStateChanged;
            _gameStateMachine.OnLastRoundResultChanged -= HandleLastRoundResultChanged;
            _playerRegistry.OnSessionsChanged -= HandleSessionsChanged;
            if (_activeLobbyConfig != null) _activeLobbyConfig.OnChanged -= HandleLobbyConfigChanged;
        }

        private void EmptyLobbyUI()
        {
            _uiManager.ChangeLobbyStatusText("");
            _uiManager.ChangeJoinedPlayerAmount("");
            _uiManager.ChangeCountdownText("");
            _uiManager.ChangeNextCatchersText("");
        }

        private void HandleLobbyConfigChanged(LobbyConfig _) => ShowPlayerCount();

        // the stats can arrive after the results state on a client, so the highlights follow them
        private void HandleSessionsChanged()
        {
            ShowPlayerCount();
            if (_gameStateMachine.CurrentState == GameState.Results && _gameStateMachine.LastRoundResult != RoundResult.None) ShowRoundHighlights();
        }

        private void ShowPlayerCount()
        {
            RefreshStartAvailability();
            if(_gameStateMachine.CurrentState == GameState.Lobby || _gameStateMachine.CurrentState == GameState.WaitingForPlayers || _gameStateMachine.CurrentState == GameState.Countdown)
            {
                _playerRegistry.CopySessionsTo(_sessionBuffer);
                _uiManager.ChangeJoinedPlayerAmount(string.Format(_playerCountFormat, _sessionBuffer.Count, _activeLobbyConfig.Config.MaxPlayers, LobbyReadiness.CountReady(_sessionBuffer)));
                ShowNextCatchers();
            }
        }

        // every instance works this out from the synced sessions, the same way the server picks at round start
        private void ShowNextCatchers()
        {
            CatcherQueue.CopyNextCatchers(_sessionBuffer, _gameLobbySettings.GetCatcherCount(_sessionBuffer.Count), _nextCatcherBuffer);
            if (_nextCatcherBuffer.Count == 0)
            {
                _uiManager.ChangeNextCatchersText("");
                return;
            }

            _nextCatcherNameBuffer.Clear();
            foreach (var session in _nextCatcherBuffer) _nextCatcherNameBuffer.Add(session.DisplayName.ToString());
            _uiManager.ChangeNextCatchersText(string.Format(_nextCatchersFormat, string.Join(_nextCatchersSeparator, _nextCatcherNameBuffer)));
        }

        // Host only: the start button works once enough players are in and everyone is ready; other players never see it
        private void RefreshStartAvailability()
        {
            _uiManager.ChangeStartGameButtonVisibility(IsHost);
            _lobbyMenuState.ToggleCanEditLobbySettings(IsHost && IsLobbyConfigEditable(_gameStateMachine.CurrentState));
            if (!IsHost)
            {
                _uiManager.ChangeStartGameButtonAvailability(false);
                return;
            }

            _playerRegistry.CopySessionsTo(_sessionBuffer);
            bool canStart = _gameStateMachine.CurrentState == GameState.WaitingForPlayers && LobbyReadiness.CanStart(_sessionBuffer, _gameLobbySettings.MinRequiredPlayers);
            _uiManager.ChangeStartGameButtonAvailability(canStart);
        }

        private void OnStateChanged(GameState previous, GameState current)
        {
            RefreshStartAvailability();
            switch (current)
            {
                case GameState.Lobby:
                    _uiManager.ChangeLobbyStatusText("Initializing Lobby...");
                    break;
                case GameState.WaitingForPlayers:
                    _uiManager.ChangeLobbyStatusText($"Waiting for players... ({_gameLobbySettings.MinRequiredPlayers} required)");
                    break;

                case GameState.Countdown:
                    _uiManager.ChangeLobbyStatusText($"Game starting in");
                    break;

                case GameState.AssigningTeams:
                    _uiManager.ChangeLobbyStatusText($"Assigning teams...");
                    break;
                case GameState.Playing:
                    //_uiManager.ShowGameplayUI();
                    
                    break;

                case GameState.DeterminingWinner:
                    break;

                case GameState.Results:
                    ShowResultsIfReady();
                    break;
            }
        }

        // The state and the result are separate NetworkVariables, so either can arrive first on a client
        private void HandleLastRoundResultChanged(RoundResult result)
        {
            if (_gameStateMachine.CurrentState == GameState.Results) ShowResultsIfReady();
        }

        private void ShowResultsIfReady()
        {
            var result = _gameStateMachine.LastRoundResult;
            if (result == RoundResult.None) return;

            var winningTeam = result == RoundResult.CatchersWin ? Team.Catcher : Team.Runner;
            var localTeam = GetPlayerTeam(NetworkManager.LocalClientId);
            var title = result == RoundResult.CatchersWin ? _catchersWinTitle : _runnersWinTitle;
            _uiManager.ShowResults(title, GetLocalResultSubtitle(localTeam, winningTeam));
            ShowRoundHighlights();
        }

        private void ShowRoundHighlights()
        {
            _playerRegistry.CopySessionsTo(_sessionBuffer);
            _highlightLineBuffer.Clear();
            AddHighlight(_mostCatchesFormat, session => session.Catches);
            AddHighlight(_mostRescuesFormat, session => session.Rescues);
            AddHighlight(_mostStationsFormat, session => session.StationsCompleted);
            AddHighlight(_longestChaseFormat, session => session.LongestChaseInSeconds);
            _uiManager.ShowRoundHighlights(string.Join(Environment.NewLine, _highlightLineBuffer));
        }

        private void AddHighlight(string format, Func<PlayerSession, float> getValue)
        {
            float bestValue = RoundHighlights.CopyLeaders(_sessionBuffer, getValue, _highlightLeaderBuffer);
            if (_highlightLeaderBuffer.Count == 0) return;

            _highlightNameBuffer.Clear();
            foreach (var session in _highlightLeaderBuffer) _highlightNameBuffer.Add(session.DisplayName.ToString());
            _highlightLineBuffer.Add(string.Format(format, string.Join(_highlightNamesSeparator, _highlightNameBuffer), bestValue));
        }

        private string GetLocalResultSubtitle(Team localTeam, Team winningTeam)
        {
            if (localTeam == Team.None) return string.Empty;
            return localTeam == winningTeam ? _localWinSubtitle : _localLossSubtitle;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            UnsubscribeFromUI();
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }

    }

    public enum GameState
    {
        Lobby = 1 << 0,
        WaitingForPlayers = 1<<1,
        Countdown = 1<<2,
        AssigningTeams = 1<<3,
        LoadingGameplay = 1 << 4,
        WaitForRunnerHide = 1 << 5,
        Playing = 1 << 6,
        DeterminingWinner = 1 << 7,
        Results = 1 << 8
    }
}
