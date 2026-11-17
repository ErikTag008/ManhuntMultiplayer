using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Player
{
    // How many runners are up, knocked and eliminated in a set of sessions, and how many catchers there are
    public readonly struct RunnerCounts
    {
        public readonly int Up;
        public readonly int Knocked;
        public readonly int Eliminated;
        public readonly int Catchers;

        public RunnerCounts(int up, int knocked, int eliminated, int catchers)
        {
            Up = up;
            Knocked = knocked;
            Eliminated = eliminated;
            Catchers = catchers;
        }

        public static RunnerCounts From(IEnumerable<PlayerSession> sessions)
        {
            int up = 0;
            int knocked = 0;
            int eliminated = 0;
            int catchers = 0;
            foreach (var session in sessions)
            {
                if (session.Team == Team.Catcher) catchers++;
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

            return new RunnerCounts(up, knocked, eliminated, catchers);
        }
    }
}
