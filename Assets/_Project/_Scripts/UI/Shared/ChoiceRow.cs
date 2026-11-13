using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Label with previous/next arrows that step through a list of options; wraps around at both ends
    public class ChoiceRow : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private TMP_Text _valueText;
        [SerializeField] private Button _previousButton;
        [SerializeField] private Button _nextButton;

        public event Action<int> OnIndexChanged;

        private readonly List<string> _options = new();
        private int _index;

        public Selectable Selectable => _nextButton;

        private void Awake()
        {
            _previousButton.onClick.AddListener(SelectPrevious);
            _nextButton.onClick.AddListener(SelectNext);
        }

        public void Setup(string label, IReadOnlyList<string> options)
        {
            _label.text = label;
            _options.Clear();
            _options.AddRange(options);
            SetIndexWithoutNotify(_index);
        }

        public void SetIndexWithoutNotify(int index)
        {
            _index = _options.Count == 0 ? 0 : Mathf.Clamp(index, 0, _options.Count - 1);
            _valueText.text = _options.Count == 0 ? string.Empty : _options[_index];
        }

        private void SelectPrevious() => Step(-1);

        private void SelectNext() => Step(1);

        private void Step(int direction)
        {
            if (_options.Count == 0) return;

            SetIndexWithoutNotify((_index + direction + _options.Count) % _options.Count);
            OnIndexChanged?.Invoke(_index);
        }

        private void OnDestroy()
        {
            _previousButton.onClick.RemoveListener(SelectPrevious);
            _nextButton.onClick.RemoveListener(SelectNext);
        }
    }
}
