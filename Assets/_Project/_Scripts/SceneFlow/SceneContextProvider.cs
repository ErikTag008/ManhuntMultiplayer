namespace Project.Assets._Project._Scripts.SceneFlow
{
    // Project-scoped holder of the current scene's context, filled by scene installers
    public class SceneContextProvider
    {
        private ISceneContext _current;

        public void Register(ISceneContext sceneContext) => _current = sceneContext;

        // A late unregister from the previous scene must not clear the context of the scene that replaced it
        public void Unregister(ISceneContext sceneContext)
        {
            if (_current == sceneContext) _current = null;
        }

        public bool TryGetCurrent(SceneType sceneType, out ISceneContext sceneContext)
        {
            sceneContext = _current != null && _current.SceneType == sceneType ? _current : null;
            return sceneContext != null;
        }
    }
}
