using NUnit.Framework;
using Project.Assets._Project._Scripts.Managers;

namespace Project.Assets._Project.Tests.EditMode
{
    public class RoundTimeCutTests
    {
        private const double Cut = 30.0;
        private const double Min = 30.0;

        [Test]
        public void PlentyLeft_CutsFully() => Assert.AreEqual(90.0, RoundTimeCut.GetRemainingAfterCut(120.0, Cut, Min));

        [Test]
        public void CutWouldGoBelowMin_ClampsToMin() => Assert.AreEqual(Min, RoundTimeCut.GetRemainingAfterCut(45.0, Cut, Min));

        [Test]
        public void ExactlyMinPlusCut_LandsOnMin() => Assert.AreEqual(Min, RoundTimeCut.GetRemainingAfterCut(60.0, Cut, Min));

        [Test]
        public void AtMin_Unchanged() => Assert.AreEqual(Min, RoundTimeCut.GetRemainingAfterCut(Min, Cut, Min));

        [Test]
        public void BelowMin_NeverExtended() => Assert.AreEqual(12.0, RoundTimeCut.GetRemainingAfterCut(12.0, Cut, Min));

        [Test]
        public void ZeroCut_Unchanged() => Assert.AreEqual(100.0, RoundTimeCut.GetRemainingAfterCut(100.0, 0.0, Min));

        [Test]
        public void NegativeCut_NeverExtends() => Assert.AreEqual(100.0, RoundTimeCut.GetRemainingAfterCut(100.0, -Cut, Min));
    }
}
