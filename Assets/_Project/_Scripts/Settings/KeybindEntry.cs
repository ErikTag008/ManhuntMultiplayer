using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.Settings
{
    // One rebindable row: an action, and for composites (Move) the part to rebind, e.g. "up"
    [Serializable]
    public class KeybindEntry
    {
        [field: SerializeField] public string DisplayName { get; private set; }
        [field: SerializeField] public InputActionReference Action { get; private set; }
        [field: SerializeField] public string CompositePart { get; private set; }
        [field: SerializeField] public bool HasGamepadBinding { get; private set; } = true;
        // Rows with a common group may share a key, for actions that never run together (Catch while alive, Spectate while out).
        // Several groups are comma-separated, so Catch can share with both Spectate rows while those two can't share with each other.
        [field: SerializeField] public string ShareGroup { get; private set; }

        private const char ShareGroupSeparator = ',';

        public bool CanShareKeyWith(KeybindEntry other)
        {
            if (other == null || string.IsNullOrWhiteSpace(ShareGroup) || string.IsNullOrWhiteSpace(other.ShareGroup)) return false;

            var otherGroups = other.ShareGroup.Split(ShareGroupSeparator);
            foreach (var group in ShareGroup.Split(ShareGroupSeparator))
            {
                var name = group.Trim();
                if (name.Length == 0) continue;

                foreach (var otherGroup in otherGroups)
                {
                    if (otherGroup.Trim() == name) return true;
                }
            }

            return false;
        }
    }
}
