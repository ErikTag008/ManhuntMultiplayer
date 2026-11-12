using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.Player;
using Reflex.Attributes;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DevTools
{
    // Development-only remote control for automated multiplayer tests: the host tells any client's own player to hold
    // Interact, move, teleport or leave. Commands run on the owning client through InputReader, like real input would.
    public class DevTestDriver : MonoBehaviour
    {
        [Inject] private readonly IConnectionService _connectionService;
        [SerializeField] private NetworkManager _networkManager;
        [SerializeField] private string _messageName = "DevTestCommand";
        [SerializeField] private int _messageSizeInBytes = 32;

        private bool _isHandlerRegistered;

        private void Awake()
        {
            if (!Debug.isDebugBuild) enabled = false;
        }

        private void OnEnable()
        {
            _networkManager.OnClientStarted += HandleClientStarted;
            _networkManager.OnClientStopped += HandleClientStopped;
            if (_networkManager.IsClient) HandleClientStarted();
        }

        // Host-side API, called from tests through the Editor
        public void SendInteractHeld(ulong clientId, bool isHeld) => Send(clientId, DevTestCommandType.InteractHeld, isHeld, Vector3.zero);

        // direction is the Move action value: x = strafe, y = forward
        public void SendMove(ulong clientId, Vector2 direction) => Send(clientId, DevTestCommandType.Move, false, direction);

        public void SendTeleport(ulong clientId, Vector3 position) => Send(clientId, DevTestCommandType.Teleport, false, position);

        public void SendLeave(ulong clientId) => Send(clientId, DevTestCommandType.Leave, false, Vector3.zero);

        private void Send(ulong clientId, DevTestCommandType type, bool flag, Vector3 vector)
        {
            if (!enabled || !_networkManager.IsServer) return;

            if (clientId == _networkManager.LocalClientId)
            {
                Execute(type, flag, vector);
                return;
            }

            using var writer = new FastBufferWriter(_messageSizeInBytes, Allocator.Temp);
            writer.WriteValueSafe((byte)type);
            writer.WriteValueSafe(flag);
            writer.WriteValueSafe(vector);
            _networkManager.CustomMessagingManager.SendNamedMessage(_messageName, clientId, writer);
        }

        private void HandleClientStarted()
        {
            if (_isHandlerRegistered) return;

            _networkManager.CustomMessagingManager.RegisterNamedMessageHandler(_messageName, HandleCommandMessage);
            _isHandlerRegistered = true;
        }

        private void HandleClientStopped(bool wasHost) => UnregisterHandler();

        private void HandleCommandMessage(ulong senderClientId, FastBufferReader reader)
        {
            if (senderClientId != NetworkManager.ServerClientId) return;

            reader.ReadValueSafe(out byte type);
            reader.ReadValueSafe(out bool flag);
            reader.ReadValueSafe(out Vector3 vector);
            Execute((DevTestCommandType)type, flag, vector);
        }

        private void Execute(DevTestCommandType type, bool flag, Vector3 vector)
        {
            var playerObject = _networkManager.LocalClient?.PlayerObject;
            EUtils.Logger.Log($"[DevTestDriver] client {_networkManager.LocalClientId}: {type} flag={flag} vector={vector}");

            if (type == DevTestCommandType.Leave)
            {
                _connectionService.Leave();
                return;
            }

            if (playerObject == null || !playerObject.TryGetComponent(out InputReader inputReader))
            {
                EUtils.Logger.LogWarning($"[DevTestDriver] client {_networkManager.LocalClientId} has no local player for {type}.");
                return;
            }

            switch (type)
            {
                case DevTestCommandType.InteractHeld:
                    inputReader.SimulateInteractHeld(flag);
                    break;
                case DevTestCommandType.Move:
                    inputReader.SimulateMove(vector);
                    break;
                case DevTestCommandType.Teleport:
                    if (playerObject.TryGetComponent(out PlayerController playerController))
                    {
                        playerController.TeleportRpc(vector, playerObject.transform.rotation);
                    }
                    break;
            }
        }

        private void UnregisterHandler()
        {
            if (!_isHandlerRegistered) return;

            _networkManager.CustomMessagingManager?.UnregisterNamedMessageHandler(_messageName);
            _isHandlerRegistered = false;
        }

        private void OnDisable()
        {
            _networkManager.OnClientStarted -= HandleClientStarted;
            _networkManager.OnClientStopped -= HandleClientStopped;
            UnregisterHandler();
        }
    }

    public enum DevTestCommandType : byte
    {
        InteractHeld,
        Move,
        Teleport,
        Leave
    }
}
