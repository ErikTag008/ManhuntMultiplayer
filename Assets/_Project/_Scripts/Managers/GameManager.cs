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

    public class GameManager : NetworkBehaviour, IPlayerRegistry
    {
        [SerializeField, SceneReference] private string _gameScene;
        [SerializeField, SceneReference] private string _lobbyScene;
        [SerializeField, SceneReference] private string _mainMenuScene;
        [Inject] private readonly SceneLifecycleManager _sceneLifecycleManager;
        //[Inject] private readonly UIManager _uiManager;
        [Inject] private readonly GameLobbySettings _gameLobbySettings;
        private PlayerSpawner _playerSpawner;
        private NetworkVariable<GameState> _state = new();
        private CancellationTokenSource _gameLoopCTS;
        [SerializeField] private List<PlayerController> _players = new();
        [SerializeField] private NetworkList<PlayerInfo> _playerInfos = new();
        private NetworkVariable<int> _playerCount = new();
        private NetworkVariable<double> _countdownEndTime = new();
        private CancellationTokenSource _countdownCTS = new();
        private bool _gameStartRequested = false;

        public static GameManager Instance { get; private set; }

        private void Awake()
        { 
            Instance = this;
            _lobbyScene = System.IO.Path.GetFileNameWithoutExtension(_lobbyScene);
            _gameScene = System.IO.Path.GetFileNameWithoutExtension(_gameScene);
            _mainMenuScene = System.IO.Path.GetFileNameWithoutExtension(_mainMenuScene);
        }

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
                case var name when name == _lobbyScene:
                    _sceneLifecycleManager.InitializeScene(SceneType.Lobby);
                    break;

                case var name when name == _gameScene:
                    _sceneLifecycleManager.InitializeScene(SceneType.Gameplay);
                    break;

                case var name when name == _mainMenuScene:
                    _sceneLifecycleManager.InitializeScene(SceneType.MainMenu);
                    break;

                default:
                    Debug.LogError($"Unknown loaded scene: {scene.name}");
                    break;
            }
        }

        private void OnSceneUnloaded(Scene scene)
        {
            switch (scene.name)
            {
                case var name when name == _lobbyScene:
                    _sceneLifecycleManager.ClearScene(SceneType.Lobby);
                    break;

                case var name when name == _gameScene:
                    _sceneLifecycleManager.ClearScene(SceneType.Gameplay);
                    break;

                case var name when name == _mainMenuScene:
                    _sceneLifecycleManager.ClearScene(SceneType.MainMenu);
                    break;
                default:
                    Debug.LogError($"Unknown loaded scene: {scene.name}");
                    break;
            }
        }

        public override void OnNetworkSpawn()
        {
            GameObjectInjector.InjectObject(gameObject, gameObject.scene.GetSceneContainer());
            //DontDestroyOnLoad(gameObject);
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] Called OnNetworkSpawn for Client {NetworkManager.Singleton.LocalClientId}...", "yellow"));
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] IsHost = {IsHost}...", "yellow"));
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] IsClient = {IsClient}...", "yellow"));
            UIManager.Instance.OnRequestLobbyUIInitialization += HandleLobbyUIInitialization;
            UIManager.Instance.OnRequestGameUIInitialization += HandleGameUIInitialization;
            Debug.Log($"Spawn: State={_state.Value}, PlayerCount={_playerCount.Value}");
            if (!IsServer) return;
            
            _gameLoopCTS = new();
            Debug.Log("[GameManager] Trying to Start Game Loop");
            GameLoop(_gameLoopCTS.Token).Forget();
        }

        private void HandleGameUIInitialization()
        {
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] Initializing Game UI for Client {NetworkManager.Singleton.LocalClientId}...", "yellow"));
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] IsHost = {IsHost}...", "yellow"));
            Debug.Log(EUtils.Logger.Colorize($"[GameManager] IsClient = {IsClient}...", "yellow"));
            UIManager.Instance.ChangePlayerTeamText(GetPlayerTeam(NetworkManager.Singleton.LocalClientId).ToString());
        }

        private Team GetPlayerTeam(ulong clientId)
        {
            foreach (var playerInfo in _playerInfos)
            {
                if (playerInfo.ClientId == clientId)
                {
                    UIManager.Instance.ChangePlayerTeamText(playerInfo.Team.ToString());
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

            UIManager.Instance.ChangeStartGameButtonAvailability(IsHost);
            if (IsHost)
            {
                EmptyLobbyUI();
                SubscribeToServerChanges();
                OnStateChanged(_state.Value, _state.Value);
                OnPlayerCountChanged(_playerCount.Value, _playerCount.Value);
                
                UIManager.Instance.OnRequestGameStart += HandleGameStartRequest;
            }
            if (IsClient)
            {
                InitializeGameState();
                

            }
        }

        private void HandleGameStartRequest()
        {
            if (!IsHost) return;
            if (_state.Value == GameState.WaitingForPlayers && _playerCount.Value >= _gameLobbySettings.MinRequiredPlayers)
            {
                _gameStartRequested = true;
            }
            else
            {
                Debug.LogWarning($"Cannot start game. Current state: {_state.Value}, Player count: {_playerCount.Value}");
            }
        }

        public override void OnNetworkDespawn()
        {
            UnsubscribeFromServerChanges();
            if (IsServer)
            {
                try
                {
                    _gameLoopCTS?.Cancel();
                    _gameLoopCTS?.Dispose();
                }
                catch (ObjectDisposedException) { }
            }
        }

        private void InitializeGameState()
        {
            EmptyLobbyUI();
            SubscribeToServerChanges();
            OnStateChanged(_state.Value, _state.Value);
            OnPlayerCountChanged(_playerCount.Value, _playerCount.Value);
        }

        private void SubscribeToServerChanges()
        {
            _state.OnValueChanged += OnStateChanged;
            _playerCount.OnValueChanged += OnPlayerCountChanged;
            _countdownEndTime.OnValueChanged += StartCountdown;
        }

        private void UnsubscribeFromServerChanges()
        {
            _state.OnValueChanged -= OnStateChanged;
            _playerCount.OnValueChanged -= OnPlayerCountChanged;
            _countdownEndTime.OnValueChanged -= StartCountdown;
        }

        private static void EmptyLobbyUI()
        {
            UIManager.Instance.ChangeLobbyStatusText("");
            UIManager.Instance.ChangeJoinedPlayerAmount("");
            UIManager.Instance.ChangeCountdownText("");
        }

        public void StartCountdown(double _, double endTime)
        {
            _countdownCTS?.Cancel();
            _countdownCTS = new();
            CountdownLoop(endTime, _countdownCTS.Token).Forget();
        }

        private async UniTaskVoid CountdownLoop(double endTime, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var remaining = endTime - NetworkManager.Singleton.ServerTime.Time;

                if (remaining <= 0)
                    break;

                UIManager.Instance.ChangeCountdownText(Mathf.CeilToInt((float)remaining).ToString());
                await UniTask.Yield(cancellationToken: token);
            }

        }

        public void RegisterPlayer(PlayerController player)
        {
            if (!IsServer) return;
            RegisterPlayerInternal(player);
        }
        private void RegisterPlayerInternal(PlayerController player)
        {
            if (_players.Contains(player)) return;
            _players.Add(player);
            UpdatePlayerCount();
            Debug.Log($"Registered player {player.OwnerClientId}. Total: {_players.Count}");
        }

        private void UpdatePlayerCount() => _playerCount.Value = _players.Count;

        private void OnPlayerCountChanged(int previousCount, int newCount)
        {
            if(_state.Value == GameState.Lobby || _state.Value == GameState.WaitingForPlayers || _state.Value == GameState.Countdown)
            {
                UIManager.Instance.ChangeJoinedPlayerAmount($"{newCount}/{_gameLobbySettings.MaxConnectedPlayers} players joined");
            }
        }

        private void OnStateChanged(GameState previous, GameState current)
        {
            print($"Game State Changed to {current}");
            switch (current)
            {
                case GameState.Lobby:
                    UIManager.Instance.ChangeLobbyStatusText("Initializing Lobby...");
                    break;
                case GameState.WaitingForPlayers:
                    UIManager.Instance.ChangeLobbyStatusText($"Waiting for players... ({_gameLobbySettings.MinRequiredPlayers} required)");
                    break;

                case GameState.Countdown:
                    UIManager.Instance.ChangeLobbyStatusText($"Game starting in");
                    StartCountdown(0.0, _countdownEndTime.Value);
                    break;

                case GameState.AssigningTeams:
                    UIManager.Instance.ChangeLobbyStatusText($"Assigning teams...");
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
            _state.OnValueChanged -= OnStateChanged;
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }

        private async UniTaskVoid GameLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {

                _state.Value = GameState.Lobby;

                await LoadLobby(token);

                _state.Value = GameState.WaitingForPlayers;
                await WaitForEnoughPlayers(token);

                _countdownEndTime.Value = NetworkManager.ServerTime.Time + _gameLobbySettings.GameStartWaitTimeInSeconds;
                _state.Value = GameState.Countdown;
                await CountdownToGameStart(token);

                _state.Value = GameState.AssigningTeams;
                AssignTeams();

                _state.Value = GameState.LoadingGameplay;
                await LoadGameplayScene(token);

                _state.Value = GameState.WaitForRunnerHide;
                await WaitForRunnerHide(token);

                _state.Value = GameState.Playing;
                await PlayRound(token);

                _state.Value = GameState.DeterminingWinner;
                DetermineWinner();

                _state.Value = GameState.Results;
                await ShowResults(token);

                await ReturnToLobby(token);
            }
        }

        

        private async UniTask<Scene> LoadNetworkScene(string sceneNameToLoad, CancellationToken token, LoadSceneMode loadSceneMode = LoadSceneMode.Additive, bool setActiveScene = true)
        {
            var loadedScene = SceneManager.GetSceneByName(sceneNameToLoad);
            if (NetworkManager.Singleton == null || NetworkManager.Singleton.SceneManager == null)
            {
                Debug.LogError("[GameManager] NetworkManager or SceneManager is missing!");
                return loadedScene;
            }
            if (loadedScene.isLoaded)
            {
                if (setActiveScene) SceneManager.SetActiveScene(loadedScene);
                Debug.LogWarning($"The Scene you tried to load is already Loaded");
                return loadedScene;
            }
            var status = NetworkManager.Singleton.SceneManager.LoadScene(sceneNameToLoad, loadSceneMode);

            if (status != SceneEventProgressStatus.Started)
            {
                Debug.LogError($"Failed to load {sceneNameToLoad} scene");
                return loadedScene;
            }

            await UniTask.WaitUntil(() => SceneManager.GetSceneByName(sceneNameToLoad).isLoaded, cancellationToken: token);

            loadedScene = SceneManager.GetSceneByName(sceneNameToLoad);

            if (setActiveScene) SceneManager.SetActiveScene(loadedScene);

            return loadedScene;
        }

        private async UniTask<Scene> UnloadNetworkScene(string sceneNameToUnload, CancellationToken token)
        {
            
            var unloadedScene = SceneManager.GetSceneByName(sceneNameToUnload);
            if (NetworkManager.Singleton == null || NetworkManager.Singleton.SceneManager == null)
            {
                Debug.LogError("[GameManager] NetworkManager or SceneManager is missing!");
                return unloadedScene;
            }
            if (unloadedScene.IsValid())
            {
                var status = NetworkManager.Singleton.SceneManager.UnloadScene(unloadedScene);
                if (status != SceneEventProgressStatus.Started)
                {
                    Debug.LogError($"Failed to unload scene: {unloadedScene.name}");
                    return unloadedScene;
                }
                await UniTask.WaitUntil(() => !unloadedScene.isLoaded, cancellationToken: token);
            }
            else
            {
                await UniTask.Yield(cancellationToken: token);
            }
            return unloadedScene;
        }

        private async UniTask LoadLobby(CancellationToken token)
        {
            await LoadNetworkScene(_lobbyScene, token);

        }

        private async UniTask ReturnToLobby(CancellationToken token)
        {
            await LoadNetworkScene(_lobbyScene, token);
            await UnloadNetworkScene(_gameScene, token);
        }

        private async UniTask LoadGameplayScene(CancellationToken token)
        {
            await LoadNetworkScene(_gameScene, token);
            await UnloadNetworkScene(_lobbyScene, token);
        }

        

        private async UniTask WaitForEnoughPlayers(CancellationToken token)
        {
            await UniTask.WaitUntil(() => _gameStartRequested, cancellationToken: token);
            _gameStartRequested = false;
            print("Enough Players Connected");
        }

        private async UniTask CountdownToGameStart(CancellationToken token)
        {
            await UniTask.WaitUntil(() => NetworkManager.ServerTime.Time >= _countdownEndTime.Value, cancellationToken: token);
        }

        private HashSet<ulong> _catcherIds;

        private void AssignTeams()
        {
            Debug.Log("Players Count: " + _players.Count);
            var shuffled = _players.OrderBy(_ => UnityEngine.Random.value).ToList();

            int catcherCount = Mathf.Min(_gameLobbySettings.MaxCatcherPlayers, shuffled.Count - 1);

            _catcherIds = shuffled.Take(catcherCount).Select(p => p.OwnerClientId).ToHashSet();

            foreach (var player in _players)
            {
                var team = _catcherIds.Contains(player.OwnerClientId) ? Team.Catcher : Team.Runner;

                player.SetTeam(team);
                _playerInfos.Add(new PlayerInfo { ClientId = player.OwnerClientId, Team = team });
                Debug.Log($"Player {player.OwnerClientId} -> {team}");
            }
        }

        private async UniTask WaitForRunnerHide(CancellationToken token)
        {
            await PlayerGameSpawnDistributor.Instance.DistributePlayersToSpawns(_players);
            await UniTask.WaitForSeconds(_gameLobbySettings.RunnersHideWaitTime, cancellationToken: token);
        }
        private async UniTask PlayRound(CancellationToken token)
        {
            await UniTask.WaitForSeconds(_gameLobbySettings.GameDurationInSeconds, cancellationToken: token);
        }


        private void DetermineWinner()
        {

        }

        private async UniTask ShowResults(CancellationToken token)
        {
            await UniTask.WaitForEndOfFrame(cancellationToken: token);

        }

        public void SetActiveSpawner(PlayerSpawner playerSpawner)
        {
            _playerSpawner = playerSpawner;
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
