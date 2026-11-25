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
        // knocks the runner down and counts the knock in one session change
        void Knock(ulong clientId);
        // A knocked runner's bleed-out ran out; the round's game mode decides what happens to them
        void ReportBledOut(ulong clientId);
        void SetAbility(ulong clientId, int abilityId);
        void SetReady(ulong clientId, bool isReady);
        // a GameScenes map index, or PlayerSession.NoMapVote to clear the vote
        void SetMapVote(ulong clientId, int mapIndex);
        // after a catcher turn, so everyone else goes first next time
        void MoveToBackOfCatcherQueue(ulong clientId);
        void ResetLifeStates();
        void AddCatch(ulong clientId);
        void AddRescue(ulong clientId);
        void AddStationCompleted(ulong clientId);
        // keeps the longest chase of the round
        void RecordChase(ulong clientId, float durationInSeconds);
        void ResetRoundStats();
        void ResetForLobby();
    }
}
