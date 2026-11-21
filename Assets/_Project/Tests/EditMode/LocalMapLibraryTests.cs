using NUnit.Framework;
using Project.Assets._Project._Scripts.SceneFlow.Maps;
using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class LocalMapLibraryTests
    {
        // SHA-256 of the ASCII bytes "abc"
        private const string AbcHash = "ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad";

        private MapLibrarySettings _settings;
        private string _folderPath;

        [SetUp]
        public void SetUp()
        {
            _folderPath = Path.Combine(Path.GetTempPath(), $"{nameof(LocalMapLibraryTests)}_{Guid.NewGuid():N}");
            Directory.CreateDirectory(_folderPath);
            _settings = CreateSettings(_folderPath);
        }

        [TearDown]
        public void TearDown()
        {
            UnityEngine.Object.DestroyImmediate(_settings);
            if (Directory.Exists(_folderPath)) Directory.Delete(_folderPath, true);
        }

        public static MapLibrarySettings CreateSettings(string folderPath)
        {
            var settings = ScriptableObject.CreateInstance<MapLibrarySettings>();
            var serializedSettings = new SerializedObject(settings);
            serializedSettings.FindProperty("<FolderName>k__BackingField").stringValue = folderPath;
            serializedSettings.ApplyModifiedPropertiesWithoutUndo();
            return settings;
        }

        [Test]
        public void TryParseInfo_Valid()
        {
            Assert.IsTrue(LocalMapLibrary.TryParseInfo(ToJson("yard", "Yard", MapSdk.Version, "yard.mapbundle"), out var info, out string reason), reason);
            Assert.AreEqual("yard", info.Id);
            Assert.AreEqual("yard.mapbundle", info.BundleFileName);
        }

        [Test]
        public void TryParseInfo_WrongVersion_Rejected() =>
            Assert.IsFalse(LocalMapLibrary.TryParseInfo(ToJson("yard", "Yard", MapSdk.Version + 1, "yard.mapbundle"), out _, out _));

        [Test]
        public void TryParseInfo_BundleOutsideTheFolder_Rejected() =>
            Assert.IsFalse(LocalMapLibrary.TryParseInfo(ToJson("yard", "Yard", MapSdk.Version, "../yard.mapbundle"), out _, out _));

        [Test]
        public void TryParseInfo_NoId_Rejected() =>
            Assert.IsFalse(LocalMapLibrary.TryParseInfo(ToJson(string.Empty, "Yard", MapSdk.Version, "yard.mapbundle"), out _, out _));

        [Test]
        public void TryParseInfo_BrokenOrEmpty_Rejected()
        {
            Assert.IsFalse(LocalMapLibrary.TryParseInfo("{ not json", out _, out _));
            Assert.IsFalse(LocalMapLibrary.TryParseInfo(string.Empty, out _, out _));
        }

        [Test]
        public void Rescan_FindsMapAndHashesItsBundle()
        {
            WriteMap("yard", "yard.mapbundle");
            var library = new LocalMapLibrary(_settings);

            Assert.AreEqual(1, library.Maps.Count);
            Assert.AreEqual(AbcHash, library.Maps[0].ContentHash);
            Assert.IsTrue(library.TryFind("yard", AbcHash, out var entry));
            Assert.AreEqual(Encoding.ASCII.GetByteCount("abc"), entry.SizeInBytes);
        }

        [Test]
        public void TryFind_DifferentHash_NotFoundButContained()
        {
            WriteMap("yard", "yard.mapbundle");
            var library = new LocalMapLibrary(_settings);

            Assert.IsFalse(library.TryFind("yard", "0000", out _));
            Assert.IsTrue(library.Contains("yard"));
        }

        [Test]
        public void Rescan_SkipsMissingBundleAndWrongVersion()
        {
            File.WriteAllText(Path.Combine(_folderPath, _settings.GetInfoFileName("ghost")), ToJson("ghost", "Ghost", MapSdk.Version, "ghost.mapbundle"));
            File.WriteAllText(Path.Combine(_folderPath, _settings.GetInfoFileName("old")), ToJson("old", "Old", MapSdk.Version + 1, "old.mapbundle"));
            File.WriteAllText(Path.Combine(_folderPath, "old.mapbundle"), "abc");
            WriteMap("yard", "yard.mapbundle");

            var library = new LocalMapLibrary(_settings);

            Assert.AreEqual(1, library.Maps.Count);
            Assert.AreEqual("yard", library.Maps[0].Id);
        }

        [Test]
        public void Rescan_PicksUpNewMaps()
        {
            var library = new LocalMapLibrary(_settings);
            Assert.AreEqual(0, library.Maps.Count);

            WriteMap("yard", "yard.mapbundle");
            library.Rescan();

            Assert.AreEqual(1, library.Maps.Count);
        }

        [Test]
        public void NoFolder_Empty()
        {
            Directory.Delete(_folderPath, true);

            Assert.AreEqual(0, new LocalMapLibrary(_settings).Maps.Count);
        }

        [Test]
        public void Rescan_PreviewNextToTheMap_Found()
        {
            WriteMap("yard", "yard.mapbundle", "yard.preview.png");
            File.WriteAllText(Path.Combine(_folderPath, "yard.preview.png"), "png");

            var library = new LocalMapLibrary(_settings);

            Assert.AreEqual(Path.Combine(_folderPath, "yard.preview.png"), library.Maps[0].PreviewPath);
        }

        [TestCase(null)]
        [TestCase("missing.png")]
        [TestCase("yard.preview.gif")]
        [TestCase("../yard.preview.png")]
        public void Rescan_NoOrUnusablePreview_MapStillListedWithoutOne(string previewFileName)
        {
            WriteMap("yard", "yard.mapbundle", previewFileName);
            File.WriteAllText(Path.Combine(_folderPath, "yard.preview.gif"), "gif");

            var library = new LocalMapLibrary(_settings);

            Assert.AreEqual(1, library.Maps.Count);
            Assert.IsNull(library.Maps[0].PreviewPath);
        }

        [Test]
        public void Rescan_PreviewTooLarge_MapStillListedWithoutOne()
        {
            WriteMap("yard", "yard.mapbundle", "yard.preview.png");
            File.WriteAllBytes(Path.Combine(_folderPath, "yard.preview.png"), new byte[_settings.MaxPreviewSizeInBytes + 1]);

            var library = new LocalMapLibrary(_settings);

            Assert.IsNull(library.Maps[0].PreviewPath);
        }

        private void WriteMap(string id, string bundleFileName, string previewFileName = null)
        {
            File.WriteAllText(Path.Combine(_folderPath, bundleFileName), "abc");
            File.WriteAllText(Path.Combine(_folderPath, _settings.GetInfoFileName(id)), ToJson(id, id, MapSdk.Version, bundleFileName, previewFileName));
        }

        private static string ToJson(string id, string displayName, int sdkVersion, string bundleFileName, string previewFileName = null) =>
            JsonUtility.ToJson(new MapBundleInfo
            {
                Id = id,
                DisplayName = displayName,
                SdkVersion = sdkVersion,
                BundleFileName = bundleFileName,
                PreviewFileName = previewFileName
            });
    }
}
