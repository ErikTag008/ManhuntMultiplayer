using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Player
{
    // How many runners are up, knocked and eliminated in a set of sessions
    public readonly struct RunnerCounts
    {
        public readonly int Up;
        public readonly int Knocked;
        public readonly int Eliminated;

        public RunnerCounts(int up, int knocked, int eliminated)
        {
            Up = up;
            Knocked = knocked;
            Eliminated = eliminated;
        }

        public static RunnerCounts From(IEnumerable<PlayerSession> sessions)
        {
            int up = 0;
            int knocked = 0;
            int eliminated = 0;
            foreach (var session in sessions)
            {
                if (session.Team != Team.Runner) continue;

                switch (session.LifeState)
                {
                    case LifeState.Up:
                        up++;
                        break;
                    case LifeState.Knocked:
                        knocked++;
                        break;
                    case LifeState.Eliminated:
                        eliminated++;
                        break;
                }
            }

            return new RunnerCounts(up, knocked, eliminated);
        }
    }
}
