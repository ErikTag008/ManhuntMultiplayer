using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Places one marker per marker point over a stretched area: x and y are the viewport position (0..1), z the distance
    // in meters, which shrinks far markers (not their labels). Markers are pooled copies of an inactive template; extras
    // are hidden. A template with a TMP text child can also show a label per marker, either set by the caller or the distance.
    public class RevealMarkerLayer : MonoBehaviour
    {
        private const int NoDistanceShown = -1;

        [SerializeField] private RectTransform _area;
        [SerializeField] private RectTransform _markerTemplate;
        // markers at or closer than the near distance show at the near scale, at or past the far distance at the far scale
        [SerializeField] private float _nearDistanceInMeters = 5f;
        [SerializeField] private float _farDistanceInMeters = 60f;
        [SerializeField] private float _nearScale = 1f;
        [SerializeField] private float _farScale = 0.5f;
        // empty leaves the label to the caller's SetLabel; otherwise the label shows the rounded distance in this format
        [SerializeField] private string _distanceLabelFormat = "";

        private readonly List<RectTransform> _markers = new();
        // null for markers whose template has no text
        private readonly List<TMP_Text> _labels = new();
        // formatting allocates, so a label is only rewritten when its rounded distance changes
        private readonly List<int> _shownDistances = new();

        public void ShowMarkers(IReadOnlyList<Vector3> markerPoints)
        {
            for (int i = 0; i < markerPoints.Count; i++)
            {
                if (i == _markers.Count) AddMarker();

                var marker = _markers[i];
                Vector2 viewportPosition = markerPoints[i];
                // anchoring both corners to the point pins the marker there whatever the area's size
                marker.anchorMin = viewportPosition;
                marker.anchorMax = viewportPosition;
                marker.anchoredPosition = Vector2.zero;
                ScaleMarker(i, GetScale(markerPoints[i].z));
                ShowDistance(i, markerPoints[i].z);
                if (!marker.gameObject.activeSelf) marker.gameObject.SetActive(true);
            }

            for (int i = markerPoints.Count; i < _markers.Count; i++)
            {
                if (_markers[i].gameObject.activeSelf) _markers[i].gameObject.SetActive(false);
            }
        }

        // call after ShowMarkers, with an index it placed
        public void SetLabel(int index, string text)
        {
            if (index < 0 || index >= _labels.Count || _labels[index] == null) return;

            _labels[index].text = text;
        }

        private float GetScale(float distanceInMeters)
        {
            float t = Mathf.InverseLerp(_nearDistanceInMeters, _farDistanceInMeters, distanceInMeters);
            return Mathf.Lerp(_nearScale, _farScale, t);
        }

        // only the icon shrinks: the label undoes its marker's scale so far text stays readable
        private void ScaleMarker(int index, float scale)
        {
            _markers[index].localScale = Vector3.one * scale;
            if (_labels[index] != null && scale > 0f) _labels[index].transform.localScale = Vector3.one / scale;
        }

        private void ShowDistance(int index, float distanceInMeters)
        {
            if (string.IsNullOrEmpty(_distanceLabelFormat) || _labels[index] == null) return;

            int roundedDistance = Mathf.RoundToInt(distanceInMeters);
            if (_shownDistances[index] == roundedDistance) return;

            _shownDistances[index] = roundedDistance;
            _labels[index].text = string.Format(_distanceLabelFormat, roundedDistance);
        }

        private void AddMarker()
        {
            var marker = Instantiate(_markerTemplate, _area);
            _markers.Add(marker);
            _labels.Add(marker.GetComponentInChildren<TMP_Text>(true));
            _shownDistances.Add(NoDistanceShown);
        }
    }
}
