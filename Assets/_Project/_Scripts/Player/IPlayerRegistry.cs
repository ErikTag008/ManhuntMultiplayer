using System;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Player
{
    public interface IPlayerRegistry
    {
        // Every instance
        int PlayerCount { get; }
        event Action OnSessionsChanged;
        bool TryGetSession(ulong clientId, out PlayerSession session);
        // Fills a caller-owned list so per-frame checks don't allocate
        void CopySessionsTo(List<PlayerSession> buffer);

        // Server only
        List<PlayerController> GetPlayers();
        void RegisterPlayer(PlayerController player);
        void UnregisterPlayer(PlayerController player);
        void SetTeam(ulong clientId, Team team);
        void SetLifeState(ulong clientId, LifeState lifeState);
        void ResetLifeStates();
        void ResetForLobby();
    }
}
