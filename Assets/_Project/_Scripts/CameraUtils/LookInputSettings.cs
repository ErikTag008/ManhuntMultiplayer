using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Settings;
using Unity.Cinemachine;

namespace Project.Assets._Project._Scripts.CameraUtils
{
    // Applies the player's look sensitivity to a Cinemachine input controller whose first two axes are look X and Y
    public static class LookInputSettings
    {
        private const int XIndex = 0;
        private const int YIndex = 1;

        // the stats hold the base sensitivity; the settings scale it per device and can invert Y
        public static void Apply(CinemachineInputAxisController controller, InputReader inputReader, ICameraStats cameraStats, GameSettingsValues settings)
        {
            bool isUsingMouse = inputReader.IsUsingMouse;
            float xGain = isUsingMouse ? cameraStats.MouseLookXSensitivity * settings.MouseSensitivityX : cameraStats.GamepadLookXSensitivity * settings.GamepadSensitivityX;
            float yGain = isUsingMouse ? cameraStats.MouseLookYSensitivity * settings.MouseSensitivityY : cameraStats.GamepadLookYSensitivity * settings.GamepadSensitivityY;
            controller.Controllers[XIndex].Input.Gain = xGain;
            controller.Controllers[YIndex].Input.Gain = settings.IsLookYInverted ? yGain : -yGain;
            // Mouse delta is already a per-frame amount; scaling it by deltaTime again makes look speed follow the frame rate (stutter)
            controller.Controllers[XIndex].Input.CancelDeltaTime = isUsingMouse;
            controller.Controllers[YIndex].Input.CancelDeltaTime = isUsingMouse;
        }
    }
}
