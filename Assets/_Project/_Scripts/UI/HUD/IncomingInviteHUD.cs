using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Popup for a friend's lobby invite on every screen: avatar, name, Accept and Decline. While the game holds the cursor
    // it only shows a hint to open the menu; once the cursor is free, focus moves to Decline so a stray press can't leave the match.
    public class IncomingInviteHUD : MonoBehaviour
    {
        [Inject] private readonly IncomingInviteState _state;
        [Inject] private readonly FriendAvatarCache _avatarCache;
        [Inject] private readonly IConnectionService _connectionService;
        [Inject] private readonly PauseMenuState _pauseMenuState;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private RawImage _avatarImage;
        // shown until the friend's avatar has loaded, and for friends without one
        [SerializeField] private Texture _placeholderAvatar;
        [SerializeField] private Color _placeholderAvatarColor = new(1f, 1f, 1f, 0.15f);
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _noteText;
        [SerializeField] private Button _acceptButton;
        [SerializeField] private Button _declineButton;
        // a KeyHintText naming the menu key, shown while the cursor is locked
        [SerializeField] private GameObject _openMenuHint;
        // {0} is the friend's name
        [SerializeField] private string _titleFormat = "{0} invited you to play";
        [SerializeField] private string _menuNote = "Join their lobby?";
        [SerializeField] private string _leaveNote = "Accepting leaves your current lobby.";
        [SerializeField] private string _hostLeaveNote = "You are the host.\nAccepting ends the match for everyone.";
        [SerializeField, Min(1f)] private float _expireAfterInSeconds = 45f;

        private CancellationTokenSource _expireCTS;
        private GameObject _selectionBeforeShown;
        private ulong _shownFriendId;
        private bool _wasCursorFree;

        private void Start()
        {
            _state.OnCurrentChanged += Refresh;
            _avatarCache.OnAvatarLoaded += HandleAvatarLoaded;
            _acceptButton.onClick.AddListener(_state.Accept);
            _declineButton.onClick.AddListener(_state.Decline);
            Refresh();
        }

        private void LateUpdate()
        {
            if (!_panel.IsShown) return;

            bool isCursorFree = Cursor.lockState != CursorLockMode.Locked;
            _openMenuHint.SetActive(!isCursorFree);
            if (isCursorFree && !_wasCursorFree) TakeFocus();
            _wasCursorFree = isCursorFree;
        }

        private void Refresh()
        {
            if (!_state.TryGetCurrent(out var invite))
            {
                Hide();
                return;
            }

            _shownFriendId = invite.FriendId;
            _titleText.text = string.Format(_titleFormat, invite.FriendName);
            _noteText.text = !_connectionService.IsConnected ? _menuNote : _pauseMenuState.DoesLeavingEndSession ? _hostLeaveNote : _leaveNote;
            ShowAvatar(_avatarCache.TryGetAvatar(invite.FriendId, out var avatar) ? avatar : null);
            StartExpiring();
            if (_panel.IsShown) return;

            // LateUpdate focuses Decline on the first frame the cursor is free
            _wasCursorFree = false;
            _panel.Show();
        }

        private void Hide()
        {
            StopExpiring();
            if (!_panel.IsShown) return;

            _panel.Hide();
            _openMenuHint.SetActive(false);
            RestoreSelection();
        }

        // remembered when focus is taken, not when shown: in gameplay the menu opens (and picks its button) after the popup appears
        private void TakeFocus()
        {
            var eventSystem = EventSystem.current;
            var selected = eventSystem != null ? eventSystem.currentSelectedGameObject : null;
            if (selected == null || !selected.transform.IsChildOf(transform)) _selectionBeforeShown = selected;
            _declineButton.Select();
        }

        // the menu behind keeps its focus when the popup closes, unless it closed or was hidden meanwhile
        private void RestoreSelection()
        {
            var eventSystem = EventSystem.current;
            if (eventSystem == null) return;

            var selected = eventSystem.currentSelectedGameObject;
            if (selected != null && !selected.transform.IsChildOf(transform)) return;

            bool canRestore = _selectionBeforeShown != null && _selectionBeforeShown.activeInHierarchy;
            eventSystem.SetSelectedGameObject(canRestore ? _selectionBeforeShown : null);
            _selectionBeforeShown = null;
        }

        private void HandleAvatarLoaded(ulong friendId)
        {
            if (!_panel.IsShown || friendId != _shownFriendId) return;
            if (_avatarCache.TryGetAvatar(friendId, out var avatar)) ShowAvatar(avatar);
        }

        private void ShowAvatar(Texture avatar)
        {
            bool hasAvatar = avatar != null;
            _avatarImage.texture = hasAvatar ? avatar : _placeholderAvatar;
            _avatarImage.color = hasAvatar ? Color.white : _placeholderAvatarColor;
        }

        private void StartExpiring()
        {
            StopExpiring();
            _expireCTS = new();
            Expire(_expireCTS.Token).Forget();
        }

        private void StopExpiring()
        {
            _expireCTS?.Cancel();
            _expireCTS?.Dispose();
            _expireCTS = null;
        }

        // an unanswered invite counts as declined; the menus run in real time
        private async UniTaskVoid Expire(CancellationToken token)
        {
            await UniTask.WaitForSeconds(_expireAfterInSeconds, ignoreTimeScale: true, cancellationToken: token);
            _state.Decline();
        }

        private void OnDestroy()
        {
            StopExpiring();
            _state.OnCurrentChanged -= Refresh;
            _avatarCache.OnAvatarLoaded -= HandleAvatarLoaded;
            _acceptButton.onClick.RemoveListener(_state.Accept);
            _declineButton.onClick.RemoveListener(_state.Decline);
        }
    }
}
