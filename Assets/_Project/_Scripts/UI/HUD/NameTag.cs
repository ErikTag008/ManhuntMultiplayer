using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // One name tag on the local player's screen: where it sits (viewport 0..1), whose it is and how it looks
    public readonly struct NameTag : IEquatable<NameTag>
    {
        public readonly Vector2 ViewportPosition;
        public readonly string Name;
        public readonly NameTagTone Tone;
        public readonly float Alpha;
        public readonly NameTagReadiness Readiness;
        public readonly bool IsSpeaking;

        public NameTag(Vector2 viewportPosition, string name, NameTagTone tone, float alpha, NameTagReadiness readiness, bool isSpeaking)
        {
            ViewportPosition = viewportPosition;
            Name = name;
            Tone = tone;
            Alpha = alpha;
            Readiness = readiness;
            IsSpeaking = isSpeaking;
        }

        public bool Equals(NameTag other) =>
            ViewportPosition == other.ViewportPosition && Name == other.Name && Tone == other.Tone && Alpha == other.Alpha &&
            Readiness == other.Readiness && IsSpeaking == other.IsSpeaking;
    }

    // the UI can't see the Player teams, so the feed maps them to these
    public enum NameTagTone
    {
        Neutral,
        Runner,
        Catcher,
        Knocked
    }

    // the lobby ready mark; None outside the lobby
    public enum NameTagReadiness
    {
        None,
        Ready,
        NotReady
    }
}
