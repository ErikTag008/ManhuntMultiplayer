using Assets._Project._Scripts.SceneReference;
using UnityEngine;

namespace Project.Assets._Project._Scripts.SceneFlow
{
    // A playable map; built-in scenes today, Workshop AssetBundle maps later
    [CreateAssetMenu(fileName = "MapDefinition", menuName = "ScriptableObjects/MapDefinition", order = 1)]
    public class MapDefinition : ScriptableObject
    {
        [field: SerializeField] public string DisplayName { get; private set; }
        [field: SerializeField, SceneReference] public string Scene { get; private set; }

        public string SceneName => System.IO.Path.GetFileNameWithoutExtension(Scene);
    }
}
