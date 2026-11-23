using NUnit.Framework;
using Project.Assets._Project._Scripts.Networking;
using System.Collections.Generic;

namespace Project.Assets._Project.Tests.EditMode
{
    public class InvitableFriendTests
    {
        [Test]
        public void PlayingThisGame_ComesFirst()
        {
            var friends = new List<InvitableFriend> { new(1, "Alice", false), new(2, "Zed", true) };
            friends.Sort(InvitableFriend.CompareForInvite);
            Assert.AreEqual(2ul, friends[0].Id);
        }

        [Test]
        public void SameGroup_SortsByNameIgnoringCase()
        {
            var friends = new List<InvitableFriend> { new(1, "bob", false), new(2, "Alice", false), new(3, "carl", false) };
            friends.Sort(InvitableFriend.CompareForInvite);
            Assert.AreEqual(new[] { 2ul, 1ul, 3ul }, new[] { friends[0].Id, friends[1].Id, friends[2].Id });
        }

        [Test]
        public void SameName_SortsById()
        {
            var friends = new List<InvitableFriend> { new(9, "Sam", true), new(4, "sam", true) };
            friends.Sort(InvitableFriend.CompareForInvite);
            Assert.AreEqual(4ul, friends[0].Id);
        }

        [Test]
        public void NullName_BecomesEmpty()
        {
            Assert.AreEqual(string.Empty, new InvitableFriend(1, null, false).Name);
        }
    }
}
