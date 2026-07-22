using Alchemy.Inspector;
using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.DI;
using Project.Assets._Project._Scripts.Player;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    [Serializable]
    public class GameManager : NetworkBehaviour, IPlayerRegistry
    {
        [Inject] private readonly UIManager _uiManager;
        [Inject] private readonly Camera _mainCamera;
        [Inject] private readonly GameplayCamera _gameplayCamera;
        [Inject] private readonly GameLobbySettings _gameLobbySettings;
        private NetworkVariable<GameState> _state = new();
        private CancellationTokenSource _gameLoopCTS;
        [SerializeField] private List<PlayerController> _players = new(10);
        private bool _isReady = false;

        private void Awake()
        {
            ToggleCamera(false);
            _uiManager.OnHostStart += HandleHostStart;
            _uiManager.OnClientStart += HandleClientStart;
            _state.OnValueChanged += OnStateChanged;
            OnStateChanged(_state.Value, _state.Value);
        }

        public override void OnNetworkSpawn()
        {
            
            if (!IsServer) return;
            foreach (var player in FindObjectsByType<PlayerController>())
            {
                print("Found Player: " + player);
                RegisterPlayer(player);
            }
            Debug.Log($"GameManager ready. Players loaded: {_players.Count}");
            _gameLoopCTS = new();
            GameLoop(_gameLoopCTS.Token).Forget();
        }

        public void RegisterPlayer(PlayerController player)
        {
            if (!IsServer)
                return;

            RegisterPlayerInternal(player);
        }
        private void RegisterPlayerInternal(PlayerController player)
        {
            if (_players.Contains(player))
                return;

            _players.Add(player);
            Debug.Log($"Registered player {player.OwnerClientId}. Total: {_players.Count}");
        }
        private void OnStateChanged(GameState previous, GameState current)
        {
            print($"Game State Changed to {current}");
            switch (current)
            {
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
                }
                catch (ObjectDisposedException) { }
            }
            
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            _state.OnValueChanged -= OnStateChanged;
        }

        private async UniTaskVoid GameLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _state.Value = GameState.WaitingForPlayers;
                await WaitForEnoughPlayers(token);

                _state.Value = GameState.Countdown;
                await CountdownToGameStart(token);

                _state.Value = GameState.AssigningTeams;
                AssignTeams();

                _state.Value = GameState.Playing;
                await PlayRound(token);

                _state.Value = GameState.DeterminingWinner;
                DetermineWinner();

                _state.Value = GameState.Results;
                await ShowResults(token);

                ResetRound();
            }
        }

        

        private async UniTask WaitForEnoughPlayers(CancellationToken token)
        {
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
            var shuffled = _players
                .OrderBy(_ => UnityEngine.Random.value)
                .ToList();

            int catcherCount = Mathf.Min(
                _gameLobbySettings.MaximumCatcherPlayers,
                shuffled.Count - 1 // guarantees at least one runner
            );

            _catcherIds = shuffled
                .Take(catcherCount)
                .Select(p => p.OwnerClientId)
                .ToHashSet();

            foreach (var player in _players)
            {
                var team = _catcherIds.Contains(player.OwnerClientId)
                    ? Team.Catcher
                    : Team.Runner;

                player.SetTeam(team);

                Debug.Log($"Player {player.OwnerClientId} -> {team}");
            }
        }

        private async UniTask PlayRound(CancellationToken token)
        {
            await UniTask.WaitForEndOfFrame(cancellationToken: token);

        }

        private void DetermineWinner()
        {

        }

        private async UniTask ShowResults(CancellationToken token)
        {
            await UniTask.WaitForEndOfFrame(cancellationToken: token);

        }

        private void ResetRound()
        {

        }

        [Button]
        private void ToggleCamera(bool isGameplayCamera)
        {
            Camera gameplayCam = _gameplayCamera;
            if (isGameplayCamera)
            {
                _mainCamera.gameObject.SetActive(false);
                gameplayCam.gameObject.SetActive(true);
            }
            else
            {
                gameplayCam.gameObject.SetActive(false);
                _mainCamera.gameObject.SetActive(true);
            }
        }

        private void HandleClientStart()
        {
            NetworkManager.Singleton.StartClient();
            _uiManager.ToggleServerStarterUI(false);
        }

        private void HandleHostStart()
        {
            NetworkManager.Singleton.StartHost();
            _uiManager.ToggleServerStarterUI(false);
        }

        
    }

    public enum GameState
    {
        WaitingForPlayers,
        Countdown,
        AssigningTeams,
        Playing,
        DeterminingWinner,
        Results,
        ResetingRound
    }
}
