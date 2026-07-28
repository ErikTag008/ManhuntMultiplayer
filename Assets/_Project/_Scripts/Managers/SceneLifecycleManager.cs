using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Managers
{
    public class SceneLifecycleManager
    {
        private readonly HashSet<ISceneInitialized> _sceneInitializedObjects = new();
        private SceneType? _currentSceneType;

        

        public void Register(ISceneInitialized sceneObject)
        {
            if (_sceneInitializedObjects.Contains(sceneObject)) return;
            _sceneInitializedObjects.Add(sceneObject);

            if (_currentSceneType.HasValue)
            {
                sceneObject.InitializeSceneReferences(_currentSceneType.Value);
            }
        }

        public void Unregister(ISceneInitialized sceneObject)
        {
            _sceneInitializedObjects.Remove(sceneObject);
        }

        public void InitializeScene(SceneType sceneType)
        {
            _currentSceneType = sceneType;
            foreach (var sceneObject in _sceneInitializedObjects)
            {
                sceneObject?.InitializeSceneReferences(sceneType);
            }
        }

        public void ClearScene(SceneType sceneType)
        {
            if (_currentSceneType == sceneType)
            {
                _currentSceneType = null;
            }

            foreach (var sceneObject in _sceneInitializedObjects)
            {
                sceneObject?.ClearSceneReferences(sceneType);
            }
        }
    }
}
