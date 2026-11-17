using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Voice
{
    [CreateAssetMenu(fileName = "VoiceSettings", menuName = "ScriptableObjects/VoiceSettings", order = 1)]
    public class VoiceSettings : ScriptableObject
    {
        // full volume up to the min distance, then a linear fade to silence at the max
        [field: SerializeField, Min(0f)] public float MinDistanceInMeters { get; private set; } = 3f;
        [field: SerializeField, Min(0f)] public float MaxDistanceInMeters { get; private set; } = 25f;
        [field: SerializeField, Range(0f, 1f)] public float LivingSpatialBlend { get; private set; } = 1f;
        // ghosts and spectators aren't anywhere meaningful in the world, so their voice isn't placed
        [field: SerializeField, Range(0f, 1f)] public float DeadSpatialBlend { get; private set; } = 0f;

        [field: SerializeField] public string PushToTalkActionName { get; private set; } = "PushToTalk";
        [field: SerializeField, Min(0f)] public float ReadIntervalInSeconds { get; private set; } = 0.05f;
        // a voice that ran dry waits for this much before playing again, so small network gaps don't stutter
        [field: SerializeField, Min(0f)] public float StartBufferInSeconds { get; private set; } = 0.1f;
        // anything beyond this is dropped from the oldest end, so a stalled voice catches up instead of lagging behind
        [field: SerializeField, Min(0.01f)] public float MaxBufferedInSeconds { get; private set; } = 0.5f;
        // bigger packets go reliable; Netcode refuses unreliable messages above its MTU and Steam's relay drops them around 1200 bytes
        [field: SerializeField, Min(1)] public int MaxUnreliablePayloadBytes { get; private set; } = 1000;
        // {0} is the client id, shown until the player's name arrives
        [field: SerializeField] public string UnknownPeerNameFormat { get; private set; } = "Player {0}";

        // Dev only: the owner also hears their own voice, to test capture and playback on one PC
        [field: SerializeField] public bool IsLoopbackOn { get; private set; } = false;
        [field: SerializeField, Range(0f, 1f)] public float LoopbackSpatialBlend { get; private set; } = 0f;
    }
}
