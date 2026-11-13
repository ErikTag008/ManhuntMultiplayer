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
        // Rows with the same non-empty group may share a key, for actions that never run together (Catch while alive, Spectate while out)
        [field: SerializeField] public string ShareGroup { get; private set; }

        public bool CanShareKeyWith(KeybindEntry other) => other != null && !string.IsNullOrEmpty(ShareGroup) && ShareGroup == other.ShareGroup;
    }
}
