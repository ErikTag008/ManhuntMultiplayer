using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Label plus two binding buttons (keyboard/mouse and gamepad); a column without a binding shows a fixed text and can't be clicked
    public class KeybindRow : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Button _keyboardButton;
        [SerializeField] private TMP_Text _keyboardText;
        [SerializeField] private Button _gamepadButton;
        [SerializeField] private TMP_Text _gamepadText;
        [SerializeField] private string _unavailableText = "-";

        public event Action OnKeyboardClicked;
        public event Action OnGamepadClicked;

        public Selectable Selectable => _keyboardButton;

        private void Awake()
        {
            _keyboardButton.onClick.AddListener(HandleKeyboardClicked);
            _gamepadButton.onClick.AddListener(HandleGamepadClicked);
        }

        public void Setup(string label) => _label.text = label;

        public void SetBindingTexts(string keyboardText, string gamepadText)
        {
            SetColumn(_keyboardButton, _keyboardText, keyboardText);
            SetColumn(_gamepadButton, _gamepadText, gamepadText);
        }

        public void Focus(bool isGamepad) => (isGamepad ? _gamepadButton : _keyboardButton).Select();

        private void SetColumn(Button button, TMP_Text text, string bindingText)
        {
            bool isAvailable = !string.IsNullOrEmpty(bindingText);
            button.interactable = isAvailable;
            text.text = isAvailable ? bindingText : _unavailableText;
        }

        private void HandleKeyboardClicked() => OnKeyboardClicked?.Invoke();

        private void HandleGamepadClicked() => OnGamepadClicked?.Invoke();

        private void OnDestroy()
        {
            _keyboardButton.onClick.RemoveListener(HandleKeyboardClicked);
            _gamepadButton.onClick.RemoveListener(HandleGamepadClicked);
        }
    }
}
