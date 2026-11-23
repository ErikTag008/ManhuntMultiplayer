using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // One entry of a friend list: avatar, name and status texts next to an action button that reports the row's index
    public class FriendInviteRow : MonoBehaviour
    {
        [SerializeField] private RawImage _avatarImage;
        // shown until the friend's avatar has loaded, and for friends without one
        [SerializeField] private Texture _placeholderAvatar;
        [SerializeField] private Color _placeholderAvatarColor = new(1f, 1f, 1f, 0.15f);
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _statusText;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _buttonLabel;

        public event Action<int> OnClicked;

        private int _index;

        public Selectable Selectable => _button;

        private void Awake() => _button.onClick.AddListener(HandleClicked);

        public void Setup(int index, string friendName, string status, string buttonLabel, bool isInteractable)
        {
            _index = index;
            _nameText.text = friendName;
            _statusText.text = status;
            _buttonLabel.text = buttonLabel;
            _button.interactable = isInteractable;
        }

        public void ChangeAvatar(Texture avatar)
        {
            bool hasAvatar = avatar != null;
            _avatarImage.texture = hasAvatar ? avatar : _placeholderAvatar;
            _avatarImage.color = hasAvatar ? Color.white : _placeholderAvatarColor;
        }

        private void HandleClicked() => OnClicked?.Invoke(_index);

        private void OnDestroy() => _button.onClick.RemoveListener(HandleClicked);
    }
}
