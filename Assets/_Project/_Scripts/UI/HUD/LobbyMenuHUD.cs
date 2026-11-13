using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Lobby menu: ability pick and ready-up, shown while the local player has the menu open
    public class LobbyMenuHUD : MonoBehaviour
    {
        [Inject] private readonly LobbyMenuState _state;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private OptionList _abilityList;
        [SerializeField] private Button _readyButton;
        [SerializeField] private TMP_Text _readyButtonLabel;
        [SerializeField] private Image _readyButtonImage;
        // the label says what clicking does; the colour says where you stand
        [SerializeField] private string _readyUpLabel = "Ready up";
        [SerializeField] private string _cancelReadyLabel = "You're ready\n<size=60%>click to cancel</size>";
        [SerializeField] private Color _notReadyColor = new(0.85f, 0.55f, 0.15f, 1f);
        [SerializeField] private Color _readyColor = new(0.2f, 0.6f, 0.3f, 1f);

        private readonly List<(int id, string label)> _optionBuffer = new();

        private void Start()
        {
            _state.OnOpenChanged += HandleOpenChanged;
            _state.OnAbilityOptionsChanged += HandleAbilityOptionsChanged;
            _state.OnChoiceChanged += HandleChoiceChanged;
            _abilityList.OnOptionClicked += _state.RequestAbilityPick;
            _readyButton.onClick.AddListener(_state.RequestReadyToggle);
            // values set before this scene's UI started
            HandleAbilityOptionsChanged();
            HandleChoiceChanged();
            HandleOpenChanged(_state.IsOpen);
        }

        private void HandleOpenChanged(bool isOpen)
        {
            if (isOpen == _panel.IsShown) return;

            if (isOpen)
            {
                _panel.Show();
                // a gamepad has no cursor, so navigation needs a focused button to start from
                _abilityList.FocusSelected();
            }
            else
            {
                _panel.Hide();
            }
        }

        private void HandleAbilityOptionsChanged()
        {
            _optionBuffer.Clear();
            foreach (var option in _state.AbilityOptions) _optionBuffer.Add((option.Id, option.Label));
            _abilityList.Build(_optionBuffer);
        }

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
            _readyButton.onClick.RemoveListener(_state.RequestReadyToggle);
        }
    }
}
