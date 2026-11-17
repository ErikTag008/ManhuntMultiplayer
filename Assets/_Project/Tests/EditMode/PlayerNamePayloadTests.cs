using NUnit.Framework;
using Project.Assets._Project._Scripts.Networking;
using System.Text;
using Unity.Collections;

namespace Project.Assets._Project.Tests.EditMode
{
    public class PlayerNamePayloadTests
    {
        [TestCase("Alex")]
        [TestCase("Jürgen ★")]
        public void Name_RoundTrips(string name)
        {
            Assert.IsTrue(PlayerNamePayload.TryDecode(PlayerNamePayload.Encode(name), out var decoded));
            Assert.AreEqual(name, decoded);
        }

        [Test]
        public void LongName_IsCutToFitDisplayName()
        {
            var longName = new string('a', 200);

            var payload = PlayerNamePayload.Encode(longName);

            Assert.LessOrEqual(payload.Length, FixedString64Bytes.UTF8MaxLengthInBytes);
            Assert.IsTrue(PlayerNamePayload.TryDecode(payload, out var decoded));
            Assert.IsTrue(longName.StartsWith(decoded));
        }

        [Test]
        public void LongPayload_IsCutOnDecode()
        {
            var payload = Encoding.UTF8.GetBytes(new string('b', 500));

            Assert.IsTrue(PlayerNamePayload.TryDecode(payload, out var decoded));
            Assert.LessOrEqual(Encoding.UTF8.GetByteCount(decoded), FixedString64Bytes.UTF8MaxLengthInBytes);
        }

        [Test]
        public void EmptyOrBlankPayload_HasNoName()
        {
            Assert.IsFalse(PlayerNamePayload.TryDecode(null, out _));
            Assert.IsFalse(PlayerNamePayload.TryDecode(new byte[0], out _));
            Assert.IsFalse(PlayerNamePayload.TryDecode(Encoding.UTF8.GetBytes("   "), out _));
        }

        [Test]
        public void NullName_EncodesEmpty()
        {
            Assert.AreEqual(0, PlayerNamePayload.Encode(null).Length);
        }
    }
}
