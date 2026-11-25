using Project.Assets._Project._Scripts.Settings;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Names the pad button that steps a tab row (LB on the left, RB on the right); shown only while a gamepad is in use
    public class TabStepHintText : MonoBehaviour
    {
        [Inject] private readonly MenuButtonInput _menuButtons;
        [Inject] private readonly ControlSchemeState _controlScheme;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private bool _isNextTab;
        // {0} is the button
        [SerializeField] private string _format = "{0}";

        private void Start()
        {
            _controlScheme.OnChanged += HandleControlSchemeChanged;
            Refresh();
        }

        private void HandleControlSchemeChanged(bool _) => Refresh();

        private void Refresh()
        {
            _text.enabled = _controlScheme.IsGamepad;
            _text.text = string.Format(_format, _isNextTab ? _menuButtons.NextTabText : _menuButtons.PreviousTabText);
        }

        private void OnDestroy() => _controlScheme.OnChanged -= HandleControlSchemeChanged;
    }
}
