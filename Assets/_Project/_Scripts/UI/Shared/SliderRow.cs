using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Label, slider and value text in one row
    public class SliderRow : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _valueText;

        public event Action<float> OnValueChanged;

        private Func<float, string> _formatValue;

        public Selectable Selectable => _slider;

        private void Awake() => _slider.onValueChanged.AddListener(HandleSliderChanged);

        public void Setup(string label, float min, float max, bool isWholeNumbers, Func<float, string> formatValue)
        {
            _label.text = label;
            _formatValue = formatValue;
            _slider.minValue = min;
            _slider.maxValue = max;
            _slider.wholeNumbers = isWholeNumbers;
        }

        public void SetValueWithoutNotify(float value)
        {
            _slider.SetValueWithoutNotify(value);
            RefreshValueText();
        }

        private void HandleSliderChanged(float value)
        {
            RefreshValueText();
            OnValueChanged?.Invoke(value);
        }

        private void RefreshValueText() => _valueText.text = _formatValue != null ? _formatValue(_slider.value) : _slider.value.ToString();

        private void OnDestroy() => _slider.onValueChanged.RemoveListener(HandleSliderChanged);
    }
}
