using Project.Assets._Project._Scripts.Settings;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Says how to turn a DragRotateArea: drag with the mouse, or its turn axis' current gamepad binding
    public class DragRotateHintText : MonoBehaviour
    {
        [Inject] private readonly ControlSchemeState _controlScheme;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private DragRotateArea _rotateArea;
        [SerializeField] private string _pointerHint = "Drag to rotate";
        // {0} is the turn binding, e.g. "LT/RT"
        [SerializeField] private string _gamepadHintFormat = "{0}: rotate";

        private void Start()
        {
            _controlScheme.OnChanged += HandleControlSchemeChanged;
            Refresh();
        }

        private void HandleControlSchemeChanged(bool _) => Refresh();

        private void Refresh() =>
            _text.text = _controlScheme.IsGamepad ? string.Format(_gamepadHintFormat, _rotateArea.TurnBindingText) : _pointerHint;

        private void OnDestroy() => _controlScheme.OnChanged -= HandleControlSchemeChanged;
    }
}
