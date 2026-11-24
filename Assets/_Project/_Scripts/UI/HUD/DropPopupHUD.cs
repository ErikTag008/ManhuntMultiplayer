using DG.Tweening;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // A short popup near the screen centre when this runner takes a drop: the effect's name in its good/bad colour and what it does.
    // A new pickup replaces the one showing.
    public class DropPopupHUD : MonoBehaviour
    {
        [Inject] private readonly GameHUDState _state;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _descriptionText;
        [SerializeField] private Color _goodDropColor = new(0.45f, 0.9f, 0.45f, 1f);
        [SerializeField] private Color _badDropColor = new(1f, 0.4f, 0.35f, 1f);
        [SerializeField, Min(0f)] private float _shownDurationInSeconds = 2.5f;

        private Tween _hideTween;

        private void Start() => _state.OnDropTaken += HandleDropTaken;

        private void HandleDropTaken(string effectName, string description, bool isGood)
        {
            _nameText.text = effectName;
            _nameText.color = isGood ? _goodDropColor : _badDropColor;
            _descriptionText.text = description;
            _panel.Show();
            _hideTween?.Kill();
            _hideTween = DOVirtual.DelayedCall(_shownDurationInSeconds, _panel.Hide);
        }

        private void OnDestroy()
        {
            _state.OnDropTaken -= HandleDropTaken;
            _hideTween?.Kill();
        }
    }
}
