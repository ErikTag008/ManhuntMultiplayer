using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // The local player's emote wheel: the player opens it with its emotes, aims at a slice and closes it to pick one;
    // aiming back at the centre cancels. The wheel view only draws it.
    public class EmoteWheelState
    {
        public const int NoSelection = -1;
        private const float FullTurnInDegrees = 360f;

        private readonly List<EmoteWheelOption> _options = new();
        private bool _isOpen;
        private int _highlightedIndex = NoSelection;
        private int _lastAimedIndex = NoSelection;

        public event Action<bool> OnOpenChanged;
        public event Action<int> OnHighlightChanged;

        public bool IsOpen => _isOpen;
        public IReadOnlyList<EmoteWheelOption> Options => _options;
        public int HighlightedIndex => _highlightedIndex;

        public void Open(IEnumerable<EmoteWheelOption> options)
        {
            if (_isOpen) return;

            _options.Clear();
            _options.AddRange(options);
            _highlightedIndex = NoSelection;
            _lastAimedIndex = NoSelection;
            _isOpen = true;
            OnOpenChanged?.Invoke(true);
        }

        // Aim inside the dead zone is the centre, which picks nothing
        public void Aim(Vector2 aim, float deadZone)
        {
            if (!_isOpen) return;

            int index = PickSlice(aim, _options.Count, deadZone);
            if (index != NoSelection) _lastAimedIndex = index;
            if (index == _highlightedIndex) return;

            _highlightedIndex = index;
            OnHighlightChanged?.Invoke(index);
        }

        // Returns the highlighted option's index, or NoSelection when the aim is at the centre.
        // isLastAimedKept picks the last aimed slice from the centre too: a stick springing back as it is released.
        public int Close(bool isLastAimedKept = false)
        {
            if (!_isOpen) return NoSelection;

            int picked = _highlightedIndex == NoSelection && isLastAimedKept ? _lastAimedIndex : _highlightedIndex;
            _isOpen = false;
            _highlightedIndex = NoSelection;
            _lastAimedIndex = NoSelection;
            OnOpenChanged?.Invoke(false);
            return picked;
        }

        // Slice 0 is centred at the top and the rest follow clockwise
        public static int PickSlice(Vector2 aim, int sliceCount, float deadZone)
        {
            if (sliceCount <= 0 || aim.magnitude < deadZone) return NoSelection;

            float sliceAngle = FullTurnInDegrees / sliceCount;
            float angle = Mathf.Repeat(Mathf.Atan2(aim.x, aim.y) * Mathf.Rad2Deg + sliceAngle / 2f, FullTurnInDegrees);
            return Mathf.Min(Mathf.FloorToInt(angle / sliceAngle), sliceCount - 1);
        }

        // Where slice i's centre points, as a unit vector with up = slice 0
        public static Vector2 SliceDirection(int index, int sliceCount)
        {
            if (sliceCount <= 0) return Vector2.up;

            float angle = index * FullTurnInDegrees / sliceCount * Mathf.Deg2Rad;
            return new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
        }
    }

    public readonly struct EmoteWheelOption
    {
        public readonly string Label;
        public readonly Sprite Icon;

        public EmoteWheelOption(string label, Sprite icon)
        {
            Label = label;
            Icon = icon;
        }
    }
}
