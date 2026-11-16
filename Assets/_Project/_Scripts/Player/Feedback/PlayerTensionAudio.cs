using KBCore.Refs;
using Reflex.Attributes;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Feedback
{
    // The local runner's heartbeat and tension music, rising as the nearest catcher gets closer during the hunt.
    // Only the owner hears it (2D sources); catchers, eliminated runners (ghosts, spectators) and other instances stay silent.
    [RequireComponent(typeof(PlayerController), typeof(PlayerLifeState))]
    public class PlayerTensionAudio : ValidatedMonoBehaviour
    {
        // injected by PlayerController.Awake together with the rest of the player
        [Inject] private readonly SpawnedPlayerDirectory _spawnedPlayers;
        [Inject] private readonly HuntPhase _huntPhase;
        [SerializeField, Self] private PlayerController _controller;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField] private AudioSource _heartbeatSource;
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private TensionAudioData _data;

        private const float SecondsPerMinute = 60f;

        private float _intensity;
        private float _beatProgress = 1f;

        public float Intensity => _intensity;

        private bool IsTensionHeard => _lifeState.IsOwner && _huntPhase.IsActive && _controller.Team == Team.Runner && !_lifeState.IsEliminated;

        private void Update()
        {
            float targetIntensity = IsTensionHeard ? GetTargetIntensity() : 0f;
            if (_intensity <= 0f && targetIntensity <= 0f) return;

            _intensity = Mathf.MoveTowards(_intensity, targetIntensity, _data.IntensityChangeSpeed * Time.deltaTime);
            UpdateMusic();
            UpdateHeartbeat();
        }

        private float GetTargetIntensity()
        {
            if (!TryGetNearestCatcherDistance(out float distance) || distance >= _data.RadiusInMeters) return 0f;

            float closeness = 1f - distance / _data.RadiusInMeters;
            return Mathf.Clamp01(_data.IntensityByCloseness.Evaluate(closeness));
        }

        private bool TryGetNearestCatcherDistance(out float distance)
        {
            float nearestSqrDistance = float.MaxValue;
            foreach (var player in _spawnedPlayers.Players)
            {
                if (player == null || player.Team != Team.Catcher) continue;

                float sqrDistance = (player.transform.position - transform.position).sqrMagnitude;
                if (sqrDistance < nearestSqrDistance) nearestSqrDistance = sqrDistance;
            }

            distance = Mathf.Sqrt(nearestSqrDistance);
            return nearestSqrDistance < float.MaxValue;
        }

        private void UpdateMusic()
        {
            if (_data.MusicLayer == null) return;

            if (_intensity <= 0f)
            {
                _musicSource.Stop();
                return;
            }

            _musicSource.volume = _intensity * _data.MusicLayerMaxVolume;
            if (_musicSource.isPlaying) return;

            _musicSource.clip = _data.MusicLayer;
            _musicSource.loop = true;
            _musicSource.Play();
        }

        // the first beat comes right as the heartbeat starts, then the rate follows the intensity
        private void UpdateHeartbeat()
        {
            if (_data.HeartbeatSFX == null) return;

            if (_intensity < _data.HeartbeatMinIntensity)
            {
                _beatProgress = 1f;
                return;
            }

            if (_beatProgress >= 1f)
            {
                _beatProgress -= 1f;
                _heartbeatSource.PlayOneShot(_data.HeartbeatSFX, Mathf.Lerp(_data.HeartbeatSFXVolume.x, _data.HeartbeatSFXVolume.y, _intensity));
            }

            float beatsPerSecond = Mathf.Lerp(_data.HeartbeatRate.x, _data.HeartbeatRate.y, _intensity) / SecondsPerMinute;
            _beatProgress += beatsPerSecond * Time.deltaTime;
        }
    }
}
