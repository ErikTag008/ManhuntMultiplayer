using System;

namespace Project.Assets._Project._Scripts.Networking
{
    // A platform friend who can be invited to the current session
    public readonly struct InvitableFriend
    {
        public readonly ulong Id;
        public readonly string Name;
        public readonly bool IsPlayingThisGame;

        public InvitableFriend(ulong id, string name, bool isPlayingThisGame)
        {
            Id = id;
            Name = name ?? string.Empty;
            IsPlayingThisGame = isPlayingThisGame;
        }

        // friends already in the game first, then by name; the id keeps equal names in a stable order between refreshes
        public static int CompareForInvite(InvitableFriend a, InvitableFriend b)
        {
            if (a.IsPlayingThisGame != b.IsPlayingThisGame) return a.IsPlayingThisGame ? -1 : 1;

            int byName = string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase);
            return byName != 0 ? byName : a.Id.CompareTo(b.Id);
        }
    }
}
