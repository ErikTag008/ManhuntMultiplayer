using NUnit.Framework;
using Project.Assets._Project._Scripts.Settings;
using UnityEngine;

namespace Project.Tests.EditMode
{
    public class KeybindEntryTests
    {
        [Test]
        public void CanShareKeyWith_CatchSharesWithBothSpectateRows()
        {
            var catchEntry = CreateEntry("SpectateNext, SpectatePrevious");

            Assert.IsTrue(catchEntry.CanShareKeyWith(CreateEntry("SpectateNext")));
            Assert.IsTrue(catchEntry.CanShareKeyWith(CreateEntry("SpectatePrevious")));
            Assert.IsTrue(CreateEntry("SpectateNext").CanShareKeyWith(catchEntry));
        }

        [Test]
        public void CanShareKeyWith_SpectateRowsCantShareWithEachOther()
        {
            Assert.IsFalse(CreateEntry("SpectateNext").CanShareKeyWith(CreateEntry("SpectatePrevious")));
        }

        [Test]
        public void CanShareKeyWith_EmptyGroupsNeverShare()
        {
            Assert.IsFalse(CreateEntry("").CanShareKeyWith(CreateEntry("")));
            Assert.IsFalse(CreateEntry("SpectateNext").CanShareKeyWith(CreateEntry("")));
            Assert.IsFalse(CreateEntry(", ").CanShareKeyWith(CreateEntry(",")));
            Assert.IsFalse(CreateEntry("SpectateNext").CanShareKeyWith(null));
        }

        private static KeybindEntry CreateEntry(string shareGroup)
        {
            var entry = new KeybindEntry();
            JsonUtility.FromJsonOverwrite($"{{\"<ShareGroup>k__BackingField\":\"{shareGroup}\"}}", entry);
            return entry;
        }
    }
}
