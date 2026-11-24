using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Host-only page of the pause menu: the other players, each with a Kick button behind a confirm.
    // The confirm is the pause menu's own dialog, so it has to sit above this page in the hierarchy.
    public class PlayersMenuHUD : MonoBehaviour
    {
        [Inject] private readonly PlayersMenuState _state;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private Transform _listContainer;
        [SerializeField] private FriendInviteRow _rowPrefab;
        [SerializeField] private Button _closeButton;
        [SerializeField] private TMP_Text _listStatusText;
        [SerializeField] private ConfirmDialog _confirmDialog;
        [SerializeField] private string _kickLabel = "Kick";
        [SerializeField] private string _noPlayersText = "No other players";
        [SerializeField] private string _kickMessageFormat = "Kick {0}?\nThey can't rejoin until you host a new lobby.";

        public event Action OnClosed;

        private readonly List<FriendInviteRow> _rows = new();
        private readonly List<List<Selectable>> _navigationRows = new();
        // a player picked in the confirm, by client id, so the list changing under the dialog can't kick someone else
        private ulong _pendingKickClientId;

        public bool IsOpen => _panel.IsShown;

        private void Start()
        {
            _state.OnPlayersChanged += HandlePlayersChanged;
            _confirmDialog.OnClosed += HandleConfirmClosed;
            _closeButton.onClick.AddListener(Close);
        }

        public void Open()
        {
            if (_panel.IsShown) return;

            _panel.Show();
            ShowPlayers();
            // a gamepad has no cursor, so navigation needs a focused button to start from
            FocusFirst();
        }

        public void Close()
        {
            if (!_panel.IsShown) return;

            _confirmDialog.Close();
            _panel.Hide();
            OnClosed?.Invoke();
        }

        // the confirm sits on top of this page; back closes it before the page
        public void Back()
        {
            if (_confirmDialog.IsOpen) _confirmDialog.Close();
            else Close();
        }

        private void HandlePlayersChanged()
        {
            if (!_panel.IsShown) return;

            // hosting ended (e.g. the session closed) while the page was open
            if (!_state.CanKick)
            {
                Close();
                return;
            }

            ShowPlayers();
            if (!_confirmDialog.IsOpen) RestoreFocusIfLost();
        }

        private void ShowPlayers()
        {
            var players = _state.Players;
            for (int i = 0; i < players.Count; i++)
            {
                var row = i < _rows.Count ? _rows[i] : CreateRow();
                row.gameObject.SetActive(true);
                row.Setup(i, players[i].Name, string.Empty, _kickLabel, true);
                row.ChangeAvatar(null);
            }
            for (int i = players.Count; i < _rows.Count; i++) _rows[i].gameObject.SetActive(false);

            _listStatusText.gameObject.SetActive(players.Count == 0);
            _listStatusText.text = _noPlayersText;
            LinkNavigation();
        }

        private FriendInviteRow CreateRow()
        {
            var row = Instantiate(_rowPrefab, _listContainer);
            row.OnClicked += AskToKick;
            _rows.Add(row);
            return row;
        }

        private void AskToKick(int index)
        {
            var players = _state.Players;
            if (index < 0 || index >= players.Count) return;

            _pendingKickClientId = players[index].ClientId;
            _confirmDialog.Open(string.Format(_kickMessageFormat, players[index].Name), Kick);
        }

        private void Kick() => _state.RequestKick(_pendingKickClientId);

        private void HandleConfirmClosed()
        {
            if (_panel.IsShown) FocusFirst();
        }

        // player rows, then the close button; explicit links keep a gamepad inside the list while it covers the menu
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
            var eventSystem = EventSystem.current;
            if (eventSystem == null || IsUsable(eventSystem.currentSelectedGameObject)) return;

            FocusFirst();
        }

        private void FocusFirst()
        {
            var firstRow = _rows.Find(row => row.gameObject.activeInHierarchy);
            if (firstRow != null) firstRow.Selectable.Select();
            else _closeButton.Select();
        }

        // inside this page only: focus left on the pause menu behind it counts as lost
        private bool IsUsable(GameObject target) =>
            target != null && target.activeInHierarchy && target.transform.IsChildOf(transform);

        private void OnDestroy()
        {
            _state.OnPlayersChanged -= HandlePlayersChanged;
            _confirmDialog.OnClosed -= HandleConfirmClosed;
            _closeButton.onClick.RemoveListener(Close);
            foreach (var row in _rows) row.OnClicked -= AskToKick;
        }
    }
}
