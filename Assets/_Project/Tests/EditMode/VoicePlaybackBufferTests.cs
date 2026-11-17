using NUnit.Framework;
using Project.Assets._Project._Scripts.Player.Voice;

namespace Project.Assets._Project.Tests.EditMode
{
    public class VoicePlaybackBufferTests
    {
        private static byte[] ToPcm16(params short[] samples)
        {
            var bytes = new byte[samples.Length * 2];
            for (int i = 0; i < samples.Length; i++)
            {
                bytes[i * 2] = (byte)(samples[i] & 0xFF);
                bytes[i * 2 + 1] = (byte)((samples[i] >> 8) & 0xFF);
            }

            return bytes;
        }

        private static void Write(VoicePlaybackBuffer buffer, params short[] samples)
        {
            var bytes = ToPcm16(samples);
            buffer.WritePcm16(bytes, 0, bytes.Length);
        }

        [Test]
        public void Read_BeforeStartBuffer_PlaysSilence()
        {
            var buffer = new VoicePlaybackBuffer(8, 3);
            Write(buffer, 1000, 2000);
            var data = new[] { 1f, 1f };

            buffer.Read(data);

            Assert.AreEqual(0f, data[0]);
            Assert.AreEqual(0f, data[1]);
            Assert.AreEqual(2, buffer.BufferedSampleCount);
            Assert.IsFalse(buffer.IsPlaying);
        }

        [Test]
        public void Read_AfterStartBuffer_ConvertsPcm16AndPadsWithSilence()
        {
            var buffer = new VoicePlaybackBuffer(8, 2);
            Write(buffer, 16384, -32768);
            var data = new[] { 1f, 1f, 1f };

            buffer.Read(data);

            Assert.AreEqual(0.5f, data[0], 0.0001f);
            Assert.AreEqual(-1f, data[1], 0.0001f);
            Assert.AreEqual(0f, data[2]);
            Assert.AreEqual(0, buffer.BufferedSampleCount);
        }

        [Test]
        public void Read_AfterRunningDry_WaitsForStartBufferAgain()
        {
            var buffer = new VoicePlaybackBuffer(8, 2);
            Write(buffer, 100, 200);
            buffer.Read(new float[2]);
            Write(buffer, 16384);
            var data = new[] { 1f };

            buffer.Read(data);

            Assert.AreEqual(0f, data[0]);
            Assert.AreEqual(1, buffer.BufferedSampleCount);
        }

        [Test]
        public void Write_BeyondCapacity_DropsTheOldestSamples()
        {
            var buffer = new VoicePlaybackBuffer(3, 1);
            Write(buffer, 1, 2, 3, 16384, 8192);
            var data = new float[3];

            buffer.Read(data);

            Assert.AreEqual(3, buffer.Capacity);
            Assert.AreEqual(3f / 32768f, data[0], 0.000001f);
            Assert.AreEqual(0.5f, data[1], 0.0001f);
            Assert.AreEqual(0.25f, data[2], 0.0001f);
        }

        [Test]
        public void Write_OddByteCount_IgnoresTheTrailingByte()
        {
            var buffer = new VoicePlaybackBuffer(8, 1);
            var bytes = ToPcm16(16384, 16384);

            buffer.WritePcm16(bytes, 0, bytes.Length - 1);

            Assert.AreEqual(1, buffer.BufferedSampleCount);
        }

        [Test]
        public void Clear_EmptiesAndStopsPlaying()
        {
            var buffer = new VoicePlaybackBuffer(8, 1);
            Write(buffer, 100, 200);
            buffer.Read(new float[1]);

            buffer.Clear();

            Assert.AreEqual(0, buffer.BufferedSampleCount);
            Assert.IsFalse(buffer.IsPlaying);
        }
    }
}
