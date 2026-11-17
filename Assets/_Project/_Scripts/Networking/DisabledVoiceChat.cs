using System;

namespace Project.Assets._Project._Scripts.Networking
{
    // Local mode has no voice: nothing is captured, so nothing is ever sent or played
    public class DisabledVoiceChat : IVoiceChat
    {
        public bool IsAvailable => false;
        public int SampleRate => 0;

        public void SetRecording(bool isRecording) { }

        public bool TryReadCompressed(out byte[] compressed)
        {
            compressed = null;
            return false;
        }

        public bool TryDecompress(byte[] compressed, out ArraySegment<byte> pcm)
        {
            pcm = default;
            return false;
        }
    }
}
