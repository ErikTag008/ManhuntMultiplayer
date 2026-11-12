using KBCore.Refs;
using Project.Assets._Project._Scripts.Player;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using Reflex.Extensions;
using Reflex.Injectors;
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
        [SerializeField, Self] private PlayerRegistry _playerRegistry;
        [SerializeField, Self] private GameStateMachine _gameStateMachine;

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

            _uiManager.ChangeStartGameButtonAvailability(IsHost);
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

        private void SubscribeToServerChanges()
        {
            _gameStateMachine.OnStateChanged += OnStateChanged;
            _playerRegistry.OnSessionsChanged += ShowPlayerCount;
        }

        private void UnsubscribeFromServerChanges()
        {
            _gameStateMachine.OnStateChanged -= OnStateChanged;
            _playerRegistry.OnSessionsChanged -= ShowPlayerCount;
        }

        private void EmptyLobbyUI()
        {
            _uiManager.ChangeLobbyStatusText("");
            _uiManager.ChangeJoinedPlayerAmount("");
            _uiManager.ChangeCountdownText("");
        }

        private void ShowPlayerCount()
        {
            if(_gameStateMachine.CurrentState == GameState.Lobby || _gameStateMachine.CurrentState == GameState.WaitingForPlayers || _gameStateMachine.CurrentState == GameState.Countdown)
            {
                _uiManager.ChangeJoinedPlayerAmount($"{_playerRegistry.PlayerCount}/{_gameLobbySettings.MaxConnectedPlayers} players joined");
            }
        }

        private void OnStateChanged(GameState previous, GameState current)
        {
            print($"Game State Changed to {current}");
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
                    //_uiManager.ShowResults();
                    break;
            }
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
