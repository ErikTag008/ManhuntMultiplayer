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

        private float _stepProgress;
        private bool _wasAudible;
        private int _lastClipIndex = -1;

        private void LateUpdate()
        {
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
