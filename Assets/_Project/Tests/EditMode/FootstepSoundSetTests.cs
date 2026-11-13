using NUnit.Framework;
using Project.Assets._Project._Scripts.Player;
using UnityEditor;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class FootstepSoundSetTests
    {
        private const int PickCount = 500;

        private static FootstepSoundSet CreateSet(int clipCount)
        {
            var set = ScriptableObject.CreateInstance<FootstepSoundSet>();
            var serialized = new SerializedObject(set);
            var clips = serialized.FindProperty("<Clips>k__BackingField");
            clips.arraySize = clipCount;
            serialized.ApplyModifiedPropertiesWithoutUndo();
            return set;
        }

        [Test]
        public void NoClips_PicksNothing()
        {
            var set = CreateSet(0);
            Assert.AreEqual(-1, set.PickNextIndex(-1));
            Object.DestroyImmediate(set);
        }

        [Test]
        public void OneClip_AlwaysPicksIt()
        {
            var set = CreateSet(1);
            Assert.AreEqual(0, set.PickNextIndex(0));
            Object.DestroyImmediate(set);
        }

        [Test]
        public void SeveralClips_NeverRepeatsAndUsesEveryOther()
        {
            var set = CreateSet(3);
            var seen = new bool[3];
            int last = -1;
            for (int i = 0; i < PickCount; i++)
            {
                int index = set.PickNextIndex(last);
                Assert.That(index, Is.InRange(0, 2));
                Assert.AreNotEqual(last, index);
                seen[index] = true;
                last = index;
            }

            Assert.IsTrue(seen[0] && seen[1] && seen[2]);
            Object.DestroyImmediate(set);
        }
    }
}
