using NUnit.Framework;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.UI.HUD;

namespace Project.Assets._Project.Tests.EditMode
{
    public class IncomingInviteStateTests
    {
        [Test]
        public void Invites_ShowOldestFirst()
        {
            var state = new IncomingInviteState();
            state.Add(new LobbyInvite(10, 1, "Alice"));
            state.Add(new LobbyInvite(20, 2, "Bob"));

            Assert.IsTrue(state.TryGetCurrent(out var invite));
            Assert.AreEqual(10ul, invite.LobbyId);
        }

        [Test]
        public void Decline_MovesToTheNextInvite()
        {
            var state = new IncomingInviteState();
            state.Add(new LobbyInvite(10, 1, "Alice"));
            state.Add(new LobbyInvite(20, 2, "Bob"));
            int changes = 0;
            state.OnCurrentChanged += () => changes++;

            state.Decline();

            Assert.IsTrue(state.TryGetCurrent(out var invite));
            Assert.AreEqual(20ul, invite.LobbyId);
            Assert.AreEqual(1, changes);
        }

        [Test]
        public void SameLobbyAgain_ReplacesInsteadOfQueueing()
        {
            var state = new IncomingInviteState();
            state.Add(new LobbyInvite(10, 1, "Alice"));
            state.Add(new LobbyInvite(10, 3, "Carl"));

            state.Decline();

            Assert.IsFalse(state.HasCurrent);
        }

        [Test]
        public void Accept_ClearsEveryInviteAndReportsTheCurrentOne()
        {
            var state = new IncomingInviteState();
            state.Add(new LobbyInvite(10, 1, "Alice"));
            state.Add(new LobbyInvite(20, 2, "Bob"));
            ulong acceptedLobbyId = 0;
            state.OnAccepted += invite => acceptedLobbyId = invite.LobbyId;

            state.Accept();

            Assert.AreEqual(10ul, acceptedLobbyId);
            Assert.IsFalse(state.HasCurrent);
        }

        [Test]
        public void AnswersWithoutInvites_DoNothing()
        {
            var state = new IncomingInviteState();
            bool isAccepted = false;
            state.OnAccepted += _ => isAccepted = true;

            state.Accept();
            state.Decline();

            Assert.IsFalse(isAccepted);
            Assert.IsFalse(state.HasCurrent);
        }
    }
}
