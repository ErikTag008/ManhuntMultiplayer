using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Cosmetics
{
    // A set of renderers whose materials can be swapped for one override and put back. Capture before overriding,
    // so the remembered materials are the renderers' own.
    public class MaterialOverrideGroup
    {
        private readonly List<Renderer> _renderers = new();
        private readonly List<Material[]> _originalMaterials = new();
        private Material _currentOverride;

        public void Capture(List<Renderer> renderers)
        {
            Clear();
            foreach (var renderer in renderers)
            {
                if (renderer == null) continue;

                _renderers.Add(renderer);
                _originalMaterials.Add(renderer.sharedMaterials);
            }
        }

        // null puts the renderers' own materials back; false when nothing had to change
        public bool Apply(Material materialOverride)
        {
            if (materialOverride == _currentOverride) return false;

            _currentOverride = materialOverride;
            for (int i = 0; i < _renderers.Count; i++)
            {
                var renderer = _renderers[i];
                // a swapped-out model may already be destroyed
                if (renderer == null) continue;

                renderer.sharedMaterials = materialOverride != null ? CreateOverrides(_originalMaterials[i].Length, materialOverride) : _originalMaterials[i];
            }

            return true;
        }

        // forgets the renderers without touching them
        public void Clear()
        {
            _renderers.Clear();
            _originalMaterials.Clear();
            _currentOverride = null;
        }

        private static Material[] CreateOverrides(int count, Material material)
        {
            var materials = new Material[count];
            for (int i = 0; i < count; i++) materials[i] = material;
            return materials;
        }
    }
}
