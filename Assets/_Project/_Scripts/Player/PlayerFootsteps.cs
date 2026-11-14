using KBCore.Refs;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Plays this player's footsteps from its movement on every instance, so others hear where it is (3D, fades with distance).
    // Moving slower than the silent share of the full run speed (walking, crouching, a small stick push, crawling) makes no sound,
    // and neither do slides and ledge climbs, where the feet aren't stepping.
    [RequireComponent(typeof(PlayerMotion), typeof(PlayerLifeState), typeof(PlayerPosture))]
    public class PlayerFootsteps : ValidatedMonoBehaviour
    {
        [SerializeField, Self] private PlayerMotion _motion;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private PlayerPosture _posture;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private FootstepSoundSet _soundSet;
        [SerializeField, Range(0f, 1f)] private float _silentSpeedShare = 0.4f;
        [SerializeField] private float _stepsPerSecondAtFullSpeed = 4.5f;
        // the first step after starting to run comes quickly instead of after a full step interval
        [SerializeField, Range(0f, 1f)] private float _firstStepHead = 0.6f;
        // shorter air time (stairs, small bumps, ground probe flicker) lands silently
        [SerializeField] private float _minAirTimeForLandingInSeconds = 0.25f;

        private float _stepProgress;
        private bool _wasAudible;
        private int _lastClipIndex = -1;
        private float _airTime;

        private void LateUpdate()
        {
            if (TryLand()) return;

            float normalizedSpeed = _motion.NormalizedPlanarSpeed;
            bool isStepping = _posture.Posture is Posture.Standing or Posture.Crouching;
            bool isAudible = _lifeState.IsUp && isStepping && _motion.IsGrounded && normalizedSpeed >= _silentSpeedShare;
            if (!isAudible)
            {
                _wasAudible = false;
                return;
            }

            if (!_wasAudible) _stepProgress = _firstStepHead;
            _wasAudible = true;

            _stepProgress += normalizedSpeed * _stepsPerSecondAtFullSpeed * Time.deltaTime;
            if (_stepProgress < 1f) return;

            _stepProgress -= 1f;
            PlayStep();
        }

        // Landing makes noise even at walk speed or crouched, so jumping can't be used to move silently.
        // The landing frame skips the step, and the next step comes a full interval later.
        private bool TryLand()
        {
            if (!_motion.IsGrounded)
            {
                _airTime += Time.deltaTime;
                return false;
            }

            bool isLanding = _airTime >= _minAirTimeForLandingInSeconds;
            _airTime = 0f;
            if (!isLanding || !_lifeState.IsUp || _posture.Posture == Posture.Mantling) return false;

            PlayLanding();
            _stepProgress = 0f;
            _wasAudible = true;
            return true;
        }

        private void PlayLanding()
        {
            var clip = _soundSet.PickLandingClip();
            if (clip == null) return;

            _audioSource.pitch = Random.Range(_soundSet.LandingPitchRange.x, _soundSet.LandingPitchRange.y);
            _audioSource.PlayOneShot(clip, _soundSet.LandingVolume);
        }

        private void PlayStep()
        {
            int index = _soundSet.PickNextIndex(_lastClipIndex);
            if (index < 0) return;

            _lastClipIndex = index;
            _audioSource.pitch = Random.Range(_soundSet.PitchRange.x, _soundSet.PitchRange.y);
            _audioSource.PlayOneShot(_soundSet.Clips[index], _soundSet.Volume);
        }
    }
}
