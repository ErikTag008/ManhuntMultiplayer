using System;
using System.Collections.Generic;
using UnityEngine;

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
        private bool _isAbilityShown;
        private string _abilityName;
        private string _abilityReadyHint;
        private float _abilityCooldownRemainingInSeconds;
        private float _abilityCooldownProgress;
        private bool _isDropEffectShown;
        private string _dropEffectName;
        private bool _isDropEffectGood;
        private float _dropEffectRemainingInSeconds;
        private float _dropEffectProgress;
        private readonly List<Vector2> _revealMarkerPositions = new();
        private bool _isStationCountShown;
        private int _stationsCompleted;
        private int _stationsTotal;
        private bool _isStationHintShown;
        private readonly List<Vector2> _stationMarkerPositions = new();
        private bool _isLungeHintShown;
        private bool _isLungeChargeShown;
        private float _lungeChargeProgress;

        public event Action OnRunnerCountsChanged;
        public event Action OnBleedOutChanged;
        public event Action OnRescueChanged;
        public event Action OnAbilityChanged;
        public event Action OnDropEffectChanged;
        public event Action OnRevealMarkersChanged;
        public event Action OnStationCountsChanged;
        public event Action OnStationHintChanged;
        public event Action OnStationMarkersChanged;
        public event Action OnLungeChanged;
        // the seconds a station just took off the round; a one-off, so a HUD that starts later doesn't replay it
        public event Action<float> OnStationCompleted;

        public int RunnersUp => _runnersUp;
        public int RunnersKnocked => _runnersKnocked;
        public int RunnersOut => _runnersOut;
        public bool IsBleedOutShown => _isBleedOutShown;
        public float BleedOutRemainingInSeconds => _bleedOutRemainingInSeconds;
        // 1 when the bleed-out starts, 0 when it runs out
        public float BleedOutProgress => _bleedOutProgress;
        public bool IsRescueShown => _isRescueShown;
        public float RescueProgress => _rescueProgress;
        public bool IsAbilityShown => _isAbilityShown;
        public string AbilityName => _abilityName;
        public string AbilityReadyHint => _abilityReadyHint;
        public float AbilityCooldownRemainingInSeconds => _abilityCooldownRemainingInSeconds;
        // 1 right after use, 0 when ready
        public float AbilityCooldownProgress => _abilityCooldownProgress;
        public bool IsDropEffectShown => _isDropEffectShown;
        public string DropEffectName => _dropEffectName;
        public bool IsDropEffectGood => _isDropEffectGood;
        public float DropEffectRemainingInSeconds => _dropEffectRemainingInSeconds;
        // 1 when the effect starts, 0 when it runs out
        public float DropEffectProgress => _dropEffectProgress;
        // viewport positions (0..1) of revealed runners on this catcher's screen
        public IReadOnlyList<Vector2> RevealMarkerPositions => _revealMarkerPositions;
        public bool IsStationCountShown => _isStationCountShown;
        public int StationsCompleted => _stationsCompleted;
        public int StationsTotal => _stationsTotal;
        public bool IsStationHintShown => _isStationHintShown;
        // viewport positions (0..1) of unfinished stations on this player's screen
        public IReadOnlyList<Vector2> StationMarkerPositions => _stationMarkerPositions;
        public bool IsLungeHintShown => _isLungeHintShown;
        public bool IsLungeChargeShown => _isLungeChargeShown;
        public float LungeChargeProgress => _lungeChargeProgress;

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

        public void SetAbility(bool isShown, string abilityName, string readyHint, float cooldownRemainingInSeconds, float cooldownProgress)
        {
            if (_isAbilityShown == isShown && _abilityName == abilityName && _abilityReadyHint == readyHint
                && _abilityCooldownRemainingInSeconds == cooldownRemainingInSeconds && _abilityCooldownProgress == cooldownProgress) return;

            _isAbilityShown = isShown;
            _abilityName = abilityName;
            _abilityReadyHint = readyHint;
            _abilityCooldownRemainingInSeconds = cooldownRemainingInSeconds;
            _abilityCooldownProgress = cooldownProgress;
            OnAbilityChanged?.Invoke();
        }

        public void SetDropEffect(bool isShown, string effectName, bool isGood, float remainingInSeconds, float progress)
        {
            if (_isDropEffectShown == isShown && _dropEffectName == effectName && _isDropEffectGood == isGood
                && _dropEffectRemainingInSeconds == remainingInSeconds && _dropEffectProgress == progress) return;

            _isDropEffectShown = isShown;
            _dropEffectName = effectName;
            _isDropEffectGood = isGood;
            _dropEffectRemainingInSeconds = remainingInSeconds;
            _dropEffectProgress = progress;
            OnDropEffectChanged?.Invoke();
        }

        // copies the positions, so the caller can reuse its list
        public void SetRevealMarkers(IReadOnlyList<Vector2> viewportPositions)
        {
            if (CopyPositionsIfChanged(_revealMarkerPositions, viewportPositions)) OnRevealMarkersChanged?.Invoke();
        }

        public void SetStationCounts(bool isShown, int completed, int total)
        {
            if (_isStationCountShown == isShown && _stationsCompleted == completed && _stationsTotal == total) return;

            _isStationCountShown = isShown;
            _stationsCompleted = completed;
            _stationsTotal = total;
            OnStationCountsChanged?.Invoke();
        }

        public void SetStationHint(bool isShown)
        {
            if (_isStationHintShown == isShown) return;

            _isStationHintShown = isShown;
            OnStationHintChanged?.Invoke();
        }

        // copies the positions, so the caller can reuse its list
        public void SetStationMarkers(IReadOnlyList<Vector2> viewportPositions)
        {
            if (CopyPositionsIfChanged(_stationMarkerPositions, viewportPositions)) OnStationMarkersChanged?.Invoke();
        }

        public void NotifyStationCompleted(float appliedCutInSeconds) => OnStationCompleted?.Invoke(appliedCutInSeconds);

        public void SetLunge(bool isHintShown, bool isChargeShown, float chargeProgress)
        {
            if (_isLungeHintShown == isHintShown && _isLungeChargeShown == isChargeShown && _lungeChargeProgress == chargeProgress) return;

            _isLungeHintShown = isHintShown;
            _isLungeChargeShown = isChargeShown;
            _lungeChargeProgress = chargeProgress;
            OnLungeChanged?.Invoke();
        }

        // false when nothing changed, so no event is raised
        private static bool CopyPositionsIfChanged(List<Vector2> current, IReadOnlyList<Vector2> next)
        {
            if (ArePositionsEqual(current, next)) return false;

            current.Clear();
            for (int i = 0; i < next.Count; i++) current.Add(next[i]);
            return true;
        }

        private static bool ArePositionsEqual(List<Vector2> current, IReadOnlyList<Vector2> next)
        {
            if (current.Count != next.Count) return false;

            for (int i = 0; i < next.Count; i++)
            {
                if (current[i] != next[i]) return false;
            }

            return true;
        }
    }
}
