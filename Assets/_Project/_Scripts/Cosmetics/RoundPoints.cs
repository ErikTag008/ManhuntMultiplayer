namespace Project.Assets._Project._Scripts.Cosmetics
{
    // One player's points for one round, split by source for the results screen
    public readonly struct RoundPoints
    {
        public readonly int Base;
        public readonly int WinBonus;
        public readonly int Catches;
        public readonly int Rescues;
        public readonly int Stations;
        public readonly int Chase;

        public int Total => Base + WinBonus + Catches + Rescues + Stations + Chase;

        public RoundPoints(int basePoints, int winBonus, int catches, int rescues, int stations, int chase)
        {
            Base = basePoints;
            WinBonus = winBonus;
            Catches = catches;
            Rescues = rescues;
            Stations = stations;
            Chase = chase;
        }
    }
}
