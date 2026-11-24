using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Sounds of the round banners; swap the clips here when the human-made audio arrives
    [CreateAssetMenu(fileName = "RoundAnnouncementData", menuName = "ScriptableObjects/RoundAnnouncementData", order = 1)]
    public class RoundAnnouncementData : ScriptableObject
    {
        [field: SerializeField] public AudioClip HuntStartSFX { get; private set; }
        [field: SerializeField, Range(0f, 1f)] public float HuntStartSFXVolume { get; private set; } = 0.8f;
    }
}
