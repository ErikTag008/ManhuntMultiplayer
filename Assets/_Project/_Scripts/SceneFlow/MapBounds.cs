using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Assets._Project._Scripts.SceneFlow
{
    // The box a map lets free-flying players move in. The bounds are in world space and axis-aligned; this object's transform
    // doesn't move them. "Fit To Level" on the component's context menu wraps every renderer and collider under the level root, plus padding.
    // In play mode it also raises an invisible barrier at the level's edge (the bounds minus the side padding) with a ceiling at the
    // bounds' top, so living players can't wall-jump over the perimeter.
    public class MapBounds : MonoBehaviour
    {
        [SerializeField] private Bounds _bounds = new(Vector3.zero, new Vector3(200f, 100f, 200f));
        // the scene's environment; only read by Fit To Level
        [SerializeField] private Transform _levelRoot;
        [SerializeField, Min(0f)] private float _sidePaddingInMeters = 5f;
        [SerializeField, Min(0f)] private float _bottomPaddingInMeters = 5f;
        [SerializeField, Min(0f)] private float _topPaddingInMeters = 15f;
        [SerializeField] private bool _hasPlayerBarrier = true;
        [SerializeField, Min(0.1f)] private float _barrierThicknessInMeters = 2f;
        [SerializeField] private string _barrierLayerName = "Default";
        [SerializeField] private string _barrierName = "PlayerBarrier";
        [SerializeField] private Color _gizmoColor = Color.cyan;
        [SerializeField] private Color _barrierGizmoColor = Color.magenta;

        private GameObject _playerBarrier;

        public Bounds Bounds => _bounds;

        private void Awake()
        {
            if (_hasPlayerBarrier) BuildPlayerBarrier();
        }

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

        // The level's footprint: Fit To Level adds the side padding around it, so taking it off again finds the perimeter's outer face
        private Bounds GetBarrierBounds()
        {
            Vector3 inset = new(_sidePaddingInMeters, 0f, _sidePaddingInMeters);
            var barrierBounds = new Bounds();
            barrierBounds.SetMinMax(_bounds.min + inset, _bounds.max - inset);
            return barrierBounds;
        }

        // Kept at the scene root so this object's scale or rotation can't bend it; it lives in this object's scene and dies with it
        private void BuildPlayerBarrier()
        {
            Bounds inner = GetBarrierBounds();
            if (inner.size.x <= 0f || inner.size.z <= 0f) return;

            int layer = LayerMask.NameToLayer(_barrierLayerName);
            if (layer < 0)
            {
                Debug.LogWarning($"[{nameof(MapBounds)}] Layer '{_barrierLayerName}' doesn't exist; the player barrier is off.", this);
                return;
            }

            _playerBarrier = new GameObject(_barrierName) { layer = layer };
            SceneManager.MoveGameObjectToScene(_playerBarrier, gameObject.scene);

            Vector3 min = inner.min;
            Vector3 max = inner.max;
            float thickness = _barrierThicknessInMeters;
            // four walls from the floor of the bounds to their top, then a lid over the whole footprint
            AddBarrierBox(new Vector3(min.x - thickness, min.y, max.z), new Vector3(max.x + thickness, max.y, max.z + thickness));
            AddBarrierBox(new Vector3(min.x - thickness, min.y, min.z - thickness), new Vector3(max.x + thickness, max.y, min.z));
            AddBarrierBox(new Vector3(max.x, min.y, min.z), new Vector3(max.x + thickness, max.y, max.z));
            AddBarrierBox(new Vector3(min.x - thickness, min.y, min.z), new Vector3(min.x, max.y, max.z));
            AddBarrierBox(new Vector3(min.x - thickness, max.y, min.z - thickness), new Vector3(max.x + thickness, max.y + thickness, max.z + thickness));
        }

        private void AddBarrierBox(Vector3 min, Vector3 max)
        {
            var boxBounds = new Bounds();
            boxBounds.SetMinMax(min, max);
            var box = _playerBarrier.AddComponent<BoxCollider>();
            box.center = boxBounds.center;
            box.size = boxBounds.size;
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

        private void OnDestroy()
        {
            if (_playerBarrier != null) Destroy(_playerBarrier);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _gizmoColor;
            Gizmos.DrawWireCube(_bounds.center, _bounds.size);
            if (!_hasPlayerBarrier) return;

            Bounds barrierBounds = GetBarrierBounds();
            Gizmos.color = _barrierGizmoColor;
            Gizmos.DrawWireCube(barrierBounds.center, barrierBounds.size);
        }
    }
}
