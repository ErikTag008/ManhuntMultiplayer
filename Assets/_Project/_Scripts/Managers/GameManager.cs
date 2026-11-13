using KBCore.Refs;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.Player;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using Reflex.Extensions;
using Reflex.Injectors;
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
        [SerializeField, Self] private PlayerRegistry _playerRegistry;
        [SerializeField, Self] private GameStateMachine _gameStateMachine;
        [SerializeField] private string _catchersWinTitle = "Catchers win!";
        [SerializeField] private string _runnersWinTitle = "Runners win!";
        [SerializeField] private string _localWinSubtitle = "You won";
        [SerializeField] private string _localLossSubtitle = "You lost";
        [SerializeField] private string _playerCountFormat = "{0}/{1} players joined  ·  {2} ready";

        private readonly List<PlayerSession> _sessionBuffer = new();

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
            _uiManager.OnRequestLobbyUIInitialization += HandleLobbyUIInitialization;
            _uiManager.OnRequestGameUIInitialization += HandleGameUIInitialization;
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

            RefreshStartAvailability();
            if (IsHost)
            {
                EmptyLobbyUI();
                SubscribeToServerChanges();
                OnStateChanged(_gameStateMachine.CurrentState, _gameStateMachine.CurrentState);
                ShowPlayerCount();

                _uiManager.OnRequestGameStart += HandleGameStartRequest;
            }
            if (IsClient)
            {
                InitializeGameState();
            }
        }

        private void HandleGameStartRequest()
        {
            if (!IsHost) return;
            _gameStateMachine.RequestGameStart();
        }

        public override void OnNetworkDespawn()
        {
            UnsubscribeFromServerChanges();
            if (IsServer)
            {
                _gameStateMachine.StopGameLoop();
            }
        }

        private void InitializeGameState()
        {
            EmptyLobbyUI();
            SubscribeToServerChanges();
            OnStateChanged(_gameStateMachine.CurrentState, _gameStateMachine.CurrentState);
            ShowPlayerCount();
        }

        // Runs on every lobby load, so drop the previous subscriptions first instead of stacking them
        private void SubscribeToServerChanges()
        {
            UnsubscribeFromServerChanges();
            _gameStateMachine.OnStateChanged += OnStateChanged;
            _gameStateMachine.OnLastRoundResultChanged += HandleLastRoundResultChanged;
            _playerRegistry.OnSessionsChanged += ShowPlayerCount;
            _activeLobbyConfig.OnChanged += HandleLobbyConfigChanged;
        }

        private void UnsubscribeFromServerChanges()
        {
            _gameStateMachine.OnStateChanged -= OnStateChanged;
            _gameStateMachine.OnLastRoundResultChanged -= HandleLastRoundResultChanged;
            _playerRegistry.OnSessionsChanged -= ShowPlayerCount;
            if (_activeLobbyConfig != null) _activeLobbyConfig.OnChanged -= HandleLobbyConfigChanged;
        }

        private void EmptyLobbyUI()
        {
            _uiManager.ChangeLobbyStatusText("");
            _uiManager.ChangeJoinedPlayerAmount("");
            _uiManager.ChangeCountdownText("");
        }

        private void HandleLobbyConfigChanged(LobbyConfig _) => ShowPlayerCount();

        private void ShowPlayerCount()
        {
            RefreshStartAvailability();
            if(_gameStateMachine.CurrentState == GameState.Lobby || _gameStateMachine.CurrentState == GameState.WaitingForPlayers || _gameStateMachine.CurrentState == GameState.Countdown)
            {
                _playerRegistry.CopySessionsTo(_sessionBuffer);
                _uiManager.ChangeJoinedPlayerAmount(string.Format(_playerCountFormat, _sessionBuffer.Count, _activeLobbyConfig.Config.MaxPlayers, LobbyReadiness.CountReady(_sessionBuffer)));
            }
        }

        // Host only: the start button works once enough players are in and everyone is ready
        private void RefreshStartAvailability()
        {
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
            print($"Game State Changed to {current}");
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
        }

        private string GetLocalResultSubtitle(Team localTeam, Team winningTeam)
        {
            if (localTeam == Team.None) return string.Empty;
            return localTeam == winningTeam ? _localWinSubtitle : _localLossSubtitle;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
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
