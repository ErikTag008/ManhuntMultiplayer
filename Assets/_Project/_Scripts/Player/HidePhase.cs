using System;

namespace Project.Assets._Project._Scripts.Player
{
    // Project-scoped mirror of whether the round is in its hide phase, so player components can read it
    // without referencing the Managers assembly. Only GameStateMachine writes to it, on every instance.
    public class HidePhase
    {
        private bool _isActive;

        public event Action<bool> OnChanged;

        public bool IsActive => _isActive;

        public void Toggle(bool isActive)
        {
            if (_isActive == isActive) return;

            _isActive = isActive;
            OnChanged?.Invoke(isActive);
        }
    }
}
