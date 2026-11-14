using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Physics queries for wall-jumps and ledge climbs. Positions are the player's feet; probes start inside the
    // player's own body, which raycasts ignore.
    public static class ParkourProbe
    {
        private const float FullCircleInDegrees = 360f;

        // The closest near-vertical surface around the body, with its normal flattened to point away from it
        public static bool TryFindWall(Vector3 feetPosition, float bodyRadius, ParkourSettings settings, LayerMask wallLayers, out Vector3 wallNormal)
        {
            wallNormal = Vector3.zero;
            Vector3 origin = feetPosition + Vector3.up * settings.WallCheckHeight;
            float length = bodyRadius + settings.WallCheckDistance;
            float stepInDegrees = FullCircleInDegrees / settings.WallCheckRayCount;
            float closestDistance = Mathf.Infinity;

            for (int i = 0; i < settings.WallCheckRayCount; i++)
            {
                Vector3 direction = Quaternion.Euler(0f, stepInDegrees * i, 0f) * Vector3.forward;
                if (!Physics.Raycast(origin, direction, out RaycastHit hit, length, wallLayers, QueryTriggerInteraction.Ignore)) continue;
                if (Mathf.Abs(hit.normal.y) > settings.WallMaxNormalY || hit.distance >= closestDistance) continue;

                Vector3 flatNormal = new(hit.normal.x, 0f, hit.normal.z);
                if (flatNormal.sqrMagnitude <= 0f) continue;

                closestDistance = hit.distance;
                wallNormal = flatNormal.normalized;
            }

            return closestDistance < Mathf.Infinity;
        }

        // A walkable ledge top in reach in front of the body, with room to stand on it; landingPosition is where the feet end up
        public static bool TryFindLedge(Vector3 feetPosition, Vector3 forward, float bodyRadius, float standingHeight, float maxGroundAngle,
            ParkourSettings settings, LayerMask obstacleLayers, out Vector3 landingPosition)
        {
            landingPosition = Vector3.zero;
            forward.y = 0f;
            if (forward.sqrMagnitude <= 0f) return false;
            forward.Normalize();

            float reach = bodyRadius + settings.MantleReach;
            Vector3 topProbeOrigin = feetPosition + Vector3.up * settings.MantleMaxHeight + forward * reach;
            float topProbeLength = settings.MantleMaxHeight - settings.MantleMinHeight;
            if (!Physics.Raycast(topProbeOrigin, Vector3.down, out RaycastHit topHit, topProbeLength, obstacleLayers, QueryTriggerInteraction.Ignore)) return false;
            if (Vector3.Angle(topHit.normal, Vector3.up) > maxGroundAngle) return false;

            float ledgeHeight = topHit.point.y - feetPosition.y;

            // the top must belong to an edge right in front, not to something further away
            Vector3 edgeProbeOrigin = feetPosition + Vector3.up * (ledgeHeight - settings.MantleEdgeProbeDepth);
            if (!Physics.Raycast(edgeProbeOrigin, forward, out RaycastHit edgeHit, reach, obstacleLayers, QueryTriggerInteraction.Ignore)) return false;

            // the body has to pass over the edge
            Vector3 overEdgeOrigin = feetPosition + Vector3.up * (ledgeHeight + settings.SurfaceClearance + bodyRadius);
            if (Physics.Raycast(overEdgeOrigin, forward, edgeHit.distance + settings.MantleLandingDepth, obstacleLayers, QueryTriggerInteraction.Ignore)) return false;

            Vector3 landing = feetPosition + forward * (edgeHit.distance + settings.MantleLandingDepth);
            landing.y = topHit.point.y + settings.SurfaceClearance;

            Vector3 bottom = landing + Vector3.up * (bodyRadius + settings.SurfaceClearance);
            Vector3 top = landing + Vector3.up * (standingHeight - bodyRadius);
            if (Physics.CheckCapsule(bottom, top, bodyRadius, obstacleLayers, QueryTriggerInteraction.Ignore)) return false;

            landingPosition = landing;
            return true;
        }
    }
}
