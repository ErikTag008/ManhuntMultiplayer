namespace Project.Assets._Project._Scripts.Networking
{
    // The playable maps by index, as LobbyConfig.MapIndex refers to them
    public interface IMapCatalog
    {
        int MapCount { get; }
        string GetMapDisplayName(int index);
    }
}
