using Project.Assets._Project._Scripts.CameraUtils;
using Reflex.Attributes;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class LobbyReferenceHolder : Singleton<LobbyReferenceHolder>
    {
        [Inject] public readonly Camera GameplayCamera;
        [Inject] public readonly FPCameraInstaller FPCameraInstaller;
    }

}
