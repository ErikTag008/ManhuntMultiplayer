using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Stations
{
    [CreateAssetMenu(fileName = "StationSettings", menuName = "ScriptableObjects/StationSettings", order = 1)]
    public class StationSettings : ScriptableObject
    {
        // one runner or several, a station always fills at this rate
        [field: SerializeField, Min(0f)] public float HoldDurationInSeconds { get; private set; } = 10f;
        [field: SerializeField, Min(0f)] public float InteractRange { get; private set; } = 2.5f;
        [field: SerializeField, Min(0f)] public float TimeCutInSeconds { get; private set; } = 30f;
        // a completed station never takes the round below this
        [field: SerializeField, Min(0f)] public float MinRemainingInSeconds { get; private set; } = 30f;
        // loops on the station while it is being worked, so others can hear it
        [field: SerializeField] public AudioClip ActiveLoopSFX { get; private set; }
        [field: SerializeField, Range(0f, 1f)] public float ActiveLoopSFXVolume { get; private set; } = 1f;
    }
}
