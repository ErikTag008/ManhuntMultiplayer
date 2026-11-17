using System;

namespace Project.Assets._Project._Scripts.Player.Voice
{
    // Ring buffer between the network (main thread writes decoded 16-bit PCM) and a streaming AudioClip (audio thread reads floats).
    // Plays silence while empty, and after running dry waits until the start amount is buffered again.
    // When full, the oldest samples are dropped so a delayed voice catches up.
    public class VoicePlaybackBuffer
    {
        private const int BytesPerSample = 2;
        private const float Pcm16Scale = 32768f;

        private readonly object _lock = new();
        private readonly float[] _samples;
        private readonly int _startSampleCount;
        private int _readIndex;
        private int _count;
        private bool _isPlaying;

        public VoicePlaybackBuffer(int capacityInSamples, int startSampleCount)
        {
            _samples = new float[Math.Max(1, capacityInSamples)];
            _startSampleCount = Math.Clamp(startSampleCount, 1, _samples.Length);
        }

        public int Capacity => _samples.Length;

        public int BufferedSampleCount
        {
            get
            {
                lock (_lock) return _count;
            }
        }

        public bool IsPlaying
        {
            get
            {
                lock (_lock) return _isPlaying;
            }
        }

        // little-endian 16-bit mono; a trailing odd byte is ignored
        public void WritePcm16(byte[] bytes, int offset, int length)
        {
            int end = offset + length - length % BytesPerSample;
            lock (_lock)
            {
                for (int i = offset; i < end; i += BytesPerSample)
                {
                    short sample = (short)(bytes[i] | bytes[i + 1] << 8);
                    Push(sample / Pcm16Scale);
                }
            }
        }

        // fills the whole span; the clip's PCMReaderCallback calls this on the audio thread
        public void Read(float[] data)
        {
            lock (_lock)
            {
                if (!_isPlaying && _count >= _startSampleCount) _isPlaying = true;

                int written = 0;
                if (_isPlaying)
                {
                    for (; written < data.Length && _count > 0; written++)
                    {
                        data[written] = _samples[_readIndex];
                        _readIndex = (_readIndex + 1) % _samples.Length;
                        _count--;
                    }

                    if (_count == 0) _isPlaying = false;
                }

                Array.Clear(data, written, data.Length - written);
            }
        }

        public void Clear()
        {
            lock (_lock)
            {
                _readIndex = 0;
                _count = 0;
                _isPlaying = false;
            }
        }

        private void Push(float sample)
        {
            if (_count == _samples.Length)
            {
                _readIndex = (_readIndex + 1) % _samples.Length;
                _count--;
            }

            _samples[(_readIndex + _count) % _samples.Length] = sample;
            _count++;
        }
    }
}
