using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Networking
{
    // Defaults and allowed ranges for the host's lobby options
    [CreateAssetMenu(fileName = "LobbyConfigData", menuName = "ScriptableObjects/LobbyConfigData", order = 1)]
    public class LobbyConfigData : ScriptableObject
    {
        // float steps don't add up exactly, so the last value may land just past the max
        private const float RangeTolerance = 0.001f;

        [field: SerializeField] public string DefaultName { get; private set; } = "Manhunt lobby";
        [field: SerializeField, Min(1)] public int MaxNameLength { get; private set; } = 32;
        [field: SerializeField] public LobbyVisibility DefaultVisibility { get; private set; } = LobbyVisibility.Public;
        [field: SerializeField, Min(0)] public int DefaultMapIndex { get; private set; } = 0;

        [field: SerializeField, Min(1)] public int MinMaxPlayers { get; private set; } = 4;
        [field: SerializeField, Min(1)] public int MaxMaxPlayers { get; private set; } = 10;
        [field: SerializeField, Min(1)] public int DefaultMaxPlayers { get; private set; } = 10;
        [field: SerializeField, Min(1)] public int MaxPlayersStep { get; private set; } = 1;

        [field: SerializeField, Min(0f)] public float MinHideDurationInSeconds { get; private set; } = 15f;
        [field: SerializeField, Min(0f)] public float MaxHideDurationInSeconds { get; private set; } = 60f;
        [field: SerializeField, Min(0f)] public float DefaultHideDurationInSeconds { get; private set; } = 30f;
        [field: SerializeField, Min(0.1f)] public float HideDurationStepInSeconds { get; private set; } = 5f;

        [field: SerializeField, Min(0f)] public float MinRoundDurationInSeconds { get; private set; } = 180f;
        [field: SerializeField, Min(0f)] public float MaxRoundDurationInSeconds { get; private set; } = 600f;
        [field: SerializeField, Min(0f)] public float DefaultRoundDurationInSeconds { get; private set; } = 300f;
        [field: SerializeField, Min(0.1f)] public float RoundDurationStepInSeconds { get; private set; } = 30f;

        public LobbyConfig CreateDefault() => new()
        {
            Name = LobbyConfig.ToName(DefaultName),
            Visibility = DefaultVisibility,
            MaxPlayers = DefaultMaxPlayers,
            MapIndex = DefaultMapIndex,
            HideDurationInSeconds = DefaultHideDurationInSeconds,
            RoundDurationInSeconds = DefaultRoundDurationInSeconds
        };

        // Blank names fall back to the default; long ones are cut to MaxNameLength
        public string SanitizeName(string name)
        {
            var trimmed = name == null ? string.Empty : name.Trim();
            if (trimmed.Length == 0) return DefaultName;

            return trimmed.Length > MaxNameLength ? trimmed.Substring(0, MaxNameLength).TrimEnd() : trimmed;
        }

        public void GetMaxPlayerOptions(List<int> results) => FillRange(MinMaxPlayers, MaxMaxPlayers, MaxPlayersStep, results);

        public void GetHideDurationOptions(List<float> results) =>
            FillRange(MinHideDurationInSeconds, MaxHideDurationInSeconds, HideDurationStepInSeconds, results);

        public void GetRoundDurationOptions(List<float> results) =>
            FillRange(MinRoundDurationInSeconds, MaxRoundDurationInSeconds, RoundDurationStepInSeconds, results);

        // min, min + step, ... up to max; a non-positive step or an inverted range gives just min
        public static void FillRange(int min, int max, int step, List<int> results)
        {
            results.Clear();
            if (step <= 0 || max < min)
            {
                results.Add(min);
                return;
            }

            for (int value = min; value <= max; value += step) results.Add(value);
        }

        public static void FillRange(float min, float max, float step, List<float> results)
        {
            results.Clear();
            if (step <= 0f || max < min)
            {
                results.Add(min);
                return;
            }

            int count = Mathf.FloorToInt((max - min) / step + RangeTolerance);
            for (int i = 0; i <= count; i++) results.Add(min + step * i);
        }

        // Index of the option nearest to value, so a value off the step grid still picks a sensible entry; -1 when empty
        public static int FindClosestIndex(IReadOnlyList<int> options, int value)
        {
            int closestIndex = -1;
            int closestDistance = int.MaxValue;
            for (int i = 0; i < options.Count; i++)
            {
                int distance = Mathf.Abs(options[i] - value);
                if (distance >= closestDistance) continue;

                closestIndex = i;
                closestDistance = distance;
            }

            return closestIndex;
        }

        public static int FindClosestIndex(IReadOnlyList<float> options, float value)
        {
            int closestIndex = -1;
            float closestDistance = float.MaxValue;
            for (int i = 0; i < options.Count; i++)
            {
                float distance = Mathf.Abs(options[i] - value);
                if (distance >= closestDistance) continue;

                closestIndex = i;
                closestDistance = distance;
            }

            return closestIndex;
        }
    }
}
