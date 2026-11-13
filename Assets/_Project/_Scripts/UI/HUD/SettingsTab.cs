using Project.Assets._Project._Scripts.Settings;
using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // One settings tab: its label, which category Reset clears, and the page it shows
    [Serializable]
    public class SettingsTab
    {
        [field: SerializeField] public string Label { get; private set; }
        [field: SerializeField] public SettingsCategory Category { get; private set; }
        [field: SerializeField] public GameObject Page { get; private set; }
    }
}
