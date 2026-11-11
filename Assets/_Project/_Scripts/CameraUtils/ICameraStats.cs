namespace Project.Assets._Project._Scripts.CameraUtils
{
    public interface ICameraStats
    {
        public float MaxPitch { get; }
        public float MouseLookXSensitivity { get; }
        public float MouseLookYSensitivity { get; }
        public float GamepadLookXSensitivity { get; }
        public float GamepadLookYSensitivity { get; }
    }
}
