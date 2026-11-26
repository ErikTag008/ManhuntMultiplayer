using UnityEditor;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Editor
{
    [CreateAssetMenu(fileName = "GameBuildSettings", menuName = "ScriptableObjects/GameBuildSettings", order = 1)]
    public class GameBuildSettings : ScriptableObject
    {
        // relative to the project folder; git-ignored
        [field: SerializeField] public string OutputRootFolder { get; private set; } = "Builds";
        [field: SerializeField] public string ReleaseLabel { get; private set; } = "Release";
        [field: SerializeField] public string DevelopmentLabel { get; private set; } = "Dev";
        [field: SerializeField] public string DirtyTreeSuffix { get; private set; } = "-dirty";
        [field: SerializeField] public string ReportFileName { get; private set; } = "BuildReport.txt";

        [field: SerializeField] public bool IsWindowsBuilt { get; private set; } = true;
        [field: SerializeField] public string WindowsFolderName { get; private set; } = "Windows";
        [field: SerializeField] public string WindowsZipName { get; private set; } = "ManhuntMultiplayerWindows.zip";
        [field: SerializeField] public ScriptingImplementation WindowsScriptingBackend { get; private set; } = ScriptingImplementation.IL2CPP;

        // only the Mono Linux player module is installed
        [field: SerializeField] public bool IsLinuxBuilt { get; private set; } = true;
        [field: SerializeField] public string LinuxFolderName { get; private set; } = "Linux";
        [field: SerializeField] public string LinuxZipName { get; private set; } = "ManhuntMultiplayerLinux.zip";
        [field: SerializeField] public ScriptingImplementation LinuxScriptingBackend { get; private set; } = ScriptingImplementation.Mono2x;

        // folders the build writes next to the player that must not ship (IL2CPP symbols, Burst debug info)
        [field: SerializeField] public string[] ExcludedFolderMarkers { get; private set; } = { "_BackUpThisFolder_", "_DoNotShip" };
        // 0100755 = regular file, rwxr-xr-x, so Linux players can start the extracted binaries
        [field: SerializeField] public int UnixExecutableMode { get; private set; } = 33261;
        [field: SerializeField] public System.IO.Compression.CompressionLevel ZipCompressionLevel { get; private set; } = System.IO.Compression.CompressionLevel.Optimal;

        // components from this assembly are removed from scenes in release builds, where the assembly isn't compiled
        [field: SerializeField] public string DevToolsAssemblyName { get; private set; } = "Project.DevTools";

        // editor code may search the AssetDatabase; nothing in the game reads these settings
        public static bool TryLoad(out GameBuildSettings settings)
        {
            settings = null;
            string[] guids = AssetDatabase.FindAssets($"t:{nameof(GameBuildSettings)}");
            if (guids.Length > 0) settings = AssetDatabase.LoadAssetAtPath<GameBuildSettings>(AssetDatabase.GUIDToAssetPath(guids[0]));
            return settings != null;
        }
    }
}
