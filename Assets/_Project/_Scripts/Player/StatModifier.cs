using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Serializable so drop and ability data assets can author modifiers in the Inspector
    [Serializable]
    public class StatModifier : IStatModifier
    {
        [SerializeField] private ModifiableStat _stat;
        [SerializeField] private StatModifierKind _kind = StatModifierKind.Multiply;
        [SerializeField] private float _value = 1f;

        // Unity's serializer only runs the field initializers above (Multiply x1, a no-op) through a parameterless constructor
        private StatModifier() { }

        public StatModifier(ModifiableStat stat, StatModifierKind kind, float value)
        {
            _stat = stat;
            _kind = kind;
            _value = value;
        }

        public ModifiableStat Stat => _stat;
        public StatModifierKind Kind => _kind;
        public float Value => _value;
    }
}
