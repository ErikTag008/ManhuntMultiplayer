using Project.Assets._Project._Scripts.CameraUtils;
using Reflex.Attributes;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class GameplayReferenceHolder : Singleton<GameplayReferenceHolder>
    {
        [Inject] public Camera GameplayCamera { get; private set; }
        [Inject] public FPCameraInstaller FPCameraInstaller { get; private set; }
    }

}
