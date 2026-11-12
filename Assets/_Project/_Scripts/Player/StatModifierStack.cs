using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Active modifiers on one player. Timed entries stop applying once they expire and are pruned on the next Add/Remove.
    public class StatModifierStack
    {
        private readonly List<Entry> _entries = new();
        private readonly Func<float> _getTime;

        public StatModifierStack() : this(() => Time.time) { }

        // the clock is injectable so EditMode tests can control expiry
        public StatModifierStack(Func<float> getTime)
        {
            _getTime = getTime;
        }

        public int Count => _entries.Count;

        // Stays until removed, e.g. the knocked crawl while knocked
        public void Add(IStatModifier modifier) => Add(modifier, float.PositiveInfinity);

        public void Add(IStatModifier modifier, float durationInSeconds)
        {
            if (modifier == null) return;

            RemoveExpired();
            _entries.Add(new Entry(modifier, _getTime() + durationInSeconds));
        }

        // Removes one entry of this modifier, so the same modifier added twice needs two removes
        public bool Remove(IStatModifier modifier)
        {
            RemoveExpired();
            int index = _entries.FindIndex(entry => entry.Modifier == modifier);
            if (index < 0) return false;

            _entries.RemoveAt(index);
            return true;
        }

        public void Clear() => _entries.Clear();

        // Never below zero: a strong slow can't turn movement backwards
        public float Apply(ModifiableStat stat, float baseValue)
        {
            float now = _getTime();
            float added = 0f;
            float multiplier = 1f;

            foreach (var entry in _entries)
            {
                if (entry.ExpiresAt <= now || entry.Modifier.Stat != stat) continue;

                switch (entry.Modifier.Kind)
                {
                    case StatModifierKind.Add:
                        added += entry.Modifier.Value;
                        break;
                    case StatModifierKind.Multiply:
                        multiplier *= entry.Modifier.Value;
                        break;
                }
            }

            return Mathf.Max(0f, (baseValue + added) * multiplier);
        }

        private void RemoveExpired()
        {
            float now = _getTime();
            _entries.RemoveAll(entry => entry.ExpiresAt <= now);
        }

        private readonly struct Entry
        {
            public readonly IStatModifier Modifier;
            public readonly float ExpiresAt;

            public Entry(IStatModifier modifier, float expiresAt)
            {
                Modifier = modifier;
                ExpiresAt = expiresAt;
            }
        }
    }
}
