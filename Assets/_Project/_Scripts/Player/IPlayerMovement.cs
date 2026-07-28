using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    public interface IPlayerMovement 
    {
        void Start();
        void HandleJump(bool isButtonDown = true);
        void HandleFixedMovement(Vector2 moveDirection);
        bool IsGrounded();
        void DrawGizmos();
        void ChangeCamera(Camera camera);
    }
}
