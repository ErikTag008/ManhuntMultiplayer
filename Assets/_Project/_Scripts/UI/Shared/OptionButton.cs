using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // One choice in an OptionList: a button with a label that tints itself when selected
    public class OptionButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Image _background;
        [SerializeField] private Color _normalColor = new(0.15f, 0.15f, 0.2f, 0.87f);
        [SerializeField] private Color _selectedColor = new(0.2f, 0.6f, 0.3f, 1f);

        public event Action<int> OnClicked;

        private int _id;

        public int Id => _id;
        public Selectable Selectable => _button;

        private void Awake() => _button.onClick.AddListener(HandleClicked);

        public void Setup(int id, string label)
        {
            _id = id;
            _label.text = label;
        }

        public void ToggleSelected(bool isSelected) => _background.color = isSelected ? _selectedColor : _normalColor;

        // gives keyboard/gamepad navigation a starting point
        public void Focus() => _button.Select();

        private void HandleClicked() => OnClicked?.Invoke(_id);

        private void OnDestroy() => _button.onClick.RemoveListener(HandleClicked);
    }
}
