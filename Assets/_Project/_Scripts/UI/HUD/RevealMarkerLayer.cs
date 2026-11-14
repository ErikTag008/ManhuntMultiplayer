using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Places one marker per viewport position (0..1) over a stretched area. Markers are pooled copies of an
    // inactive template; extras are hidden.
    public class RevealMarkerLayer : MonoBehaviour
    {
        [SerializeField] private RectTransform _area;
        [SerializeField] private RectTransform _markerTemplate;

        private readonly List<RectTransform> _markers = new();

        public void ShowMarkers(IReadOnlyList<Vector2> viewportPositions)
        {
            for (int i = 0; i < viewportPositions.Count; i++)
            {
                if (i == _markers.Count) _markers.Add(Instantiate(_markerTemplate, _area));

                var marker = _markers[i];
                // anchoring both corners to the point pins the marker there whatever the area's size
                marker.anchorMin = viewportPositions[i];
                marker.anchorMax = viewportPositions[i];
                marker.anchoredPosition = Vector2.zero;
                if (!marker.gameObject.activeSelf) marker.gameObject.SetActive(true);
            }

            for (int i = viewportPositions.Count; i < _markers.Count; i++)
            {
                if (_markers[i].gameObject.activeSelf) _markers[i].gameObject.SetActive(false);
            }
        }
    }
}
