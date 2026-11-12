using Reflex.Attributes;
using System;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Player
{
    // Up / Knocked / Eliminated read from this player's session; PlayerRegistry owns the value
    public class PlayerLifeState : NetworkBehaviour
    {
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [Inject] private readonly IPlayerRegistry _playerRegistry;

        public event Action<LifeState> OnLifeStateChanged;

        private LifeState _state;

        public LifeState State => _state;
        public bool IsUp => _state == LifeState.Up;

        public override void OnNetworkSpawn()
        {
            _sessionDirectory.OnSessionChanged += HandleSessionChanged;
            _state = _sessionDirectory.TryGetSession(OwnerClientId, out var session) ? session.LifeState : LifeState.Up;
        }

        // Server only; players are spawned after GameSystems, so the registry is injected on the server
        public void Knock()
        {
            if (!IsServer || !IsUp) return;
            if (_playerRegistry == null)
            {
                EUtils.Logger.LogError($"[PlayerLifeState] No player registry; can't knock player {OwnerClientId}.");
                return;
            }

            _playerRegistry.SetLifeState(OwnerClientId, LifeState.Knocked);
        }

        private void HandleSessionChanged(PlayerSession session)
        {
            if (session.ClientId != OwnerClientId || session.LifeState == _state) return;

            _state = session.LifeState;
            OnLifeStateChanged?.Invoke(_state);
        }

        public override void OnNetworkDespawn() => _sessionDirectory.OnSessionChanged -= HandleSessionChanged;
    }

    public enum LifeState
    {
        Up,
        Knocked,
        Eliminated
    }
}
