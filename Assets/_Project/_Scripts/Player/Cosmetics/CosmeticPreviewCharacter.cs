using Project.Assets._Project._Scripts.Cosmetics;
using Project.Assets._Project._Scripts.Weapons;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Cosmetics
{
    // One team's model on the Customize turntable, built from that team's stats, so a replaced model or weapon shows
    // up here without changes. Dressed the same way as the in-game player.
    public class CosmeticPreviewCharacter
    {
        private readonly MaterialOverrideGroup _bodyMaterials = new();
        private readonly MaterialOverrideGroup _weaponMaterials = new();
        private readonly List<Renderer> _bodyRenderers = new();
        // the body renderers that were on before hiding, so ones the model ships switched off stay off
        private readonly List<Renderer> _hiddenRenderers = new();
        private readonly List<Renderer> _rendererBuffer = new();
        private readonly Transform _model;
        private readonly MeleeWeaponBase _weapon;
        private readonly Animator _animator;
        private CosmeticItem _appliedOutfit;
        private GameObject _attachment;

        public Transform Model => _model;
        public GameObject Attachment => _attachment;
        public MeleeWeaponBase Weapon => _weapon;

        public CosmeticPreviewCharacter(PlayerStats stats, Transform parent)
        {
            _model = Object.Instantiate(stats.Model, parent, false);
            _model.GetComponentsInChildren(true, _bodyRenderers);
            CosmeticDressing.CaptureBodyRenderers(_model, _bodyMaterials, _rendererBuffer);
            CosmeticDressing.StripToVisuals(_model.gameObject, _model.gameObject.layer);
            // an Animator only poses the model on its first update, so the pose and the bounds are right from the first render
            _animator = _model.GetComponentInChildren<Animator>();
            UpdatePose();

            if (stats.WeaponPrefab == null) return;

            _weapon = Object.Instantiate(stats.WeaponPrefab);
            _weapon.AttachTo(FindWeaponSocket(stats));
            CosmeticDressing.StripToVisuals(_weapon.gameObject, _model.gameObject.layer);
            CosmeticDressing.CaptureWeaponRenderers(_weapon, _weaponMaterials, _rendererBuffer);
        }

        public void ToggleShown(bool isShown)
        {
            if (isShown == _model.gameObject.activeSelf) return;

            _model.gameObject.SetActive(isShown);
            // a re-enabled Animator starts over from the rest pose
            if (isShown) UpdatePose();
        }

        public void Dress(CosmeticItem outfit, CosmeticItem weaponLook)
        {
            _weaponMaterials.Apply(weaponLook != null ? weaponLook.MaterialOverride : null);
            if (outfit == _appliedOutfit) return;

            if (_attachment != null)
            {
                // Destroy waits for the frame's end, and a thumbnail rendered right after must not show the old one
                _attachment.SetActive(false);
                Object.Destroy(_attachment);
            }

            _appliedOutfit = outfit;
            _bodyMaterials.Apply(outfit != null ? outfit.MaterialOverride : null);
            _attachment = CosmeticDressing.AddAttachment(_model, outfit);
        }

        // the weapon alone makes a clearer weapon thumbnail
        public void ToggleBodyShown(bool isShown)
        {
            if (isShown)
            {
                foreach (var renderer in _hiddenRenderers)
                {
                    if (renderer != null) renderer.enabled = true;
                }

                _hiddenRenderers.Clear();
            }
            else
            {
                foreach (var renderer in _bodyRenderers)
                {
                    if (renderer == null || !renderer.enabled) continue;

                    renderer.enabled = false;
                    _hiddenRenderers.Add(renderer);
                }
            }

            if (_attachment != null) _attachment.SetActive(isShown);
        }

        // false when nothing under the root renders
        public bool TryGetBounds(Component root, out Bounds bounds)
        {
            bounds = default;
            if (root == null) return false;

            root.GetComponentsInChildren(false, _rendererBuffer);
            bool hasBounds = false;
            foreach (var renderer in _rendererBuffer)
            {
                if (!renderer.enabled) continue;

                if (hasBounds) bounds.Encapsulate(renderer.bounds);
                else bounds = renderer.bounds;
                hasBounds = true;
            }

            _rendererBuffer.Clear();
            return hasBounds;
        }

        private void UpdatePose()
        {
            if (_animator != null) _animator.Update(0f);
        }

        // the rig's socket like PlayerCombat; a model without a rig holds it where the stats place the player's weapon
        private Transform FindWeaponSocket(PlayerStats stats)
        {
            var rig = _model.GetComponentInChildren<CharacterRig>();
            if (rig != null && rig.WeaponSocket != null) return rig.WeaponSocket;

            var pivot = new GameObject(nameof(PlayerStats.WeaponPivotLocalPos)).transform;
            pivot.SetParent(_model, false);
            pivot.localPosition = stats.WeaponPivotLocalPos;
            return pivot;
        }
    }
}
