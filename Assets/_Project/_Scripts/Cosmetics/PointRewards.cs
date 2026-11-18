using UnityEngine;

namespace Project.Assets._Project._Scripts.Cosmetics
{
    // What one round pays a player who played it
    [CreateAssetMenu(fileName = "PointRewards", menuName = "ScriptableObjects/PointRewards", order = 1)]
    public class PointRewards : ScriptableObject
    {
        [field: SerializeField, Min(0)] public int PointsPerRound { get; private set; } = 10;
        [field: SerializeField, Min(0)] public int WinBonus { get; private set; } = 20;
        [field: SerializeField, Min(0)] public int PointsPerCatch { get; private set; } = 5;
        [field: SerializeField, Min(0)] public int PointsPerRescue { get; private set; } = 5;
        [field: SerializeField, Min(0)] public int PointsPerStation { get; private set; } = 5;
        // the longest chase pays PointsPerChaseStep for every full step, up to MaxChasePoints
        [field: SerializeField, Min(0f)] public float ChaseStepInSeconds { get; private set; } = 10f;
        [field: SerializeField, Min(0)] public int PointsPerChaseStep { get; private set; } = 2;
        [field: SerializeField, Min(0)] public int MaxChasePoints { get; private set; } = 10;
    }
}
