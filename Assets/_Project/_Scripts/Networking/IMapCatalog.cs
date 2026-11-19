using System;

namespace Project.Assets._Project._Scripts.Networking
{
    // The playable maps by index, as LobbyConfig.MapIndex refers to them
    public interface IMapCatalog
    {
        // the list or its names changed, e.g. a client got the host's list
        event Action OnChanged;

        int MapCount { get; }
        string GetMapDisplayName(int index);
    }
}
