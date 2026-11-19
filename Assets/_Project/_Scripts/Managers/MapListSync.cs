using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.SceneFlow.Maps;
using Reflex.Attributes;
using System.Collections.Generic;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Managers
{
    // Shares the server's map list (built-in and bundle maps): the server fills it from its SessionMapCatalog,
    // clients mirror it into theirs, so a map index means the same map on every instance
    public class MapListSync : NetworkBehaviour
    {
        [Inject] private readonly SessionMapCatalog _mapCatalog;

        private readonly NetworkList<MapListing> _listings = new();
        private readonly List<MapListing> _listingBuffer = new();

        // GameManager injects GameSystems in its own OnNetworkSpawn, so the injected catalog is only certain to be set here
        protected override void OnNetworkPostSpawn()
        {
            if (IsServer)
            {
                _listings.Clear();
                foreach (var listing in _mapCatalog.Listings) _listings.Add(listing);
                return;
            }

            _listings.OnListChanged += HandleListChanged;
            PushListings();
        }

        private void HandleListChanged(NetworkListEvent<MapListing> _) => PushListings();

        private void PushListings()
        {
            _listingBuffer.Clear();
            foreach (var listing in _listings) _listingBuffer.Add(listing);
            _mapCatalog.SetRemoteListings(_listingBuffer);
        }

        public override void OnNetworkDespawn()
        {
            _listings.OnListChanged -= HandleListChanged;
            // a no-op on the server, which never mirrors
            _mapCatalog?.ClearRemoteListings();
        }
    }
}
