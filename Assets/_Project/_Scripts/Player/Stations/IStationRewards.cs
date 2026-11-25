namespace Project.Assets._Project._Scripts.Player.Stations
{
    // Server only: what a completed station pays out. A project-wide service, so a station synced into a joining client's
    // map can be injected before the network-spawned game systems exist there
    public interface IStationRewards
    {
        void CreditStation(ulong clientId);
        // Never extends the round and never takes it below the minimum
        bool TryCutRoundTime(float cutInSeconds, float minRemainingInSeconds, out float appliedCutInSeconds);
    }
}
