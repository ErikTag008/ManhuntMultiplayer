using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Abilities
{
    // Project-scoped list of the smoke clouds spawned on this instance; filled on clients too. Each SmokeCloud adds and removes itself.
    public class SmokeCloudDirectory
    {
        private readonly List<SmokeCloud> _clouds = new();

        public void Add(SmokeCloud cloud)
        {
            if (!_clouds.Contains(cloud)) _clouds.Add(cloud);
        }

        public void Remove(SmokeCloud cloud) => _clouds.Remove(cloud);

        public bool IsInsideAny(Vector3 position)
        {
            for (int i = 0; i < _clouds.Count; i++)
            {
                if (_clouds[i].Contains(position)) return true;
            }

            return false;
        }
    }
}
