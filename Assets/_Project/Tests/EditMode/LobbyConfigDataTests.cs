using NUnit.Framework;
using Project.Assets._Project._Scripts.Networking;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class LobbyConfigDataTests
    {
        private LobbyConfigData _data;

        [SetUp]
        public void SetUp() => _data = ScriptableObject.CreateInstance<LobbyConfigData>();

        [TearDown]
        public void TearDown() => Object.DestroyImmediate(_data);

        [Test]
        public void MaxPlayerOptions_RunFromMinToMax()
        {
            var options = new List<int>();
            _data.GetMaxPlayerOptions(options);

            CollectionAssert.AreEqual(new[] { 4, 5, 6, 7, 8, 9, 10 }, options);
        }

        [Test]
        public void HideDurationOptions_StepByFiveSeconds()
        {
            var options = new List<float>();
            _data.GetHideDurationOptions(options);

            CollectionAssert.AreEqual(new[] { 15f, 20f, 25f, 30f, 35f, 40f, 45f, 50f, 55f, 60f }, options);
        }

        [Test]
        public void RoundDurationOptions_StepByThirtySeconds()
        {
            var options = new List<float>();
            _data.GetRoundDurationOptions(options);

            Assert.AreEqual(15, options.Count);
            Assert.AreEqual(180f, options[0]);
            Assert.AreEqual(600f, options[options.Count - 1]);
        }

        [Test]
        public void Defaults_AreAmongTheOptions()
        {
            var config = _data.CreateDefault();
            var maxPlayerOptions = new List<int>();
            var hideOptions = new List<float>();
            var roundOptions = new List<float>();
            _data.GetMaxPlayerOptions(maxPlayerOptions);
            _data.GetHideDurationOptions(hideOptions);
            _data.GetRoundDurationOptions(roundOptions);

            CollectionAssert.Contains(maxPlayerOptions, config.MaxPlayers);
            CollectionAssert.Contains(hideOptions, config.HideDurationInSeconds);
            CollectionAssert.Contains(roundOptions, config.RoundDurationInSeconds);
            Assert.AreEqual(_data.DefaultName, config.Name.ToString());
            Assert.AreEqual(LobbyVisibility.Public, config.Visibility);
        }

        [Test]
        public void FillRange_StopsAtMaxWhenTheStepOvershoots()
        {
            var options = new List<int>();
            LobbyConfigData.FillRange(1, 10, 4, options);

            CollectionAssert.AreEqual(new[] { 1, 5, 9 }, options);
        }

        [Test]
        public void FillRange_KeepsTheLastFloatStepDespiteRounding()
        {
            var options = new List<float>();
            LobbyConfigData.FillRange(0f, 1f, 0.1f, options);

            Assert.AreEqual(11, options.Count);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void FillRange_WithoutAPositiveStep_GivesOnlyMin(int step)
        {
            var options = new List<int>();
            LobbyConfigData.FillRange(4, 10, step, options);

            CollectionAssert.AreEqual(new[] { 4 }, options);
        }

        [Test]
        public void FindClosestIndex_PicksTheNearestOption()
        {
            var options = new List<float> { 15f, 20f, 25f };

            Assert.AreEqual(1, LobbyConfigData.FindClosestIndex(options, 21f));
            Assert.AreEqual(-1, LobbyConfigData.FindClosestIndex(new List<float>(), 21f));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void SanitizeName_UsesTheDefaultForBlankNames(string name)
        {
            Assert.AreEqual(_data.DefaultName, _data.SanitizeName(name));
        }

        [Test]
        public void SanitizeName_TrimsAndCutsLongNames()
        {
            Assert.AreEqual("My lobby", _data.SanitizeName("  My lobby  "));
            Assert.AreEqual(_data.MaxNameLength, _data.SanitizeName(new string('x', _data.MaxNameLength + 10)).Length);
        }

        [Test]
        public void ToName_CutsNamesThatDontFitInsteadOfThrowing()
        {
            var name = LobbyConfig.ToName(new string('x', 200));

            Assert.Greater(name.Length, 0);
            Assert.LessOrEqual(name.Length, name.Capacity);
        }
    }
}
