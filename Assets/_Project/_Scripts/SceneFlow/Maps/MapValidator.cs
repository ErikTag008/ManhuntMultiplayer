using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.SceneFlow.Maps
{
    // Checks a bundle map prefab against the SDK and library rules. Every problem is reported, not just the first,
    // so a creator can fix them all in one go.
    public static class MapValidator
    {
        // the bundle size to pass while there is no bundle yet (the export tool)
        public const long NoBundleSize = -1;

        // the errors list is cleared first
        public static bool Validate(GameObject map, MapLibrarySettings settings, long bundleSizeInBytes, List<string> errors)
        {
            errors.Clear();
            if (map == null)
            {
                errors.Add($"There is no map prefab with a {nameof(MapRoot)}.");
                return false;
            }

            if (map.TryGetComponent(out MapRoot mapRoot)) ValidateRoot(mapRoot, errors);
            else errors.Add($"{map.name} has no {nameof(MapRoot)} on its root object.");

            ValidateCount<RunnerSpawnMarker>(map, settings.MinRunnerSpawns, errors);
            ValidateCount<CatcherSpawnMarker>(map, settings.MinCatcherSpawns, errors);
            ValidateCount<DropPointMarker>(map, settings.MinDropPoints, errors);
            ValidateCount<StationMarker>(map, settings.MinStations, errors);
            ValidateBounds(map, settings.MaxMapSizeInMeters, errors);
            ValidateNoNetworking(map, errors);
            ValidateNoMissingScripts(map, errors);

            if (bundleSizeInBytes != NoBundleSize && bundleSizeInBytes > settings.MaxBundleSizeInBytes)
            {
                errors.Add($"The bundle is {bundleSizeInBytes} bytes; the limit is {settings.MaxBundleSizeInMegabytes} MB.");
            }

            return errors.Count == 0;
        }

        // the id names the bundle file and is sent over the network, so it must be a valid file name that fits a FixedString64Bytes
        public static bool IsValidId(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return false;
            if (id.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0) return false;

            return Encoding.UTF8.GetByteCount(id) <= FixedString64Bytes.UTF8MaxLengthInBytes;
        }

        private static void ValidateRoot(MapRoot mapRoot, List<string> errors)
        {
            if (mapRoot.SdkVersion != MapSdk.Version)
            {
                errors.Add($"The map was made with map SDK {mapRoot.SdkVersion}; this game uses {MapSdk.Version}. Export it again.");
            }

            if (!IsValidId(mapRoot.Id))
            {
                errors.Add($"The map Id \"{mapRoot.Id}\" must be set, be a valid file name and be at most {FixedString64Bytes.UTF8MaxLengthInBytes} bytes.");
            }

            if (string.IsNullOrWhiteSpace(mapRoot.DisplayName)) errors.Add("The map has no display name.");
        }

        private static void ValidateCount<T>(GameObject map, int minCount, List<string> errors) where T : Component
        {
            int count = map.GetComponentsInChildren<T>(true).Length;
            if (count < minCount) errors.Add($"The map has {count} {typeof(T).Name}; it needs at least {minCount}.");
        }

        private static void ValidateBounds(GameObject map, float maxSizeInMeters, List<string> errors)
        {
            var mapBounds = map.GetComponentsInChildren<MapBounds>(true);
            if (mapBounds.Length != 1)
            {
                errors.Add($"The map has {mapBounds.Length} {nameof(MapBounds)}; it needs exactly 1.");
                return;
            }

            Vector3 size = mapBounds[0].Bounds.size;
            float longestSide = Mathf.Max(size.x, Mathf.Max(size.y, size.z));
            if (longestSide > maxSizeInMeters)
            {
                errors.Add($"The {nameof(MapBounds)} are {longestSide} m on their longest side; the limit is {maxSizeInMeters} m.");
            }
        }

        // the game spawns its own network objects at the markers; a map can't bring any
        private static void ValidateNoNetworking(GameObject map, List<string> errors)
        {
            foreach (var networkObject in map.GetComponentsInChildren<NetworkObject>(true))
            {
                errors.Add($"{networkObject.name} has a {nameof(NetworkObject)}; maps can't contain network objects.");
            }

            foreach (var networkBehaviour in map.GetComponentsInChildren<NetworkBehaviour>(true))
            {
                errors.Add($"{networkBehaviour.name} has a {nameof(NetworkBehaviour)} ({networkBehaviour.GetType().Name}); maps can't contain network behaviours.");
            }
        }

        // a script the game doesn't have shows up as a null component
        private static void ValidateNoMissingScripts(GameObject map, List<string> errors)
        {
            var components = new List<Component>();
            foreach (var child in map.GetComponentsInChildren<Transform>(true))
            {
                child.GetComponents(components);
                foreach (var component in components)
                {
                    if (component != null) continue;

                    errors.Add($"{child.name} has a missing script.");
                    break;
                }
            }
        }
    }
}
