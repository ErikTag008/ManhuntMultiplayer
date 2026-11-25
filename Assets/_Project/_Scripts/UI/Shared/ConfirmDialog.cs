using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Yes/no question on a fade panel; the callback runs only on confirm. A question may name its own buttons;
    // otherwise they keep the labels set on the prefab.
    public class ConfirmDialog : MonoBehaviour
    {
        [SerializeField] private FadePanel _panel;
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _cancelButton;
        [SerializeField] private TMP_Text _confirmLabel;
        [SerializeField] private TMP_Text _cancelLabel;

        public event Action OnClosed;

        private Action _onConfirmed;
        private string _defaultConfirmLabel;
        private string _defaultCancelLabel;

        public bool IsOpen => _panel.IsShown;

        private void Awake()
        {
            _confirmButton.onClick.AddListener(Confirm);
            _cancelButton.onClick.AddListener(Close);
            _defaultConfirmLabel = _confirmLabel.text;
            _defaultCancelLabel = _cancelLabel.text;
        }

        // focus starts on cancel, so a stray gamepad press doesn't confirm
        public void Open(string message, Action onConfirmed, string confirmLabel = null, string cancelLabel = null)
        {
            _messageText.text = message;
            _confirmLabel.text = confirmLabel ?? _defaultConfirmLabel;
            _cancelLabel.text = cancelLabel ?? _defaultCancelLabel;
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
