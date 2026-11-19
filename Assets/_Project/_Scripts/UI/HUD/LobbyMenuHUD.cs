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
        // {0} is the map name, {1} its vote count
        [SerializeField] private string _mapVoteLabelFormat = "{0}  <size=75%>({1})</size>";
        [SerializeField] private Button _readyButton;
        [SerializeField] private TMP_Text _readyButtonLabel;
        [SerializeField] private Image _readyButtonImage;
        [SerializeField] private Button _customizeButton;
        // optional: shown only when the session can invite friends (Steam)
        [SerializeField] private Button _inviteFriendsButton;
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
        // the label says what clicking does; the colour says where you stand
        [SerializeField] private string _readyUpLabel = "Ready up";
        [SerializeField] private string _cancelReadyLabel = "You're ready\n<size=60%>click to cancel</size>";
        [SerializeField] private Color _notReadyColor = new(0.85f, 0.55f, 0.15f, 1f);
        [SerializeField] private Color _readyColor = new(0.2f, 0.6f, 0.3f, 1f);

        private readonly List<(int id, string label)> _optionBuffer = new();
        private CancellationTokenSource _copiedLabelCTS;

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
            if (_inviteFriendsButton != null) _inviteFriendsButton.onClick.AddListener(_connectionService.OpenInviteDialog);
            if (_copyJoinCodeButton != null) _copyJoinCodeButton.onClick.AddListener(CopyJoinCode);
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
            }
        }

        private void OpenCustomize() => _state.ToggleCustomizeOpen(true);

        private void RefreshInviteButton()
        {
            if (_inviteFriendsButton == null) return;
            _inviteFriendsButton.gameObject.SetActive(_connectionService.CanInviteFriends);
        }

        private void RefreshJoinCode()
        {
            if (_joinCodeGroup == null || _joinCodeText == null || _copyJoinCodeButtonLabel == null) return;

            var joinCode = _connectionService.JoinCode;
            _joinCodeGroup.SetActive(!string.IsNullOrEmpty(joinCode));
            if (string.IsNullOrEmpty(joinCode)) return;

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
                _optionBuffer.Add((option.Id, FormatMapLabel(option.Label, VoteCountAt(i))));
            }

            _mapVoteList.Build(_optionBuffer);
            _mapVotePanel.SetActive(_state.MapOptions.Count > 1);
            HandleMapVotesChanged();
        }

        private void HandleMapVotesChanged()
        {
            for (int i = 0; i < _state.MapOptions.Count; i++)
            {
                var option = _state.MapOptions[i];
                _mapVoteList.ChangeLabel(option.Id, FormatMapLabel(option.Label, VoteCountAt(i)));
            }

            _mapVoteList.Select(_state.MapVote);
        }

        private int VoteCountAt(int index) => index < _state.MapVoteCounts.Count ? _state.MapVoteCounts[index] : 0;

        private string FormatMapLabel(string mapName, int voteCount) => string.Format(_mapVoteLabelFormat, mapName, voteCount);

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
            if (_inviteFriendsButton != null) _inviteFriendsButton.onClick.RemoveListener(_connectionService.OpenInviteDialog);
            if (_copyJoinCodeButton != null) _copyJoinCodeButton.onClick.RemoveListener(CopyJoinCode);
            StopCopiedLabel();
        }
    }
}
