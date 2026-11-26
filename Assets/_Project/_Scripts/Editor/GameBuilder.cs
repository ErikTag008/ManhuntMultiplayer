using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Project.Assets._Project._Scripts.Editor
{
    // Builds Windows and Linux players from the enabled build scenes into Builds/<product>-<version>-<kind>-<commit>/,
    // zips each platform and writes a report. Command line:
    // Unity -batchmode -quit -projectPath <path> -executeMethod Project.Assets._Project._Scripts.Editor.GameBuilder.BuildReleaseFromCommandLine
    public static class GameBuilder
    {
        private const string ReleasePath = "Tools/Build/Release Build (Windows + Linux)";
        private const string DevelopmentPath = "Tools/Build/Development Build (Windows + Linux)";
        private const string OpenFolderPath = "Tools/Build/Open Builds Folder";
        private const string DialogTitle = "Game Build";
        private const string DialogOk = "OK";
        private const string GitExecutable = "git";
        private const string GitShortHashArguments = "rev-parse --short HEAD";
        private const string GitStatusArguments = "status --porcelain";
        private const string NoCommitLabel = "nocommit";
        private const string WindowsExecutableExtension = ".exe";
        private const int SuccessExitCode = 0;
        private const int FailureExitCode = 1;
        private const int UnixModeShift = 16;
        private const long BytesPerMegabyte = 1024 * 1024;

        [MenuItem(ReleasePath)]
        private static void BuildReleaseFromMenu() => BuildFromMenu(false);

        [MenuItem(DevelopmentPath)]
        private static void BuildDevelopmentFromMenu() => BuildFromMenu(true);

        [MenuItem(OpenFolderPath)]
        private static void OpenBuildsFolder()
        {
            if (!TryLoadSettings(out var settings)) return;

            Directory.CreateDirectory(settings.OutputRootFolder);
            EditorUtility.RevealInFinder(settings.OutputRootFolder);
        }

        public static void BuildReleaseFromCommandLine() => BuildFromCommandLine(false);

        public static void BuildDevelopmentFromCommandLine() => BuildFromCommandLine(true);

        // outputFolder stays null when nothing was built
        public static bool TryBuildAll(bool isDevelopment, out string outputFolder, out string summary)
        {
            outputFolder = null;
            summary = null;
            if (BuildPipeline.isBuildingPlayer)
            {
                summary = "A player build is already running.";
                return false;
            }
            if (!GameBuildSettings.TryLoad(out var settings))
            {
                summary = $"There is no {nameof(GameBuildSettings)} asset in the project.";
                return false;
            }

            string[] scenes = EditorBuildSettings.scenes.Where(scene => scene.enabled).Select(scene => scene.path).ToArray();
            if (scenes.Length == 0)
            {
                summary = "No scenes are enabled in the build settings.";
                return false;
            }

            string commitLabel = GetCommitLabel(settings);
            outputFolder = Path.Combine(settings.OutputRootFolder, GetBuildName(settings, isDevelopment, commitLabel));
            if (Directory.Exists(outputFolder) && Directory.EnumerateFileSystemEntries(outputFolder).Any())
            {
                summary = $"{outputFolder} already exists and isn't empty; delete or rename it first.";
                return false;
            }

            Directory.CreateDirectory(outputFolder);
            var targets = GetTargets(settings);
            var lines = new List<string>
            {
                $"{PlayerSettings.productName} {Application.version} ({(isDevelopment ? settings.DevelopmentLabel : settings.ReleaseLabel)})",
                $"Built {DateTime.Now:yyyy-MM-dd HH:mm} from {commitLabel}",
            };

            var originalTarget = EditorUserBuildSettings.activeBuildTarget;
            var originalBackend = PlayerSettings.GetScriptingBackend(NamedBuildTarget.Standalone);
            bool hasSucceeded = true;
            try
            {
                foreach (var target in targets)
                {
                    try
                    {
                        hasSucceeded &= BuildPlatform(target, scenes, outputFolder, isDevelopment, settings, lines);
                    }
                    catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException)
                    {
                        // a failed zip or file write is reported like a failed build instead of skipping the report
                        lines.Add($"{target.FolderName}: FAILED after the build: {exception.Message}");
                        hasSucceeded = false;
                    }
                }
            }
            finally
            {
                PlayerSettings.SetScriptingBackend(NamedBuildTarget.Standalone, originalBackend);
                // the Linux build writes its temporary backend to ProjectSettings.asset, so the restore must be saved too
                AssetDatabase.SaveAssets();
                if (EditorUserBuildSettings.activeBuildTarget != originalTarget)
                {
                    EditorUserBuildSettings.SwitchActiveBuildTarget(BuildPipeline.GetBuildTargetGroup(originalTarget), originalTarget);
                }
            }

            lines.Add(hasSucceeded ? "Result: all platforms succeeded" : "Result: FAILED");
            summary = string.Join(Environment.NewLine, lines);
            File.WriteAllText(Path.Combine(outputFolder, settings.ReportFileName), summary);
            return hasSucceeded;
        }

        private static void BuildFromMenu(bool isDevelopment)
        {
            bool hasSucceeded = TryBuildAll(isDevelopment, out string outputFolder, out string summary);
            EditorUtility.DisplayDialog(DialogTitle, summary, DialogOk);
            if (hasSucceeded) EditorUtility.RevealInFinder(outputFolder);
        }

        private static void BuildFromCommandLine(bool isDevelopment)
        {
            bool hasSucceeded = TryBuildAll(isDevelopment, out _, out string summary);
            if (hasSucceeded) Debug.Log($"[{nameof(GameBuilder)}] {summary}");
            else Debug.LogError($"[{nameof(GameBuilder)}] {summary}");

            EditorApplication.Exit(hasSucceeded ? SuccessExitCode : FailureExitCode);
        }

        private static bool TryLoadSettings(out GameBuildSettings settings)
        {
            if (GameBuildSettings.TryLoad(out settings)) return true;

            EditorUtility.DisplayDialog(DialogTitle, $"There is no {nameof(GameBuildSettings)} asset in the project.", DialogOk);
            return false;
        }

        private static List<PlatformTarget> GetTargets(GameBuildSettings settings)
        {
            var targets = new List<PlatformTarget>();
            if (settings.IsWindowsBuilt)
            {
                targets.Add(new(BuildTarget.StandaloneWindows64, settings.WindowsFolderName, settings.WindowsZipName, settings.WindowsScriptingBackend,
                    WindowsExecutableExtension, false));
            }
            if (settings.IsLinuxBuilt)
            {
                targets.Add(new(BuildTarget.StandaloneLinux64, settings.LinuxFolderName, settings.LinuxZipName, settings.LinuxScriptingBackend,
                    string.Empty, true));
            }
            return targets;
        }

        private static bool BuildPlatform(PlatformTarget target, string[] scenes, string outputFolder, bool isDevelopment,
            GameBuildSettings settings, List<string> lines)
        {
            string platformFolder = Path.Combine(outputFolder, target.FolderName);
            PlayerSettings.SetScriptingBackend(NamedBuildTarget.Standalone, target.Backend);

            var options = new BuildPlayerOptions
            {
                scenes = scenes,
                target = target.Target,
                targetGroup = BuildTargetGroup.Standalone,
                locationPathName = Path.Combine(platformFolder, PlayerSettings.productName + target.ExecutableExtension),
                options = isDevelopment ? BuildOptions.Development : BuildOptions.None,
            };

            BuildReport report = BuildPipeline.BuildPlayer(options);
            var buildSummary = report.summary;
            string line = $"{target.FolderName}: {buildSummary.result}, {target.Backend}, {buildSummary.totalErrors} errors, " +
                $"{buildSummary.totalWarnings} warnings, {buildSummary.totalTime:mm\\:ss}";
            if (buildSummary.result != BuildResult.Succeeded)
            {
                lines.Add(line);
                return false;
            }

            string zipPath = Path.Combine(outputFolder, target.ZipName);
            ZipPlatformFolder(platformFolder, target, zipPath, settings);
            lines.Add($"{line}, zip {new FileInfo(zipPath).Length / BytesPerMegabyte} MB");
            return true;
        }

        // the zip's top folder is the platform folder; Linux entries carry the executable mode
        private static void ZipPlatformFolder(string platformFolder, PlatformTarget target, string zipPath, GameBuildSettings settings)
        {
            using var zipStream = new FileStream(zipPath, FileMode.CreateNew);
            using var archive = new ZipArchive(zipStream, ZipArchiveMode.Create);
            string rootPath = Path.GetFullPath(platformFolder);
            foreach (string filePath in Directory.EnumerateFiles(rootPath, "*", SearchOption.AllDirectories))
            {
                string relativePath = filePath.Substring(rootPath.Length).TrimStart(Path.DirectorySeparatorChar);
                if (settings.ExcludedFolderMarkers.Any(marker => relativePath.Contains(marker))) continue;

                string entryName = $"{target.FolderName}/{relativePath.Replace(Path.DirectorySeparatorChar, '/')}";
                var entry = archive.CreateEntry(entryName, settings.ZipCompressionLevel);
                if (target.IsUnixModeSet) entry.ExternalAttributes = settings.UnixExecutableMode << UnixModeShift;

                using var entryStream = entry.Open();
                using var fileStream = File.OpenRead(filePath);
                fileStream.CopyTo(entryStream);
            }
        }

        private static string GetBuildName(GameBuildSettings settings, bool isDevelopment, string commitLabel)
        {
            string kind = isDevelopment ? settings.DevelopmentLabel : settings.ReleaseLabel;
            return $"{PlayerSettings.productName}-{Application.version}-{kind}-{commitLabel}";
        }

        // short commit hash, marked when the working tree has changes the build includes
        private static string GetCommitLabel(GameBuildSettings settings)
        {
            if (!TryRunGit(GitShortHashArguments, out string hash) || string.IsNullOrEmpty(hash)) return NoCommitLabel;

            bool isDirty = TryRunGit(GitStatusArguments, out string status) && !string.IsNullOrEmpty(status);
            return isDirty ? hash + settings.DirtyTreeSuffix : hash;
        }

        private static bool TryRunGit(string arguments, out string output)
        {
            output = null;
            try
            {
                var startInfo = new ProcessStartInfo(GitExecutable, arguments)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8,
                };
                using var process = Process.Start(startInfo);
                if (process == null) return false;

                output = process.StandardOutput.ReadToEnd().Trim();
                process.WaitForExit();
                return process.ExitCode == SuccessExitCode;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                // git isn't on the PATH
                return false;
            }
        }

        private readonly struct PlatformTarget
        {
            public readonly BuildTarget Target;
            public readonly string FolderName;
            public readonly string ZipName;
            public readonly ScriptingImplementation Backend;
            public readonly string ExecutableExtension;
            public readonly bool IsUnixModeSet;

            public PlatformTarget(BuildTarget target, string folderName, string zipName, ScriptingImplementation backend,
                string executableExtension, bool isUnixModeSet)
            {
                Target = target;
                FolderName = folderName;
                ZipName = zipName;
                Backend = backend;
                ExecutableExtension = executableExtension;
                IsUnixModeSet = isUnixModeSet;
            }
        }
    }
}
