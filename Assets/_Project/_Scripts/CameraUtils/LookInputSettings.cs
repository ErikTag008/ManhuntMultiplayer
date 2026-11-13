using Project.Assets._Project._Scripts.Input;
using Unity.Cinemachine;

namespace Project.Assets._Project._Scripts.CameraUtils
{
    // Applies the player's look sensitivity to a Cinemachine input controller whose first two axes are look X and Y
    public static class LookInputSettings
    {
        private const int XIndex = 0;
        private const int YIndex = 1;

        public static void Apply(CinemachineInputAxisController controller, InputReader inputReader, ICameraStats cameraStats)
        {
            bool isUsingMouse = inputReader.IsUsingMouse;
            controller.Controllers[XIndex].Input.Gain = isUsingMouse ? cameraStats.MouseLookXSensitivity : cameraStats.GamepadLookXSensitivity;
            controller.Controllers[YIndex].Input.Gain = isUsingMouse ? -cameraStats.MouseLookYSensitivity : -cameraStats.GamepadLookYSensitivity;
            // Mouse delta is already a per-frame amount; scaling it by deltaTime again makes look speed follow the frame rate (stutter)
            controller.Controllers[XIndex].Input.CancelDeltaTime = isUsingMouse;
            controller.Controllers[YIndex].Input.CancelDeltaTime = isUsingMouse;
        }
    }
}
