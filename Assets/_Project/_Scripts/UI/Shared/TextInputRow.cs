using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Label and a text field in one row
    public class TextInputRow : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private TMP_InputField _inputField;

        public event Action<string> OnTextChanged;

        public string Text => _inputField.text;
        public Selectable Selectable => _inputField;

        private void Awake() => _inputField.onValueChanged.AddListener(HandleTextChanged);

        public void Setup(string label, string placeholder, int characterLimit)
        {
            _label.text = label;
            _inputField.characterLimit = characterLimit;
            if (_inputField.placeholder is TMP_Text placeholderText) placeholderText.text = placeholder;
        }

        public void SetTextWithoutNotify(string text) => _inputField.SetTextWithoutNotify(text);

        private void HandleTextChanged(string text) => OnTextChanged?.Invoke(text);

        private void OnDestroy() => _inputField.onValueChanged.RemoveListener(HandleTextChanged);
    }
}
