using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // One choice in an OptionList: a button with a label that tints itself when selected,
    // plus an optional detail text (e.g. a count badge) that hides itself while empty
    public class OptionButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Image _background;
        // optional; the object shown or hidden with the detail, e.g. a badge around the text
        [SerializeField] private TMP_Text _detailText;
        [SerializeField] private GameObject _detailRoot;
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
            ChangeLabel(label);
        }

        public void ChangeLabel(string label) => _label.text = label;

        public void ChangeDetail(string detail)
        {
            if (_detailText == null) return;

            _detailText.text = detail;
            var detailRoot = _detailRoot != null ? _detailRoot : _detailText.gameObject;
            detailRoot.SetActive(!string.IsNullOrEmpty(detail));
        }

        public void ToggleSelected(bool isSelected) => _background.color = isSelected ? _selectedColor : _normalColor;

        // gives keyboard/gamepad navigation a starting point
        public void Focus() => _button.Select();

        private void HandleClicked() => OnClicked?.Invoke(_id);

        private void OnDestroy() => _button.onClick.RemoveListener(HandleClicked);
    }
}
