using KBCore.Refs;
using Project.Assets._Project._Scripts.Cosmetics;
using Reflex.Attributes;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Cosmetics
{
    // Lobby scene turntable for the Customize screen, set apart from the playable area so its camera sees only the
    // preview. The models and weapon come from the team stats, and the camera frames them by their renderer bounds,
    // so other models fit without retuning. The camera looks back along this object's forward at the model's front.
    public class CosmeticPreviewStage : ValidatedMonoBehaviour, ICosmeticPreview
    {
        private const float Half = 0.5f;

        [Inject] private readonly CatcherStats _catcherStats;
        [Inject] private readonly RunnerStats _runnerStats;
        [Inject] private readonly CosmeticProfileService _profile;
        [SerializeField, Child] private Camera _camera;
        // the models are built under it and it turns, the camera stays
        [SerializeField] private Transform _turntable;
        [SerializeField] private Vector2Int _viewResolution = new(768, 1024);
        [SerializeField] private int _thumbnailResolution = 256;
        [SerializeField] private int _depthBufferBits = 24;
        [SerializeField] private int _antiAliasingSamples = 4;
        // how much room is left around the framed model, 1 being a tight fit
        [SerializeField] private float _viewPadding = 1.1f;
        [SerializeField] private float _thumbnailPadding = 1.2f;
        // a weapon seen from its side shows its shape best
        [SerializeField] private float _weaponThumbnailYaw = 90f;

        private readonly Dictionary<CosmeticItem, RenderTexture> _thumbnails = new();
        private CosmeticPreviewCharacter _catcher;
        private CosmeticPreviewCharacter _runner;
        private CosmeticItem _shownItem;
        private RenderTexture _view;
        private float _yaw;

        public Texture View => GetView();

        private void Awake() => _camera.enabled = false;

        public void ToggleShown(bool isShown)
        {
            _camera.targetTexture = GetView();
            _camera.enabled = isShown;
            Show(_shownItem);
        }

        public void Show(CosmeticItem item)
        {
            _shownItem = item;
            // kept for when the view is shown; a hidden view builds and dresses nothing
            if (item == null || !_camera.enabled)
            {
                HideCharacters();
                return;
            }

            var character = ShowCharacterFor(item, true);
            _turntable.localRotation = Quaternion.identity;
            // framed facing front, so turning the model never zooms the camera
            if (character.TryGetBounds(character.Model, out Bounds bounds)) Frame(bounds, (float)_viewResolution.x / _viewResolution.y, _viewPadding);
            ApplyYaw();
        }

        public void Rotate(float degrees)
        {
            _yaw += degrees;
            ApplyYaw();
        }

        public void ResetRotation()
        {
            _yaw = 0f;
            ApplyYaw();
        }

        public Texture GetThumbnail(CosmeticItem item)
        {
            if (item == null) return null;
            if (item.Icon != null) return item.Icon;
            if (_thumbnails.TryGetValue(item, out var thumbnail)) return thumbnail;

            thumbnail = RenderThumbnail(item);
            _thumbnails[item] = thumbnail;
            return thumbnail;
        }

        private RenderTexture GetView()
        {
            if (_view == null) _view = CreateTexture(_viewResolution.x, _viewResolution.y);
            return _view;
        }

        private RenderTexture CreateTexture(int width, int height) => new(width, height, _depthBufferBits, RenderTextureFormat.ARGB32)
        {
            antiAliasing = _antiAliasingSamples
        };

        // rendered at once with the same camera, then the live view is put back as it was
        private RenderTexture RenderThumbnail(CosmeticItem item)
        {
            // the other slots keep the model's own look, so a cached tile never shows a later equip
            var character = ShowCharacterFor(item, false);
            bool isWeapon = item.Slot == CosmeticSlot.CatcherWeapon && character.Weapon != null;
            Component target = character.Model;
            if (isWeapon) target = character.Weapon;
            else if (character.Attachment != null) target = character.Attachment.transform;

            _turntable.localRotation = Quaternion.Euler(0f, isWeapon ? _weaponThumbnailYaw : 0f, 0f);
            if (isWeapon) character.ToggleBodyShown(false);

            var thumbnail = CreateTexture(_thumbnailResolution, _thumbnailResolution);
            if (character.TryGetBounds(target, out Bounds bounds))
            {
                Frame(bounds, 1f, _thumbnailPadding);
                _camera.targetTexture = thumbnail;
                _camera.Render();
            }

            character.ToggleBodyShown(true);
            _camera.targetTexture = GetView();
            if (_camera.enabled && _shownItem != null) Show(_shownItem);
            else HideCharacters();
            return thumbnail;
        }

        // the slot's team model, dressed with the item and, when wanted, with what is equipped in its other slots
        private CosmeticPreviewCharacter ShowCharacterFor(CosmeticItem item, bool isWearingEquipped)
        {
            bool isCatcher = item.Slot != CosmeticSlot.RunnerOutfit;
            var character = isCatcher ? GetCatcher() : GetRunner();
            if (isCatcher) character.Dress(GetLook(item, CosmeticSlot.CatcherOutfit, isWearingEquipped), GetLook(item, CosmeticSlot.CatcherWeapon, isWearingEquipped));
            else character.Dress(GetLook(item, CosmeticSlot.RunnerOutfit, isWearingEquipped), null);

            ToggleCharacterShown(_catcher, character == _catcher);
            ToggleCharacterShown(_runner, character == _runner);
            return character;
        }

        private CosmeticItem GetLook(CosmeticItem item, CosmeticSlot slot, bool isWearingEquipped)
        {
            if (item.Slot == slot) return item;
            return isWearingEquipped ? _profile.GetEquipped(slot) : null;
        }

        private CosmeticPreviewCharacter GetCatcher() => _catcher ??= new CosmeticPreviewCharacter(_catcherStats, _turntable);

        private CosmeticPreviewCharacter GetRunner() => _runner ??= new CosmeticPreviewCharacter(_runnerStats, _turntable);

        private void HideCharacters()
        {
            ToggleCharacterShown(_catcher, false);
            ToggleCharacterShown(_runner, false);
        }

        private static void ToggleCharacterShown(CosmeticPreviewCharacter character, bool isShown) => character?.ToggleShown(isShown);

        private void ApplyYaw() => _turntable.localRotation = Quaternion.Euler(0f, _yaw, 0f);

        // backs the camera off along the stage's forward until the bounds fit the frame's height and width
        private void Frame(Bounds bounds, float aspect, float padding)
        {
            float tanHalfFov = Mathf.Tan(_camera.fieldOfView * Half * Mathf.Deg2Rad);
            Vector3 forward = transform.forward;
            float halfWidth = GetHalfSize(bounds.extents, transform.right);
            float halfHeight = GetHalfSize(bounds.extents, transform.up);
            float halfDepth = GetHalfSize(bounds.extents, forward);
            float distance = Mathf.Max(halfHeight, halfWidth / aspect) * padding / tanHalfFov + halfDepth;

            _camera.transform.SetPositionAndRotation(bounds.center + forward * distance, Quaternion.LookRotation(-forward, transform.up));
        }

        // how far the box reaches along a direction, so a turned stage frames as well as one along the world axes
        private static float GetHalfSize(Vector3 extents, Vector3 direction) =>
            Mathf.Abs(extents.x * direction.x) + Mathf.Abs(extents.y * direction.y) + Mathf.Abs(extents.z * direction.z);

        private void OnDestroy()
        {
            if (_camera != null) _camera.targetTexture = null;
            if (_view != null)
            {
                _view.Release();
                Destroy(_view);
            }

            foreach (var thumbnail in _thumbnails.Values)
            {
                thumbnail.Release();
                Destroy(thumbnail);
            }

            _thumbnails.Clear();
        }
    }
}
