using KBCore.Refs;
using Project.Assets._Project._Scripts.Input;
using Reflex.Attributes;
using System;
using Unity.Cinemachine;
using UnityEngine;

namespace Project.Assets._Project._Scripts.CameraUtils
{
    public class FPCameraInstaller : ValidatedMonoBehaviour
    {
        [Inject] private readonly ICameraStats _cameraStats;
        private InputReader _inputReader;
        [SerializeField, Self] private CinemachineCamera _camera;
        [SerializeField, Self] private CinemachineInputAxisController _cinemachineInputAxisController;
        [SerializeField, Self] private CinemachinePanTilt _cinemachinePanTilt;
        public event Action OnCameraRotationChanged;
        private void Start()
        {
            CinemachineCore.CameraUpdatedEvent.AddListener(OnCameraUpdate);

        }

        private void OnDestroy()
        {
            CinemachineCore.CameraUpdatedEvent.RemoveListener(OnCameraUpdate);

        }

        private void OnCameraUpdate(CinemachineBrain brain)
        {
            if (brain.ActiveVirtualCamera != _camera as ICinemachineCamera)
                return;
            OnCameraRotationChanged?.Invoke();
        }

        private void Update()
        {
            if(_inputReader == null) return;
            LookInputSettings.Apply(_cinemachineInputAxisController, _inputReader, _cameraStats);
            _cinemachinePanTilt.TiltAxis.Range = new Vector2(-_cameraStats.MaxPitch, _cameraStats.MaxPitch);
        }

        public void BindCameraToPlayer(IFirstPersonCameraTarget player)
        {
            print(EUtils.Logger.Colorize("Bind Camera Was Called", "blue"));
            if (player == null)
            {
                print(EUtils.Logger.Colorize("PLAYER IS NULL TO THE FPCAMERA", "red"));
                return;
            }
            _camera.Target.TrackingTarget = player.CameraTarget;
            _inputReader = player.InputReader;
            print(EUtils.Logger.Colorize("Successfully Binded Camera To Player", "green"));

        }
    }
}
