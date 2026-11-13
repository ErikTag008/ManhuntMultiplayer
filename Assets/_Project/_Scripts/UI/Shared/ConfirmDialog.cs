using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Yes/no question on a fade panel; the callback runs only on confirm
    public class ConfirmDialog : MonoBehaviour
    {
        [SerializeField] private FadePanel _panel;
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _cancelButton;

        public event Action OnClosed;

        private Action _onConfirmed;

        public bool IsOpen => _panel.IsShown;

        private void Awake()
        {
            _confirmButton.onClick.AddListener(Confirm);
            _cancelButton.onClick.AddListener(Close);
        }

        // focus starts on cancel, so a stray gamepad press doesn't confirm
        public void Open(string message, Action onConfirmed)
        {
            _messageText.text = message;
            _onConfirmed = onConfirmed;
            _panel.Show();
            _cancelButton.Select();
        }

        public void Close()
        {
            if (!_panel.IsShown) return;

            _onConfirmed = null;
            _panel.Hide();
            OnClosed?.Invoke();
        }

        private void Confirm()
        {
            var onConfirmed = _onConfirmed;
            Close();
            onConfirmed?.Invoke();
        }

        private void OnDestroy()
        {
            _confirmButton.onClick.RemoveListener(Confirm);
            _cancelButton.onClick.RemoveListener(Close);
        }
    }
}
