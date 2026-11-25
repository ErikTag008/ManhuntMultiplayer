using DG.Tweening;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // The round's phase on the gameplay HUD: a short banner when the hide phase and the hunt start (the hide banner names
    // the local player's team), a cue at the hunt start, and a Hide / Hunt label next to the round timer.
    // A player who joined mid-round gets a banner saying they watch until the next round instead, and no cue
    public class RoundHUD : MonoBehaviour
    {
        [Inject] private readonly GameHUDState _state;
        [SerializeField] private FadePanel _bannerPanel;
        [SerializeField] private TMP_Text _bannerText;
        [SerializeField] private string _runnerHideBannerText = "You're a Runner: hide";
        [SerializeField] private string _catcherHideBannerText = "You're the Catcher: wait for the door";
        [SerializeField] private string _huntBannerText = "The hunt begins";
        [SerializeField] private string _sittingOutBannerText = "Round in progress: you're watching until the next one";
        [SerializeField, Min(0f)] private float _bannerShownDurationInSeconds = 3f;
        [SerializeField] private TMP_Text _phaseLabel;
        [SerializeField] private string _hidePhaseLabel = "Hide";
        [SerializeField] private string _huntPhaseLabel = "Hunt";
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private RoundAnnouncementData _announcementData;

        private RoundPhase _shownPhase;
        private Tween _bannerHideTween;

        private void Start()
        {
            _state.OnRoundPhaseChanged += HandleRoundPhaseChanged;
            // a phase that started before this scene's UI did still gets its banner
            HandleRoundPhaseChanged();
        }

        private void HandleRoundPhaseChanged()
        {
            var phase = _state.RoundPhase;
            _phaseLabel.text = GetPhaseLabel(phase);
            if (phase == _shownPhase)
            {
                // the team (or a mid-round joiner's session) can reach a client just after the phase started, so a showing banner follows it
                if (phase != RoundPhase.None && _bannerPanel.IsShown) _bannerText.text = GetBannerText(phase);
                return;
            }

            _shownPhase = phase;
            switch (phase)
            {
                case RoundPhase.Hide:
                    ShowBanner(GetBannerText(phase));
                    break;
                case RoundPhase.Hunt:
                    ShowBanner(GetBannerText(phase));
                    if (!_state.IsLocalSittingOut) PlayHuntStartCue();
                    break;
                case RoundPhase.None:
                    HideBanner();
                    break;
            }
        }

        private string GetBannerText(RoundPhase phase)
        {
            if (_state.IsLocalSittingOut) return _sittingOutBannerText;
            if (phase == RoundPhase.Hunt) return _huntBannerText;
            return _state.IsLocalCatcher ? _catcherHideBannerText : _runnerHideBannerText;
        }

        private string GetPhaseLabel(RoundPhase phase) => phase switch
        {
            RoundPhase.Hide => _hidePhaseLabel,
            RoundPhase.Hunt => _huntPhaseLabel,
            _ => string.Empty
        };

        private void ShowBanner(string text)
        {
            _bannerText.text = text;
            _bannerPanel.Show();
            _bannerHideTween?.Kill();
            _bannerHideTween = DOVirtual.DelayedCall(_bannerShownDurationInSeconds, _bannerPanel.Hide);
        }

        private void HideBanner()
        {
            _bannerHideTween?.Kill();
            if (_bannerPanel.IsShown) _bannerPanel.Hide();
        }

        private void PlayHuntStartCue()
        {
            if (_announcementData == null || _announcementData.HuntStartSFX == null) return;

            _audioSource.PlayOneShot(_announcementData.HuntStartSFX, _announcementData.HuntStartSFXVolume);
        }

        private void OnDestroy()
        {
            _state.OnRoundPhaseChanged -= HandleRoundPhaseChanged;
            _bannerHideTween?.Kill();
        }
    }
}
