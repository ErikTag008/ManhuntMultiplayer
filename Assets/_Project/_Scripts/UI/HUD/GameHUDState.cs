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
        private int _catchers;
        private bool _isBleedOutShown;
        private float _bleedOutRemainingInSeconds;
        private float _bleedOutProgress;
        private bool _isBleedOutPaused;
        private bool _isRescueShown;
        private float _rescueProgress;
        private bool _isAbilityShown;
        private string _abilityName;
        private string _abilityReadyHint;
        private string _abilityDescription;
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
        private bool _isGhost;
        private bool _isGhostFlying;
        private bool _isGhostPingReady;
        private float _ghostPingCooldownRemainingInSeconds;
        private float _ghostPingCooldownProgress;
        private readonly List<NameTag> _nameTags = new();
        private RoundPhase _roundPhase;
        private bool _isLocalCatcher;
        private bool _isLocalSittingOut;
        private bool _isCrosshairWanted;
        private bool _isRescueHintShown;
        private string _rescueHintName;
        private readonly List<Vector2> _knockedMarkerPositions = new();
        private readonly List<int> _knockedMarkerSeconds = new();
        private bool _isSpectating;
        private bool _isVoiceTransmitting;

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
        public event Action OnGhostChanged;
        public event Action OnNameTagsChanged;
        public event Action OnRoundPhaseChanged;
        public event Action OnCrosshairChanged;
        public event Action OnRescueHintChanged;
        public event Action OnKnockedMarkersChanged;
        public event Action OnSpectatingChanged;
        public event Action OnVoiceTransmittingChanged;
        // the effect's name, its description and whether it's good, the moment this runner takes a drop; a one-off
        public event Action<string, string, bool> OnDropTaken;
        // a teammate's name the moment they get knocked; a one-off like OnStationCompleted
        public event Action<string> OnTeammateKnocked;
        // the seconds a station just took off the round; a one-off, so a HUD that starts later doesn't replay it
        public event Action<float> OnStationCompleted;

        public int RunnersUp => _runnersUp;
        public int RunnersKnocked => _runnersKnocked;
        public int RunnersOut => _runnersOut;
        public int Catchers => _catchers;
        public bool IsBleedOutShown => _isBleedOutShown;
        public float BleedOutRemainingInSeconds => _bleedOutRemainingInSeconds;
        // 1 when the bleed-out starts, 0 when it runs out
        public float BleedOutProgress => _bleedOutProgress;
        // held by a rescue in progress or a catcher standing nearby
        public bool IsBleedOutPaused => _isBleedOutPaused;
        public bool IsRescueShown => _isRescueShown;
        public float RescueProgress => _rescueProgress;
        public bool IsAbilityShown => _isAbilityShown;
        public string AbilityName => _abilityName;
        public string AbilityReadyHint => _abilityReadyHint;
        public string AbilityDescription => _abilityDescription;
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
        public bool IsGhost => _isGhost;
        // false while the ghost watches through the spectator camera
        public bool IsGhostFlying => _isGhostFlying;
        public bool IsGhostPingReady => _isGhostPingReady;
        public float GhostPingCooldownRemainingInSeconds => _ghostPingCooldownRemainingInSeconds;
        // 1 right after a ping, 0 when ready
        public float GhostPingCooldownProgress => _ghostPingCooldownProgress;
        // the other players' name tags this player can see right now
        public IReadOnlyList<NameTag> NameTags => _nameTags;
        public RoundPhase RoundPhase => _roundPhase;
        public bool IsLocalCatcher => _isLocalCatcher;
        // the local player joined mid-round and only watches it
        public bool IsLocalSittingOut => _isLocalSittingOut;
        // true while the local player aims at something in a round; menus and the setting decide on top of it
        public bool IsCrosshairWanted => _isCrosshairWanted;
        public bool IsRescueHintShown => _isRescueHintShown;
        // the knocked teammate a rescue would start on
        public string RescueHintName => _rescueHintName;
        // viewport positions (0..1) of knocked teammates on this runner's screen
        public IReadOnlyList<Vector2> KnockedMarkerPositions => _knockedMarkerPositions;
        // whole bleed-out seconds left per knocked marker, 0 when not known yet
        public IReadOnlyList<int> KnockedMarkerSeconds => _knockedMarkerSeconds;
        // true while this player watches another one through the spectator camera
        public bool IsSpectating => _isSpectating;
        // the local mic is sending voice
        public bool IsVoiceTransmitting => _isVoiceTransmitting;

        public void SetRunnerCounts(int up, int knocked, int eliminated, int catchers)
        {
            if (_runnersUp == up && _runnersKnocked == knocked && _runnersOut == eliminated && _catchers == catchers) return;

            _runnersUp = up;
            _runnersKnocked = knocked;
            _runnersOut = eliminated;
            _catchers = catchers;
            OnRunnerCountsChanged?.Invoke();
        }

        public void SetBleedOut(bool isShown, float remainingInSeconds, float progress, bool isPaused)
        {
            if (_isBleedOutShown == isShown && _bleedOutRemainingInSeconds == remainingInSeconds && _bleedOutProgress == progress
                && _isBleedOutPaused == isPaused) return;

            _isBleedOutShown = isShown;
            _isBleedOutPaused = isPaused;
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

        public void SetAbility(bool isShown, string abilityName, string readyHint, string description, float cooldownRemainingInSeconds,
            float cooldownProgress)
        {
            if (_isAbilityShown == isShown && _abilityName == abilityName && _abilityReadyHint == readyHint && _abilityDescription == description
                && _abilityCooldownRemainingInSeconds == cooldownRemainingInSeconds && _abilityCooldownProgress == cooldownProgress) return;

            _isAbilityShown = isShown;
            _abilityName = abilityName;
            _abilityReadyHint = readyHint;
            _abilityDescription = description;
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

        public void SetGhost(bool isGhost, bool isFlying, bool isPingReady, float pingCooldownRemainingInSeconds, float pingCooldownProgress)
        {
            if (_isGhost == isGhost && _isGhostFlying == isFlying && _isGhostPingReady == isPingReady
                && _ghostPingCooldownRemainingInSeconds == pingCooldownRemainingInSeconds && _ghostPingCooldownProgress == pingCooldownProgress) return;

            _isGhost = isGhost;
            _isGhostFlying = isFlying;
            _isGhostPingReady = isPingReady;
            _ghostPingCooldownRemainingInSeconds = pingCooldownRemainingInSeconds;
            _ghostPingCooldownProgress = pingCooldownProgress;
            OnGhostChanged?.Invoke();
        }

        public void SetRoundPhase(RoundPhase phase, bool isLocalCatcher, bool isLocalSittingOut)
        {
            if (_roundPhase == phase && _isLocalCatcher == isLocalCatcher && _isLocalSittingOut == isLocalSittingOut) return;

            _roundPhase = phase;
            _isLocalCatcher = isLocalCatcher;
            _isLocalSittingOut = isLocalSittingOut;
            OnRoundPhaseChanged?.Invoke();
        }

        public void SetCrosshair(bool isWanted)
        {
            if (_isCrosshairWanted == isWanted) return;

            _isCrosshairWanted = isWanted;
            OnCrosshairChanged?.Invoke();
        }

        public void SetRescueHint(bool isShown, string teammateName)
        {
            if (_isRescueHintShown == isShown && _rescueHintName == teammateName) return;

            _isRescueHintShown = isShown;
            _rescueHintName = teammateName;
            OnRescueHintChanged?.Invoke();
        }

        // copies both lists, so the caller can reuse them; they pair up by index
        public void SetKnockedMarkers(IReadOnlyList<Vector2> viewportPositions, IReadOnlyList<int> secondsLeft)
        {
            bool hasPositionsChanged = CopyPositionsIfChanged(_knockedMarkerPositions, viewportPositions);
            bool haveSecondsChanged = CopySecondsIfChanged(secondsLeft);
            if (hasPositionsChanged || haveSecondsChanged) OnKnockedMarkersChanged?.Invoke();
        }

        public void NotifyTeammateKnocked(string teammateName) => OnTeammateKnocked?.Invoke(teammateName);

        public void NotifyDropTaken(string effectName, string description, bool isGood) => OnDropTaken?.Invoke(effectName, description, isGood);

        public void SetSpectating(bool isSpectating)
        {
            if (_isSpectating == isSpectating) return;

            _isSpectating = isSpectating;
            OnSpectatingChanged?.Invoke();
        }

        public void SetVoiceTransmitting(bool isTransmitting)
        {
            if (_isVoiceTransmitting == isTransmitting) return;

            _isVoiceTransmitting = isTransmitting;
            OnVoiceTransmittingChanged?.Invoke();
        }

        // copies the tags, so the caller can reuse its list
        public void SetNameTags(IReadOnlyList<NameTag> tags)
        {
            if (AreNameTagsEqual(tags)) return;

            _nameTags.Clear();
            for (int i = 0; i < tags.Count; i++) _nameTags.Add(tags[i]);
            OnNameTagsChanged?.Invoke();
        }

        // false when nothing changed, so no event is raised
        private static bool CopyPositionsIfChanged(List<Vector2> current, IReadOnlyList<Vector2> next)
        {
            if (ArePositionsEqual(current, next)) return false;

            current.Clear();
            for (int i = 0; i < next.Count; i++) current.Add(next[i]);
            return true;
        }

        private bool CopySecondsIfChanged(IReadOnlyList<int> next)
        {
            bool isEqual = _knockedMarkerSeconds.Count == next.Count;
            for (int i = 0; isEqual && i < next.Count; i++) isEqual = _knockedMarkerSeconds[i] == next[i];
            if (isEqual) return false;

            _knockedMarkerSeconds.Clear();
            for (int i = 0; i < next.Count; i++) _knockedMarkerSeconds.Add(next[i]);
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

        private bool AreNameTagsEqual(IReadOnlyList<NameTag> tags)
        {
            if (_nameTags.Count != tags.Count) return false;

            for (int i = 0; i < tags.Count; i++)
            {
                if (!_nameTags[i].Equals(tags[i])) return false;
            }

            return true;
        }
    }

    public enum RoundPhase
    {
        None,
        Hide,
        Hunt
    }
}
