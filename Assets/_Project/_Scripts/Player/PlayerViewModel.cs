using KBCore.Refs;
using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.Weapons;
using Reflex.Attributes;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Rendering;

namespace Project.Assets._Project._Scripts.Player
{
    // Owner only: a first-person copy of the held weapon in a hand, on a layer only the camera's view model overlay draws,
    // so it never sinks into a wall. It copies the model hand's animated pose before the look tilt is added, then rides
    // the camera, so a swing still plays but looking up or down doesn't move it on screen. The world weapon keeps its shadow.
    [DefaultExecutionOrder(RunBeforePlayerAnimator)]
    [RequireComponent(typeof(PlayerTeam), typeof(PlayerCombat), typeof(PlayerLifeState))]
    [RequireComponent(typeof(PlayerEmote))]
    public class PlayerViewModel : NetworkBehaviour
    {
        // PlayerAnimator adds the look tilt in its LateUpdate at the default order
        private const int RunBeforePlayerAnimator = -5;

        // injected by PlayerController.Awake together with the rest of the player
        [Inject] private readonly ActiveCameraProvider _cameraProvider;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerCombat _combat;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private PlayerEmote _emote;
        // the eye point the first-person camera follows
        [SerializeField] private Transform _cameraTarget;
        // root = grip point, like a weapon socket; the weapon copy sits on it (placeholder until the human-made arms)
        [SerializeField] private Transform _handPrefab;
        [SerializeField] private string _viewModelLayerName = "FirstPersonView";
        // nudges the copied hand pose in camera space
        [SerializeField] private Vector3 _positionOffset = Vector3.zero;
        [SerializeField] private Vector3 _rotationOffsetInDegrees = Vector3.zero;

        private Transform _view;
        private MeleeWeaponBase _worldWeapon;
        private readonly List<Renderer> _worldWeaponRenderers = new();
        private Vector3 _localPosition;
        private Quaternion _localRotation = Quaternion.identity;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            if (!IsOwner)
            {
                enabled = false;
                return;
            }

            _combat.OnWeaponChanged += HandleWeaponChanged;
            RenderPipelineManager.beginCameraRendering += HandleBeginCameraRendering;
        }

        protected override void OnNetworkPostSpawn()
        {
            if (IsOwner) HandleWeaponChanged(_combat.CurrentWeapon);
        }

        private void LateUpdate()
        {
            bool isShown = _view != null && _worldWeapon != null && _cameraProvider.Current != null && _lifeState.IsUp && !_emote.IsInThirdPerson;
            ToggleViewShown(isShown);
            if (isShown) SampleHandPose();
        }

        // the camera brain moves the camera late in the frame, so the view follows it just before it draws
        private void HandleBeginCameraRendering(ScriptableRenderContext context, Camera camera)
        {
            if (_view == null || !_view.gameObject.activeSelf || camera != _cameraProvider.Current) return;

            var cameraTransform = camera.transform;
            _view.SetPositionAndRotation(cameraTransform.TransformPoint(_localPosition), cameraTransform.rotation * _localRotation);
        }

        // the model's hand before the tilt, seen from the eyes with only the body's heading, so pitch drops out
        private void SampleHandPose()
        {
            if (_worldWeapon == null) return;

            var socket = _worldWeapon.transform.parent;
            var model = _team.Model;
            if (socket == null || model == null) return;

            var eyeRotation = Quaternion.Euler(0f, model.eulerAngles.y, 0f);
            var inverseEyeRotation = Quaternion.Inverse(eyeRotation);
            _localPosition = inverseEyeRotation * (socket.position - _cameraTarget.position) + _positionOffset;
            _localRotation = Quaternion.Euler(_rotationOffsetInDegrees) * (inverseEyeRotation * socket.rotation);
        }

        private void HandleWeaponChanged(MeleeWeaponBase weapon)
        {
            if (weapon == _worldWeapon && _view != null) return;

            DestroyView();
            _worldWeapon = weapon;
            _worldWeaponRenderers.Clear();
            if (weapon == null || _handPrefab == null) return;

            weapon.GetComponentsInChildren(true, _worldWeaponRenderers);

            int layer = LayerMask.NameToLayer(_viewModelLayerName);
            if (layer < 0) return;

            _view = Instantiate(_handPrefab, transform);
            var weaponCopy = Instantiate(weapon, _view);
            weaponCopy.AttachTo(_view);
            StripToVisuals(weaponCopy);
            PrepareForOverlay(_view, layer);
            _view.gameObject.SetActive(false);
        }

        // only the look of the weapon is copied: it must not collide or report hits
        private static void StripToVisuals(MeleeWeaponBase weaponCopy)
        {
            foreach (var collider in weaponCopy.GetComponentsInChildren<Collider>(true))
            {
                collider.enabled = false;
                Destroy(collider);
            }

            Destroy(weaponCopy);
        }

        private static void PrepareForOverlay(Transform view, int layer)
        {
            foreach (var child in view.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = layer;
            }

            foreach (var renderer in view.GetComponentsInChildren<Renderer>(true))
            {
                renderer.shadowCastingMode = ShadowCastingMode.Off;
                renderer.receiveShadows = false;
            }
        }

        // while the view shows, the owner sees the weapon only through it; the world one still casts its shadow.
        // Checked every frame because PlayerTeam also rewrites the mode when an emote shows or hides the own model
        private void ToggleViewShown(bool isShown)
        {
            if (_view != null && _view.gameObject.activeSelf != isShown) _view.gameObject.SetActive(isShown);
            if (_worldWeapon == null) return;

            var mode = isShown ? ShadowCastingMode.ShadowsOnly : ShadowCastingMode.On;
            foreach (var renderer in _worldWeaponRenderers)
            {
                if (renderer != null && renderer.shadowCastingMode != mode) renderer.shadowCastingMode = mode;
            }
        }

        private void DestroyView()
        {
            if (_view != null) Destroy(_view.gameObject);
            _view = null;
        }

        public override void OnNetworkDespawn()
        {
            if (!IsOwner) return;

            _combat.OnWeaponChanged -= HandleWeaponChanged;
            RenderPipelineManager.beginCameraRendering -= HandleBeginCameraRendering;
            DestroyView();
        }
    }
}
