namespace Project.Assets._Project._Scripts.Networking
{
    public enum JoinRejection
    {
        None,
        LobbyFull,
        RoundInProgress,
        Kicked
    }

    // Whether the host lets a connecting client in
    public static class JoinAdmission
    {
        // The host's own client always gets in; a player the host kicked stays out for the hosted session;
        // a running round turns everyone else away, whatever the slot count
        public static JoinRejection Evaluate(bool isHostClient, bool isKicked, bool areJoinsOpen, int takenSlotCount, int maxPlayers)
        {
            if (isHostClient) return JoinRejection.None;
            if (isKicked) return JoinRejection.Kicked;
            if (!areJoinsOpen) return JoinRejection.RoundInProgress;
            return takenSlotCount >= maxPlayers ? JoinRejection.LobbyFull : JoinRejection.None;
        }
    }
}
