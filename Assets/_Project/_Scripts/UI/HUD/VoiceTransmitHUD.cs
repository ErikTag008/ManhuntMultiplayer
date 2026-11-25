using Reflex.Attributes;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Small mic icon on the local HUD while this player's mic sends voice, so push to talk gives feedback
    public class VoiceTransmitHUD : MonoBehaviour
    {
        [Inject] private readonly GameHUDState _state;
        [SerializeField] private GameObject _icon;

        private void Start()
        {
            _state.OnVoiceTransmittingChanged += HandleVoiceTransmittingChanged;
            HandleVoiceTransmittingChanged();
        }

        private void HandleVoiceTransmittingChanged() => _icon.SetActive(_state.IsVoiceTransmitting);

        private void OnDestroy() => _state.OnVoiceTransmittingChanged -= HandleVoiceTransmittingChanged;
    }
}
