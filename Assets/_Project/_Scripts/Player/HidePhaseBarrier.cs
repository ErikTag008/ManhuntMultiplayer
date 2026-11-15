using Reflex.Attributes;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Shows a blocker (e.g. the catcher spawn room's door) only while the hide phase is active.
    // The hide phase is mirrored on every instance, so each one toggles its own copy and owner-side movement collides with it.
    public class HidePhaseBarrier : MonoBehaviour
    {
        [Inject] private readonly HidePhase _hidePhase;
        // a child with the blocker's colliders and renderers; never this object, which must stay active to keep listening
        [SerializeField] private GameObject _barrier;

        private void Start()
        {
            _hidePhase.OnChanged += HandleHidePhaseChanged;
            // the hide phase may already be running when the scene starts
            HandleHidePhaseChanged(_hidePhase.IsActive);
        }

        private void HandleHidePhaseChanged(bool isActive)
        {
            if (_barrier != null) _barrier.SetActive(isActive);
        }

        private void OnDestroy()
        {
            _hidePhase.OnChanged -= HandleHidePhaseChanged;
        }
    }
}
