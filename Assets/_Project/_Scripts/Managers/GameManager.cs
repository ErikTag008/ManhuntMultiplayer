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
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Assets._Project._Scripts.Managers
{

    public class GameManager : NetworkBehaviour, IPlayerRegistry, ISceneInitialized
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
        [SerializeField] private List<PlayerController> _players = new(10);
        public static GameManager Instance { get; private set; }

        private void Awake()
        { 
            Instance = this;
            _lobbyScene = System.IO.Path.GetFileNameWithoutExtension(_lobbyScene);
            _gameScene = System.IO.Path.GetFileNameWithoutExtension(_gameScene);
            _mainMenuScene = System.IO.Path.GetFileNameWithoutExtension(_mainMenuScene);
            _state.OnValueChanged += OnStateChanged;
            OnStateChanged(_state.Value, _state.Value);
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
            DontDestroyOnLoad(gameObject);
            if (!IsServer) return;
            _gameLoopCTS = new();
            Debug.Log("[GameManager] Trying to Start Game Loop");
            GameLoop(_gameLoopCTS.Token).Forget();
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
            Debug.Log($"Registered player {player.OwnerClientId}. Total: {_players.Count}");
        }
        private void OnStateChanged(GameState previous, GameState current)
        {
            print($"Game State Changed to {current}");
            switch (current)
            {
                case GameState.Lobby:
                    break;
                case GameState.WaitingForPlayers:
                    //_uiManager.ShowWaitingScreen();
                    break;

                case GameState.Countdown:
                    //_uiManager.ShowCountdown();
                    break;

                case GameState.AssigningTeams: 
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

        public override void OnNetworkDespawn()
        {
            if (IsServer)
            {
                try
                {
                    _gameLoopCTS?.Cancel();
                    _gameLoopCTS?.Dispose();
                } catch (ObjectDisposedException) { }
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
            await UniTask.WaitUntil(() => _players.Count >= _gameLobbySettings.MinRequiredPlayers, cancellationToken: token);
            print("Enought Players Connected");
            await UniTask.WaitForSeconds(_gameLobbySettings.MaxWaitForPlayersTimeInSeconds, cancellationToken: token);
        }

        private async UniTask CountdownToGameStart(CancellationToken token)
        {
            await UniTask.WaitForSeconds(_gameLobbySettings.GameStartWaitTimeInSeconds, cancellationToken: token);
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

                Debug.Log($"Player {player.OwnerClientId} -> {team}");
            }
        }

        private async UniTask WaitForRunnerHide(CancellationToken token)
        {
            PlayerGameSpawnDistributor.Instance.DistributePlayersToSpawns(_players);
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

        public void InitializeSceneReferences(SceneType scene)
        {
            switch (scene)
            {
                case SceneType.MainMenu:
                    break;
                case SceneType.Lobby:
                    break;
                case SceneType.Gameplay:
                    break;
            }
        }

        public void ClearSceneReferences(SceneType scene)
        {
            switch (scene)
            {
                case SceneType.MainMenu:
                    break;
                case SceneType.Lobby:
                    break;
                case SceneType.Gameplay:
                    break;
            }
        }

        public void SetActiveSpawner(PlayerSpawner playerSpawner)
        {
            _playerSpawner = playerSpawner;
        }
    }

    public enum GameState
    {
        Lobby,
        WaitingForPlayers,
        Countdown,
        AssigningTeams,
        LoadingGameplay,
        WaitForRunnerHide,
        Playing,
        DeterminingWinner,
        Results
    }
}
