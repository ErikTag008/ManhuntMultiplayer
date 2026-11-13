using Cysharp.Threading.Tasks;
using KBCore.Refs;
using Project.Assets._Project._Scripts.Player;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class GameStateMachine : NetworkBehaviour, IGameStateMachine
    {
        [Inject] private readonly IUIManager _uiManager;
        [Inject] private readonly ITeamAssignmentService _teamAssignmentService;
        [Inject] private readonly IWinConditionEvaluator _winConditionEvaluator;
        [Inject] private readonly GameLobbySettings _settings;
        [Inject] private readonly GameScenes _gameScenes;
        [Inject] private readonly HidePhase _hidePhase;
        [SerializeField, Self] private PlayerRegistry _playerRegistry;
        [SerializeField, Self] private NetworkCoordinator _networkCoordinator;

        public event Action<GameState, GameState> OnStateChanged;
        public event Action<RoundResult> OnLastRoundResultChanged;

        private readonly NetworkVariable<GameState> _state = new();
        private readonly NetworkVariable<double> _countdownEndTime = new();
        private readonly NetworkVariable<RoundResult> _lastRoundResult = new();
        private readonly List<PlayerSession> _sessionBuffer = new();
        private CancellationTokenSource _gameLoopCTS;
        private CancellationTokenSource _countdownCTS;
        private bool _gameStartRequested;
        private GameSystemsRegistry _gameSystemsRegistry;

        public GameState CurrentState => _state.Value;
        public RoundResult LastRoundResult => _lastRoundResult.Value;

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
            _lastRoundResult.OnValueChanged += HandleLastRoundResultChanged;
            _countdownEndTime.OnValueChanged += StartCountdown;
            // the spawn value doesn't raise OnValueChanged
            RefreshHidePhase();
        }

        public void StartGameLoop()
        {
            RestartCTS(ref _gameLoopCTS);
            GameLoop(_gameLoopCTS.Token).Forget();
        }

        public void StopGameLoop() => DisposeCTS(ref _gameLoopCTS);

        // Only once enough players are in and every one of them is ready
        public void RequestGameStart()
        {
            if (!IsServer || _state.Value != GameState.WaitingForPlayers) return;

            _playerRegistry.CopySessionsTo(_sessionBuffer);
            if (LobbyReadiness.CanStart(_sessionBuffer, _settings.MinRequiredPlayers)) _gameStartRequested = true;
        }

        private async UniTaskVoid GameLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _state.Value = GameState.Lobby;
                _playerRegistry.ResetForLobby();
                await _networkCoordinator.LoadNetworkScene(_gameScenes.LobbySceneName, token);

                // someone un-readying (or leaving) during the countdown sends the lobby back to waiting
                do
                {
                    _state.Value = GameState.WaitingForPlayers;
                    await WaitForEnoughPlayers(token);

                    _countdownEndTime.Value = NetworkManager.ServerTime.Time + _settings.GameStartWaitTimeInSeconds;
                    _state.Value = GameState.Countdown;
                }
                while (!await WaitForCountdownWhileReady(token));

                _state.Value = GameState.AssigningTeams;
                _lastRoundResult.Value = RoundResult.None;
                _teamAssignmentService.AssignTeams();

                _state.Value = GameState.LoadingGameplay;
                await _networkCoordinator.LoadNetworkScene(_gameScenes.DefaultMap.SceneName, token);

                _playerRegistry.ResetLifeStates();
                _countdownEndTime.Value = NetworkManager.ServerTime.Time + _settings.RunnersHideWaitTime;
                _state.Value = GameState.WaitForRunnerHide;
                await WaitForRunnerHide(token);

                // the round timer reuses the countdown text, so players see the time left
                _countdownEndTime.Value = NetworkManager.ServerTime.Time + _settings.GameDurationInSeconds;
                _state.Value = GameState.Playing;
                var result = await PlayRound(token);

                _state.Value = GameState.DeterminingWinner;
                _countdownEndTime.Value = NetworkManager.ServerTime.Time;
                _lastRoundResult.Value = result;
                EUtils.Logger.Log($"[GameStateMachine] Round over: {result}");

                _state.Value = GameState.Results;
                // the next iteration loads the lobby again
                await UniTask.WaitForSeconds(_settings.ResultsDurationInSeconds, cancellationToken: token);
            }
        }

        private async UniTask WaitForEnoughPlayers(CancellationToken token)
        {
            await UniTask.WaitUntil(() => _gameStartRequested, cancellationToken: token);
            _gameStartRequested = false;
        }

        private async UniTask WaitForCountdownEnd(CancellationToken token)
        {
            await UniTask.WaitUntil(() => NetworkManager.ServerTime.Time >= _countdownEndTime.Value, cancellationToken: token);
        }

        // False when the lobby stopped being startable before the countdown ran out; the countdown text is cleared then
        private async UniTask<bool> WaitForCountdownWhileReady(CancellationToken token)
        {
            bool isStillReady = true;
            await UniTask.WaitUntil(() =>
            {
                _playerRegistry.CopySessionsTo(_sessionBuffer);
                isStillReady = LobbyReadiness.CanStart(_sessionBuffer, _settings.MinRequiredPlayers);
                return !isStillReady || NetworkManager.ServerTime.Time >= _countdownEndTime.Value;
            }, cancellationToken: token);

            if (!isStillReady) _countdownEndTime.Value = NetworkManager.ServerTime.Time;
            return isStillReady;
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
            await WaitForCountdownEnd(token);
        }

        // Ends early once the evaluator has a winner; otherwise the timer decides
        private async UniTask<RoundResult> PlayRound(CancellationToken token)
        {
            var result = RoundResult.None;
            await UniTask.WaitUntil(() =>
            {
                bool isTimeUp = NetworkManager.ServerTime.Time >= _countdownEndTime.Value;
                _playerRegistry.CopySessionsTo(_sessionBuffer);
                result = _winConditionEvaluator.Evaluate(_sessionBuffer, isTimeUp);
                return result != RoundResult.None;
            }, cancellationToken: token);

            return result;
        }

        private void HandleStateChanged(GameState previous, GameState current)
        {
            RefreshHidePhase();
            OnStateChanged?.Invoke(previous, current);
        }

        private void RefreshHidePhase() => _hidePhase.Toggle(_state.Value == GameState.WaitForRunnerHide);

        private void HandleLastRoundResultChanged(RoundResult previous, RoundResult current) => OnLastRoundResultChanged?.Invoke(current);

        private void StartCountdown(double _, double endTime)
        {
            RestartCTS(ref _countdownCTS);
            CountdownLoop(endTime, _countdownCTS.Token).Forget();
        }

        private async UniTaskVoid CountdownLoop(double endTime, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var remaining = endTime - NetworkManager.ServerTime.Time;
                if (remaining <= 0)
                {
                    _uiManager.ChangeCountdownText(string.Empty);
                    break;
                }
                _uiManager.ChangeCountdownText(EUtils.Format.MinutesSeconds((float)remaining));
                await UniTask.Yield(cancellationToken: token);
            }
        }

        private static void RestartCTS(ref CancellationTokenSource cts)
        {
            DisposeCTS(ref cts);
            cts = new();
        }

        private static void DisposeCTS(ref CancellationTokenSource cts)
        {
            cts?.Cancel();
            cts?.Dispose();
            cts = null;
        }

        public override void OnNetworkDespawn()
        {
            _state.OnValueChanged -= HandleStateChanged;
            _lastRoundResult.OnValueChanged -= HandleLastRoundResultChanged;
            _countdownEndTime.OnValueChanged -= StartCountdown;
            _hidePhase.Toggle(false);
            DisposeCTS(ref _countdownCTS);
        }

        public override void OnDestroy()
        {
            DisposeCTS(ref _gameLoopCTS);
            DisposeCTS(ref _countdownCTS);
            _gameSystemsRegistry?.Unregister(this);
            base.OnDestroy();
        }
    }
}
