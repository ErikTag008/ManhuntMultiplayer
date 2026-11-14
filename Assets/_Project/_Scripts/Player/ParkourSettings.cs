using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Crouch, slide, wall-jump and ledge climb tuning; one copy per team stats asset so catchers can be balanced apart
    [Serializable]
    public class ParkourSettings
    {
        [field: Header("Crouch")]
        [field: SerializeField, Min(0.1f)] public float CrouchHeight { get; private set; } = 1.2f;
        // below PlayerFootsteps' silent share, so crouching is a quiet way to sneak
        [field: SerializeField, Range(0f, 1f)] public float CrouchSpeedMultiplier { get; private set; } = 0.35f;
        // how fast the camera eases between standing and crouched eye height
        [field: SerializeField] public float CrouchCameraSmoothing { get; private set; } = 15f;

        [field: Header("Slide")]
        // a crouch press above this planar speed slides instead of crouching
        [field: SerializeField] public float SlideMinStartSpeed { get; private set; } = 12f;
        [field: SerializeField] public float SlideBoostSpeed { get; private set; } = 8f;
        [field: SerializeField] public float SlideMaxSpeed { get; private set; } = 38f;
        [field: SerializeField] public float SlideEndSpeed { get; private set; } = 8f;
        [field: SerializeField] public float SlideMaxDurationInSeconds { get; private set; } = 1.2f;
        [field: SerializeField] public float SlideCooldownInSeconds { get; private set; } = 0.6f;
        // replaces HorizontalDamping while sliding, so the slide coasts instead of stopping at once
        [field: SerializeField] public float SlideDamping { get; private set; } = 0.8f;

        [field: Header("Wall Jump")]
        // gap between the body and the wall that still counts as touching it
        [field: SerializeField] public float WallCheckDistance { get; private set; } = 0.35f;
        [field: SerializeField] public float WallCheckHeight { get; private set; } = 1f;
        [field: SerializeField, Min(1)] public int WallCheckRayCount { get; private set; } = 8;
        // walls lean at most this far from vertical (0 = only perfectly vertical walls)
        [field: SerializeField, Range(0f, 1f)] public float WallMaxNormalY { get; private set; } = 0.3f;
        [field: SerializeField] public float WallJumpAwaySpeed { get; private set; } = 14f;
        [field: SerializeField] public float WallJumpUpSpeed { get; private set; } = 14f;
        [field: SerializeField] public float WallJumpCooldownInSeconds { get; private set; } = 0.25f;
        // no air steering right after the kick, so holding toward the wall doesn't cancel it
        [field: SerializeField] public float WallJumpControlLockInSeconds { get; private set; } = 0.25f;
        // walls whose normals are at least this alike count as the same wall (no climbing one wall with repeated jumps)
        [field: SerializeField, Range(-1f, 1f)] public float SameWallNormalDot { get; private set; } = 0.8f;

        [field: Header("Ledge Climb")]
        // ledge top height above the feet that can be climbed
        [field: SerializeField] public float MantleMinHeight { get; private set; } = 0.8f;
        [field: SerializeField] public float MantleMaxHeight { get; private set; } = 2.2f;
        // how far in front of the body the ledge may start
        [field: SerializeField] public float MantleReach { get; private set; } = 0.6f;
        // how far onto the ledge the player ends up
        [field: SerializeField] public float MantleLandingDepth { get; private set; } = 0.6f;
        // forward input needed (0..1) so a player falling past a ledge isn't pulled onto it
        [field: SerializeField, Range(0f, 1f)] public float MantleMinForwardInput { get; private set; } = 0.5f;
        [field: SerializeField] public float MantleRiseDurationInSeconds { get; private set; } = 0.25f;
        [field: SerializeField] public float MantleForwardDurationInSeconds { get; private set; } = 0.15f;
        [field: SerializeField] public float MantleExitSpeed { get; private set; } = 6f;
        // probes this far below the ledge top to confirm the edge is right in front of the body
        [field: SerializeField] public float MantleEdgeProbeDepth { get; private set; } = 0.15f;

        // small gap kept from surfaces: the climb lifts this far above the ledge, and headroom checks start this far above the ground
        [field: Header("Shared")]
        [field: SerializeField] public float SurfaceClearance { get; private set; } = 0.05f;
    }
}
