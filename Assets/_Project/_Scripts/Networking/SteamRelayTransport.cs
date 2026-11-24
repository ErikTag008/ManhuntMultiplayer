using Steamworks;
using Steamworks.Data;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Networking
{
    // Netcode over Steam's relay network, addressed by the host's SteamId.
    // Adapted from FacepunchTransport (com.community.netcode.transport.facepunch, MIT license), but it never inits or
    // shuts down SteamClient (SteamPlatform owns that) and only closes its own sockets.
    public class SteamRelayTransport : NetworkTransport, IConnectionManager, ISocketManager
    {
        private const int InitialPayloadCacheSize = 4096;
        private const int PayloadCacheGrowthFactor = 2;

        private readonly Dictionary<ulong, Connection> _clientConnections = new();
        // server only: the Steam user behind each client connection
        private readonly Dictionary<ulong, ulong> _clientSteamIds = new();
        private ConnectionManager _connectionManager;
        private SocketManager _socketManager;
        private byte[] _payloadCache = new byte[InitialPayloadCacheSize];
        private ulong _hostSteamId;

        public override ulong ServerClientId => 0;

        // Client only: whose relay socket StartClient connects to
        public void SetHostSteamId(ulong hostSteamId) => _hostSteamId = hostSteamId;

        public override void Initialize(NetworkManager networkManager = null)
        {
            _clientConnections.Clear();
            _clientSteamIds.Clear();
        }

        // Server only: transportClientId is the transport's id (NetworkManager.GetTransportIdFromClientId), not Netcode's client id
        public bool TryGetSteamId(ulong transportClientId, out ulong steamId) => _clientSteamIds.TryGetValue(transportClientId, out steamId);

        public override bool StartServer()
        {
            _socketManager = SteamNetworkingSockets.CreateRelaySocket<SocketManager>();
            if (_socketManager == null) return false;

            _socketManager.Interface = this;
            return true;
        }

        public override bool StartClient()
        {
            if (_hostSteamId == 0) return false;

            _connectionManager = SteamNetworkingSockets.ConnectRelay<ConnectionManager>(_hostSteamId);
            if (_connectionManager == null) return false;

            _connectionManager.Interface = this;
            return true;
        }

        public override void Send(ulong clientId, ArraySegment<byte> payload, NetworkDelivery networkDelivery)
        {
            var sendType = ToSendType(networkDelivery);
            if (clientId == ServerClientId)
            {
                _connectionManager?.Connection.SendMessage(payload.Array, payload.Offset, payload.Count, sendType);
            }
            else if (_clientConnections.TryGetValue(clientId, out var connection))
            {
                connection.SendMessage(payload.Array, payload.Offset, payload.Count, sendType);
            }
        }

        // messages arrive through the IConnectionManager / ISocketManager callbacks while receiving
        public override NetworkEvent PollEvent(out ulong clientId, out ArraySegment<byte> payload, out float receiveTime)
        {
            _connectionManager?.Receive();
            _socketManager?.Receive();

            clientId = 0;
            payload = default;
            receiveTime = Time.realtimeSinceStartup;
            return NetworkEvent.Nothing;
        }

        // linger keeps the connection open until queued reliable data (e.g. the rejection reason) is sent
        public override void DisconnectRemoteClient(ulong clientId)
        {
            if (!_clientConnections.Remove(clientId, out var connection)) return;

            _clientSteamIds.Remove(clientId);
            connection.Flush();
            connection.Close(true);
        }

        public override void DisconnectLocalClient() => _connectionManager?.Connection.Close();

        public override ulong GetCurrentRtt(ulong clientId) => 0;

        public override void Shutdown()
        {
            // while the app quits SteamPlatform may already have shut Steam down, which closed these sockets with it
            if (SteamClient.IsValid)
            {
                _connectionManager?.Close();
                _socketManager?.Close();
            }

            _connectionManager = null;
            _socketManager = null;
            _clientConnections.Clear();
            _clientSteamIds.Clear();
        }

        void IConnectionManager.OnConnecting(ConnectionInfo info) { }

        void IConnectionManager.OnConnected(ConnectionInfo info) =>
            InvokeOnTransportEvent(NetworkEvent.Connect, ServerClientId, default, Time.realtimeSinceStartup);

        void IConnectionManager.OnDisconnected(ConnectionInfo info) =>
            InvokeOnTransportEvent(NetworkEvent.Disconnect, ServerClientId, default, Time.realtimeSinceStartup);

        void IConnectionManager.OnMessage(IntPtr data, int size, long messageNum, long recvTime, int channel) =>
            InvokeOnTransportEvent(NetworkEvent.Data, ServerClientId, CopyPayload(data, size), Time.realtimeSinceStartup);

        void ISocketManager.OnConnecting(Connection connection, ConnectionInfo info) => connection.Accept();

        void ISocketManager.OnConnected(Connection connection, ConnectionInfo info)
        {
            if (!_clientConnections.TryAdd(connection.Id, connection)) return;

            _clientSteamIds[connection.Id] = info.Identity.SteamId.Value;

            InvokeOnTransportEvent(NetworkEvent.Connect, connection.Id, default, Time.realtimeSinceStartup);
        }

        void ISocketManager.OnDisconnected(Connection connection, ConnectionInfo info)
        {
            if (!_clientConnections.Remove(connection.Id)) return;

            _clientSteamIds.Remove(connection.Id);

            InvokeOnTransportEvent(NetworkEvent.Disconnect, connection.Id, default, Time.realtimeSinceStartup);
        }

        void ISocketManager.OnMessage(Connection connection, NetIdentity identity, IntPtr data, int size, long messageNum, long recvTime, int channel) =>
            InvokeOnTransportEvent(NetworkEvent.Data, connection.Id, CopyPayload(data, size), Time.realtimeSinceStartup);

        // Steam frees the message after the callback, so it's copied into a reused buffer that Netcode reads before the next one
        private ArraySegment<byte> CopyPayload(IntPtr data, int size)
        {
            if (_payloadCache.Length < size) _payloadCache = new byte[Math.Max(_payloadCache.Length * PayloadCacheGrowthFactor, size)];

            Marshal.Copy(data, _payloadCache, 0, size);
            return new ArraySegment<byte>(_payloadCache, 0, size);
        }

        private static SendType ToSendType(NetworkDelivery networkDelivery) => networkDelivery switch
        {
            NetworkDelivery.Unreliable or NetworkDelivery.UnreliableSequenced => SendType.Unreliable,
            _ => SendType.Reliable
        };
    }
}
