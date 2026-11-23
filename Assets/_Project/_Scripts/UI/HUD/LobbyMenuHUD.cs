using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Lobby menu: ability pick, map vote, ready-up, Customize, invites and the join code, shown while the local player has the menu
    // open and the Customize screen doesn't cover it
    public class LobbyMenuHUD : MonoBehaviour
    {
        [Inject] private readonly LobbyMenuState _state;
        [Inject] private readonly IConnectionService _connectionService;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private OptionList _abilityList;
        // hidden while there is only one map to vote for
        [SerializeField] private GameObject _mapVotePanel;
        [SerializeField] private OptionList _mapVoteList;
        // {0} is the vote count; no votes shows no badge
        [SerializeField] private string _singleVoteFormat = "{0} vote";
        [SerializeField] private string _multipleVotesFormat = "{0} votes";
        [SerializeField] private Button _readyButton;
        [SerializeField] private TMP_Text _readyButtonLabel;
        [SerializeField] private Image _readyButtonImage;
        [SerializeField] private Button _customizeButton;
        // optional: shown only when the session can invite friends (Steam)
        [SerializeField] private Button _inviteFriendsButton;
        [SerializeField] private TMP_Text _inviteFriendsButtonLabel;
        [SerializeField] private string _inviteFriendsLabel = "Invite friends";
        // optional: the in-game invite list; without it the platform invite dialog opens instead
        [SerializeField] private FriendInviteHUD _friendInvite;
        // shown on the button for a moment when the invite dialog can't open and there is no in-game list
        [SerializeField] private string _inviteUnavailableLabel = "Overlay unavailable\n<size=60%>share the join code</size>";
        [SerializeField, Min(0f)] private float _inviteUnavailableLabelDurationInSeconds = 3f;
        // optional: shown only when the session has a join code (Steam)
        [SerializeField] private GameObject _joinCodeGroup;
        [SerializeField] private TMP_Text _joinCodeText;
        [SerializeField] private Button _copyJoinCodeButton;
        [SerializeField] private TMP_Text _copyJoinCodeButtonLabel;
        // {0} is the join code
        [SerializeField] private string _joinCodeFormat = "Code: {0}";
        [SerializeField] private string _copyLabel = "Copy";
        [SerializeField] private string _copiedLabel = "Copied!";
        [SerializeField, Min(0f)] private float _copiedLabelDurationInSeconds = 1.5f;
        // optional: shown with the join code when the platform status hides the game from friends (Steam Invisible)
        [SerializeField] private GameObject _hiddenFromFriendsHint;
        // stays on screen outside the panel, so walking players know how to get the menu back; hidden under Customize,
        // which has its own hint. {0} is the key
        [SerializeField] private KeyHintText _menuToggleHint;
        [SerializeField] private string _walkAroundHintFormat = "{0}: walk around";
        [SerializeField] private string _openMenuHintFormat = "{0}: open lobby menu";
        // the label says what clicking does; the colour says where you stand
        [SerializeField] private string _readyUpLabel = "Ready up";
        [SerializeField] private string _cancelReadyLabel = "You're ready\n<size=60%>click to cancel</size>";
        [SerializeField] private Color _notReadyColor = new(0.85f, 0.55f, 0.15f, 1f);
        [SerializeField] private Color _readyColor = new(0.2f, 0.6f, 0.3f, 1f);

        private readonly List<(int id, string label)> _optionBuffer = new();
        private CancellationTokenSource _copiedLabelCTS;
        private CancellationTokenSource _inviteUnavailableLabelCTS;

        private void Start()
        {
            _state.OnOpenChanged += HandleOpenChanged;
            _state.OnAbilityOptionsChanged += HandleAbilityOptionsChanged;
            _state.OnChoiceChanged += HandleChoiceChanged;
            _abilityList.OnOptionClicked += _state.RequestAbilityPick;
            _state.OnMapOptionsChanged += HandleMapOptionsChanged;
            _state.OnMapVotesChanged += HandleMapVotesChanged;
            _mapVoteList.OnOptionClicked += _state.RequestMapVote;
            _readyButton.onClick.AddListener(_state.RequestReadyToggle);
            _state.OnCustomizeOpenChanged += HandleCustomizeOpenChanged;
            _customizeButton.onClick.AddListener(OpenCustomize);
            if (_inviteFriendsButton != null) _inviteFriendsButton.onClick.AddListener(InviteFriends);
            if (_copyJoinCodeButton != null) _copyJoinCodeButton.onClick.AddListener(CopyJoinCode);
            if (_friendInvite != null) _friendInvite.OnClosed += HandleFriendInviteClosed;
            RefreshInviteButton();
            RefreshJoinCode();
            // values set before this scene's UI started
            HandleAbilityOptionsChanged();
            HandleChoiceChanged();
            HandleMapOptionsChanged();
            HandleOpenChanged(_state.IsOpen);
        }

        private void HandleOpenChanged(bool _) => RefreshPanel(_abilityList.FocusSelected);

        // back from Customize, focus returns to the button that opened it
        private void HandleCustomizeOpenChanged(bool _) => RefreshPanel(_customizeButton.Select);

        private void RefreshPanel(Action focus)
        {
            bool isShown = _state.IsOpen && !_state.IsCustomizeOpen;
            RefreshMenuToggleHint(isShown);
            if (isShown == _panel.IsShown) return;

            if (isShown)
            {
                RefreshInviteButton();
                RefreshJoinCode();
                _panel.Show();
                // a gamepad has no cursor, so navigation needs a focused button to start from
                focus();
            }
            else
            {
                _panel.Hide();
                if (_friendInvite != null) _friendInvite.Close();
            }
        }

        private void RefreshMenuToggleHint(bool isPanelShown)
        {
            if (_menuToggleHint == null) return;

            _menuToggleHint.gameObject.SetActive(!_state.IsCustomizeOpen);
            _menuToggleHint.ChangeFormat(isPanelShown ? _walkAroundHintFormat : _openMenuHintFormat);
        }

        private void OpenCustomize() => _state.ToggleCustomizeOpen(true);

        private void RefreshInviteButton()
        {
            if (_inviteFriendsButton == null) return;
            _inviteFriendsButton.gameObject.SetActive(_connectionService.CanInviteFriends);
            StopInviteUnavailableLabel();
            if (_inviteFriendsButtonLabel != null) _inviteFriendsButtonLabel.text = _inviteFriendsLabel;
        }

        private void InviteFriends()
        {
            if (_friendInvite != null)
            {
                _friendInvite.Open();
                return;
            }
            if (_connectionService.TryOpenInviteDialog()) return;
            if (_inviteFriendsButtonLabel == null) return;

            StopInviteUnavailableLabel();
            _inviteUnavailableLabelCTS = new();
            ShowInviteUnavailableLabel(_inviteUnavailableLabelCTS.Token).Forget();
        }

        // focus goes back to the button that opened the list, unless the menu closed with it
        private void HandleFriendInviteClosed()
        {
            if (_panel.IsShown && _inviteFriendsButton != null && _inviteFriendsButton.gameObject.activeInHierarchy) _inviteFriendsButton.Select();
        }

        // the menu runs in real time
        private async UniTaskVoid ShowInviteUnavailableLabel(CancellationToken token)
        {
            _inviteFriendsButtonLabel.text = _inviteUnavailableLabel;
            await UniTask.WaitForSeconds(_inviteUnavailableLabelDurationInSeconds, ignoreTimeScale: true, cancellationToken: token);
            _inviteFriendsButtonLabel.text = _inviteFriendsLabel;
        }

        private void StopInviteUnavailableLabel()
        {
            _inviteUnavailableLabelCTS?.Cancel();
            _inviteUnavailableLabelCTS?.Dispose();
            _inviteUnavailableLabelCTS = null;
        }

        private void RefreshJoinCode()
        {
            if (_joinCodeGroup == null || _joinCodeText == null || _copyJoinCodeButtonLabel == null) return;

            var joinCode = _connectionService.JoinCode;
            bool hasJoinCode = !string.IsNullOrEmpty(joinCode);
            _joinCodeGroup.SetActive(hasJoinCode);
            // read when the menu opens; a status change while it's open shows next time
            if (_hiddenFromFriendsHint != null) _hiddenFromFriendsHint.SetActive(hasJoinCode && _connectionService.IsHiddenFromFriends);
            if (!hasJoinCode) return;

            _joinCodeText.text = string.Format(_joinCodeFormat, joinCode);
            StopCopiedLabel();
            _copyJoinCodeButtonLabel.text = _copyLabel;
        }

        private void CopyJoinCode()
        {
            var joinCode = _connectionService.JoinCode;
            if (string.IsNullOrEmpty(joinCode) || _copyJoinCodeButtonLabel == null) return;

            GUIUtility.systemCopyBuffer = joinCode;
            StopCopiedLabel();
            _copiedLabelCTS = new();
            ShowCopiedLabel(_copiedLabelCTS.Token).Forget();
        }

        // the menu runs in real time
        private async UniTaskVoid ShowCopiedLabel(CancellationToken token)
        {
            _copyJoinCodeButtonLabel.text = _copiedLabel;
            await UniTask.WaitForSeconds(_copiedLabelDurationInSeconds, ignoreTimeScale: true, cancellationToken: token);
            _copyJoinCodeButtonLabel.text = _copyLabel;
        }

        private void StopCopiedLabel()
        {
            _copiedLabelCTS?.Cancel();
            _copiedLabelCTS?.Dispose();
            _copiedLabelCTS = null;
        }

        private void HandleAbilityOptionsChanged()
        {
            _optionBuffer.Clear();
            foreach (var option in _state.AbilityOptions) _optionBuffer.Add((option.Id, option.Label));
            _abilityList.Build(_optionBuffer);
        }

        private void HandleMapOptionsChanged()
        {
            _optionBuffer.Clear();
            for (int i = 0; i < _state.MapOptions.Count; i++)
            {
                var option = _state.MapOptions[i];
                _optionBuffer.Add((option.Id, option.Label));
            }

            _mapVoteList.Build(_optionBuffer);
            foreach (var option in _state.MapOptions) _mapVoteList.ChangePreview(option.Id, option.Preview);
            _mapVotePanel.SetActive(_state.MapOptions.Count > 1);
            HandleMapVotesChanged();
        }

        private void HandleMapVotesChanged()
        {
            for (int i = 0; i < _state.MapOptions.Count; i++)
            {
                var option = _state.MapOptions[i];
                _mapVoteList.ChangeDetail(option.Id, FormatVoteCount(VoteCountAt(i)));
            }

            _mapVoteList.Select(_state.MapVote);
        }

        private int VoteCountAt(int index) => index < _state.MapVoteCounts.Count ? _state.MapVoteCounts[index] : 0;

        private string FormatVoteCount(int voteCount) => voteCount switch
        {
            0 => string.Empty,
            1 => string.Format(_singleVoteFormat, voteCount),
            _ => string.Format(_multipleVotesFormat, voteCount)
        };

        private void HandleChoiceChanged()
        {
            _abilityList.Select(_state.SelectedAbilityId);
            _readyButtonLabel.text = _state.IsReady ? _cancelReadyLabel : _readyUpLabel;
            _readyButtonImage.color = _state.IsReady ? _readyColor : _notReadyColor;
        }

        private void OnDestroy()
        {
            _state.OnOpenChanged -= HandleOpenChanged;
            _state.OnAbilityOptionsChanged -= HandleAbilityOptionsChanged;
            _state.OnChoiceChanged -= HandleChoiceChanged;
            _abilityList.OnOptionClicked -= _state.RequestAbilityPick;
            _state.OnMapOptionsChanged -= HandleMapOptionsChanged;
            _state.OnMapVotesChanged -= HandleMapVotesChanged;
            _mapVoteList.OnOptionClicked -= _state.RequestMapVote;
            _readyButton.onClick.RemoveListener(_state.RequestReadyToggle);
            _state.OnCustomizeOpenChanged -= HandleCustomizeOpenChanged;
            _customizeButton.onClick.RemoveListener(OpenCustomize);
            if (_inviteFriendsButton != null) _inviteFriendsButton.onClick.RemoveListener(InviteFriends);
            if (_copyJoinCodeButton != null) _copyJoinCodeButton.onClick.RemoveListener(CopyJoinCode);
            if (_friendInvite != null) _friendInvite.OnClosed -= HandleFriendInviteClosed;
            StopCopiedLabel();
            StopInviteUnavailableLabel();
        }
    }
}
