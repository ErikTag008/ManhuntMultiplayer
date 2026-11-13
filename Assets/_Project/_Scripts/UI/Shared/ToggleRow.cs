using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Label and an on/off toggle in one row
    public class ToggleRow : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Toggle _toggle;

        public event Action<bool> OnToggled;

        public Selectable Selectable => _toggle;

        private void Awake() => _toggle.onValueChanged.AddListener(HandleToggled);

        public void Setup(string label) => _label.text = label;

        public void SetIsOnWithoutNotify(bool isOn) => _toggle.SetIsOnWithoutNotify(isOn);

        private void HandleToggled(bool isOn) => OnToggled?.Invoke(isOn);

        private void OnDestroy() => _toggle.onValueChanged.RemoveListener(HandleToggled);
    }
}
