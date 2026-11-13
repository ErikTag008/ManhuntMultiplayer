using NUnit.Framework;
using Project.Assets._Project._Scripts;
using Project.Assets._Project._Scripts.Settings;
using UnityEditor;
using UnityEngine;

namespace Project.Tests.EditMode
{
    public class SettingsTests
    {
        private const string TestSaveKey = "SettingsTests.GameSettings";
        private const float MinDecibels = -80f;

        private SettingsData _data;

        [SetUp]
        public void SetUp()
        {
            _data = ScriptableObject.CreateInstance<SettingsData>();
            var serialized = new SerializedObject(_data);
            serialized.FindProperty("<SaveKey>k__BackingField").stringValue = TestSaveKey;
            serialized.ApplyModifiedPropertiesWithoutUndo();
            PlayerPrefs.DeleteKey(TestSaveKey);
        }

        [TearDown]
        public void TearDown()
        {
            PlayerPrefs.DeleteKey(TestSaveKey);
            Object.DestroyImmediate(_data);
        }

        [Test]
        public void LinearToDecibels_FullVolumeIsZeroAndSilenceIsTheFloor()
        {
            Assert.AreEqual(0f, EUtils.Math.LinearToDecibels(1f, MinDecibels), 0.0001f);
            Assert.AreEqual(MinDecibels, EUtils.Math.LinearToDecibels(0f, MinDecibels));
            Assert.AreEqual(MinDecibels, EUtils.Math.LinearToDecibels(0.00001f, MinDecibels));
            Assert.AreEqual(-6.0206f, EUtils.Math.LinearToDecibels(0.5f, MinDecibels), 0.001f);
        }

        [Test]
        public void CopyCategoryFrom_OnlyTouchesThatCategory()
        {
            var target = _data.CreateDefaults();
            var source = _data.CreateDefaults();
            source.MasterVolume = 0.1f;
            source.FieldOfView = 99f;
            source.MouseSensitivityX = 2.5f;

            target.CopyCategoryFrom(source, SettingsCategory.Audio);

            Assert.AreEqual(0.1f, target.MasterVolume);
            Assert.AreEqual(_data.DefaultFieldOfView, target.FieldOfView);
            Assert.AreEqual(_data.DefaultSensitivity, target.MouseSensitivityX);
        }

        [Test]
        public void Clamp_KeepsValuesInsideTheMenuRanges()
        {
            var values = _data.CreateDefaults();
            values.FieldOfView = 500f;
            values.SfxVolume = 2f;
            values.GamepadSensitivityY = -1f;
            values.FrameCap = -30;
            values.BindingOverridesJson = null;

            _data.Clamp(values);

            Assert.AreEqual(_data.MaxFieldOfView, values.FieldOfView);
            Assert.AreEqual(1f, values.SfxVolume);
            Assert.AreEqual(_data.MinSensitivity, values.GamepadSensitivityY);
            Assert.AreEqual(0, values.FrameCap);
            Assert.AreEqual(string.Empty, values.BindingOverridesJson);
        }

        [Test]
        public void Service_SavedChangesLoadInANewService()
        {
            var service = new GameSettingsService(_data);
            service.Change(SettingsCategory.Game, values => values.IsLookYInverted = true);
            service.Change(SettingsCategory.Audio, values => values.MusicVolume = 0.25f);
            service.Save();

            var reloaded = new GameSettingsService(_data);

            Assert.IsTrue(reloaded.Values.IsLookYInverted);
            Assert.AreEqual(0.25f, reloaded.Values.MusicVolume, 0.0001f);
        }

        [Test]
        public void Service_ChangeRaisesTheCategory()
        {
            var service = new GameSettingsService(_data);
            SettingsCategory? raised = null;
            service.OnChanged += category => raised = category;

            service.Change(SettingsCategory.Video, values => values.FieldOfView = 80f);

            Assert.AreEqual(SettingsCategory.Video, raised);
        }

        [Test]
        public void Service_ResetCategoryRestoresDefaultsForThatTabOnly()
        {
            var service = new GameSettingsService(_data);
            service.Change(SettingsCategory.Video, values => values.FieldOfView = 90f);
            service.Change(SettingsCategory.Audio, values => values.UiVolume = 0.3f);

            service.ResetCategory(SettingsCategory.Video);

            Assert.AreEqual(_data.DefaultFieldOfView, service.Values.FieldOfView);
            Assert.AreEqual(0.3f, service.Values.UiVolume, 0.0001f);
        }

        [Test]
        public void Service_UnreadableSaveFallsBackToDefaults()
        {
            PlayerPrefs.SetString(TestSaveKey, "{ not json");

            var service = new GameSettingsService(_data);

            Assert.AreEqual(_data.DefaultMasterVolume, service.Values.MasterVolume);
            Assert.AreEqual(_data.DefaultFieldOfView, service.Values.FieldOfView);
        }
    }
}
