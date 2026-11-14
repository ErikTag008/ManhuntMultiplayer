using KBCore.Refs;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Settings;
using Reflex.Attributes;
using Unity.Cinemachine;
using UnityEngine;

namespace Project.Assets._Project._Scripts.CameraUtils
{
    // Third-person orbit camera that watches a target. Its priority sits above the first-person rig,
    // so enabling the camera takes over the view and disabling it hands the view back.
    public class SpectatorCamera : ValidatedMonoBehaviour
    {
        [Inject] private readonly ICameraStats _cameraStats;
        [Inject] private readonly GameSettingsService _settings;
        [SerializeField, Self] private CinemachineCamera _camera;
        [SerializeField, Self] private CinemachineOrbitalFollow _orbitalFollow;
        [SerializeField, Self] private CinemachineInputAxisController _inputAxisController;

        private InputReader _inputReader;

        public bool IsWatching => _camera.enabled;
        public Transform Target => _camera.Target.TrackingTarget;

        // the owner's PlayerInput enables its actions; Cinemachine enabling Look itself would undo the pause menu turning it off
        private void Awake()
        {
            _inputAxisController.AutoEnableInputs = false;
            ToggleCamera(false);
        }

        private void Update()
        {
            if (!IsWatching || _inputReader == null) return;
            LookInputSettings.Apply(_inputAxisController, _inputReader, _cameraStats, _settings.Values);
        }

        // A new target starts the orbit behind them at the default pitch, facing the given heading, with no ease-in
        public void Watch(Transform target, float headingInDegrees, InputReader inputReader)
        {
            if (target == null) return;

            bool isNewTarget = target != Target;
            _inputReader = inputReader;
            _camera.Target.TrackingTarget = target;
            if (isNewTarget || !IsWatching)
            {
                _orbitalFollow.HorizontalAxis.Value = headingInDegrees;
                _orbitalFollow.VerticalAxis.Value = _orbitalFollow.VerticalAxis.Center;
                // snap to the new target instead of damping in from the last pose, which can be across or outside the map
                _camera.PreviousStateIsValid = false;
            }

            ToggleCamera(true);
        }

        // The target is gone and nobody else can be watched: keep the current pose instead of cutting away
        public void HoldLastView() => _camera.Target.TrackingTarget = null;

        public void Stop()
        {
            ToggleCamera(false);
            _camera.Target.TrackingTarget = null;
            _inputReader = null;
        }

        // the input controller keeps moving the orbit axes while the camera is off, so it is switched with it
        private void ToggleCamera(bool isEnabled)
        {
            _camera.enabled = isEnabled;
            _inputAxisController.enabled = isEnabled;
        }
    }
}
