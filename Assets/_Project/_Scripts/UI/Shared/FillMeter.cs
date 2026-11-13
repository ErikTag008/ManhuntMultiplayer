using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Generic meter: a filled Image (horizontal bar, radial ring...) and an optional label.
    // The fill method and look are set on the Image in the scene.
    public class FillMeter : MonoBehaviour
    {
        [SerializeField] private Image _fillImage;
        [SerializeField] private TMP_Text _label;

        public void SetValue(float normalizedValue) => _fillImage.fillAmount = Mathf.Clamp01(normalizedValue);

        public void SetLabel(string text)
        {
            if (_label == null || _label.text == text) return;
            _label.text = text;
        }
    }
}
