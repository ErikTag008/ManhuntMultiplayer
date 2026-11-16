namespace Project.Assets._Project._Scripts
{
    // The round rules the host picks in the lobby. Classic: a bled-out runner is out of the round.
    // Infection: a runner who bleeds out during the hunt joins the catchers.
    public enum GameMode
    {
        Classic,
        Infection
    }
}
