using KBCore.Refs;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Drops
{
    // The drop effect a runner currently has, one at a time. The server writes the effect id and its end time;
    // every instance reads the effect as active only while it is Up, a runner, and before the end time on the server clock,
    // so a late clear from the server never stretches an effect. The owner applies the effect's movement modifiers.
    [RequireComponent(typeof(PlayerController), typeof(PlayerTeam), typeof(PlayerLifeState))]
    public class PlayerDropEffects : NetworkBehaviour
    {
        private const int NoEffectId = 0;

        [Inject] private readonly DropCatalog _catalog;
        [SerializeField, Self] private PlayerController _controller;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerLifeState _lifeState;

        // Every instance: raised when the active effect starts, is replaced or ends (null), expiry included
        public event Action<DropEffectData> OnActiveEffectChanged;

        private readonly NetworkVariable<int> _effectId = new(NoEffectId);
        private readonly NetworkVariable<double> _endTime = new();
        // Owner only: the exact instances added, since the stack removes modifiers by reference
        private readonly List<IStatModifier> _appliedModifiers = new();
        private DropEffectData _shownEffect;

        public DropEffectData ActiveEffect
        {
            get
            {
                if (!IsSpawned || _effectId.Value == NoEffectId) return null;
                if (_team.Team != Team.Runner || !_lifeState.IsUp) return null;
                if (NetworkManager.ServerTime.Time >= _endTime.Value) return null;
                return _catalog.TryGet(_effectId.Value, out var effect) ? effect : null;
            }
        }
        public float RemainingInSeconds => ActiveEffect != null ? Mathf.Max(0f, (float)(_endTime.Value - NetworkManager.ServerTime.Time)) : 0f;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            _team.OnStatsChanged += HandleStatsChanged;
            _lifeState.OnLifeStateChanged += HandleLifeStateChanged;
        }

        private void Update()
        {
            if (!IsSpawned) return;

            if (IsServer) ClearIfExpired();
            RefreshActiveEffect();
        }

        public bool Has(DropStatus status)
        {
            var effect = ActiveEffect;
            return effect != null && effect.Has(status);
        }

        // Server only: a new pickup replaces the current effect
        public void Apply(DropEffectData effect)
        {
            if (!IsServer || effect == null) return;

            _effectId.Value = effect.Id;
            _endTime.Value = NetworkManager.ServerTime.Time + effect.DurationInSeconds;
        }

        // Server only: a shield blocks one catch and is used up by it
        public bool TryConsumeShield()
        {
            if (!IsServer || !Has(DropStatus.Shielded)) return false;

            ClearEffect();
            return true;
        }

        // A team change starts a new round or returns to the lobby, so the effect ends
        private void HandleStatsChanged(PlayerStats _)
        {
            if (IsServer) ClearEffect();
        }

        // knocked and eliminated runners lose their effect
        private void HandleLifeStateChanged(LifeState state)
        {
            if (IsServer && state != LifeState.Up) ClearEffect();
        }

        private void ClearIfExpired()
        {
            if (_effectId.Value != NoEffectId && NetworkManager.ServerTime.Time >= _endTime.Value) ClearEffect();
        }

        // Server only
        private void ClearEffect()
        {
            _effectId.Value = NoEffectId;
            _endTime.Value = 0;
        }

        private void RefreshActiveEffect()
        {
            var effect = ActiveEffect;
            if (effect == _shownEffect) return;

            _shownEffect = effect;
            if (IsOwner) ApplyModifiers(effect);
            OnActiveEffectChanged?.Invoke(effect);
        }

        // Owner only: movement runs on the owner. PlayerController clears the whole stack on a team change,
        // so removing an instance that is already gone is expected and harmless.
        private void ApplyModifiers(DropEffectData effect)
        {
            RemoveAppliedModifiers();
            if (effect == null) return;

            foreach (var modifier in effect.Modifiers)
            {
                if (modifier == null) continue;

                _controller.StatModifiers.Add(modifier);
                _appliedModifiers.Add(modifier);
            }
        }

        private void RemoveAppliedModifiers()
        {
            foreach (var modifier in _appliedModifiers) _controller.StatModifiers.Remove(modifier);
            _appliedModifiers.Clear();
        }

        public override void OnNetworkDespawn()
        {
            _team.OnStatsChanged -= HandleStatsChanged;
            _lifeState.OnLifeStateChanged -= HandleLifeStateChanged;
            if (IsOwner) RemoveAppliedModifiers();
            if (_shownEffect == null) return;

            _shownEffect = null;
            OnActiveEffectChanged?.Invoke(null);
        }
    }
}
