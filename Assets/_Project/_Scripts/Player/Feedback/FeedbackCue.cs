using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Feedback
{
    // One gameplay moment's sound and particle burst. Both are optional, so a cue can be sound-only or visual-only;
    // swapping the clips or the effect prefab changes the feedback without code changes.
    [Serializable]
    public class FeedbackCue
    {
        [field: SerializeField] public AudioClip[] Clips { get; private set; }
        [field: SerializeField, Range(0f, 1f)] public float Volume { get; private set; } = 1f;
        [field: SerializeField] public Vector2 PitchRange { get; private set; } = new(0.95f, 1.05f);
        // spawned at the player and left to destroy itself (its main module's Stop Action)
        [field: SerializeField] public ParticleSystem VfxPrefab { get; private set; }
        // the burst sits on the player's own first-person camera, so it's hidden from them unless set
        [field: SerializeField] public bool IsVfxShownToOwner { get; private set; }

        public bool HasContent => (Clips != null && Clips.Length > 0) || VfxPrefab != null;

        // null when no clip is available
        public AudioClip PickClip()
        {
            if (Clips == null || Clips.Length == 0) return null;

            return Clips[UnityEngine.Random.Range(0, Clips.Length)];
        }

        public float PickPitch() => UnityEngine.Random.Range(PitchRange.x, PitchRange.y);
    }
}
