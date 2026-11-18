using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Emotes
{
    // Every emote on the wheel, in wheel order (the first sits at the top, the rest go clockwise).
    // Emotes are sent by their index here, so every build must share the same list.
    [CreateAssetMenu(fileName = "EmoteCatalog", menuName = "ScriptableObjects/EmoteCatalog", order = 1)]
    public class EmoteCatalog : ScriptableObject
    {
        [field: SerializeField] public List<EmoteData> Emotes { get; private set; } = new();
        // the server ignores emotes closer together than this, so nobody can spam them
        [field: SerializeField, Min(0f)] public float CooldownInSeconds { get; private set; } = 1f;

        public bool TryGet(int index, out EmoteData emote)
        {
            emote = index >= 0 && index < Emotes.Count ? Emotes[index] : null;
            return emote != null;
        }
    }
}
