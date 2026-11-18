namespace Project.Assets._Project._Scripts.Managers
{
    public static class RoundProgress
    {
        // From team assignment until the lobby loads again a round is running, so nobody new can take part
        public static bool IsInProgress(GameState state) => state switch
        {
            GameState.Lobby or GameState.WaitingForPlayers or GameState.Countdown => false,
            _ => true
        };
    }
}
