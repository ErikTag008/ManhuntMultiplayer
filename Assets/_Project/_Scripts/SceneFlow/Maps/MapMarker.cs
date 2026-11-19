using UnityEngine;

namespace Project.Assets._Project._Scripts.SceneFlow.Maps
{
    // A point a bundle map gives the game; the position and forward direction are what's used
    public abstract class MapMarker : MonoBehaviour
    {
        [SerializeField] private Color _gizmoColor = Color.white;
        [SerializeField, Min(0f)] private float _gizmoRadiusInMeters = 0.5f;
        [SerializeField, Min(0f)] private float _gizmoArrowLengthInMeters = 1f;

        protected abstract Color DefaultGizmoColor { get; }

        private void Reset() => _gizmoColor = DefaultGizmoColor;

        private void OnDrawGizmos()
        {
            Gizmos.color = _gizmoColor;
            Gizmos.DrawWireSphere(transform.position, _gizmoRadiusInMeters);
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * _gizmoArrowLengthInMeters);
        }
    }
}
