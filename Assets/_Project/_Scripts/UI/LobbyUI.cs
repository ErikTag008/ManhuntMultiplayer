using DG.Tweening;
using Project.Assets._Project._Scripts.UI.HUD;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI
{
    public class LobbyUI : MonoBehaviour, ILobbyUI
    {
        [SerializeField] private TMP_Text _joinedPlayerAmountText;
        [SerializeField] private TMP_Text _lobbyStatusText;
        [SerializeField] private TMP_Text _countdownText;
        [SerializeField] private TMP_Text _nextCatchersText;
        [SerializeField] private Button _gameStartButton;
        [Inject] private readonly IUIManager _uiManager;
        [Inject] private readonly LobbyMenuState _lobbyMenuState;
        // on the Start Game button: it shows with the lobby menu, so it fades and pops up from its bottom edge
        [SerializeField] private CanvasGroup _gameStartButtonGroup;
        [SerializeField] private float _gameStartAppearDelay = 0.1f;
        [SerializeField] private float _gameStartAppearDuration = 0.35f;
        [SerializeField] private float _gameStartHiddenScale = 0.6f;
        [SerializeField] private Ease _gameStartAppearEase = Ease.OutBack;
        [SerializeField] private float _gameStartDisappearDuration = 0.15f;
        [SerializeField] private Ease _gameStartDisappearEase = Ease.InCubic;

        private Tween _gameStartButtonTween;
        private bool _isGameStartAllowed;
        private bool _isGameStartButtonShown;

        private void Start()
        {
            _uiManager.OnJoinedPlayerAmountChanged += HandleJoinedPlayerAmountChange;
            _uiManager.OnLobbyStatusTextChanged += HandleLobbyStatusChange;
            _uiManager.OnCountdownTextChanged += HandleCountdownChange;
            _uiManager.OnNextCatchersTextChanged += HandleNextCatchersChange;
            _uiManager.OnStartGameButtonAvailabilityChanged += HandleGameStartButtonAvailabilityChange;
            _uiManager.OnStartGameButtonVisibilityChanged += HandleGameStartButtonVisibilityChange;
            _lobbyMenuState.OnOpenChanged += HandleLobbyMenuChanged;
            _lobbyMenuState.OnCustomizeOpenChanged += HandleLobbyMenuChanged;
            // hidden until the host says it's theirs, so joining players never see it flash
            HideGameStartButtonImmediately();
            _uiManager.RequestLobbyUIInitialization();
            _gameStartButton.onClick.AddListener(_uiManager.StartGame);
        }

        private void HandleUITextChange(TMP_Text uiText, string text)
        {
            if (uiText.text == text) return;
            uiText.text = text;
        }

        // the start key works while walking around too, when the button itself is hidden with the menu
        public void InvokeGameStartButtonPress()
        {
            if (_isGameStartAllowed && _gameStartButton.interactable)
                _gameStartButton.onClick.Invoke();
        }

        private void HandleGameStartButtonAvailabilityChange(bool isActive)
        {
            _gameStartButton.interactable = isActive;
        }

        private void HandleGameStartButtonVisibilityChange(bool isVisible)
        {
            _isGameStartAllowed = isVisible;
            RefreshGameStartButton();
        }

        private void HandleLobbyMenuChanged(bool _) => RefreshGameStartButton();

        // the host's button belongs to the lobby menu: it shows only while that menu is on screen
        private void RefreshGameStartButton()
        {
            bool isShown = _isGameStartAllowed && _lobbyMenuState.IsOpen && !_lobbyMenuState.IsCustomizeOpen;
            if (isShown == _isGameStartButtonShown) return;

            _isGameStartButtonShown = isShown;
            if (isShown) ShowGameStartButton();
            else HideGameStartButton();
        }

        private void ShowGameStartButton()
        {
            var buttonTransform = _gameStartButton.transform;
            _gameStartButtonTween?.Kill();
            _gameStartButton.gameObject.SetActive(true);
            _gameStartButtonGroup.interactable = true;
            _gameStartButtonGroup.blocksRaycasts = true;
            _gameStartButtonGroup.alpha = 0f;
            buttonTransform.localScale = Vector3.one * _gameStartHiddenScale;
            _gameStartButtonTween = DOTween.Sequence()
                .AppendInterval(_gameStartAppearDelay)
                .Append(buttonTransform.DOScale(Vector3.one, _gameStartAppearDuration).SetEase(_gameStartAppearEase))
                .Join(FadeGameStartButton(1f, _gameStartAppearDuration))
                .SetUpdate(true)
                .SetLink(_gameStartButton.gameObject);
        }

        // switched off at once so navigation skips it while it fades
        private void HideGameStartButton()
        {
            _gameStartButtonTween?.Kill();
            _gameStartButtonGroup.interactable = false;
            _gameStartButtonGroup.blocksRaycasts = false;
            if (!_gameStartButton.gameObject.activeInHierarchy)
            {
                HideGameStartButtonImmediately();
                return;
            }

            _gameStartButtonTween = DOTween.Sequence()
                .Append(_gameStartButton.transform.DOScale(Vector3.one * _gameStartHiddenScale, _gameStartDisappearDuration).SetEase(_gameStartDisappearEase))
                .Join(FadeGameStartButton(0f, _gameStartDisappearDuration))
                .SetUpdate(true)
                .SetLink(_gameStartButton.gameObject)
                .OnComplete(HideGameStartButtonImmediately);
        }

        // core DOTween.To: the CanvasGroup DOFade shortcut lives in the DOTween UI module, which no project assembly references
        private Tween FadeGameStartButton(float alpha, float duration) =>
            DOTween.To(() => _gameStartButtonGroup.alpha, value => _gameStartButtonGroup.alpha = value, alpha, duration);

        private void HideGameStartButtonImmediately()
        {
            _isGameStartButtonShown = false;
            _gameStartButtonGroup.alpha = 0f;
            _gameStartButtonGroup.interactable = false;
            _gameStartButtonGroup.blocksRaycasts = false;
            _gameStartButton.transform.localScale = Vector3.one;
            if (_gameStartButton.gameObject.activeSelf) _gameStartButton.gameObject.SetActive(false);
        }

        private void HandleJoinedPlayerAmountChange(string text) => HandleUITextChange(_joinedPlayerAmountText, text);

        private void HandleLobbyStatusChange(string text) => HandleUITextChange(_lobbyStatusText, text);

        private void HandleCountdownChange(string text) => HandleUITextChange(_countdownText, text);

        private void HandleNextCatchersChange(string text) => HandleUITextChange(_nextCatchersText, text);

        private void OnDestroy()
        {
            var uiManager = _uiManager;
            uiManager.OnJoinedPlayerAmountChanged -= HandleJoinedPlayerAmountChange;
            uiManager.OnLobbyStatusTextChanged -= HandleLobbyStatusChange;
            uiManager.OnCountdownTextChanged -= HandleCountdownChange;
            uiManager.OnNextCatchersTextChanged -= HandleNextCatchersChange;
            uiManager.OnStartGameButtonAvailabilityChanged -= HandleGameStartButtonAvailabilityChange;
            uiManager.OnStartGameButtonVisibilityChanged -= HandleGameStartButtonVisibilityChange;
            _lobbyMenuState.OnOpenChanged -= HandleLobbyMenuChanged;
            _lobbyMenuState.OnCustomizeOpenChanged -= HandleLobbyMenuChanged;
            _gameStartButton.onClick.RemoveListener(uiManager.StartGame);
            _gameStartButtonTween?.Kill();
        }
    }
}
