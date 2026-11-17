using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace Project.Assets._Project._Scripts.Networking
{
    // Where hosts advertise their lobby and the browser finds them: local files or Steam lobbies
    public interface ILobbyDirectory
    {
        // False when every lobby is found whatever the distance (local files), so the browser hides that choice
        bool HasSearchDistance { get; }

        // Creates or updates this instance's own advert
        void Publish(LobbyListing listing);
        void Unpublish();
        // Replaces results with the lobbies found; never throws for unreadable entries
        UniTask FetchLobbies(LobbySearchDistance distance, List<LobbyListing> results, CancellationToken token);
    }
}
