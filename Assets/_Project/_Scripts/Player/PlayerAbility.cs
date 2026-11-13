using KBCore.Refs;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Player.Abilities;
using Reflex.Attributes;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // One ability per runner. The owner applies the effect at once so it feels instant (movement is owner-authoritative);
    // the server owns the cooldown as a synced end time and ignores uses that come too early or from players who can't use one.
    [RequireComponent(typeof(PlayerController), typeof(PlayerTeam), typeof(PlayerLifeState))]
    [RequireComponent(typeof(PlayerHideHold), typeof(InputReader))]
    public class PlayerAbility : NetworkBehaviour
    {
        [Inject] private readonly AbilityCatalog _catalog;
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [SerializeField, Self] private PlayerController _controller;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private PlayerHideHold _hideHold;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField, Min(0f)] private float _serverToleranceInSeconds = 0.25f;

        private readonly NetworkVariable<double> _cooldownEndTime = new();
        // Owner only: keeps the ability locked until the server's new end time arrives
        private double _predictedCooldownEndTime;

        // Only runners have an ability: the session's pick, or the catalog default until picks exist
        public AbilityData Ability => _team.Team == Team.Runner ? _catalog.Resolve(SessionAbilityId) : null;
        public float CooldownRemainingInSeconds
        {
            get
            {
                double endTime = IsOwner ? System.Math.Max(_cooldownEndTime.Value, _predictedCooldownEndTime) : _cooldownEndTime.Value;
                return AbilityCooldown.RemainingInSeconds(NetworkManager.ServerTime.Time, endTime);
            }
        }

        private int SessionAbilityId => _sessionDirectory.TryGetSession(OwnerClientId, out var session) ? session.AbilityId : PlayerSession.NoAbility;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            _team.OnStatsChanged += HandleStatsChanged;
            if (!IsOwner) return;

            _inputReader.OnAbility += HandleAbilityPressed;
            _inputReader.OnJump += HandleJumpChanged;
        }

        private void HandleAbilityPressed() => TryUse(AbilityTrigger.AbilityKey);

        private void HandleJumpChanged(bool isButtonDown)
        {
            if (isButtonDown) TryUse(AbilityTrigger.AirJump);
        }

        // A team change starts a new round or returns to the lobby, so the cooldown starts fresh
        private void HandleStatsChanged(PlayerStats _)
        {
            if (IsServer) _cooldownEndTime.Value = 0;
            _predictedCooldownEndTime = 0;
        }

        // Owner only
        private void TryUse(AbilityTrigger trigger)
        {
            var ability = Ability;
            if (ability == null || ability.Trigger != trigger || !CanUseAbility()) return;
            if (CooldownRemainingInSeconds > 0f) return;

            var movement = _controller.Movement;
            if (movement == null || !ability.TryActivate(movement)) return;

            _predictedCooldownEndTime = NetworkManager.ServerTime.Time + ability.CooldownInSeconds;
            UseAbilityServerRpc();
        }

        [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Owner)]
        private void UseAbilityServerRpc()
        {
            var ability = Ability;
            if (ability == null || !CanUseAbility()) return;

            double now = NetworkManager.ServerTime.Time;
            if (!AbilityCooldown.IsAcceptedByServer(now, _cooldownEndTime.Value, _serverToleranceInSeconds)) return;

            _cooldownEndTime.Value = now + ability.CooldownInSeconds;
        }

        // knocked, eliminated and hide-phase-held players can't use abilities
        private bool CanUseAbility() => _lifeState.IsUp && !_hideHold.IsHeld;

        public override void OnNetworkDespawn()
        {
            _team.OnStatsChanged -= HandleStatsChanged;
            if (!IsOwner) return;

            _inputReader.OnAbility -= HandleAbilityPressed;
            _inputReader.OnJump -= HandleJumpChanged;
        }
    }
}
