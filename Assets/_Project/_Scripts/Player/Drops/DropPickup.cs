using Reflex.Attributes;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Drops
{
    // An in-scene drop box. The server gives the first Up runner that touches it a random effect from the catalog,
    // hides it on every instance and brings it back after the respawn delay. Boxes stay hidden and can't be taken during the hide phase.
    public class DropPickup : NetworkBehaviour
    {
        [Inject] private readonly DropCatalog _catalog;
        [Inject] private readonly HidePhase _hidePhase;
        // a child shown while the box can be taken; never this object, which must stay active to keep checking
        [SerializeField] private GameObject _model;
        [SerializeField, Min(0f)] private float _pickupRadius = 1f;
        [SerializeField] private LayerMask _playerLayers = ~0;
        [SerializeField, Min(0f)] private float _respawnDelayInSeconds = 20f;
        [SerializeField, Min(1)] private int _maxOverlaps = 8;
        [SerializeField] private float _spinDegreesPerSecond = 90f;

        private readonly NetworkVariable<bool> _isAvailable = new(true);
        private Collider[] _overlaps;
        // Server only
        private double _respawnTime;

        public bool IsAvailable => _isAvailable.Value;

        private void Awake() => _overlaps = new Collider[_maxOverlaps];

        public override void OnNetworkSpawn()
        {
            _isAvailable.OnValueChanged += HandleAvailableChanged;
            _hidePhase.OnChanged += HandleHidePhaseChanged;
            RefreshModel();
        }

        private void Update()
        {
            if (_model != null && _model.activeSelf) _model.transform.Rotate(Vector3.up, _spinDegreesPerSecond * Time.deltaTime, Space.World);
        }

        private void FixedUpdate()
        {
            if (!IsSpawned || !IsServer || _hidePhase.IsActive) return;

            if (_isAvailable.Value) TryGiveDrop();
            else if (NetworkManager.ServerTime.Time >= _respawnTime) _isAvailable.Value = true;
        }

        private void HandleAvailableChanged(bool _, bool __) => RefreshModel();

        private void HandleHidePhaseChanged(bool _) => RefreshModel();

        private void RefreshModel() => ToggleModel(_isAvailable.Value && !_hidePhase.IsActive);

        // Server only: catchers, knocked and eliminated players can't take a box
        private void TryGiveDrop()
        {
            int hitCount = Physics.OverlapSphereNonAlloc(transform.position, _pickupRadius, _overlaps, _playerLayers);
            for (int i = 0; i < hitCount; i++)
            {
                var team = _overlaps[i].GetComponentInParent<PlayerTeam>();
                if (team == null || team.Team != Team.Runner) continue;
                if (!team.TryGetComponent(out PlayerLifeState lifeState) || !lifeState.IsUp) continue;
                if (!team.TryGetComponent(out PlayerDropEffects dropEffects)) continue;
                if (!_catalog.TryPick(Random.value, out var effect)) return;

                dropEffects.Apply(effect);
                _isAvailable.Value = false;
                _respawnTime = NetworkManager.ServerTime.Time + _respawnDelayInSeconds;
                return;
            }
        }

        private void ToggleModel(bool isShown)
        {
            if (_model != null) _model.SetActive(isShown);
        }

        public override void OnNetworkDespawn()
        {
            _isAvailable.OnValueChanged -= HandleAvailableChanged;
            _hidePhase.OnChanged -= HandleHidePhaseChanged;
        }

        private void OnDrawGizmosSelected() => Gizmos.DrawWireSphere(transform.position, _pickupRadius);
    }
}
