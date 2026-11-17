using Steamworks;
using System;
using System.IO;

namespace Project.Assets._Project._Scripts.Networking
{
    // Steam voice: SteamUser records the microphone, detects speech and compresses it; the same API decodes others' voice.
    // Steam itself stays SteamPlatform's to start and stop.
    public class SteamVoiceChat : IVoiceChat
    {
        private readonly SteamPlatform _steam;
        private readonly MemoryStream _decompressed = new();

        public SteamVoiceChat(SteamPlatform steam)
        {
            _steam = steam;
            if (IsAvailable) SteamUser.SampleRate = SteamUser.OptimalSampleRate;
        }

        public bool IsAvailable => _steam.IsReady && SteamClient.IsValid;
        public int SampleRate => (int)SteamUser.SampleRate;

        public void SetRecording(bool isRecording)
        {
            if (!IsAvailable) return;
            SteamUser.VoiceRecord = isRecording;
        }

        public bool TryReadCompressed(out byte[] compressed)
        {
            compressed = null;
            if (!IsAvailable || !SteamUser.HasVoiceData) return false;

            compressed = SteamUser.ReadVoiceDataBytes();
            return compressed != null && compressed.Length > 0;
        }

        public bool TryDecompress(byte[] compressed, out ArraySegment<byte> pcm)
        {
            pcm = default;
            if (!IsAvailable || compressed == null || compressed.Length == 0) return false;

            _decompressed.Position = 0;
            _decompressed.SetLength(0);
            SteamUser.DecompressVoice(compressed, _decompressed);
            if (_decompressed.Length == 0) return false;

            pcm = new ArraySegment<byte>(_decompressed.GetBuffer(), 0, (int)_decompressed.Length);
            return true;
        }
    }
}
