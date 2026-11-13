using Alchemy.Inspector;
using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.UI;
using Project.Assets._Project._Scripts.UI.HUD;
using Reflex.Attributes;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    // Hosts or joins from the main menu's requests; DevAutoConnect goes through IUIManager with the defaults
    public class MainMenuStarter : MonoBehaviour
    {
        [Inject] private readonly ServerStarterUI _serverStarterUI;
        [Inject] private readonly MainMenuState _mainMenuState;
        [Inject] private readonly SceneLifecycleManager _sceneLifecycleManager;
        [Inject] private readonly IUIManager _uiManager;
        [Inject] private readonly IConnectionService _connectionService;
        [Inject] private readonly ConnectionSettings _connectionSettings;
        [Inject] private readonly LobbyConfigData _lobbyConfigData;
        [Inject] private readonly ActiveLobbyConfig _activeLobbyConfig;
        [Inject] private readonly SessionEndHandler _sessionEndHandler;
        [SerializeField, AssetsOnly] private NetworkObject _gameSystemsPrefab;
        [SerializeField] private string _hostingStatus = "Creating lobby...";
        // {0} is the address
        [SerializeField] private string _joiningStatusFormat = "Joining {0}...";

        private void Start()
        {
            _sceneLifecycleManager.InitializeScene(SceneType.MainMenu);
            _serverStarterUI.ShowDisconnectReason(_sessionEndHandler.LastDisconnectReason);
            _uiManager.OnHostStart += HandleHostStart;
            _uiManager.OnClientStart += HandleClientStart;
            _mainMenuState.OnHostRequested += HandleHostRequested;
            _mainMenuState.OnJoinRequested += HandleJoinRequested;
        }

        private void HandleHostStart() => HandleHostRequested(_lobbyConfigData.CreateDefault());

        private void HandleClientStart() => HandleJoinRequested(_connectionSettings.Address);

        // App-lifetime token: a successful host or join replaces this scene
        private void HandleHostRequested(LobbyConfig config) => HostSession(config, Application.exitCancellationToken).Forget();

        private void HandleJoinRequested(string target) => JoinSession(target, Application.exitCancellationToken).Forget();

        private async UniTaskVoid HostSession(LobbyConfig config, CancellationToken token)
        {
            if (_mainMenuState.IsBusy) return;

            BeginAttempt(_hostingStatus);
            // set before hosting, so GameSystems copies it into LobbyConfigSync when it spawns
            _activeLobbyConfig.Set(config);
            var isHosting = await _connectionService.Host(config, token);
            if (this == null) return;

            if (!isHosting)
            {
                EndFailedAttempt();
                return;
            }

            // the game loop on GameSystems loads the lobby in Single mode, which replaces this scene
            SpawnGameSystems();
        }

        private async UniTaskVoid JoinSession(string target, CancellationToken token)
        {
            if (_mainMenuState.IsBusy) return;

            var address = string.IsNullOrWhiteSpace(target) ? _connectionSettings.Address : target.Trim();
            BeginAttempt(string.Format(_joiningStatusFormat, address));
            var isJoined = await _connectionService.Join(target, token);
            if (this == null || isJoined) return;

            EndFailedAttempt();
        }

        private void BeginAttempt(string status)
        {
            _sessionEndHandler.ClearDisconnectReason();
            _serverStarterUI.ShowDisconnectReason(null);
            _mainMenuState.SetStatus(status);
            _mainMenuState.ToggleBusy(true);
        }

        private void EndFailedAttempt()
        {
            _mainMenuState.ToggleBusy(false);
            _mainMenuState.SetStatus(_connectionService.LastFailureReason);
        }

        // destroyWithScene: false keeps GameSystems alive across Single-mode scene loads
        private void SpawnGameSystems()
        {
            if (!NetworkManager.Singleton.IsServer) return;
            NetworkManager.Singleton.SpawnManager.InstantiateAndSpawn(_gameSystemsPrefab, destroyWithScene: false);
        }

        private void OnDestroy()
        {
            _uiManager.OnHostStart -= HandleHostStart;
            _uiManager.OnClientStart -= HandleClientStart;
            _mainMenuState.OnHostRequested -= HandleHostRequested;
            _mainMenuState.OnJoinRequested -= HandleJoinRequested;
        }
    }
}
