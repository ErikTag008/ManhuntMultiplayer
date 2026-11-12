using Assets._Project._Scripts.SceneReference;
using UnityEngine;

namespace Project.Assets._Project._Scripts.SceneFlow
{
    [CreateAssetMenu(fileName = "GameScenes", menuName = "ScriptableObjects/GameScenes", order = 1)]
        public class GameScenes : ScriptableObject
        {
            [field: SerializeField, SceneReference] public string LobbyScene { get; private set; }
            [field: SerializeField, SceneReference] public string MainMenuScene { get; private set; }
            [field: SerializeField] public MapDefinition DefaultMap { get; private set; }

            public string LobbySceneName => System.IO.Path.GetFileNameWithoutExtension(LobbyScene);
            public string MainMenuSceneName => System.IO.Path.GetFileNameWithoutExtension(MainMenuScene);
    }
    }
