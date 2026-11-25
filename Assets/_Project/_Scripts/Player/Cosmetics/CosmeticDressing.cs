using Project.Assets._Project._Scripts.Cosmetics;
using Project.Assets._Project._Scripts.Weapons;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Cosmetics
{
    // How an item is put on a character model, shared by the in-game player and the Customize preview so both look the same
    public static class CosmeticDressing
    {
        // the held weapon sits in the model's hand, but its look comes from the weapon slot, not the outfit
        public static void CaptureBodyRenderers(Transform model, MaterialOverrideGroup bodyMaterials, List<Renderer> buffer)
        {
            if (model == null) return;

            model.GetComponentsInChildren(true, buffer);
            buffer.RemoveAll(renderer => renderer.GetComponentInParent<MeleeWeaponBase>() != null);
            bodyMaterials.Capture(buffer);
            buffer.Clear();
        }

        public static void CaptureWeaponRenderers(MeleeWeaponBase weapon, MaterialOverrideGroup weaponMaterials, List<Renderer> buffer)
        {
            weaponMaterials.Clear();
            if (weapon == null) return;

            weapon.GetComponentsInChildren(true, buffer);
            weaponMaterials.Capture(buffer);
            buffer.Clear();
        }

        // null when the outfit has no attachment or the model has no rig bone for it
        public static GameObject AddAttachment(Transform model, CosmeticItem outfit)
        {
            if (outfit == null || outfit.AttachmentPrefab == null) return null;

            var anchor = FindAnchor(model, outfit.Anchor);
            if (anchor == null) return null;

            var attachment = Object.Instantiate(outfit.AttachmentPrefab, anchor, false);
            StripToVisuals(attachment, anchor.gameObject.layer);
            return attachment;
        }

        // an outfit is only looks: it must not block movement or catches
        public static void StripToVisuals(GameObject visual, int layer)
        {
            foreach (var collider in visual.GetComponentsInChildren<Collider>(true))
            {
                collider.enabled = false;
                Object.Destroy(collider);
            }

            foreach (var child in visual.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = layer;
            }
        }

        private static Transform FindAnchor(Transform model, CosmeticAnchor anchor)
        {
            var rig = model != null ? model.GetComponentInChildren<CharacterRig>() : null;
            if (rig == null) return null;

            return anchor switch
            {
                CosmeticAnchor.Spine => rig.Spine,
                _ => rig.Head
            };
        }
    }
}
