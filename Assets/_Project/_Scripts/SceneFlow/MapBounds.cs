using UnityEngine;

namespace Project.Assets._Project._Scripts.SceneFlow
{
    // The box a map lets free-flying players move in. The bounds are in world space and axis-aligned; this object's transform
    // doesn't move them. "Fit To Level" on the component's context menu wraps every renderer and collider under the level root, plus padding.
    public class MapBounds : MonoBehaviour
    {
        [SerializeField] private Bounds _bounds = new(Vector3.zero, new Vector3(200f, 100f, 200f));
        // the scene's environment; only read by Fit To Level
        [SerializeField] private Transform _levelRoot;
        [SerializeField, Min(0f)] private float _sidePaddingInMeters = 5f;
        [SerializeField, Min(0f)] private float _bottomPaddingInMeters = 5f;
        [SerializeField, Min(0f)] private float _topPaddingInMeters = 15f;
        [SerializeField] private Color _gizmoColor = Color.cyan;

        public Bounds Bounds => _bounds;

        // false when there is no level root or nothing under it to measure
        public bool TryFitToLevel()
        {
            if (_levelRoot == null) return false;

            bool hasLevelBounds = false;
            var levelBounds = new Bounds();
            foreach (var renderer in _levelRoot.GetComponentsInChildren<Renderer>())
            {
                Encapsulate(ref levelBounds, ref hasLevelBounds, renderer.bounds);
            }

            foreach (var collider in _levelRoot.GetComponentsInChildren<Collider>())
            {
                Encapsulate(ref levelBounds, ref hasLevelBounds, collider.bounds);
            }

            if (!hasLevelBounds) return false;

            Vector3 min = levelBounds.min - new Vector3(_sidePaddingInMeters, _bottomPaddingInMeters, _sidePaddingInMeters);
            Vector3 max = levelBounds.max + new Vector3(_sidePaddingInMeters, _topPaddingInMeters, _sidePaddingInMeters);
            _bounds.SetMinMax(min, max);
            return true;
        }

        // True when anything changed: the position is pulled back inside, and the velocity loses whatever pushes further out
        public static bool TryClamp(Bounds bounds, Vector3 position, Vector3 velocity, out Vector3 clampedPosition, out Vector3 clampedVelocity)
        {
            Vector3 min = bounds.min;
            Vector3 max = bounds.max;
            clampedPosition = new Vector3(
                Mathf.Clamp(position.x, min.x, max.x),
                Mathf.Clamp(position.y, min.y, max.y),
                Mathf.Clamp(position.z, min.z, max.z));
            clampedVelocity = new Vector3(
                RemoveOutwardSpeed(clampedPosition.x, min.x, max.x, velocity.x),
                RemoveOutwardSpeed(clampedPosition.y, min.y, max.y, velocity.y),
                RemoveOutwardSpeed(clampedPosition.z, min.z, max.z, velocity.z));
            return clampedPosition != position || clampedVelocity != velocity;
        }

        // sliding along a wall of the box keeps working; only the push through it stops
        private static float RemoveOutwardSpeed(float position, float min, float max, float speed)
        {
            if (position <= min && speed < 0f) return 0f;
            if (position >= max && speed > 0f) return 0f;
            return speed;
        }

        private static void Encapsulate(ref Bounds total, ref bool hasAny, Bounds bounds)
        {
            if (hasAny)
            {
                total.Encapsulate(bounds);
                return;
            }

            total = bounds;
            hasAny = true;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _gizmoColor;
            Gizmos.DrawWireCube(_bounds.center, _bounds.size);
        }
    }
}
