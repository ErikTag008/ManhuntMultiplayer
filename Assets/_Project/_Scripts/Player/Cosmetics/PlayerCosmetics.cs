using KBCore.Refs;
using Project.Assets._Project._Scripts.Cosmetics;
using Project.Assets._Project._Scripts.Weapons;
using Reflex.Attributes;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Cosmetics
{
    // Owner: sends its saved loadout on spawn and after every equip. Server: keeps only ids the catalog has for each slot;
    // it can't check ownership, because the profile is a local save. Every instance dresses this player for its current
    // team: a catcher gets the weapon look (also on the owner's first-person copy) and the catcher outfit, a runner and a
    // player still in the lobby the runner outfit.
    [RequireComponent(typeof(PlayerTeam), typeof(PlayerCombat), typeof(PlayerViewModel))]
    [RequireComponent(typeof(PlayerGhost))]
    public class PlayerCosmetics : NetworkBehaviour
    {
        // injected by PlayerController.Awake together with the rest of the player
        [Inject] private readonly CosmeticCatalog _catalog;
        [Inject] private readonly CosmeticProfileService _profile;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerCombat _combat;
        [SerializeField, Self] private PlayerViewModel _viewModel;
        [SerializeField, Self] private PlayerGhost _ghost;

        private readonly NetworkVariable<CosmeticLoadout> _loadout = new(CosmeticLoadout.Empty);
        private readonly MaterialOverrideGroup _bodyMaterials = new();
        private readonly MaterialOverrideGroup _weaponMaterials = new();
        private readonly List<Renderer> _rendererBuffer = new();
        private Transform _dressedModel;
        private MeleeWeaponBase _dressedWeapon;
        private CosmeticItem _appliedOutfit;
        private GameObject _attachment;

        public CosmeticLoadout Loadout => _loadout.Value;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            _loadout.OnValueChanged += HandleLoadoutChanged;
            _team.OnModelCreated += HandleModelCreated;
            _team.OnStatsChanged += HandleStatsChanged;
            _combat.OnWeaponChanged += HandleWeaponChanged;
            if (IsOwner) _profile.OnLoadoutChanged += SendLoadout;
        }

        // every OnNetworkSpawn has run by now, so the team's model and weapon are in place whatever the component order
        protected override void OnNetworkPostSpawn()
        {
            DressModel(_team.Model);
            DressWeapon(_combat.CurrentWeapon);
            if (IsOwner) SendLoadout();
        }

        private void SendLoadout() => ChangeLoadoutServerRpc(CosmeticLoadout.FromProfile(_profile));

        [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Owner)]
        private void ChangeLoadoutServerRpc(CosmeticLoadout loadout) => _loadout.Value = loadout.ValidatedBy(_catalog);

        private void HandleLoadoutChanged(CosmeticLoadout previous, CosmeticLoadout current)
        {
            DressModel(_team.Model);
            DressWeapon(_combat.CurrentWeapon);
        }

        private void HandleModelCreated(Transform model) => DressModel(model);

        // a team change that keeps the same model still switches between the catcher and the runner outfit
        private void HandleStatsChanged(PlayerStats _) => DressModel(_team.Model);

        private void HandleWeaponChanged(MeleeWeaponBase weapon) => DressWeapon(weapon);

        private CosmeticItem Resolve(CosmeticSlot slot) => _catalog.Resolve(_loadout.Value.GetId(slot), slot);

        private CosmeticSlot GetOutfitSlot() => _team.Team == Team.Catcher ? CosmeticSlot.CatcherOutfit : CosmeticSlot.RunnerOutfit;

        private void DressModel(Transform model)
        {
            if (model != _dressedModel)
            {
                // the old model and its attachment go away with the team change
                RemoveAttachment();
                _bodyMaterials.Clear();
                _appliedOutfit = null;
                _dressedModel = model;
                CosmeticDressing.CaptureBodyRenderers(model, _bodyMaterials, _rendererBuffer);
            }

            if (_dressedModel == null) return;

            var outfit = Resolve(GetOutfitSlot());
            if (outfit == _appliedOutfit) return;

            RemoveAttachment();
            _appliedOutfit = outfit;
            _bodyMaterials.Apply(outfit != null ? outfit.MaterialOverride : null);
            AddAttachment(outfit);
        }

        private void AddAttachment(CosmeticItem outfit)
        {
            _attachment = CosmeticDressing.AddAttachment(_dressedModel, outfit);
            // the owner's own outfit hides with its body, so it never blocks the first-person camera
            if (_attachment == null) return;

            _team.MatchOwnModelVisibility(_attachment.transform);
            // a late joiner's loadout arrives after its ghost hid the body, so the new outfit hides with it
            _ghost.MatchGhostVisibility(_attachment.transform);
        }

        private void RemoveAttachment()
        {
            if (_attachment != null) Destroy(_attachment);
            _attachment = null;
        }

        private void DressWeapon(MeleeWeaponBase weapon)
        {
            if (weapon != _dressedWeapon)
            {
                _dressedWeapon = weapon;
                CosmeticDressing.CaptureWeaponRenderers(weapon, _weaponMaterials, _rendererBuffer);
            }

            if (_dressedWeapon == null) return;

            var weaponLook = _team.Team == Team.Catcher ? Resolve(CosmeticSlot.CatcherWeapon) : null;
            // the first-person copy is taken from the world weapon, so it is made again with the new look
            if (_weaponMaterials.Apply(weaponLook != null ? weaponLook.MaterialOverride : null)) _viewModel.RebuildView();
        }

        public override void OnNetworkDespawn()
        {
            _loadout.OnValueChanged -= HandleLoadoutChanged;
            _team.OnModelCreated -= HandleModelCreated;
            _team.OnStatsChanged -= HandleStatsChanged;
            _combat.OnWeaponChanged -= HandleWeaponChanged;
            if (IsOwner) _profile.OnLoadoutChanged -= SendLoadout;
            RemoveAttachment();
        }
    }
}
