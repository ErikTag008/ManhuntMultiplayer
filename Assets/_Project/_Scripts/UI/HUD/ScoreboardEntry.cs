using System;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // One player's line on the hold scoreboard; the player side fills it because UI can't read sessions
    public readonly struct ScoreboardEntry : IEquatable<ScoreboardEntry>
    {
        public readonly ulong ClientId;
        public readonly string Name;
        public readonly ScoreboardTeam Team;
        public readonly ScoreboardStatus Status;
        public readonly int Catches;
        public readonly int Rescues;
        public readonly bool IsLocal;

        public ScoreboardEntry(ulong clientId, string name, ScoreboardTeam team, ScoreboardStatus status, int catches, int rescues, bool isLocal)
        {
            ClientId = clientId;
            Name = name;
            Team = team;
            Status = status;
            Catches = catches;
            Rescues = rescues;
            IsLocal = isLocal;
        }

        public bool Equals(ScoreboardEntry other) =>
            ClientId == other.ClientId &&
            Name == other.Name &&
            Team == other.Team &&
            Status == other.Status &&
            Catches == other.Catches &&
            Rescues == other.Rescues &&
            IsLocal == other.IsLocal;
    }

    // in the order the scoreboard lists the teams
    public enum ScoreboardTeam
    {
        Catcher,
        Runner,
        None
    }

    public enum ScoreboardStatus
    {
        Up,
        Knocked,
        Out,
        Ghost,
        Spectating
    }
}
