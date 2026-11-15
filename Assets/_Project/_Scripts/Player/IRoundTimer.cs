namespace Project.Assets._Project._Scripts.Player
{
    // The running round's timer as player-side systems see it; GameStateMachine implements it in the Managers assembly
    public interface IRoundTimer
    {
        // Server only, and only during the hunt. Never extends the round and never takes it below the minimum.
        bool TryCutRoundTime(float cutInSeconds, float minRemainingInSeconds, out float appliedCutInSeconds);
    }
}
