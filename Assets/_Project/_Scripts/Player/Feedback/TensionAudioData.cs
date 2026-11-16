using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Feedback
{
    // How a runner's heartbeat and tension music react to the nearest catcher.
    // Closeness is 0 at the radius and 1 at the catcher; the curve maps it to a 0-1 intensity.
    [CreateAssetMenu(fileName = "TensionAudioData", menuName = "ScriptableObjects/TensionAudioData", order = 1)]
    public class TensionAudioData : ScriptableObject
    {
        [field: SerializeField] public float RadiusInMeters { get; private set; } = 30f;
        [field: SerializeField] public AnimationCurve IntensityByCloseness { get; private set; } = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        // how fast the intensity follows the target, in intensity per second, so it swells and fades instead of jumping
        [field: SerializeField] public float IntensityChangeSpeed { get; private set; } = 1.5f;

        [field: SerializeField] public AudioClip HeartbeatSFX { get; private set; }
        [field: SerializeField] public Vector2 HeartbeatSFXVolume { get; private set; } = new(0.25f, 1f);
        // beats per minute at the lowest and the highest intensity
        [field: SerializeField] public Vector2 HeartbeatRate { get; private set; } = new(70f, 150f);
        // below this intensity the heartbeat stays silent, so a catcher at the edge of the radius doesn't start it
        [field: SerializeField, Range(0f, 1f)] public float HeartbeatMinIntensity { get; private set; } = 0.1f;

        // a loop that fades in with the intensity
        [field: SerializeField] public AudioClip MusicLayer { get; private set; }
        [field: SerializeField, Range(0f, 1f)] public float MusicLayerMaxVolume { get; private set; } = 0.6f;
    }
}
