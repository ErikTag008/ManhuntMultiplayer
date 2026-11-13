using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Generic single-choice list: builds one OptionButton per option under its container and highlights the selected one
    public class OptionList : MonoBehaviour
    {
        [SerializeField] private OptionButton _buttonPrefab;
        [SerializeField] private Transform _container;

        public event Action<int> OnOptionClicked;

        private readonly List<OptionButton> _buttons = new();
        private int _selectedId;

        public void Build(IReadOnlyList<(int id, string label)> options)
        {
            Clear();
            foreach (var (id, label) in options)
            {
                var button = Instantiate(_buttonPrefab, _container);
                button.Setup(id, label);
                button.OnClicked += HandleButtonClicked;
                _buttons.Add(button);
            }

            Select(_selectedId);
        }

        public void Select(int id)
        {
            _selectedId = id;
            foreach (var button in _buttons) button.ToggleSelected(button.Id == id);
        }

        // focuses the selected option, or the first one, so a gamepad can navigate from it
        public void FocusSelected()
        {
            if (_buttons.Count == 0) return;

            var target = _buttons.Find(button => button.Id == _selectedId) ?? _buttons[0];
            target.Focus();
        }

        private void HandleButtonClicked(int id) => OnOptionClicked?.Invoke(id);

        private void Clear()
        {
            foreach (var button in _buttons)
            {
                if (button == null) continue;

                button.OnClicked -= HandleButtonClicked;
                Destroy(button.gameObject);
            }

            _buttons.Clear();
        }

        private void OnDestroy() => Clear();
    }
}
