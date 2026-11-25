using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        public void ChangeLabel(int id, string label)
        {
            var button = _buttons.Find(candidate => candidate.Id == id);
            if (button != null) button.ChangeLabel(label);
        }

        public void ChangeDetail(int id, string detail)
        {
            var button = _buttons.Find(candidate => candidate.Id == id);
            if (button != null) button.ChangeDetail(detail);
        }

        public void ChangePreview(int id, Texture preview)
        {
            var button = _buttons.Find(candidate => candidate.Id == id);
            if (button != null) button.ChangePreview(preview);
        }

        // focuses the selected option, or the first one, so a gamepad can navigate from it
        public void FocusSelected()
        {
            if (_buttons.Count == 0) return;

            var target = _buttons.Find(button => button.Id == _selectedId) ?? _buttons[0];
            target.Focus();
        }

        // the options left to right, as one navigation row
        public void AddSelectables(List<Selectable> row)
        {
            foreach (var button in _buttons) row.Add(button.Selectable);
        }

        // the options top to bottom, one navigation row each
        public void AddSelectableRows(List<List<Selectable>> rows)
        {
            foreach (var button in _buttons) rows.Add(new List<Selectable> { button.Selectable });
        }

        // the options as a grid filled left to right, a navigation row per columnCount options
        public void AddSelectableRows(List<List<Selectable>> rows, int columnCount)
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                if (i % columnCount == 0) rows.Add(new List<Selectable>());
                rows[^1].Add(_buttons[i].Selectable);
            }
        }

        public Selectable GetSelectedSelectable()
        {
            var target = _buttons.Find(button => button.Id == _selectedId);
            return target != null ? target.Selectable : null;
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
