using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // One surface's footstep sounds. Variations play in random order without repeating the last one.
    [CreateAssetMenu(fileName = "FootstepSoundSet", menuName = "ScriptableObjects/FootstepSoundSet", order = 1)]
    public class FootstepSoundSet : ScriptableObject
    {
        [field: SerializeField] public AudioClip[] Clips { get; private set; }
        [field: SerializeField, Range(0f, 1f)] public float Volume { get; private set; } = 0.6f;
        [field: SerializeField] public Vector2 PitchRange { get; private set; } = new(0.92f, 1.08f);
        // empty uses the step clips, played louder and lower as a heavier thud
        [field: SerializeField] public AudioClip[] LandingClips { get; private set; }
        [field: SerializeField, Range(0f, 1f)] public float LandingVolume { get; private set; } = 0.9f;
        [field: SerializeField] public Vector2 LandingPitchRange { get; private set; } = new(0.78f, 0.88f);

        // null when no clip is available
        public AudioClip PickLandingClip()
        {
            var clips = LandingClips != null && LandingClips.Length > 0 ? LandingClips : Clips;
            if (clips == null || clips.Length == 0) return null;

            return clips[Random.Range(0, clips.Length)];
        }

        // -1 when no clip is available
        public int PickNextIndex(int lastIndex)
        {
            if (Clips == null || Clips.Length == 0) return -1;
            if (Clips.Length == 1) return 0;

            int index = Random.Range(0, Clips.Length - 1);
            // skipping over the last index keeps the pick uniform among the others
            return index >= lastIndex && lastIndex >= 0 ? index + 1 : index;
        }
    }
}
