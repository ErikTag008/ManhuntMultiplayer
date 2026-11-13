using System;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Values the gameplay HUD shows. Player components write them and the HUD reads them; it lives in the UI assembly
    // because UI can't reference Player. Values are kept so a HUD that starts later can catch up.
    public class GameHUDState
    {
        private int _runnersUp;
        private int _runnersKnocked;
        private int _runnersOut;
        private bool _isBleedOutShown;
        private float _bleedOutRemainingInSeconds;
        private float _bleedOutProgress;
        private bool _isRescueShown;
        private float _rescueProgress;

        public event Action OnRunnerCountsChanged;
        public event Action OnBleedOutChanged;
        public event Action OnRescueChanged;

        public int RunnersUp => _runnersUp;
        public int RunnersKnocked => _runnersKnocked;
        public int RunnersOut => _runnersOut;
        public bool IsBleedOutShown => _isBleedOutShown;
        public float BleedOutRemainingInSeconds => _bleedOutRemainingInSeconds;
        // 1 when the bleed-out starts, 0 when it runs out
        public float BleedOutProgress => _bleedOutProgress;
        public bool IsRescueShown => _isRescueShown;
        public float RescueProgress => _rescueProgress;

        public void SetRunnerCounts(int up, int knocked, int eliminated)
        {
            if (_runnersUp == up && _runnersKnocked == knocked && _runnersOut == eliminated) return;

            _runnersUp = up;
            _runnersKnocked = knocked;
            _runnersOut = eliminated;
            OnRunnerCountsChanged?.Invoke();
        }

        public void SetBleedOut(bool isShown, float remainingInSeconds, float progress)
        {
            if (_isBleedOutShown == isShown && _bleedOutRemainingInSeconds == remainingInSeconds && _bleedOutProgress == progress) return;

            _isBleedOutShown = isShown;
            _bleedOutRemainingInSeconds = remainingInSeconds;
            _bleedOutProgress = progress;
            OnBleedOutChanged?.Invoke();
        }

        public void SetRescue(bool isShown, float progress)
        {
            if (_isRescueShown == isShown && _rescueProgress == progress) return;

            _isRescueShown = isShown;
            _rescueProgress = progress;
            OnRescueChanged?.Invoke();
        }
    }
}
