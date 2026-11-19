using UnityEngine;

namespace Project.Assets._Project._Scripts.SceneFlow.Maps
{
    // Where a catcher starts the round and where infected runners come back; meant to sit behind the catcher room's door
    public class CatcherSpawnMarker : MapMarker
    {
        protected override Color DefaultGizmoColor => Color.red;
    }
}
