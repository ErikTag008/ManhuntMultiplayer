using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.UI;
using UnityEngine;

namespace Project.Assets._Project._Scripts.SceneFlow
{
    // What a loaded scene offers the persistent player; registered by the scene's installer
    public interface ISceneContext
    {
        SceneType SceneType { get; }
        Camera GameplayCamera { get; }
        FPCameraInstaller FPCameraInstaller { get; }
        // Null outside the lobby
        ILobbyUI LobbyUI { get; }
    }
}
