using Cysharp.Threading.Tasks;
using KBCore.Refs;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class GameStateMachine : NetworkBehaviour, IGameStateMachine
    {
        [Inject] private readonly IUIManager _uiManager;
        [Inject] private readonly ITeamAssignmentService _teamAssignmentService;
        [Inject] private readonly GameLobbySettings _settings;
        [Inject] private readonly GameScenes _gameScenes;
        [SerializeField, Self] private PlayerRegistry _playerRegistry;
        [SerializeField, Self] private NetworkCoordinator _networkCoordinator;

        private NetworkVariable<GameState> _state = new();
        private NetworkVariable<double> _countdownEndTime = new();
        private CancellationTokenSource _gameLoopCTS;
        private CancellationTokenSource _countdownCTS;
        private bool _gameStartRequested = false;
        private GameSystemsRegistry _gameSystemsRegistry;

        public GameState CurrentState => _state.Value;
        public event Action<GameState, GameState> OnStateChanged;

        private void OnValidate() => this.ValidateRefs();

        [Inject]
        private void RegisterInGameSystems(GameSystemsRegistry gameSystemsRegistry)
        {
            _gameSystemsRegistry = gameSystemsRegistry;
            _gameSystemsRegistry.Register(this);
        }

        public override void OnNetworkSpawn()
        {
            _state.OnValueChanged += HandleStateChanged;
            _countdownEndTime.OnValueChanged += StartCountdown;
        }

        public override void OnNetworkDespawn()
        {
            _state.OnValueChanged -= HandleStateChanged;
            _countdownEndTime.OnValueChanged -= StartCountdown;
        }


        public void StartGameLoop()
        {
            _gameLoopCTS = new();
            GameLoop(_gameLoopCTS.Token).Forget();
        }

        public void StopGameLoop()
        {
            _gameLoopCTS?.Cancel();
            _gameLoopCTS?.Dispose();
        }

        public void RequestGameStart()
        {
            if (IsServer && _state.Value == GameState.WaitingForPlayers && _playerRegistry.PlayerCount >= _settings.MinRequiredPlayers)
            {
                _gameStartRequested = true;
            }
        }

        private async UniTaskVoid GameLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _state.Value = GameState.Lobby;
                await _networkCoordinator.LoadNetworkScene(_gameScenes.LobbySceneName, token);

                _state.Value = GameState.WaitingForPlayers;
                await WaitForEnoughPlayers(token);

                _countdownEndTime.Value = NetworkManager.ServerTime.Time + _settings.GameStartWaitTimeInSeconds;
                _state.Value = GameState.Countdown;
                await CountdownToGameStart(token);

                _state.Value = GameState.AssigningTeams;
                _teamAssignmentService.AssignTeams();


                _state.Value = GameState.LoadingGameplay;
                await _networkCoordinator.LoadNetworkScene(_gameScenes.DefaultMap.SceneName, token);

                _countdownEndTime.Value = NetworkManager.ServerTime.Time + _settings.RunnersHideWaitTime;
                _state.Value = GameState.WaitForRunnerHide;
                await WaitForRunnerHide(token);

                _state.Value = GameState.Playing;
                await PlayRound(token);

                _state.Value = GameState.DeterminingWinner;
                DetermineWinner();

                _state.Value = GameState.Results;
                // the next iteration loads the lobby again
                await ShowResults(token);
            }
        }

        private async UniTask WaitForEnoughPlayers(CancellationToken token)
        {
            await UniTask.WaitUntil(() => _gameStartRequested, cancellationToken: token);
            _gameStartRequested = false;
        }

        private async UniTask CountdownToGameStart(CancellationToken token)
        {
            await UniTask.WaitUntil(() => NetworkManager.ServerTime.Time >= _countdownEndTime.Value, cancellationToken: token);
        }

        private async UniTask WaitForRunnerHide(CancellationToken token)
        {
            var spawnDistributor = _gameSystemsRegistry.SpawnDistributor;
            if (spawnDistributor == null)
            {
                EUtils.Logger.LogError("[GameStateMachine] No ISpawnDistributor registered for the gameplay scene!");
                return;
            }

            await spawnDistributor.DistributePlayersToSpawns(_playerRegistry.GetPlayers());
            await UniTask.WaitUntil(() => NetworkManager.ServerTime.Time >= _countdownEndTime.Value, cancellationToken: token);

        }

        private async UniTask PlayRound(CancellationToken token)
        {
            await UniTask.WaitForSeconds(_settings.GameDurationInSeconds, cancellationToken: token);
        }

        private void DetermineWinner() { }

        private async UniTask ShowResults(CancellationToken token)
        {
            await UniTask.WaitForEndOfFrame(cancellationToken: token);
        }

        private void HandleStateChanged(GameState prev, GameState curr) => OnStateChanged?.Invoke(prev, curr);

        private void StartCountdown(double _, double endTime)
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
                {
                    _uiManager.ChangeCountdownText(string.Empty);
                    break; 
                }
                _uiManager.ChangeCountdownText(Mathf.CeilToInt((float)remaining).ToString());
                await UniTask.Yield(cancellationToken: token);
            }
        }

        public override void OnDestroy()
        {
            _gameSystemsRegistry?.Unregister(this);
            base.OnDestroy();
        }
    }
}
