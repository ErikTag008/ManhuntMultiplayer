using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.SceneFlow.Maps;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Editor
{
    // Renders the Scene View's current view into a 16:9 JPG preview for the selected map: a MapDefinition gets it assigned,
    // a bundle map prefab gets it as <PrefabName>Preview.jpg next to the prefab, which the bundle exporter ships with the map.
    // Any PNG or JPG saved under that name, e.g. a screenshot, works the same way. Prefab Mode has no Sun, so for a lit preview
    // place the map in a lit scene, frame it there and run this with the prefab asset selected.
    public static class MapPreviewCapture
    {
        public const string CapturePath = "Tools/Maps/Capture Map Preview From Scene View";
        public const string PreviewNameSuffix = "Preview";

        private const string PreviewExtension = ".jpg";
        private const string PreviewProperty = "<Preview>k__BackingField";
        private const int PreviewWidth = 1280;
        private const int PreviewHeight = 720;
        private const int DepthBufferBits = 24;
        private const int AntiAliasingSamples = 4;
        // keeps a 1280x720 preview well under the Workshop's 1 MB preview limit
        private const int JpgQuality = 90;
        private const int PreviewMaxTextureSize = 2048;
        private const string DialogTitle = "Capture Map Preview";
        private const string DialogOk = "OK";

        [MenuItem(CapturePath)]
        private static void Capture()
        {
            var sceneView = SceneView.lastActiveSceneView;
            if (sceneView == null || sceneView.camera == null)
            {
                EditorUtility.DisplayDialog(DialogTitle, "Open a Scene View and frame the map first.", DialogOk);
                return;
            }

            if (!TryGetPreviewPath(out string previewPath, out var mapDefinition))
            {
                EditorUtility.DisplayDialog(DialogTitle, $"Select a {nameof(MapDefinition)} asset or a map prefab with a {nameof(MapRoot)} on its root.", DialogOk);
                return;
            }

            File.WriteAllBytes(previewPath, RenderPreview(sceneView.camera));
            AssetDatabase.ImportAsset(previewPath, ImportAssetOptions.ForceUpdate);
            ConfigureImporter(previewPath);
            if (mapDefinition != null) AssignPreview(mapDefinition, previewPath);
            Debug.Log($"[{nameof(MapPreviewCapture)}] Saved {previewPath}", AssetDatabase.LoadAssetAtPath<Texture2D>(previewPath));
        }

        // a bundle map prefab's preview, if it has one, in any supported image format
        public static bool TryFindBundlePreview(GameObject mapPrefab, MapLibrarySettings settings, out string previewPath)
        {
            string basePath = GetPreviewBasePath(AssetDatabase.GetAssetPath(mapPrefab));
            foreach (var extension in settings.PreviewExtensions)
            {
                previewPath = basePath + extension;
                if (File.Exists(previewPath)) return true;
            }

            previewPath = null;
            return false;
        }

        private static string GetPreviewBasePath(string assetPath) =>
            Path.Combine(Path.GetDirectoryName(assetPath), Path.GetFileNameWithoutExtension(assetPath) + PreviewNameSuffix).Replace('\\', '/');

        private static bool TryGetPreviewPath(out string previewPath, out MapDefinition mapDefinition)
        {
            previewPath = null;
            mapDefinition = Selection.activeObject as MapDefinition;
            string assetPath = mapDefinition != null ? AssetDatabase.GetAssetPath(mapDefinition) : GetSelectedMapPrefabPath();
            if (string.IsNullOrEmpty(assetPath)) return false;

            previewPath = GetPreviewBasePath(assetPath) + PreviewExtension;
            return true;
        }

        // the prefab open in Prefab Mode, or the selected prefab asset
        private static string GetSelectedMapPrefabPath()
        {
            var stage = PrefabStageUtility.GetCurrentPrefabStage();
            if (stage != null && stage.prefabContentsRoot.TryGetComponent(out MapRoot _)) return stage.assetPath;

            var selected = Selection.activeGameObject;
            if (selected == null || !PrefabUtility.IsPartOfPrefabAsset(selected)) return null;

            var root = selected.transform.root.gameObject;
            return root.TryGetComponent(out MapRoot _) ? AssetDatabase.GetAssetPath(root) : null;
        }

        // a temporary game camera at the Scene View's pose, so the preview gets the game's renderer features and post-processing
        private static byte[] RenderPreview(Camera sceneCamera)
        {
            var cameraObject = new GameObject(nameof(MapPreviewCapture)) { hideFlags = HideFlags.HideAndDontSave };
            var renderTexture = new RenderTexture(PreviewWidth, PreviewHeight, DepthBufferBits, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB)
            {
                antiAliasing = AntiAliasingSamples
            };
            var image = new Texture2D(PreviewWidth, PreviewHeight, TextureFormat.RGB24, false);
            var previousActive = RenderTexture.active;
            try
            {
                var camera = cameraObject.AddComponent<Camera>();
                camera.CopyFrom(sceneCamera);
                camera.cameraType = CameraType.Game;
                camera.aspect = (float)PreviewWidth / PreviewHeight;
                camera.targetTexture = renderTexture;
                // Prefab Mode objects live in their own preview scene
                var stage = PrefabStageUtility.GetCurrentPrefabStage();
                if (stage != null) camera.scene = stage.scene;
                camera.Render();

                RenderTexture.active = renderTexture;
                image.ReadPixels(new Rect(0f, 0f, PreviewWidth, PreviewHeight), 0, 0);
                image.Apply();
                return image.EncodeToJPG(JpgQuality);
            }
            finally
            {
                RenderTexture.active = previousActive;
                // the camera goes first so its target texture isn't released while still set
                Object.DestroyImmediate(cameraObject);
                Object.DestroyImmediate(image);
                Object.DestroyImmediate(renderTexture);
            }
        }

        private static void ConfigureImporter(string previewPath)
        {
            if (AssetImporter.GetAtPath(previewPath) is not TextureImporter importer) return;

            importer.textureType = TextureImporterType.Default;
            importer.mipmapEnabled = false;
            // keeps 16:9; the default scales to a power of two
            importer.npotScale = TextureImporterNPOTScale.None;
            importer.wrapMode = TextureWrapMode.Clamp;
            importer.maxTextureSize = PreviewMaxTextureSize;
            importer.SaveAndReimport();
        }

        private static void AssignPreview(MapDefinition mapDefinition, string previewPath)
        {
            var serializedMap = new SerializedObject(mapDefinition);
            serializedMap.FindProperty(PreviewProperty).objectReferenceValue = AssetDatabase.LoadAssetAtPath<Texture2D>(previewPath);
            serializedMap.ApplyModifiedProperties();
            AssetDatabase.SaveAssetIfDirty(mapDefinition);
        }
    }
}
