using Assets._Project._Scripts.SceneReference;
using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Player;
using Reflex.Attributes;
using Reflex.Extensions;
using Reflex.Injectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.Netcode;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Assets._Project._Scripts.Managers
{
    public class GameManager : NetworkBehaviour
    {
        [Inject] private readonly SceneLifecycleManager _sceneLifecycleManager;
        [Inject] private readonly IUIManager _uiManager;
        [Inject] private readonly IPlayerRegistry _playerRegistry;
        [Inject] private readonly ITeamAssignmentService _teamAssignmentService;
        [Inject] private readonly INetworkCoordinator _networkCoordinator;
        [Inject] private readonly IGameStateMachine _gameStateMachine;
        [Inject] private readonly GameLobbySettings _gameLobbySettings;
        [Inject] private readonly GameScenes _gameScenes;

        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            switch (scene.name)
            {
                case var name when name == _gameScenes.LobbySceneName:
                    _sceneLifecycleManager.InitializeScene(SceneType.Lobby);
                    break;

                case var name when name == _gameScenes.GameSceneName:
                    _sceneLifecycleManager.InitializeScene(SceneType.Gameplay);
                    break;

                case var name when name == _gameScenes.MainMenuSceneName:
                    _sceneLifecycleManager.InitializeScene(SceneType.MainMenu);
                    break;

                default:
                    Debug.LogError($"Unknown loaded scene: {scene.name}");
                    Debug.LogError($"Known scenes:   {_gameScenes.LobbySceneName}, {_gameScenes.GameSceneName}, {_gameScenes.MainMenuSceneName}");
                    break;
            }
        }

        private void OnSceneUnloaded(Scene scene)
        {
            switch (scene.name)
            {
                case var name when name == _gameScenes.LobbySceneName:
                    _sceneLifecycleManager.ClearScene(SceneType.Lobby);
                    break;

                case var name when name == _gameScenes.GameSceneName:
                    _sceneLifecycleManager.ClearScene(SceneType.Gameplay);
                    break;

                case var name when name == _gameScenes.MainMenuSceneName:
                    _sceneLifecycleManager.ClearScene(SceneType.MainMenu);
                    break;
                default:
                    Debug.LogError($"Unknown loaded scene: {scene.name}");
                    Debug.LogError($"Known scenes: {_gameScenes.LobbySceneName}, {_gameScenes.GameSceneName}, {_gameScenes.MainMenuSceneName}");

                    break;
            }
        }

        public override void OnNetworkSpawn()
        {
            GameObjectInjector.InjectObject(gameObject, gameObject.scene.GetSceneContainer());
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] Called OnNetworkSpawn for Client {NetworkManager.Singleton.LocalClientId}...", "yellow"));
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] IsHost = {IsHost}...", "yellow"));
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] IsClient = {IsClient}...", "yellow"));
            _uiManager.OnRequestLobbyUIInitialization += HandleLobbyUIInitialization;
            _uiManager.OnRequestGameUIInitialization += HandleGameUIInitialization;
            Debug.Log($"Spawn: State={_gameStateMachine.CurrentState}, PlayerCount={_playerRegistry.PlayerCount}");
            if (!IsServer) return;

            _gameStateMachine.StartGameLoop();
            Debug.Log("[GameManager] Triggered Game Loop in State Machine");
        }

        private void HandleGameUIInitialization()
        {
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] Initializing Game UI for Client {NetworkManager.Singleton.LocalClientId}...", "yellow"));
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] IsHost = {IsHost}...", "yellow"));
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] IsClient = {IsClient}...", "yellow"));
            _uiManager.ChangePlayerTeamText(GetPlayerTeam(NetworkManager.Singleton.LocalClientId).ToString());
        }

        private Team GetPlayerTeam(ulong clientId)
        {
            foreach (var playerInfo in _playerRegistry.PlayerInfos)
            {
                if (playerInfo.ClientId == clientId)
                {
                    _uiManager.ChangePlayerTeamText(playerInfo.Team.ToString());
                    return playerInfo.Team;
                }
            }

            Debug.LogError($"[GameManager] Player info not found for client ID: {clientId}");
            return Team.None;
        }

        private void HandleLobbyUIInitialization()
        {
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] Initializing Lobby UI for Client {NetworkManager.Singleton.LocalClientId}...", "yellow"));
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] IsHost = {IsHost}...", "yellow"));
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] IsClient = {IsClient}...", "yellow"));

            _uiManager.ChangeStartGameButtonAvailability(IsHost);
            if (IsHost)
            {
                EmptyLobbyUI();
                SubscribeToServerChanges();
                OnStateChanged(_gameStateMachine.CurrentState, _gameStateMachine.CurrentState);
                OnPlayerCountChanged(_playerRegistry.PlayerCount, _playerRegistry.PlayerCount);

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
            OnPlayerCountChanged(_playerRegistry.PlayerCount, _playerRegistry.PlayerCount);
        }

        private void SubscribeToServerChanges()
        {
            _gameStateMachine.OnStateChanged += OnStateChanged;
            _playerRegistry.PlayerCountVariable.OnValueChanged += OnPlayerCountChanged;
        }

        private void UnsubscribeFromServerChanges()
        {
            _gameStateMachine.OnStateChanged -= OnStateChanged;
            _playerRegistry.PlayerCountVariable.OnValueChanged -= OnPlayerCountChanged;
        }

        private void EmptyLobbyUI()
        {
            _uiManager.ChangeLobbyStatusText("");
            _uiManager.ChangeJoinedPlayerAmount("");
            _uiManager.ChangeCountdownText("");
        }

        private void OnPlayerCountChanged(int previousCount, int newCount)
        {
            if(_gameStateMachine.CurrentState == GameState.Lobby || _gameStateMachine.CurrentState == GameState.WaitingForPlayers || _gameStateMachine.CurrentState == GameState.Countdown)
            {
                _uiManager.ChangeJoinedPlayerAmount($"{newCount}/{_gameLobbySettings.MaxConnectedPlayers} players joined");
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
