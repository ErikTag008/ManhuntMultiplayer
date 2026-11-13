using Assets._Project._Scripts.SceneReference;
using Project.Assets._Project._Scripts.Networking;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.SceneFlow
{
    [CreateAssetMenu(fileName = "GameScenes", menuName = "ScriptableObjects/GameScenes", order = 1)]
    public class GameScenes : ScriptableObject, IMapCatalog
    {
        [field: SerializeField, SceneReference] public string LobbyScene { get; private set; }
        [field: SerializeField, SceneReference] public string MainMenuScene { get; private set; }
        [field: SerializeField] public MapDefinition DefaultMap { get; private set; }
        // The maps a host can pick, by LobbyConfig.MapIndex; empty means DefaultMap is the only one
        [field: SerializeField] public List<MapDefinition> Maps { get; private set; } = new();

        public string LobbySceneName => System.IO.Path.GetFileNameWithoutExtension(LobbyScene);
        public string MainMenuSceneName => System.IO.Path.GetFileNameWithoutExtension(MainMenuScene);

        public int MapCount => Maps.Count > 0 ? Maps.Count : DefaultMap != null ? 1 : 0;

        // Out-of-range indices and empty entries fall back to DefaultMap
        public MapDefinition GetMap(int index)
        {
            if (index < 0 || index >= Maps.Count || Maps[index] == null) return DefaultMap;
            return Maps[index];
        }

        public string GetMapDisplayName(int index)
        {
            var map = GetMap(index);
            if (map == null) return string.Empty;

            return string.IsNullOrEmpty(map.DisplayName) ? map.SceneName : map.DisplayName;
        }
    }
}
