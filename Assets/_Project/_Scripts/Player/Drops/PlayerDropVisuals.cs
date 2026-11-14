using KBCore.Refs;
using Reflex.Attributes;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Drops
{
    // How an invisible runner looks to whoever watches this instance: catchers don't see the model at all (shadow included),
    // everyone else sees it ghosted. The owner's own instance is left alone. Only renderer.enabled and sharedMaterials change.
    [RequireComponent(typeof(PlayerTeam), typeof(PlayerDropEffects))]
    public class PlayerDropVisuals : NetworkBehaviour
    {
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerDropEffects _dropEffects;
        [SerializeField] private Material _ghostMaterial;

        private readonly List<Renderer> _rendererBuffer = new();
        private readonly List<RendererState> _renderers = new();
        private VisibilityMode _mode = VisibilityMode.Normal;

        private bool IsLocalViewerCatcher =>
            _sessionDirectory.TryGetSession(NetworkManager.LocalClientId, out var session) && session.Team == Team.Catcher;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            if (IsOwner) return;

            _team.OnModelChanged += HandleModelChanged;
            _dropEffects.OnActiveEffectChanged += HandleActiveEffectChanged;
            _sessionDirectory.OnSessionChanged += HandleSessionChanged;
        }

        // every OnNetworkSpawn has run by now, so PlayerTeam's model is in place whatever the component order
        protected override void OnNetworkPostSpawn()
        {
            if (!IsOwner) HandleModelChanged(_team.Model);
        }

        private void HandleModelChanged(Transform model)
        {
            RestoreRenderers();
            CollectRenderers(model);
            ApplyMode(ResolveMode());
        }

        private void HandleActiveEffectChanged(DropEffectData _) => Refresh();

        // the local viewer switching team changes whether it sees this runner hidden or ghosted
        private void HandleSessionChanged(PlayerSession session)
        {
            if (session.ClientId == NetworkManager.LocalClientId) Refresh();
        }

        private void Refresh()
        {
            var mode = ResolveMode();
            if (mode != _mode) ApplyMode(mode);
        }

        private VisibilityMode ResolveMode()
        {
            if (!_dropEffects.Has(DropStatus.Invisible)) return VisibilityMode.Normal;
            return IsLocalViewerCatcher ? VisibilityMode.Hidden : VisibilityMode.Ghost;
        }

        private void CollectRenderers(Transform model)
        {
            if (model == null) return;

            model.GetComponentsInChildren(true, _rendererBuffer);
            foreach (var renderer in _rendererBuffer)
            {
                var originalMaterials = renderer.sharedMaterials;
                var ghostMaterials = new Material[originalMaterials.Length];
                for (int i = 0; i < ghostMaterials.Length; i++) ghostMaterials[i] = _ghostMaterial;

                _renderers.Add(new RendererState(renderer, originalMaterials, ghostMaterials, renderer.enabled));
            }

            _rendererBuffer.Clear();
        }

        private void ApplyMode(VisibilityMode mode)
        {
            _mode = mode;
            foreach (var state in _renderers)
            {
                // the old model is destroyed on a team change; its renderers may already be gone
                if (state.Renderer == null) continue;

                state.Renderer.enabled = mode != VisibilityMode.Hidden && state.WasEnabled;
                state.Renderer.sharedMaterials = mode == VisibilityMode.Ghost && _ghostMaterial != null ? state.GhostMaterials : state.OriginalMaterials;
            }
        }

        private void RestoreRenderers()
        {
            if (_mode != VisibilityMode.Normal) ApplyMode(VisibilityMode.Normal);
            _renderers.Clear();
            _mode = VisibilityMode.Normal;
        }

        public override void OnNetworkDespawn()
        {
            if (IsOwner) return;

            _team.OnModelChanged -= HandleModelChanged;
            _dropEffects.OnActiveEffectChanged -= HandleActiveEffectChanged;
            _sessionDirectory.OnSessionChanged -= HandleSessionChanged;
            RestoreRenderers();
        }

        private readonly struct RendererState
        {
            public readonly Renderer Renderer;
            public readonly Material[] OriginalMaterials;
            public readonly Material[] GhostMaterials;
            public readonly bool WasEnabled;

            public RendererState(Renderer renderer, Material[] originalMaterials, Material[] ghostMaterials, bool wasEnabled)
            {
                Renderer = renderer;
                OriginalMaterials = originalMaterials;
                GhostMaterials = ghostMaterials;
                WasEnabled = wasEnabled;
            }
        }

        private enum VisibilityMode
        {
            Normal,
            Hidden,
            Ghost
        }
    }
}
