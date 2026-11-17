using NUnit.Framework;
using Project.Assets._Project._Scripts.Voice;

namespace Project.Assets._Project.Tests.EditMode
{
    public class VoiceMuteListTests
    {
        [Test]
        public void Register_SameIdAgain_RenamesWithoutDuplicate()
        {
            var muteList = new VoiceMuteList();
            int changes = 0;
            muteList.OnPeersChanged += () => changes++;

            muteList.Register(2, "Player 2");
            muteList.Register(2, "Runner");
            muteList.Register(2, "Runner");

            Assert.AreEqual(1, muteList.Peers.Count);
            Assert.AreEqual("Runner", muteList.Peers[0].DisplayName);
            Assert.AreEqual(2, changes);
        }

        [Test]
        public void SetMuted_OnlyMutesThatPeer()
        {
            var muteList = new VoiceMuteList();
            muteList.Register(2, "A");
            muteList.Register(3, "B");

            muteList.SetMuted(2, true);

            Assert.IsTrue(muteList.IsMuted(2));
            Assert.IsFalse(muteList.IsMuted(3));

            muteList.SetMuted(2, false);
            Assert.IsFalse(muteList.IsMuted(2));
        }

        [Test]
        public void Unregister_RemovesThePeerAndForgetsItsMute()
        {
            var muteList = new VoiceMuteList();
            muteList.Register(2, "A");
            muteList.SetMuted(2, true);

            muteList.Unregister(2);

            Assert.AreEqual(0, muteList.Peers.Count);
            Assert.IsFalse(muteList.IsMuted(2));
        }
    }
}
