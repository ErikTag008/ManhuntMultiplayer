using UnityEngine;

namespace Project.Assets._Project._Scripts.Settings
{
    // Samples the Audio tab plays while the Effects and Interface sliders move; swap the clips here for the final sounds
    [CreateAssetMenu(fileName = "VolumePreviewData", menuName = "ScriptableObjects/VolumePreviewData", order = 1)]
    public class VolumePreviewData : ScriptableObject
    {
        [field: SerializeField] public AudioClip EffectsSFX { get; private set; }
        [field: SerializeField] public float EffectsSFXVolume { get; private set; } = 1f;
        [field: SerializeField] public AudioClip InterfaceSFX { get; private set; }
        [field: SerializeField] public float InterfaceSFXVolume { get; private set; } = 1f;
        // a drag only plays the sample this often
        [field: SerializeField] public float MinIntervalInSeconds { get; private set; } = 0.25f;
    }
}
