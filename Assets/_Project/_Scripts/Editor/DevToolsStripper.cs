using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Assets._Project._Scripts.Editor
{
    // Release builds don't compile the dev tools assembly, so its components are removed from every built scene
    // instead of shipping as missing scripts. Play mode and development builds keep them.
    public class DevToolsStripper : IProcessSceneWithReport
    {
        public int callbackOrder => 0;

        public void OnProcessScene(Scene scene, BuildReport report)
        {
            if (report == null) return;
            if ((report.summary.options & BuildOptions.Development) != 0) return;

            if (!GameBuildSettings.TryLoad(out var settings))
            {
                throw new BuildFailedException($"There is no {nameof(GameBuildSettings)} asset, so the dev tools can't be stripped from {scene.name}.");
            }

            int strippedCount = 0;
            foreach (var root in scene.GetRootGameObjects())
            {
                foreach (var behaviour in root.GetComponentsInChildren<MonoBehaviour>(true))
                {
                    if (behaviour == null) continue;
                    if (behaviour.GetType().Assembly.GetName().Name != settings.DevToolsAssemblyName) continue;

                    Object.DestroyImmediate(behaviour);
                    // a [RequireComponent] on another component can keep it alive
                    if (behaviour == null) strippedCount++;
                    else Debug.LogWarning($"[{nameof(DevToolsStripper)}] Couldn't remove {behaviour.GetType().Name} from {behaviour.name} in {scene.name}.");
                }
            }

            if (strippedCount > 0) Debug.Log($"[{nameof(DevToolsStripper)}] Removed {strippedCount} dev tool components from {scene.name}.");
        }
    }
}
