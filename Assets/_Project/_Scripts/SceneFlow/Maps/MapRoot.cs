using UnityEngine;

namespace Project.Assets._Project._Scripts.SceneFlow.Maps
{
    // The root of a bundle map prefab. The Id names the bundle file and must stay the same across versions of the map.
    // The export tool stamps the SDK version, so a bundle always carries the version it was exported with.
    [DisallowMultipleComponent]
    public class MapRoot : MonoBehaviour
    {
        [SerializeField] private string _id;
        [SerializeField] private string _displayName;
        [SerializeField] private int _sdkVersion = MapSdk.Version;

        public string Id => _id;
        public string DisplayName => _displayName;
        public int SdkVersion => _sdkVersion;
    }
}
