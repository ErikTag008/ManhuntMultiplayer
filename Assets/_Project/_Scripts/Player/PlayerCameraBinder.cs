using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.SceneFlow;
using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Points the current scene's first-person rig at the owner player and forwards its rotation updates
    public class PlayerCameraBinder : MonoBehaviour
    {
        public event Action OnCameraRotationChanged;
        // the bound camera has its final pose for this frame, so screen projections made now match what renders
        public event Action OnCameraUpdated;

        private FPCameraInstaller _fpCameraInstaller;
        private Camera _camera;

        public Camera Camera => _camera;

        public void Bind(ISceneContext sceneContext, IFirstPersonCameraTarget target)
        {
            Unbind();

            _fpCameraInstaller = sceneContext.FPCameraInstaller;
            if (_fpCameraInstaller == null)
            {
                EUtils.Logger.LogError($"[PlayerCameraBinder] The {sceneContext.SceneType} scene has no FPCameraInstaller.");
                return;
            }

            // only a camera that reports its updates is exposed, so screen markers never wait on one that stays silent
            _camera = sceneContext.GameplayCamera;
            _fpCameraInstaller.BindCameraToPlayer(target);
            _fpCameraInstaller.OnCameraRotationChanged += HandleCameraRotationChanged;
            _fpCameraInstaller.OnOutputCameraUpdated += HandleOutputCameraUpdated;
        }

        public void ToggleLook(bool isEnabled)
        {
            if (_fpCameraInstaller != null) _fpCameraInstaller.ToggleLookInput(isEnabled);
        }

        // the previous scene's rig may already be destroyed; `is not null` skips Unity's fake-null so the plain C# event still drops us
        public void Unbind()
        {
            if (_fpCameraInstaller is not null)
            {
                _fpCameraInstaller.OnCameraRotationChanged -= HandleCameraRotationChanged;
                _fpCameraInstaller.OnOutputCameraUpdated -= HandleOutputCameraUpdated;
            }

            _fpCameraInstaller = null;
            _camera = null;
        }

        private void HandleCameraRotationChanged() => OnCameraRotationChanged?.Invoke();

        private void HandleOutputCameraUpdated(Camera camera)
        {
            if (camera == _camera) OnCameraUpdated?.Invoke();
        }

        private void OnDestroy() => Unbind();
    }
}
