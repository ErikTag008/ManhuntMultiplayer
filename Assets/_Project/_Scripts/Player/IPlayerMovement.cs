using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    public interface IPlayerMovement 
    {
        void ToggleMovement(bool isEnabled);
        void HandleJump(bool isButtonDown = true);
        void HandleFixedMovement(Vector2 moveDirection);
        bool IsGrounded();
        void DrawGizmos();
        void ChangeCamera(Camera camera);
    }
}
