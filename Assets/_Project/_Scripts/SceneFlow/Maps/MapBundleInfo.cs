using System;

namespace Project.Assets._Project._Scripts.SceneFlow.Maps
{
    // The JSON sidecar written next to a bundle map, so the library can list maps without loading their bundles
    [Serializable]
    public class MapBundleInfo
    {
        public string Id;
        public string DisplayName;
        public int SdkVersion;
        // a file name in the same folder as the sidecar, never a path
        public string BundleFileName;
    }
}
