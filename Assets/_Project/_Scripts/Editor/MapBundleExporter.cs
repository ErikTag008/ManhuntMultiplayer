using Project.Assets._Project._Scripts.SceneFlow.Maps;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Editor
{
    // Exports the selected map prefab (with a MapRoot) as a bundle map into the local map library, for the active build target
    public static class MapBundleExporter
    {
        private const string ExportPath = "Tools/Maps/Export Selected Map Bundle";
        private const string OpenLibraryPath = "Tools/Maps/Open Map Library Folder";
        private const string TempOutputFolder = "Temp/MapBundles";
        // the build also writes a manifest bundle named after its folder, which must not clash with the map's bundle
        private const string OutputFolderSuffix = "-build";
        private const string SdkVersionProperty = "_sdkVersion";
        private const string DialogTitle = "Export Map Bundle";
        private const string DialogOk = "OK";
        private const BuildAssetBundleOptions BundleOptions = BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.StrictMode;

        [MenuItem(ExportPath)]
        private static void ExportSelected()
        {
            if (!TryGetSettings(out var settings)) return;

            var map = GetSelectedMapPrefab();
            if (map == null)
            {
                EditorUtility.DisplayDialog(DialogTitle, $"Select a map prefab asset with a {nameof(MapRoot)} on its root.", DialogOk);
                return;
            }

            StampSdkVersion(map.GetComponent<MapRoot>());
            var errors = new List<string>();
            bool hasPreview = MapPreviewCapture.TryFindBundlePreview(map, settings, out string previewSourcePath);
            if (hasPreview && new FileInfo(previewSourcePath).Length > settings.MaxPreviewSizeInBytes)
            {
                errors.Add($"Its preview {Path.GetFileName(previewSourcePath)} is larger than {settings.MaxPreviewSizeInKilobytes} KB.");
                ShowErrors(map.name, errors);
                return;
            }

            if (!MapValidator.Validate(map, settings, MapValidator.NoBundleSize, errors))
            {
                ShowErrors(map.name, errors);
                return;
            }

            var mapRoot = map.GetComponent<MapRoot>();
            if (!TryBuildBundle(map, mapRoot.Id, out string builtBundlePath)) return;

            long bundleSizeInBytes = new FileInfo(builtBundlePath).Length;
            if (!MapValidator.Validate(map, settings, bundleSizeInBytes, errors))
            {
                ShowErrors(map.name, errors);
                return;
            }

            string libraryFolder = settings.FolderPath;
            Directory.CreateDirectory(libraryFolder);
            string bundleFileName = settings.GetBundleFileName(mapRoot.Id);
            File.Copy(builtBundlePath, Path.Combine(libraryFolder, bundleFileName), true);
            string previewFileName = CopyPreview(mapRoot.Id, hasPreview ? previewSourcePath : null, settings);

            var info = new MapBundleInfo
            {
                Id = mapRoot.Id,
                DisplayName = mapRoot.DisplayName,
                SdkVersion = mapRoot.SdkVersion,
                BundleFileName = bundleFileName,
                PreviewFileName = previewFileName
            };
            string infoPath = Path.Combine(libraryFolder, settings.GetInfoFileName(mapRoot.Id));
            File.WriteAllText(infoPath, JsonUtility.ToJson(info, true));
            Debug.Log($"[{nameof(MapBundleExporter)}] Exported {mapRoot.DisplayName} ({bundleSizeInBytes} bytes) to {libraryFolder}", map);
            if (!hasPreview)
            {
                Debug.LogWarning($"[{nameof(MapBundleExporter)}] {map.name} has no {map.name}{MapPreviewCapture.PreviewNameSuffix} image next to it, " +
                    $"so the map vote shows it without a preview. Use {MapPreviewCapture.CapturePath} or save a PNG/JPG under that name.", map);
            }
        }

        [MenuItem(ExportPath, true)]
        private static bool CanExportSelected() => GetSelectedMapPrefab() != null;

        [MenuItem(OpenLibraryPath)]
        private static void OpenLibraryFolder()
        {
            if (!TryGetSettings(out var settings)) return;

            Directory.CreateDirectory(settings.FolderPath);
            EditorUtility.RevealInFinder(settings.FolderPath);
        }

        private static GameObject GetSelectedMapPrefab()
        {
            var selected = Selection.activeGameObject;
            if (selected == null || !PrefabUtility.IsPartOfPrefabAsset(selected)) return null;

            var root = selected.transform.root.gameObject;
            return root.TryGetComponent(out MapRoot _) ? root : null;
        }

        // editor code may search the AssetDatabase; the game gets the settings through Reflex
        private static bool TryGetSettings(out MapLibrarySettings settings)
        {
            settings = null;
            string[] guids = AssetDatabase.FindAssets($"t:{nameof(MapLibrarySettings)}");
            if (guids.Length > 0) settings = AssetDatabase.LoadAssetAtPath<MapLibrarySettings>(AssetDatabase.GUIDToAssetPath(guids[0]));
            if (settings != null) return true;

            EditorUtility.DisplayDialog(DialogTitle, $"There is no {nameof(MapLibrarySettings)} asset in the project.", DialogOk);
            return false;
        }

        // the bundle carries the SDK version it was exported with
        private static void StampSdkVersion(MapRoot mapRoot)
        {
            if (mapRoot.SdkVersion == MapSdk.Version) return;

            var serializedRoot = new SerializedObject(mapRoot);
            serializedRoot.FindProperty(SdkVersionProperty).intValue = MapSdk.Version;
            serializedRoot.ApplyModifiedPropertiesWithoutUndo();
            AssetDatabase.SaveAssetIfDirty(mapRoot.gameObject);
        }

        private static bool TryBuildBundle(GameObject map, string mapId, out string builtBundlePath)
        {
            // AssetBundle names are always lowercase
            string bundleName = mapId.ToLowerInvariant();
            string outputFolder = Path.Combine(TempOutputFolder, mapId + OutputFolderSuffix);
            Directory.CreateDirectory(outputFolder);
            builtBundlePath = Path.Combine(outputFolder, bundleName);

            var builds = new[]
            {
                new AssetBundleBuild
                {
                    assetBundleName = bundleName,
                    assetNames = new[] { AssetDatabase.GetAssetPath(map) }
                }
            };
            var manifest = BuildPipeline.BuildAssetBundles(outputFolder, builds, BundleOptions, EditorUserBuildSettings.activeBuildTarget);
            if (manifest != null && File.Exists(builtBundlePath)) return true;

            EditorUtility.DisplayDialog(DialogTitle, $"Building the bundle for {map.name} failed; see the Console.", DialogOk);
            return false;
        }

        // copies the preview next to the bundle, replacing an older one in any format; returns its file name, or null without one
        private static string CopyPreview(string mapId, string previewSourcePath, MapLibrarySettings settings)
        {
            string libraryFolder = settings.FolderPath;
            foreach (var extension in settings.PreviewExtensions)
            {
                string oldPreviewPath = Path.Combine(libraryFolder, settings.GetPreviewFileName(mapId, extension));
                if (File.Exists(oldPreviewPath)) File.Delete(oldPreviewPath);
            }

            if (previewSourcePath == null) return null;

            string previewFileName = settings.GetPreviewFileName(mapId, Path.GetExtension(previewSourcePath));
            File.Copy(previewSourcePath, Path.Combine(libraryFolder, previewFileName), true);
            return previewFileName;
        }

        private static void ShowErrors(string mapName, List<string> errors)
        {
            string message = $"{mapName} can't be exported:\n\n- {string.Join("\n- ", errors)}";
            Debug.LogError($"[{nameof(MapBundleExporter)}] {message}");
            EditorUtility.DisplayDialog(DialogTitle, message, DialogOk);
        }
    }
}
