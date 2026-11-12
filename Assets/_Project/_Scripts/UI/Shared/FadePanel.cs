using DG.Tweening;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Generic panel that fades its CanvasGroup in and out; starts hidden
    [RequireComponent(typeof(CanvasGroup))]
    public class FadePanel : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeInDuration = 0.35f;
        [SerializeField] private float _fadeOutDuration = 0.2f;
        [SerializeField] private Ease _fadeInEase = Ease.OutCubic;
        [SerializeField] private Ease _fadeOutEase = Ease.InCubic;

        private Tween _fadeTween;
        private bool _isShown;

        public bool IsShown => _isShown;

        private void Reset() => _canvasGroup = GetComponent<CanvasGroup>();

        private void Awake() => HideImmediately();

        public void Show() => FadeTo(true, _fadeInDuration, _fadeInEase);

        public void Hide() => FadeTo(false, _fadeOutDuration, _fadeOutEase);

        private void FadeTo(bool isShown, float duration, Ease ease)
        {
            _isShown = isShown;
            _fadeTween?.Kill();
            _canvasGroup.interactable = isShown;
            _canvasGroup.blocksRaycasts = isShown;
            // core DOTween.To: the CanvasGroup DOFade shortcut lives in the DOTween UI module, which no project assembly references
            _fadeTween = DOTween.To(() => _canvasGroup.alpha, alpha => _canvasGroup.alpha = alpha, isShown ? 1f : 0f, duration)
                .SetEase(ease)
                .SetUpdate(true);
        }

        private void HideImmediately()
        {
            _isShown = false;
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        private void OnDestroy() => _fadeTween?.Kill();
    }
}
