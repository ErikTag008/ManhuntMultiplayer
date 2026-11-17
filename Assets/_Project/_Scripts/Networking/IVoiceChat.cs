using System;

namespace Project.Assets._Project._Scripts.Networking
{
    // The platform's microphone capture and voice codec: Steam voice, or nothing in Local mode
    public interface IVoiceChat
    {
        bool IsAvailable { get; }
        // of the PCM that TryDecompress gives out
        int SampleRate { get; }

        void SetRecording(bool isRecording);
        // The compressed voice captured since the last read; false when there is none
        bool TryReadCompressed(out byte[] compressed);
        // 16-bit mono PCM at SampleRate; the segment is reused by the next call
        bool TryDecompress(byte[] compressed, out ArraySegment<byte> pcm);
    }
}
