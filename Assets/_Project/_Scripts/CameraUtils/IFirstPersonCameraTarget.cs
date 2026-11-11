using Project.Assets._Project._Scripts.Input;
using UnityEngine;

namespace Project.Assets._Project._Scripts.CameraUtils
{
    public interface IFirstPersonCameraTarget
    {
        Transform CameraTarget { get; }
        InputReader InputReader { get; }
    }
}
