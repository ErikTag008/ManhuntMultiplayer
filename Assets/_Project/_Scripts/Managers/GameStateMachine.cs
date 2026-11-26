using Cysharp.Threading.Tasks;
using KBCore.Refs;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.Player;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.SceneFlow.Maps;
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
        [Inject] private readonly SessionMapCatalog _mapCatalog;
        [Inject] private readonly MapAvailability _mapAvailability;
        [Inject] private readonly HidePhase _hidePhase;
        [Inject] private readonly HuntPhase _huntPhase;
        [SerializeField, Self] private PlayerRegistry _playerRegistry;
        [SerializeField, Self] private NetworkCoordinator _networkCoordinator;
        [SerializeField, Self] private LobbyConfigSync _lobbyConfigSync;

        public event Action<GameState, GameState> OnStateChanged;
        public event Action<RoundResult> OnLastRoundResultChanged;

        private readonly NetworkVariable<GameState> _state = new();
        private readonly NetworkVariable<double> _countdownEndTime = new();
        private readonly NetworkVariable<RoundResult> _lastRoundResult = new();
        // server time the results screen ends and the lobby loads, for the "back to lobby" countdown
        private readonly NetworkVariable<double> _resultsEndTime = new();
        // counts the rounds of this session, so per-round work (the points award) can tell rounds apart
        private readonly NetworkVariable<int> _roundNumber = new();
        private readonly List<PlayerSession> _sessionBuffer = new();
        private readonly List<int> _tiedMapBuffer = new();
        private readonly Func<int, int> _pickRandomIndex = count => UnityEngine.Random.Range(0, count);
        private CancellationTokenSource _gameLoopCTS;
        private CancellationTokenSource _countdownCTS;
        private CancellationTokenSource _resultsCountdownCTS;
        // Server only: read from the lobby config once per round, like the map and the timers
        private GameMode _roundMode;
        // Server only: nobody was made a catcher (a lone player), so the round is practice
        private bool _isPracticeRound;
        private GameSystemsRegistry _gameSystemsRegistry;
        // Server only
        private ChaseTracker _chaseTracker;

        public GameState CurrentState => _state.Value;
        public RoundResult LastRoundResult => _lastRoundResult.Value;
        public int RoundNumber => _roundNumber.Value;

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
            _resultsEndTime.OnValueChanged += StartResultsCountdown;
            if (IsServer)
            {
                _playerRegistry.OnBledOut += HandleBledOut;
                _chaseTracker = new ChaseTracker(_settings, _playerRegistry);
            }
            // the spawn value doesn't raise OnValueChanged
            RefreshPhases();
            if (_state.Value == GameState.Results) StartResultsCountdown(0, _resultsEndTime.Value);
        }

        public void StartGameLoop()
        {
            RestartCTS(ref _gameLoopCTS);
            GameLoop(_gameLoopCTS.Token).Forget();
        }

        public void StopGameLoop() => DisposeCTS(ref _gameLoopCTS);

        // Moving the end time restarts the countdown on every instance and PlayRound ends on the new time
        public bool TryCutRoundTime(float cutInSeconds, float minRemainingInSeconds, out float appliedCutInSeconds)
        {
            appliedCutInSeconds = 0f;
            if (!IsServer || _state.Value != GameState.Playing) return false;

            double now = NetworkManager.ServerTime.Time;
            double remaining = _countdownEndTime.Value - now;
            double cutRemaining = RoundTimeCut.GetRemainingAfterCut(remaining, cutInSeconds, minRemainingInSeconds);
            if (cutRemaining >= remaining) return false;

            appliedCutInSeconds = (float)(remaining - cutRemaining);
            _countdownEndTime.Value = now + cutRemaining;
            return true;
        }

        // The countdown starts by itself once the lobby is startable; this skips what is left of it
        public void RequestGameStart()
        {
            if (!IsServer || _state.Value != GameState.Countdown) return;

            _countdownEndTime.Value = NetworkManager.ServerTime.Time;
        }

        // Restarting the loop loads the lobby; no result is set, so the round awards no points
        public bool TryReturnToLobby()
        {
            if (!IsServer || !RoundProgress.CanReturnToLobby(_state.Value)) return false;

            EUtils.Logger.Log("[GameStateMachine] The host called the round off; back to the lobby.");
            _chaseTracker.EndAll();
            _countdownEndTime.Value = NetworkManager.ServerTime.Time;
            // a call-off during the results stops their back-to-lobby countdown too
            _resultsEndTime.Value = NetworkManager.ServerTime.Time;
            StartGameLoop();
            return true;
        }

        private async UniTaskVoid GameLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                // a failed map load or a called-off round can leave bodies waiting for a round spawn
                ToggleAwaitingPlacement(false);
                _state.Value = GameState.Lobby;
                _playerRegistry.ResetForLobby();
                await _networkCoordinator.LoadNetworkScene(_gameScenes.LobbySceneName, token);

                // someone un-readying (or leaving) during the countdown sends the lobby back to waiting
                do
                {
                    _state.Value = GameState.WaitingForPlayers;
                    await WaitUntilStartable(token);

                    _countdownEndTime.Value = NetworkManager.ServerTime.Time + _settings.GameStartWaitTimeInSeconds;
                    _state.Value = GameState.Countdown;
                }
                while (!await WaitForCountdownWhileReady(token));

                // read once per round, so a lobby change only applies from the next round on
                var config = _lobbyConfigSync.Config;
                _roundMode = config.Mode;
                _state.Value = GameState.AssigningTeams;
                _lastRoundResult.Value = RoundResult.None;
                _roundNumber.Value++;
                _playerRegistry.ResetRoundStats();
                _teamAssignmentService.AssignTeams();

                // the vote closes with the countdown; no votes keeps the host's map, and a map someone is missing is never picked
                _playerRegistry.CopySessionsTo(_sessionBuffer);
                _isPracticeRound = !HasCatcher(_sessionBuffer);
                int mapIndex = MapVoteTally.PickMap(_sessionBuffer, _mapCatalog.MapCount, config.MapIndex, IsMapPlayable, _pickRandomIndex, _tiedMapBuffer);
                if (!IsMapPlayable(config.MapIndex))
                {
                    EUtils.Logger.LogWarning($"[GameStateMachine] Not every player has the host map {_mapCatalog.GetMapDisplayName(config.MapIndex)}; it can't be picked.");
                }
                var map = _mapCatalog.GetListing(mapIndex);
                // the bundle map scene's loader reads it when it spawns
                _mapCatalog.SelectMap(map);
                EUtils.Logger.Log($"[GameStateMachine] Map picked: {map.DisplayName} (index {mapIndex}, host map {config.MapIndex})");

                // the bodies would stand at their lobby spots in the new map until the round spawns place them
                ToggleAwaitingPlacement(true);
                _state.Value = GameState.LoadingGameplay;
                await _networkCoordinator.LoadNetworkScene(GetSceneName(map), token);
                if (!await WaitForMapLoad(map, token))
                {
                    EUtils.Logger.LogError($"[GameStateMachine] {map.DisplayName} couldn't be loaded; back to the lobby.");
                    continue;
                }

                _playerRegistry.ResetLifeStates();
                _countdownEndTime.Value = NetworkManager.ServerTime.Time + config.HideDurationInSeconds;
                _state.Value = GameState.WaitForRunnerHide;
                await WaitForRunnerHide(token);

                // the round timer reuses the countdown text, so players see the time left
                _countdownEndTime.Value = NetworkManager.ServerTime.Time + config.RoundDurationInSeconds;
                _state.Value = GameState.Playing;
                var result = await PlayRound(token);
                // before the result is set, so the highlights are in the sessions when the results show
                _chaseTracker.EndAll();

                _state.Value = GameState.DeterminingWinner;
                // after the hunt ends, so runners put out here stay spectators instead of becoming ghosts
                if (result == RoundResult.CatchersWin) _playerRegistry.EliminateKnockedPlayers();
                _countdownEndTime.Value = NetworkManager.ServerTime.Time;
                _lastRoundResult.Value = result;
                EUtils.Logger.Log($"[GameStateMachine] Round over: {result}");

                _resultsEndTime.Value = NetworkManager.ServerTime.Time + _settings.ResultsDurationInSeconds;
                _state.Value = GameState.Results;
                // the next iteration loads the lobby again
                await UniTask.WaitUntil(() => NetworkManager.ServerTime.Time >= _resultsEndTime.Value, cancellationToken: token);
            }
        }

        private bool IsMapPlayable(int mapIndex) => _mapAvailability.IsPlayableByAll(mapIndex, NetworkManager.ConnectedClientsIds);

        private string GetSceneName(MapListing map) => map.IsBundle ? _gameScenes.BundleMapSceneName : _gameScenes.GetMap(map.BuiltInIndex).SceneName;

        // a built-in map is ready with its scene; a bundle map's scene registers a gate that waits for every instance
        private async UniTask<bool> WaitForMapLoad(MapListing map, CancellationToken token)
        {
            var mapLoadGate = _gameSystemsRegistry.MapLoadGate;
            if (mapLoadGate != null) return await mapLoadGate.WaitUntilReady(token);
            if (!map.IsBundle) return true;

            EUtils.Logger.LogError("[GameStateMachine] The bundle map scene has no IMapLoadGate (BundleMapLoader)!");
            return false;
        }

        // enough players are in and every one of them is ready
        private bool IsLobbyStartable()
        {
            _playerRegistry.CopySessionsTo(_sessionBuffer);
            return LobbyReadiness.CanStart(_sessionBuffer, _settings.MinRequiredPlayers);
        }

        private async UniTask WaitUntilStartable(CancellationToken token)
        {
            await UniTask.WaitUntil(IsLobbyStartable, cancellationToken: token);
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
                isStillReady = IsLobbyStartable();
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
                ToggleAwaitingPlacement(false);
                return;
            }

            await spawnDistributor.DistributePlayersToSpawns(_playerRegistry.GetPlayers(), token);
            // anyone the spawns ran out for shows where they stand
            ToggleAwaitingPlacement(false);
            await WaitForCountdownEnd(token);
        }

        // Ends early once the evaluator has a winner; otherwise the timer decides
        private async UniTask<RoundResult> PlayRound(CancellationToken token)
        {
            var result = RoundResult.None;
            await UniTask.WaitUntil(() =>
            {
                bool isTimeUp = NetworkManager.ServerTime.Time >= _countdownEndTime.Value;
                _chaseTracker.Tick(_playerRegistry.GetPlayers(), NetworkManager.ServerTime.Time);
                _playerRegistry.CopySessionsTo(_sessionBuffer);
                result = _winConditionEvaluator.Evaluate(_sessionBuffer, isTimeUp, _isPracticeRound);
                return result != RoundResult.None;
            }, cancellationToken: token);

            return result;
        }

        private void ToggleAwaitingPlacement(bool isAwaiting)
        {
            foreach (var player in _playerRegistry.GetPlayers())
            {
                if (player == null || !player.IsSpawned) continue;

                if (isAwaiting) player.StartAwaitingPlacement();
                else player.StopAwaitingPlacement();
            }
        }

        private static bool HasCatcher(IReadOnlyList<PlayerSession> sessions)
        {
            foreach (var session in sessions)
            {
                if (session.Team == Team.Catcher) return true;
            }
            return false;
        }

        // Infection turns a runner who bleeds out during the hunt into a catcher back at the catcher spawns;
        // otherwise (Classic, or a bleed-out after the hunt ended) the runner is out of the round
        private void HandleBledOut(ulong clientId)
        {
            bool isInfected = _roundMode == GameMode.Infection && _state.Value == GameState.Playing;
            if (!isInfected)
            {
                _playerRegistry.SetLifeState(clientId, LifeState.Eliminated);
                return;
            }

            _playerRegistry.Infect(clientId);
            var spawnDistributor = _gameSystemsRegistry.SpawnDistributor;
            if (spawnDistributor == null || !_playerRegistry.TryGetPlayer(clientId, out var player)) return;

            spawnDistributor.SendToCatcherSpawn(player);
        }

        private void HandleStateChanged(GameState previous, GameState current)
        {
            RefreshPhases();
            OnStateChanged?.Invoke(previous, current);
        }

        private void RefreshPhases()
        {
            _hidePhase.Toggle(_state.Value == GameState.WaitForRunnerHide);
            _huntPhase.Toggle(_state.Value == GameState.Playing);
        }

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

        private void StartResultsCountdown(double _, double endTime)
        {
            RestartCTS(ref _resultsCountdownCTS);
            ResultsCountdownLoop(endTime, _resultsCountdownCTS.Token).Forget();
        }

        // server time runs in real time, so a paused or slowed time scale doesn't stretch it
        private async UniTaskVoid ResultsCountdownLoop(double endTime, CancellationToken token)
        {
            int shownSeconds = IUIManager.NoResultsCountdown;
            while (!token.IsCancellationRequested)
            {
                double remaining = endTime - NetworkManager.ServerTime.Time;
                int seconds = remaining > 0 ? Mathf.CeilToInt((float)remaining) : IUIManager.NoResultsCountdown;
                if (seconds != shownSeconds)
                {
                    shownSeconds = seconds;
                    _uiManager.ChangeResultsSecondsLeft(seconds);
                }
                if (seconds == IUIManager.NoResultsCountdown) break;

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
            _resultsEndTime.OnValueChanged -= StartResultsCountdown;
            _playerRegistry.OnBledOut -= HandleBledOut;
            _hidePhase.Toggle(false);
            _huntPhase.Toggle(false);
            DisposeCTS(ref _countdownCTS);
            DisposeCTS(ref _resultsCountdownCTS);
        }

        public override void OnDestroy()
        {
            DisposeCTS(ref _gameLoopCTS);
            DisposeCTS(ref _countdownCTS);
            DisposeCTS(ref _resultsCountdownCTS);
            _gameSystemsRegistry?.Unregister(this);
            base.OnDestroy();
        }
    }
}
