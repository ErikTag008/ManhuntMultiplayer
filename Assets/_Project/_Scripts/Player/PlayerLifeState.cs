using System;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Player
{
    // Server-owned Up / Knocked / Eliminated state, replicated to everyone
    public class PlayerLifeState : NetworkBehaviour
    {
        public event Action<LifeState> OnLifeStateChanged;

        private readonly NetworkVariable<LifeState> _state = new();

        public LifeState State => _state.Value;
        public bool IsUp => _state.Value == LifeState.Up;

        public override void OnNetworkSpawn() => _state.OnValueChanged += HandleStateChanged;

        public void Knock()
        {
            if (!IsServer || !IsUp) return;
            _state.Value = LifeState.Knocked;
        }

        public void ResetState()
        {
            if (!IsServer) return;
            _state.Value = LifeState.Up;
        }

        private void HandleStateChanged(LifeState previous, LifeState current) => OnLifeStateChanged?.Invoke(current);

        public override void OnNetworkDespawn() => _state.OnValueChanged -= HandleStateChanged;
    }

    public enum LifeState
    {
        Up,
        Knocked,
        Eliminated
    }
}
