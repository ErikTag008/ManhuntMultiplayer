using NUnit.Framework;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.SceneFlow.Maps;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEditor;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class MapValidatorTests
    {
        private const string MapId = "test-map";
        private const string MapName = "Test Map";

        private readonly List<Object> _created = new();
        private readonly List<string> _errors = new();
        private MapLibrarySettings _settings;

        [SetUp]
        public void SetUp()
        {
            _settings = ScriptableObject.CreateInstance<MapLibrarySettings>();
            _created.Add(_settings);
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var created in _created)
            {
                if (created != null) Object.DestroyImmediate(created);
            }

            _created.Clear();
        }

        [Test]
        public void ValidMap_Passes()
        {
            var map = CreateValidMap();

            Assert.IsTrue(MapValidator.Validate(map, _settings, MapValidator.NoBundleSize, _errors), string.Join("\n", _errors));
            Assert.IsEmpty(_errors);
        }

        [Test]
        public void TooFewRunnerSpawns_OneError() =>
            AssertSingleError(CreateMap(_settings.MinRunnerSpawns - 1, _settings.MinCatcherSpawns, _settings.MinDropPoints, _settings.MinStations, true));

        [Test]
        public void TooFewCatcherSpawns_OneError() =>
            AssertSingleError(CreateMap(_settings.MinRunnerSpawns, _settings.MinCatcherSpawns - 1, _settings.MinDropPoints, _settings.MinStations, true));

        [Test]
        public void TooFewDropPoints_OneError() =>
            AssertSingleError(CreateMap(_settings.MinRunnerSpawns, _settings.MinCatcherSpawns, _settings.MinDropPoints - 1, _settings.MinStations, true));

        [Test]
        public void TooFewStations_OneError()
        {
            var serializedSettings = new SerializedObject(_settings);
            serializedSettings.FindProperty("<MinStations>k__BackingField").intValue = 2;
            serializedSettings.ApplyModifiedPropertiesWithoutUndo();

            AssertSingleError(CreateMap(_settings.MinRunnerSpawns, _settings.MinCatcherSpawns, _settings.MinDropPoints, 1, true));
        }

        [Test]
        public void NoMapBounds_OneError() =>
            AssertSingleError(CreateMap(_settings.MinRunnerSpawns, _settings.MinCatcherSpawns, _settings.MinDropPoints, _settings.MinStations, false));

        [Test]
        public void TwoMapBounds_OneError()
        {
            var map = CreateValidMap();
            AddChild<MapBounds>(map);

            AssertSingleError(map);
        }

        [Test]
        public void WrongSdkVersion_OneError()
        {
            var map = CreateValidMap();
            SetRoot(map, MapId, MapName, MapSdk.Version + 1);

            AssertSingleError(map);
        }

        [Test]
        public void EmptyId_OneError()
        {
            var map = CreateValidMap();
            SetRoot(map, string.Empty, MapName, MapSdk.Version);

            AssertSingleError(map);
        }

        [Test]
        public void EmptyDisplayName_OneError()
        {
            var map = CreateValidMap();
            SetRoot(map, MapId, string.Empty, MapSdk.Version);

            AssertSingleError(map);
        }

        [Test]
        public void NoMapRoot_OneError()
        {
            var map = CreateValidMap();
            Object.DestroyImmediate(map.GetComponent<MapRoot>());

            AssertSingleError(map);
        }

        [Test]
        public void OversizedBounds_OneError()
        {
            var map = CreateValidMap();
            var serializedBounds = new SerializedObject(map.GetComponentInChildren<MapBounds>());
            serializedBounds.FindProperty("_bounds").boundsValue = new Bounds(Vector3.zero, Vector3.one * (_settings.MaxMapSizeInMeters + 1f));
            serializedBounds.ApplyModifiedPropertiesWithoutUndo();

            AssertSingleError(map);
        }

        [Test]
        public void NetworkObject_OneError()
        {
            var map = CreateValidMap();
            AddChild<NetworkObject>(map);

            AssertSingleError(map);
        }

        [Test]
        public void OversizedBundle_OneError()
        {
            var map = CreateValidMap();

            Assert.IsFalse(MapValidator.Validate(map, _settings, _settings.MaxBundleSizeInBytes + 1, _errors));
            Assert.AreEqual(1, _errors.Count, string.Join("\n", _errors));
        }

        [Test]
        public void BundleAtTheLimit_Passes() =>
            Assert.IsTrue(MapValidator.Validate(CreateValidMap(), _settings, _settings.MaxBundleSizeInBytes, _errors), string.Join("\n", _errors));

        [Test]
        public void SeveralProblems_AllReported()
        {
            var map = CreateMap(_settings.MinRunnerSpawns, _settings.MinCatcherSpawns, _settings.MinDropPoints - 1, _settings.MinStations, false);
            SetRoot(map, MapId, MapName, MapSdk.Version + 1);

            Assert.IsFalse(MapValidator.Validate(map, _settings, _settings.MaxBundleSizeInBytes + 1, _errors));
            Assert.AreEqual(4, _errors.Count, string.Join("\n", _errors));
        }

        [Test]
        public void NoMap_Fails()
        {
            Assert.IsFalse(MapValidator.Validate(null, _settings, MapValidator.NoBundleSize, _errors));
            Assert.AreEqual(1, _errors.Count);
        }

        [Test]
        public void IsValidId_RejectsBadIds()
        {
            Assert.IsTrue(MapValidator.IsValidId(MapId));
            Assert.IsFalse(MapValidator.IsValidId(" "));
            Assert.IsFalse(MapValidator.IsValidId("maps/test"));
            Assert.IsFalse(MapValidator.IsValidId(new string('a', 100)));
        }

        private void AssertSingleError(GameObject map)
        {
            Assert.IsFalse(MapValidator.Validate(map, _settings, MapValidator.NoBundleSize, _errors));
            Assert.AreEqual(1, _errors.Count, string.Join("\n", _errors));
        }

        private GameObject CreateValidMap() =>
            CreateMap(_settings.MinRunnerSpawns, _settings.MinCatcherSpawns, _settings.MinDropPoints, Mathf.Max(1, _settings.MinStations), true);

        private GameObject CreateMap(int runnerSpawns, int catcherSpawns, int dropPoints, int stations, bool hasBounds)
        {
            var map = new GameObject("Map");
            _created.Add(map);
            map.AddComponent<MapRoot>();
            SetRoot(map, MapId, MapName, MapSdk.Version);

            for (int i = 0; i < runnerSpawns; i++) AddChild<RunnerSpawnMarker>(map);
            for (int i = 0; i < catcherSpawns; i++) AddChild<CatcherSpawnMarker>(map);
            for (int i = 0; i < dropPoints; i++) AddChild<DropPointMarker>(map);
            for (int i = 0; i < stations; i++) AddChild<StationMarker>(map);
            if (hasBounds) AddChild<MapBounds>(map);
            return map;
        }

        private static T AddChild<T>(GameObject map) where T : Component
        {
            var child = new GameObject(typeof(T).Name);
            child.transform.SetParent(map.transform);
            return child.AddComponent<T>();
        }

        private static void SetRoot(GameObject map, string id, string displayName, int sdkVersion)
        {
            var serializedRoot = new SerializedObject(map.GetComponent<MapRoot>());
            serializedRoot.FindProperty("_id").stringValue = id;
            serializedRoot.FindProperty("_displayName").stringValue = displayName;
            serializedRoot.FindProperty("_sdkVersion").intValue = sdkVersion;
            serializedRoot.ApplyModifiedPropertiesWithoutUndo();
        }
    }
}
