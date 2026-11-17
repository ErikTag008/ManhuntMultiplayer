using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Classic mode: a runner who is out of the round flies around unseen and can ping a catcher for the runners still in it
    [CreateAssetMenu(fileName = "GhostSettings", menuName = "ScriptableObjects/GhostSettings", order = 1)]
    public class GhostSettings : ScriptableObject
    {
        // along the camera's full forward, so looking up and moving forward climbs
        [field: SerializeField, Min(0f)] public float FlySpeed { get; private set; } = 10f;
        // Jump held rises, Crouch held sinks
        [field: SerializeField, Min(0f)] public float VerticalSpeed { get; private set; } = 8f;
        [field: SerializeField, Min(0f)] public float PingCooldownInSeconds { get; private set; } = 30f;
        // how long runners see the marker over the pinged catcher
        [field: SerializeField, Min(0f)] public float PingMarkerDurationInSeconds { get; private set; } = 3f;
        // the catcher closest to the screen centre within this angle of the view gets pinged
        [field: SerializeField, Range(0f, 180f)] public float PingAimAngleInDegrees { get; private set; } = 8f;
        [field: SerializeField, Min(0f)] public float PingMaxRangeInMeters { get; private set; } = 150f;
        // the server allows this much past the max range, since the ghost and the catcher both moved while the request travelled
        [field: SerializeField, Min(0f)] public float PingRangeToleranceInMeters { get; private set; } = 5f;
        // aim at the catcher's body rather than their feet
        [field: SerializeField, Min(0f)] public float PingAimHeightInMeters { get; private set; } = 1f;
        // after the ghost ends the body floats in place until the next teleport puts it somewhere safe; this long at most
        [field: SerializeField, Min(0f)] public float TeleportWaitMaxInSeconds { get; private set; } = 5f;
    }
}
