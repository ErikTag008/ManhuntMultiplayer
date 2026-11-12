using Project.Assets._Project._Scripts.Managers;
using Project.Assets._Project._Scripts.Player;
using Reflex.Attributes;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.DevTools
{
    // Development-only overlay; disables itself in release builds
    public class DebugMenu : MonoBehaviour
    {
        [Inject] private readonly GameSystemsRegistry _gameSystemsRegistry;
        [SerializeField] private InputAction _toggleAction = new("ToggleDebugMenu", binding: "<Keyboard>/f1");
        [SerializeField] private string _windowTitle = "Debug";
        [SerializeField] private Rect _windowRect = new(10f, 10f, 260f, 0f);
        [SerializeField] private int _windowId = 9001;

        private readonly List<PlayerSession> _sessionBuffer = new();
        private bool _isVisible;
        private CursorLockMode _previousLockMode;
        private bool _wasCursorVisible;

        private void Awake()
        {
            if (!Debug.isDebugBuild) enabled = false;
        }

        private void OnEnable()
        {
            _toggleAction.performed += HandleTogglePerformed;
            _toggleAction.Enable();
        }

        private void OnGUI()
        {
            if (!_isVisible) return;

            // InputReader locks the cursor whenever a player spawns, so keep it free while the menu is open
            ApplyMenuCursor();
            _windowRect = GUILayout.Window(_windowId, _windowRect, DrawWindow, _windowTitle);
        }

        private void HandleTogglePerformed(InputAction.CallbackContext context) => ToggleMenu(!_isVisible);

        private void ToggleMenu(bool isVisible)
        {
            _isVisible = isVisible;

            if (_isVisible)
            {
                _previousLockMode = Cursor.lockState;
                _wasCursorVisible = Cursor.visible;
                ApplyMenuCursor();
            }
            else
            {
                Cursor.lockState = _previousLockMode;
                Cursor.visible = _wasCursorVisible;
            }
        }

        private static void ApplyMenuCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void DrawWindow(int windowId)
        {
            var networkManager = NetworkManager.Singleton;
            var gameStateMachine = _gameSystemsRegistry.GameStateMachine;
            var playerRegistry = _gameSystemsRegistry.PlayerRegistry;
            bool isListening = networkManager != null && networkManager.IsListening;

            GUILayout.Label($"Role: {GetRole(networkManager)}");
            if (isListening)
            {
                GUILayout.Label($"Client id: {networkManager.LocalClientId}");
                if (networkManager.IsServer)
                {
                    GUILayout.Label($"Connected clients: {networkManager.ConnectedClientsIds.Count}");
                }
            }
            GUILayout.Label($"Game state: {(gameStateMachine != null ? gameStateMachine.CurrentState.ToString() : "-")}");
            GUILayout.Label($"Registered players: {(playerRegistry != null ? playerRegistry.PlayerCount.ToString() : "-")}");

            if (playerRegistry != null) DrawSessions(playerRegistry);

            GUI.enabled = isListening && networkManager.IsHost && gameStateMachine != null;
            if (GUILayout.Button("Request game start"))
            {
                gameStateMachine.RequestGameStart();
            }
            GUI.enabled = isListening && networkManager.IsHost && playerRegistry != null;
            if (GUILayout.Button("Knock a standing runner"))
            {
                KnockFirstStandingRunner(playerRegistry);
            }
            GUI.enabled = true;

            GUI.DragWindow();
        }

        private void DrawSessions(IPlayerRegistry playerRegistry)
        {
            playerRegistry.CopySessionsTo(_sessionBuffer);
            foreach (var session in _sessionBuffer)
            {
                GUILayout.Label($"  Player {session.ClientId}: {session.Team}, {session.LifeState}");
            }
        }

        // Server only: the player list and knocking both live on the server
        private static void KnockFirstStandingRunner(IPlayerRegistry playerRegistry)
        {
            foreach (var player in playerRegistry.GetPlayers())
            {
                if (player.Team != Team.Runner || !player.LifeState.IsUp) continue;

                player.LifeState.Knock();
                return;
            }
        }

        private static string GetRole(NetworkManager networkManager)
        {
            if (networkManager == null || !networkManager.IsListening) return "Offline";
            if (networkManager.IsHost) return "Host";
            return networkManager.IsServer ? "Server" : "Client";
        }

        private void OnDisable()
        {
            _toggleAction.performed -= HandleTogglePerformed;
            _toggleAction.Disable();
            if (_isVisible) ToggleMenu(false);
        }
    }
}
