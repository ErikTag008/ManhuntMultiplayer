using Project.Assets._Project._Scripts.SceneFlow;
using UnityEditor;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Editor
{
    // "Fit To Level" on the MapBounds component's context menu, with undo
    public static class MapBoundsMenu
    {
        private const string FitToLevelPath = "CONTEXT/MapBounds/Fit To Level";

        [MenuItem(FitToLevelPath)]
        private static void FitToLevel(MenuCommand command)
        {
            var mapBounds = (MapBounds)command.context;
            Undo.RecordObject(mapBounds, "Fit Map Bounds To Level");
            if (!mapBounds.TryFitToLevel())
            {
                Debug.LogWarning($"[{nameof(MapBoundsMenu)}] {mapBounds.name} has no level root, or nothing under it to measure.", mapBounds);
                return;
            }

            EditorUtility.SetDirty(mapBounds);
        }
    }
}
