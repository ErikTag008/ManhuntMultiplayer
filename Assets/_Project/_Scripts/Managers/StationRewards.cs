using Project.Assets._Project._Scripts.Player.Stations;

namespace Project.Assets._Project._Scripts.Managers
{
    // Forwards station payouts to the live game systems, looked up only when a station completes (on the server)
    public class StationRewards : IStationRewards
    {
        private readonly GameSystemsRegistry _gameSystemsRegistry;

        public StationRewards(GameSystemsRegistry gameSystemsRegistry)
        {
            _gameSystemsRegistry = gameSystemsRegistry;
        }

        public void CreditStation(ulong clientId) => _gameSystemsRegistry.PlayerRegistry?.AddStationCompleted(clientId);

        public bool TryCutRoundTime(float cutInSeconds, float minRemainingInSeconds, out float appliedCutInSeconds)
        {
            appliedCutInSeconds = 0f;
            var gameStateMachine = _gameSystemsRegistry.GameStateMachine;
            return gameStateMachine != null && gameStateMachine.TryCutRoundTime(cutInSeconds, minRemainingInSeconds, out appliedCutInSeconds);
        }
    }
}
