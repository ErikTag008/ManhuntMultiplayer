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

        // The host can call a round off once its map runs; while teams are picked and the map loads a scene load is in flight
        public static bool CanReturnToLobby(GameState state) => state switch
        {
            GameState.WaitForRunnerHide or GameState.Playing or GameState.DeterminingWinner or GameState.Results => true,
            _ => false
        };
    }
}
