using System;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    public class Health : NetworkBehaviour
    {
        public NetworkVariable<int> MaxHealth = new();
        public NetworkVariable<int> CurrentHealth = new();
        public bool IsDowned => CurrentHealth.Value <= 0;
        public event Action OnDowned;
        public override void OnNetworkSpawn()
        {
            if (!IsServer)
                return;

            MaxHealth.Value = 1;
            CurrentHealth.Value = MaxHealth.Value;
        }

        public void ResetHealth()
        {
            if (!IsServer)
                return;

            CurrentHealth.Value = MaxHealth.Value;
        }

        public void SetMaxHealth(int value)
        {
            if (!IsServer)
                return;

            MaxHealth.Value = value;
            CurrentHealth.Value = Mathf.Min(CurrentHealth.Value, value);
        }

        public void TakeDamage(int damage)
        {
            if (!IsServer)
                return;

            CurrentHealth.Value = Mathf.Max(
                0,
                CurrentHealth.Value - damage
            );

            if (IsDowned) OnDowned?.Invoke();
        }
    }
}
