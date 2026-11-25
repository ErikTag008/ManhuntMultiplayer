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

        // A player who joins a running round watches it; only while teams are picked and the map loads is the door shut
        public static bool AcceptsJoins(GameState state) => state switch
        {
            GameState.AssigningTeams or GameState.LoadingGameplay => false,
            _ => true
        };
    }
}
