using NUnit.Framework;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.SceneFlow.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class SessionMapCatalogTests
    {
        private readonly List<UnityEngine.Object> _created = new();
        private readonly List<MapListing> _listings = new();
        private string _folderPath;
        private LocalMapLibrary _emptyLibrary;

        [SetUp]
        public void SetUp()
        {
            // a folder that doesn't exist, so the real library never leaks into the tests
            _folderPath = Path.Combine(Path.GetTempPath(), $"{nameof(SessionMapCatalogTests)}_{Guid.NewGuid():N}");
            var settings = LocalMapLibraryTests.CreateSettings(_folderPath);
            _created.Add(settings);
            _emptyLibrary = new LocalMapLibrary(settings);
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var created in _created)
            {
                if (created != null) UnityEngine.Object.DestroyImmediate(created);
            }

            _created.Clear();
        }

        [Test]
        public void BuildLocalListings_BuiltInsKeepTheirIndicesThenBundles()
        {
            var gameScenes = CreateGameScenes("Default", "Farm", "Yard");
            var bundleMaps = new List<LocalMapEntry> { new("dock", "Dock", "dock.mapbundle", "abcd", 1) };

            SessionMapCatalog.BuildLocalListings(gameScenes, bundleMaps, _listings);

            Assert.AreEqual(3, _listings.Count);
            Assert.AreEqual(0, _listings[0].BuiltInIndex);
            Assert.AreEqual("Yard", _listings[1].DisplayName.ToString());
            Assert.AreEqual(1, _listings[1].BuiltInIndex);
            Assert.IsTrue(_listings[2].IsBundle);
            Assert.AreEqual("dock", _listings[2].Id.ToString());
            Assert.AreEqual("abcd", _listings[2].ContentHash.ToString());
        }

        [Test]
        public void NoMapsList_DefaultMapIsTheOnlyBuiltIn()
        {
            var catalog = new SessionMapCatalog(CreateGameScenes("Default"), _emptyLibrary);

            Assert.AreEqual(1, catalog.MapCount);
            Assert.AreEqual("Default", catalog.GetMapDisplayName(0));
            Assert.AreEqual(0, catalog.GetListing(0).BuiltInIndex);
        }

        [Test]
        public void OutOfRange_FallsBackToDefaultMap()
        {
            var gameScenes = CreateGameScenes("Default", "Farm");
            var catalog = new SessionMapCatalog(gameScenes, _emptyLibrary);
            var listing = catalog.GetListing(7);

            Assert.IsFalse(listing.IsBundle);
            Assert.AreEqual("Default", listing.DisplayName.ToString());
            Assert.AreEqual(gameScenes.DefaultMap, gameScenes.GetMap(listing.BuiltInIndex));
        }

        [Test]
        public void RemoteListings_MirroredUntilCleared()
        {
            var catalog = new SessionMapCatalog(CreateGameScenes("Default", "Farm"), _emptyLibrary);
            int changeCount = 0;
            catalog.OnChanged += () => changeCount++;
            var remote = new List<MapListing>
            {
                MapListing.BuiltIn(0, "Farm"),
                MapListing.Bundle("dock", "Dock", "abcd"),
                MapListing.Bundle("pier", "Pier", "ef01")
            };

            catalog.SetRemoteListings(remote);

            Assert.IsTrue(catalog.IsMirroringRemote);
            Assert.AreEqual(3, catalog.MapCount);
            Assert.AreEqual("Pier", catalog.GetMapDisplayName(2));

            catalog.ClearRemoteListings();

            Assert.IsFalse(catalog.IsMirroringRemote);
            Assert.AreEqual(1, catalog.MapCount);
            Assert.AreEqual(2, changeCount);
        }

        [Test]
        public void ClearRemoteListings_WhenNotMirroring_NoChange()
        {
            var catalog = new SessionMapCatalog(CreateGameScenes("Default"), _emptyLibrary);
            bool hasChanged = false;
            catalog.OnChanged += () => hasChanged = true;

            catalog.ClearRemoteListings();

            Assert.IsFalse(hasChanged);
        }

        [Test]
        public void SelectMap_Kept()
        {
            var catalog = new SessionMapCatalog(CreateGameScenes("Default"), _emptyLibrary);
            var listing = MapListing.Bundle("dock", "Dock", "abcd");

            catalog.SelectMap(listing);

            Assert.IsTrue(listing.Equals(catalog.SelectedMap));
        }

        [Test]
        public void MapListing_TooLongNames_Truncated() =>
            Assert.DoesNotThrow(() => MapListing.BuiltIn(0, new string('a', 200)));

        // the first name is DefaultMap, the rest fill the Maps list
        private GameScenes CreateGameScenes(string defaultMapName, params string[] mapNames)
        {
            var gameScenes = ScriptableObject.CreateInstance<GameScenes>();
            _created.Add(gameScenes);
            var serializedScenes = new SerializedObject(gameScenes);
            serializedScenes.FindProperty("<DefaultMap>k__BackingField").objectReferenceValue = CreateMap(defaultMapName);
            var maps = serializedScenes.FindProperty("<Maps>k__BackingField");
            maps.arraySize = mapNames.Length;
            for (int i = 0; i < mapNames.Length; i++) maps.GetArrayElementAtIndex(i).objectReferenceValue = CreateMap(mapNames[i]);
            serializedScenes.ApplyModifiedPropertiesWithoutUndo();
            return gameScenes;
        }

        private MapDefinition CreateMap(string displayName)
        {
            var map = ScriptableObject.CreateInstance<MapDefinition>();
            _created.Add(map);
            var serializedMap = new SerializedObject(map);
            serializedMap.FindProperty("<DisplayName>k__BackingField").stringValue = displayName;
            serializedMap.ApplyModifiedPropertiesWithoutUndo();
            return map;
        }
    }
}
