using Assets._Project._Scripts.SceneReference;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    [CreateAssetMenu(fileName = "GameScenes", menuName = "ScriptableObjects/GameScenes", order = 1)]
        public class GameScenes : ScriptableObject
        {
            [field: SerializeField, SceneReference] public string LobbyScene { get; private set; }
            [field: SerializeField, SceneReference] public string GameScene { get; private set; }
            [field: SerializeField, SceneReference] public string MainMenuScene { get; private set; }

            public string LobbySceneName => System.IO.Path.GetFileNameWithoutExtension(LobbyScene);
            public string GameSceneName => System.IO.Path.GetFileNameWithoutExtension(GameScene);
            public string MainMenuSceneName => System.IO.Path.GetFileNameWithoutExtension(MainMenuScene);
    }
    }
