using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Explicit up/down/left/right links for rows of selectables, top to bottom and each row left to right.
    // Automatic navigation skips controls that sit off-axis (a row's arrows on the right, tabs and buttons on the left).
    // A row end links to nothing, so a slider there uses left/right for its value.
    public static class NavigationGrid
    {
        public static void Link(IReadOnlyList<List<Selectable>> rows)
        {
            for (int r = 0; r < rows.Count; r++)
            {
                var row = rows[r];
                for (int i = 0; i < row.Count; i++)
                {
                    row[i].navigation = new Navigation
                    {
                        mode = Navigation.Mode.Explicit,
                        selectOnLeft = i > 0 ? row[i - 1] : null,
                        selectOnRight = i < row.Count - 1 ? row[i + 1] : null,
                        selectOnUp = r > 0 ? FindNearest(rows[r - 1], row[i]) : null,
                        selectOnDown = r < rows.Count - 1 ? FindNearest(rows[r + 1], row[i]) : null
                    };
                }
            }
        }

        // Each active child of the container is one row; rows without a usable selectable are skipped.
        // Checks interactable, not IsInteractable, so a menu can be wired while its panel is still hidden.
        public static void AddRows(Transform container, List<List<Selectable>> rows)
        {
            foreach (Transform child in container)
            {
                if (!child.gameObject.activeInHierarchy) continue;

                var row = new List<Selectable>();
                foreach (var selectable in child.GetComponentsInChildren<Selectable>())
                {
                    if (selectable.interactable) row.Add(selectable);
                }

                if (row.Count == 0) continue;

                row.Sort((a, b) => a.transform.position.x.CompareTo(b.transform.position.x));
                rows.Add(row);
            }
        }

        public static void SetUp(List<Selectable> row, Selectable target)
        {
            foreach (var selectable in row)
            {
                var navigation = selectable.navigation;
                navigation.selectOnUp = target;
                selectable.navigation = navigation;
            }
        }

        private static Selectable FindNearest(List<Selectable> row, Selectable from)
        {
            Selectable nearest = null;
            float nearestDistance = float.MaxValue;
            float x = from.transform.position.x;
            foreach (var selectable in row)
            {
                float distance = Mathf.Abs(selectable.transform.position.x - x);
                if (distance >= nearestDistance) continue;

                nearest = selectable;
                nearestDistance = distance;
            }

            return nearest;
        }
    }
}
