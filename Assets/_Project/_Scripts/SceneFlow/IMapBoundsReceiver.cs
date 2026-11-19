namespace Project.Assets._Project._Scripts.SceneFlow
{
    // A gameplay scene whose MapBounds can arrive after it loaded (a bundle map placed at runtime)
    public interface IMapBoundsReceiver
    {
        void SetMapBounds(MapBounds mapBounds);
    }
}
