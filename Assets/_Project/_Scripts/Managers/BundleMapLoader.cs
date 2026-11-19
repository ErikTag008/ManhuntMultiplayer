using Cysharp.Threading.Tasks;
using KBCore.Refs;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.SceneFlow.Maps;
using Reflex.Attributes;
using Reflex.Core;
using Reflex.Extensions;
using Reflex.Injectors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Assets._Project._Scripts.Managers
{
    // Lives in the generic bundle map scene. Every instance loads the server's selected bundle map from its own library, validates it,
    // places it in this scene and applies its MapBounds; the server also takes its spawns. Clients report how their load went, and the
    // server's IMapLoadGate lets the round start once everyone answered, disconnecting whoever failed or took too long.
    // Stations and drop boxes are spawned by the server at the map's markers after that.
    public class BundleMapLoader : NetworkBehaviour, IMapLoadGate
    {
        [Inject] private readonly SessionMapCatalog _mapCatalog;
        [Inject] private readonly LocalMapLibrary _mapLibrary;
        [Inject] private readonly MapLibrarySettings _settings;
        [Inject] private readonly IMapBoundsReceiver _mapBoundsReceiver;
        [SerializeField, Scene] private PlayerGameSpawnDistributor _spawnDistributor;
        // network prefabs (in DefaultNetworkPrefabs) that rely on [Inject]
        [SerializeField] private NetworkObject _stationPrefab;
        [SerializeField] private NetworkObject _dropPickupPrefab;
        // {0} is the map's name
        [SerializeField] private string _missingMapReasonFormat = "You don't have the map \"{0}\".";
        [SerializeField] private string _differentMapReasonFormat = "Your copy of the map \"{0}\" doesn't match the host's.";
        [SerializeField] private string _brokenMapReasonFormat = "The map \"{0}\" failed to load.";
        [SerializeField] private string _timedOutReasonFormat = "Loading the map \"{0}\" took too long.";

        private readonly NetworkVariable<MapListing> _listing = new();
        private readonly MapReadyTracker _readyTracker = new();
        private readonly UniTaskCompletionSource<bool> _localLoadCompletion = new();
        private readonly List<string> _errorBuffer = new();
        private readonly List<ulong> _clientBuffer = new();
        private GameSystemsRegistry _gameSystemsRegistry;
        private InjectingPrefabHandler _stationHandler;
        private InjectingPrefabHandler _dropPickupHandler;
        private AssetBundle _bundle;
        private GameObject _map;
        private bool _hasStartedLoading;

        private void OnValidate() => this.ValidateRefs();

        [Inject]
        private void RegisterInGameSystems(GameSystemsRegistry gameSystemsRegistry)
        {
            _gameSystemsRegistry = gameSystemsRegistry;
            _gameSystemsRegistry.Register(this);
        }

        // Before anything in this scene spawns, so a late joiner's synced stations and drop boxes already go through the handlers
        private void Awake()
        {
            var container = gameObject.scene.GetSceneContainer();
            _stationHandler = AddPrefabHandler(_stationPrefab, container);
            _dropPickupHandler = AddPrefabHandler(_dropPickupPrefab, container);
        }

        public override void OnNetworkSpawn()
        {
            if (IsServer)
            {
                _listing.Value = _mapCatalog.SelectedMap;
                NetworkManager.OnClientDisconnectCallback += HandleClientDisconnected;
                StartLoading();
                return;
            }

            // the selected map arrives with the spawn; a later value still starts the load
            if (_listing.Value.IsBundle) StartLoading();
            else _listing.OnValueChanged += HandleListingChanged;
        }

        // Server only
        public async UniTask<bool> WaitUntilReady(CancellationToken token)
        {
            if (!IsServer) return false;

            bool isLoaded = await _localLoadCompletion.Task.AttachExternalCancellation(token);
            if (!isLoaded) return false;

            foreach (ulong clientId in NetworkManager.ConnectedClientsIds)
            {
                if (clientId != NetworkManager.ServerClientId) _readyTracker.Expect(clientId);
            }

            float timeoutEndTime = Time.realtimeSinceStartup + _settings.ReadyTimeoutInSeconds;
            await UniTask.WaitUntil(() => _readyTracker.IsComplete || Time.realtimeSinceStartup >= timeoutEndTime, cancellationToken: token);

            _readyTracker.CopyMissing(_clientBuffer);
            foreach (ulong clientId in _clientBuffer) Disconnect(clientId, _timedOutReasonFormat);

            SpawnAtMarkers<StationMarker>(_stationHandler);
            SpawnAtMarkers<DropPointMarker>(_dropPickupHandler);
            return true;
        }

        private InjectingPrefabHandler AddPrefabHandler(NetworkObject prefab, Container container)
        {
            var networkManager = NetworkManager.Singleton;
            if (prefab == null || networkManager == null)
            {
                EUtils.Logger.LogError($"[BundleMapLoader] Can't add a prefab handler: prefab {(prefab != null ? prefab.name : "missing")}, NetworkManager {(networkManager != null ? "found" : "missing")}.");
                return null;
            }

            var handler = new InjectingPrefabHandler(prefab, container);
            networkManager.PrefabHandler.AddHandler(prefab, handler);
            return handler;
        }

        private void HandleListingChanged(MapListing _, MapListing current)
        {
            if (current.IsBundle) StartLoading();
        }

        private void StartLoading()
        {
            if (_hasStartedLoading) return;

            _hasStartedLoading = true;
            LoadAndReport(this.GetCancellationTokenOnDestroy()).Forget();
        }

        private async UniTaskVoid LoadAndReport(CancellationToken token)
        {
            var result = await TryLoadMap(_listing.Value, token);
            if (token.IsCancellationRequested) return;

            if (IsServer)
            {
                _localLoadCompletion.TrySetResult(result == MapLoadResult.Ready);
                return;
            }

            ReportMapLoadServerRpc(result);
        }

        // a map that throws (e.g. a component whose [Inject] this scene can't resolve) still gets an answer, so the round never waits forever
        private async UniTask<MapLoadResult> TryLoadMap(MapListing listing, CancellationToken token)
        {
            try
            {
                return await LoadMap(listing, token);
            }
            catch (OperationCanceledException)
            {
                return MapLoadResult.Failed;
            }
            catch (Exception exception)
            {
                EUtils.Logger.LogError($"[BundleMapLoader] {listing.DisplayName} failed to load: {exception}");
                return MapLoadResult.Failed;
            }
        }

        private async UniTask<MapLoadResult> LoadMap(MapListing listing, CancellationToken token)
        {
            if (!listing.IsBundle)
            {
                EUtils.Logger.LogError("[BundleMapLoader] No bundle map was selected for this scene!");
                return MapLoadResult.Failed;
            }

            string mapId = listing.Id.ToString();
            if (!_mapLibrary.TryFind(mapId, listing.ContentHash.ToString(), out var localMap))
            {
                bool hasOtherCopy = _mapLibrary.Contains(mapId);
                EUtils.Logger.LogWarning($"[BundleMapLoader] {listing.DisplayName} ({mapId}) is {(hasOtherCopy ? "a different file here" : "not in the local library")}.");
                return hasOtherCopy ? MapLoadResult.Different : MapLoadResult.Missing;
            }

            // a file removed since the library scan
            if (!File.Exists(localMap.BundlePath))
            {
                EUtils.Logger.LogWarning($"[BundleMapLoader] {listing.DisplayName}'s bundle is gone: {localMap.BundlePath}");
                return MapLoadResult.Missing;
            }

            // never cancelled midway: a bundle that finished loading without an owner could never be unloaded
            var bundle = await AssetBundle.LoadFromFileAsync(localMap.BundlePath).ToUniTask();
            if (bundle == null)
            {
                EUtils.Logger.LogError($"[BundleMapLoader] Couldn't load the bundle {localMap.BundlePath}.");
                return MapLoadResult.Failed;
            }
            if (token.IsCancellationRequested)
            {
                bundle.Unload(true);
                return MapLoadResult.Failed;
            }

            _bundle = bundle;
            var assets = await _bundle.LoadAllAssetsAsync<GameObject>().AwaitForAllAssets();
            if (token.IsCancellationRequested) return MapLoadResult.Failed;

            var mapPrefab = FindMapPrefab(assets);
            if (!MapValidator.Validate(mapPrefab, _settings, localMap.SizeInBytes, _errorBuffer))
            {
                EUtils.Logger.LogError($"[BundleMapLoader] {listing.DisplayName} isn't a valid map:\n{string.Join("\n", _errorBuffer)}");
                return MapLoadResult.Invalid;
            }

            PlaceMap(mapPrefab);
            return MapLoadResult.Ready;
        }

        private static GameObject FindMapPrefab(UnityEngine.Object[] assets)
        {
            foreach (var asset in assets)
            {
                if (asset is GameObject gameObject && gameObject.TryGetComponent(out MapRoot _)) return gameObject;
            }

            return null;
        }

        // Instantiated under an inactive holder, so every map component is injected before its Awake runs
        private void PlaceMap(GameObject mapPrefab)
        {
            var holder = new GameObject(mapPrefab.name);
            holder.SetActive(false);
            SceneManager.MoveGameObjectToScene(holder, gameObject.scene);
            _map = Instantiate(mapPrefab, holder.transform);
            GameObjectInjector.InjectRecursive(_map, gameObject.scene.GetSceneContainer());
            holder.SetActive(true);

            _mapBoundsReceiver.SetMapBounds(_map.GetComponentInChildren<MapBounds>(true));
            if (!IsServer) return;

            if (_spawnDistributor == null)
            {
                EUtils.Logger.LogError("[BundleMapLoader] No PlayerGameSpawnDistributor set; players won't be moved to the map's spawns!");
                return;
            }

            _spawnDistributor.SetSpawns(GetMarkerTransforms<CatcherSpawnMarker>(), GetMarkerTransforms<RunnerSpawnMarker>());
        }

        private Transform[] GetMarkerTransforms<T>() where T : MapMarker
        {
            var markers = _map.GetComponentsInChildren<T>(true);
            var transforms = new Transform[markers.Length];
            for (int i = 0; i < markers.Length; i++) transforms[i] = markers[i].transform;
            return transforms;
        }

        // Server only
        private void SpawnAtMarkers<T>(InjectingPrefabHandler handler) where T : MapMarker
        {
            if (_map == null || handler == null) return;

            foreach (var marker in _map.GetComponentsInChildren<T>(true))
            {
                var instance = handler.Instantiate(NetworkManager.ServerClientId, marker.transform.position, marker.transform.rotation);
                instance.Spawn(destroyWithScene: true);
            }
        }

        // the server's own load goes through _localLoadCompletion instead
        [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
        private void ReportMapLoadServerRpc(MapLoadResult result, RpcParams rpcParams = default)
        {
            ulong clientId = rpcParams.Receive.SenderClientId;
            if (clientId == NetworkManager.ServerClientId || !_readyTracker.TryReport(clientId, result)) return;
            if (result == MapLoadResult.Ready) return;

            Disconnect(clientId, GetReasonFormat(result));
        }

        private string GetReasonFormat(MapLoadResult result) => result switch
        {
            MapLoadResult.Missing => _missingMapReasonFormat,
            MapLoadResult.Different => _differentMapReasonFormat,
            _ => _brokenMapReasonFormat
        };

        // Server only
        private void Disconnect(ulong clientId, string reasonFormat)
        {
            string reason = string.Format(reasonFormat, _listing.Value.DisplayName);
            EUtils.Logger.LogWarning($"[BundleMapLoader] Disconnecting client {clientId}: {reason}");
            NetworkManager.DisconnectClient(clientId, reason);
        }

        private void HandleClientDisconnected(ulong clientId) => _readyTracker.Forget(clientId);

        private static void RemovePrefabHandler(NetworkObject prefab, InjectingPrefabHandler handler)
        {
            var networkManager = NetworkManager.Singleton;
            if (handler == null || networkManager == null) return;

            networkManager.PrefabHandler.RemoveHandler(prefab);
        }

        public override void OnNetworkDespawn()
        {
            _listing.OnValueChanged -= HandleListingChanged;
            if (NetworkManager != null) NetworkManager.OnClientDisconnectCallback -= HandleClientDisconnected;
        }

        public override void OnDestroy()
        {
            RemovePrefabHandler(_stationPrefab, _stationHandler);
            RemovePrefabHandler(_dropPickupPrefab, _dropPickupHandler);
            // a round still waiting on this map gets its answer
            _localLoadCompletion.TrySetResult(false);
            if (_bundle != null) _bundle.Unload(true);
            _gameSystemsRegistry?.Unregister(this);
            base.OnDestroy();
        }
    }
}
