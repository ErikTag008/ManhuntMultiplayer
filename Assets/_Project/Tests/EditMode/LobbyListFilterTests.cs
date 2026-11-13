using NUnit.Framework;
using Project.Assets._Project._Scripts.Networking;
using System.Collections.Generic;

namespace Project.Assets._Project.Tests.EditMode
{
    public class LobbyListFilterTests
    {
        private readonly List<LobbyListing> _results = new();

        private static LobbyListing CreateListing(string name, string region = "Local", string map = "Woods", int players = 2, int maxPlayers = 10,
            bool isInProgress = false, LobbyVisibility visibility = LobbyVisibility.Public, int ping = LobbyListing.UnknownPing) => new()
        {
            Id = name,
            Name = name,
            Region = region,
            MapName = map,
            PlayerCount = players,
            MaxPlayers = maxPlayers,
            IsInProgress = isInProgress,
            Visibility = visibility,
            PingInMilliseconds = ping
        };

        private List<string> ApplyAndGetNames(IReadOnlyList<LobbyListing> source, LobbyListFilter filter, LobbySortOrder sortOrder = LobbySortOrder.Name)
        {
            LobbyListFilter.Apply(source, filter, sortOrder, _results);
            var names = new List<string>();
            foreach (var listing in _results) names.Add(listing.Name);
            return names;
        }

        [Test]
        public void EmptyFilter_KeepsEveryLobby()
        {
            var source = new[] { CreateListing("A"), CreateListing("B", isInProgress: true), CreateListing("C", players: 10) };

            CollectionAssert.AreEquivalent(new[] { "A", "B", "C" }, ApplyAndGetNames(source, default));
        }

        [Test]
        public void Region_KeepsOnlyThatRegion()
        {
            var source = new[] { CreateListing("A", region: "EU"), CreateListing("B", region: "US"), CreateListing("C", region: "eu") };

            CollectionAssert.AreEqual(new[] { "A", "C" }, ApplyAndGetNames(source, new LobbyListFilter { Region = "EU" }));
        }

        [Test]
        public void MapName_KeepsOnlyThatMap()
        {
            var source = new[] { CreateListing("A", map: "Woods"), CreateListing("B", map: "Town") };

            CollectionAssert.AreEqual(new[] { "B" }, ApplyAndGetNames(source, new LobbyListFilter { MapName = "Town" }));
        }

        [Test]
        public void MinLobbySize_DropsSmallerLobbies()
        {
            var source = new[] { CreateListing("A", maxPlayers: 4), CreateListing("B", maxPlayers: 8), CreateListing("C", maxPlayers: 10) };

            CollectionAssert.AreEqual(new[] { "B", "C" }, ApplyAndGetNames(source, new LobbyListFilter { MinLobbySize = 8 }));
        }

        [Test]
        public void HideFull_DropsFullLobbies()
        {
            var source = new[] { CreateListing("A", players: 4, maxPlayers: 4), CreateListing("B", players: 3, maxPlayers: 4) };

            CollectionAssert.AreEqual(new[] { "B" }, ApplyAndGetNames(source, new LobbyListFilter { IsHidingFull = true }));
        }

        [Test]
        public void FullLobbies_StayWhenNotHidden()
        {
            var source = new[] { CreateListing("A", players: 4, maxPlayers: 4) };

            CollectionAssert.AreEqual(new[] { "A" }, ApplyAndGetNames(source, default));
        }

        [Test]
        public void HideInProgress_DropsRunningGames()
        {
            var source = new[] { CreateListing("A", isInProgress: true), CreateListing("B") };

            CollectionAssert.AreEqual(new[] { "B" }, ApplyAndGetNames(source, new LobbyListFilter { IsHidingInProgress = true }));
        }

        [TestCase(LobbyVisibilityFilter.Public, "A")]
        [TestCase(LobbyVisibilityFilter.FriendsOnly, "B")]
        public void Visibility_KeepsOnlyThatVisibility(LobbyVisibilityFilter visibility, string expected)
        {
            var source = new[] { CreateListing("A", visibility: LobbyVisibility.Public), CreateListing("B", visibility: LobbyVisibility.FriendsOnly) };

            CollectionAssert.AreEqual(new[] { expected }, ApplyAndGetNames(source, new LobbyListFilter { Visibility = visibility }));
        }

        [Test]
        public void SortByName_IsAlphabeticalIgnoringCase()
        {
            var source = new[] { CreateListing("charlie"), CreateListing("Alpha"), CreateListing("bravo") };

            CollectionAssert.AreEqual(new[] { "Alpha", "bravo", "charlie" }, ApplyAndGetNames(source, default, LobbySortOrder.Name));
        }

        [Test]
        public void SortByPlayers_PutsMostPlayersFirst()
        {
            var source = new[] { CreateListing("A", players: 1), CreateListing("B", players: 5), CreateListing("C", players: 3) };

            CollectionAssert.AreEqual(new[] { "B", "C", "A" }, ApplyAndGetNames(source, default, LobbySortOrder.Players));
        }

        [Test]
        public void SortByPing_PutsUnknownPingLast()
        {
            var source = new[] { CreateListing("A"), CreateListing("B", ping: 80), CreateListing("C", ping: 20) };

            CollectionAssert.AreEqual(new[] { "C", "B", "A" }, ApplyAndGetNames(source, default, LobbySortOrder.Ping));
        }

        [Test]
        public void Apply_ReplacesPreviousResultsAndSkipsMissingEntries()
        {
            _results.Add(CreateListing("Old"));
            var source = new[] { CreateListing("A"), null };

            CollectionAssert.AreEqual(new[] { "A" }, ApplyAndGetNames(source, default));
        }
    }
}
