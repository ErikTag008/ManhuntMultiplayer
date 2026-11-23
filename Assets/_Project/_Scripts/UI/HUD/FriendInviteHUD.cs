using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // In-game invite list over the lobby menu: online friends with an Invite button each, refreshed while open.
    // Sends invites without the platform overlay, which doesn't hook when the game isn't started by Steam.
    public class FriendInviteHUD : MonoBehaviour
    {
        [Inject] private readonly IConnectionService _connectionService;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private Transform _listContainer;
        [SerializeField] private FriendInviteRow _rowPrefab;
        [SerializeField] private Button _closeButton;
        [SerializeField] private TMP_Text _listStatusText;
        [SerializeField, Min(0.5f)] private float _refreshIntervalInSeconds = 5f;
        [SerializeField] private string _playingThisGameStatus = "In this game";
        [SerializeField] private string _onlineStatus = "Online";
        [SerializeField] private string _inviteLabel = "Invite";
        [SerializeField] private string _invitedLabel = "Invited";
        [SerializeField] private string _inviteFailedLabel = "Failed, retry";
        [SerializeField] private string _noFriendsText = "No friends online";

        public event Action OnClosed;

        private readonly List<InvitableFriend> _friends = new();
        private readonly List<FriendInviteRow> _rows = new();
        // what happened to each invite since the list opened; friends without an entry haven't been invited
        private readonly Dictionary<ulong, bool> _inviteResults = new();
        private readonly List<List<Selectable>> _navigationRows = new();
        private CancellationTokenSource _refreshCTS;

        public bool IsOpen => _panel.IsShown;

        private void Start() => _closeButton.onClick.AddListener(Close);

        public void Open()
        {
            if (_panel.IsShown) return;

            _inviteResults.Clear();
            _panel.Show();
            ShowFriends();
            // a gamepad has no cursor, so navigation needs a focused button to start from
            FocusFirst();
            StartRefreshing();
        }

        public void Close()
        {
            if (!_panel.IsShown) return;

            StopRefreshing();
            _panel.Hide();
            OnClosed?.Invoke();
        }

        private void StartRefreshing()
        {
            StopRefreshing();
            _refreshCTS = new();
            RefreshLoop(_refreshCTS.Token).Forget();
        }

        private void StopRefreshing()
        {
            _refreshCTS?.Cancel();
            _refreshCTS?.Dispose();
            _refreshCTS = null;
        }

        // friends come online, start the game or join the lobby while the list is open; the menu runs in real time
        private async UniTaskVoid RefreshLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await UniTask.WaitForSeconds(_refreshIntervalInSeconds, ignoreTimeScale: true, cancellationToken: token);
                ShowFriends();
            }
        }

        private void ShowFriends()
        {
            _connectionService.GetInvitableFriends(_friends);
            for (int i = 0; i < _friends.Count; i++)
            {
                var row = i < _rows.Count ? _rows[i] : CreateRow();
                ShowFriend(row, i, _friends[i]);
            }
            for (int i = _friends.Count; i < _rows.Count; i++) _rows[i].gameObject.SetActive(false);

            _listStatusText.gameObject.SetActive(_friends.Count == 0);
            _listStatusText.text = _noFriendsText;
            LinkNavigation();
            RestoreFocusIfLost();
        }

        private FriendInviteRow CreateRow()
        {
            var row = Instantiate(_rowPrefab, _listContainer);
            row.OnClicked += InviteFriend;
            _rows.Add(row);
            return row;
        }

        // an invited friend can't be invited again until the list reopens; a failed invite can be retried
        private void ShowFriend(FriendInviteRow row, int index, InvitableFriend friend)
        {
            bool hasResult = _inviteResults.TryGetValue(friend.Id, out bool isInvited);
            var status = friend.IsPlayingThisGame ? _playingThisGameStatus : _onlineStatus;
            var buttonLabel = !hasResult ? _inviteLabel : isInvited ? _invitedLabel : _inviteFailedLabel;
            row.gameObject.SetActive(true);
            row.Setup(index, friend.Name, status, buttonLabel, !isInvited);
        }

        private void InviteFriend(int index)
        {
            if (index < 0 || index >= _friends.Count) return;

            var friend = _friends[index];
            _inviteResults[friend.Id] = _connectionService.TryInviteFriend(friend.Id);
            ShowFriend(_rows[index], index, friend);
            LinkNavigation();
            // the clicked button turns off after a sent invite; a gamepad moves on to the next friend, not back to the top,
            // so a second press doesn't invite someone else by surprise
            if (!_rows[index].Selectable.interactable) FocusNear(index);
        }

        private void FocusNear(int index)
        {
            for (int i = index + 1; i < _friends.Count; i++)
            {
                if (!_rows[i].Selectable.interactable) continue;
                _rows[i].Selectable.Select();
                return;
            }
            for (int i = index - 1; i >= 0; i--)
            {
                if (!_rows[i].Selectable.interactable) continue;
                _rows[i].Selectable.Select();
                return;
            }

            _closeButton.Select();
        }

        // friend rows, then the close button; explicit links keep a gamepad inside the list while it covers the menu
        private void LinkNavigation()
        {
            _navigationRows.Clear();
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_listContainer);
            EUtils.UI.AddNavigationRows(_listContainer, _navigationRows);
            _navigationRows.Add(new List<Selectable> { _closeButton });
            EUtils.UI.LinkNavigation(_navigationRows);
        }

        private void RestoreFocusIfLost()
        {
            if (!_panel.IsShown) return;

            var eventSystem = EventSystem.current;
            if (eventSystem == null || IsUsable(eventSystem.currentSelectedGameObject)) return;

            FocusFirst();
        }

        private void FocusFirst()
        {
            var firstRow = _rows.Find(row => row.gameObject.activeInHierarchy && row.Selectable.interactable);
            if (firstRow != null) firstRow.Selectable.Select();
            else _closeButton.Select();
        }

        // inside this panel only: focus left on the lobby menu behind it counts as lost
        private bool IsUsable(GameObject target) =>
            target != null && target.activeInHierarchy && target.transform.IsChildOf(transform) &&
            (!target.TryGetComponent(out Selectable selectable) || selectable.interactable);

        private void OnDestroy()
        {
            StopRefreshing();
            _closeButton.onClick.RemoveListener(Close);
            foreach (var row in _rows) row.OnClicked -= InviteFriend;
        }
    }
}
