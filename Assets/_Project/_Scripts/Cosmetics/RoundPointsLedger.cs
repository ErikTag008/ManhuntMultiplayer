namespace Project.Assets._Project._Scripts.Cosmetics
{
    // Remembers what the current round has already paid. A client works the round's points out again whenever the
    // state, the result or the stats arrive (in any order), so each call pays only what is still owed; a round's
    // stats only grow, so its total is paid exactly once. Keep one per session: round keys restart with a new host.
    public class RoundPointsLedger
    {
        private const int NoRound = int.MinValue;

        private int _roundKey = NoRound;
        private int _awardedPoints;

        public int AwardedPoints => _awardedPoints;

        public int TakeOwed(int roundKey, int roundTotal)
        {
            if (roundKey != _roundKey)
            {
                _roundKey = roundKey;
                _awardedPoints = 0;
            }

            int owed = roundTotal > _awardedPoints ? roundTotal - _awardedPoints : 0;
            _awardedPoints += owed;
            return owed;
        }
    }
}
