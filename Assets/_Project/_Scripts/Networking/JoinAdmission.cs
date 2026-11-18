namespace Project.Assets._Project._Scripts.Networking
{
    public enum JoinRejection
    {
        None,
        LobbyFull,
        RoundInProgress
    }

    // Whether the host lets a connecting client in
    public static class JoinAdmission
    {
        // The host's own client always gets in; a running round turns everyone else away, whatever the slot count
        public static JoinRejection Evaluate(bool isHostClient, bool areJoinsOpen, int takenSlotCount, int maxPlayers)
        {
            if (isHostClient) return JoinRejection.None;
            if (!areJoinsOpen) return JoinRejection.RoundInProgress;
            return takenSlotCount >= maxPlayers ? JoinRejection.LobbyFull : JoinRejection.None;
        }
    }
}
