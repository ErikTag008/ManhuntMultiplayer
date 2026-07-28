namespace Project.Assets._Project._Scripts.Managers
{
    public interface ISceneInitialized
    {
        void InitializeSceneReferences(SceneType scene);
        void ClearSceneReferences(SceneType scene);
    }
    public enum SceneType
    {
        MainMenu,
        Lobby,
        Gameplay
    }
}
