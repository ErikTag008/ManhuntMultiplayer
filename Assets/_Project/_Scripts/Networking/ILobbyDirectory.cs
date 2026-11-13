using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace Project.Assets._Project._Scripts.Networking
{
    // Where hosts advertise their lobby and the browser finds them: local files today, Steam lobbies in P3
    public interface ILobbyDirectory
    {
        // Creates or updates this instance's own advert
        void Publish(LobbyListing listing);
        void Unpublish();
        // Replaces results with the lobbies found; never throws for unreadable entries
        UniTask FetchLobbies(List<LobbyListing> results, CancellationToken token);
    }
}
