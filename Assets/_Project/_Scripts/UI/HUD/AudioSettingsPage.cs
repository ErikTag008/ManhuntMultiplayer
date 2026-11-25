using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.Shared;
using Project.Assets._Project._Scripts.Voice;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Audio tab: master, music, SFX, UI and voice volume, shown in percent, the microphone and push-to-talk switches,
    // and a mute switch per player whose voice can be heard (none outside a session). Moving the Effects or Interface slider
    // plays a sample through that slider's mixer group, so the new level can be heard.
    public class AudioSettingsPage : MonoBehaviour
    {
        private const float PercentScale = 100f;

        [Inject] private readonly GameSettingsService _settings;
        [Inject] private readonly VoiceMuteList _muteList;
        [SerializeField] private Transform _container;
        [SerializeField] private SliderRow _sliderRowPrefab;
        [SerializeField] private ToggleRow _toggleRowPrefab;
        [SerializeField] private VolumePreviewData _previewData;
        // routed to the SFX and UI mixer groups
        [SerializeField] private AudioSource _effectsPreviewSource;
        [SerializeField] private AudioSource _interfacePreviewSource;
        [SerializeField] private string _masterLabel = "Master";
        [SerializeField] private string _musicLabel = "Music";
        [SerializeField] private string _sfxLabel = "Effects";
        [SerializeField] private string _uiLabel = "Interface";
        [SerializeField] private string _voiceLabel = "Voice";
        [SerializeField] private string _micLabel = "Microphone";
        [SerializeField] private string _pushToTalkLabel = "Push to talk";
        // {0} is the player's name
        [SerializeField] private string _muteLabelFormat = "Mute {0}";
        [SerializeField] private string _percentFormat = "{0:0}%";

        private readonly List<ToggleRow> _muteRows = new();
        private SliderRow _masterRow;
        private SliderRow _musicRow;
        private SliderRow _sfxRow;
        private SliderRow _uiRow;
        private SliderRow _voiceRow;
        private ToggleRow _micRow;
        private ToggleRow _pushToTalkRow;
        private bool _isBuilt;
        private float _nextPreviewTime;

        private void OnEnable()
        {
            if (!_isBuilt) Build();
            _settings.OnChanged += HandleSettingsChanged;
            _muteList.OnPeersChanged += RebuildMuteRows;
            Refresh();
            RebuildMuteRows();
        }

        private void Build()
        {
            _isBuilt = true;
            _masterRow = CreateRow(_masterLabel, (values, volume) => values.MasterVolume = volume);
            _musicRow = CreateRow(_musicLabel, (values, volume) => values.MusicVolume = volume);
            _sfxRow = CreateRow(_sfxLabel, (values, volume) => values.SfxVolume = volume);
            _sfxRow.OnValueChanged += _ => PlayPreview(_effectsPreviewSource, false);
            _uiRow = CreateRow(_uiLabel, (values, volume) => values.UiVolume = volume);
            _uiRow.OnValueChanged += _ => PlayPreview(_interfacePreviewSource, true);
            _voiceRow = CreateRow(_voiceLabel, (values, volume) => values.VoiceVolume = volume);
            _micRow = CreateToggleRow(_micLabel, (values, isOn) => values.IsMicOn = isOn);
            _pushToTalkRow = CreateToggleRow(_pushToTalkLabel, (values, isOn) => values.IsPushToTalk = isOn);
        }

        private SliderRow CreateRow(string label, Action<GameSettingsValues, float> apply)
        {
            var row = Instantiate(_sliderRowPrefab, _container);
            row.Setup(label, 0f, 1f, false, volume => string.Format(_percentFormat, volume * PercentScale));
            row.OnValueChanged += volume => _settings.Change(SettingsCategory.Audio, values => apply(values, volume));
            return row;
        }

        private ToggleRow CreateToggleRow(string label, Action<GameSettingsValues, bool> apply)
        {
            var row = Instantiate(_toggleRowPrefab, _container);
            row.Setup(label);
            row.OnToggled += isOn => _settings.Change(SettingsCategory.Audio, values => apply(values, isOn));
            return row;
        }

        // after the row's own handler, so the mixer already has the new level; rate-limited so a drag doesn't stack samples
        private void PlayPreview(AudioSource source, bool isInterface)
        {
            if (_previewData == null || source == null || Time.unscaledTime < _nextPreviewTime) return;

            var clip = isInterface ? _previewData.InterfaceSFX : _previewData.EffectsSFX;
            if (clip == null) return;

            _nextPreviewTime = Time.unscaledTime + _previewData.MinIntervalInSeconds;
            source.PlayOneShot(clip, isInterface ? _previewData.InterfaceSFXVolume : _previewData.EffectsSFXVolume);
        }

        // the mute rows always sit last, after the rows built once
        private void RebuildMuteRows()
        {
            foreach (var row in _muteRows) Destroy(row.gameObject);
            _muteRows.Clear();

            foreach (var peer in _muteList.Peers)
            {
                ulong clientId = peer.ClientId;
                var row = Instantiate(_toggleRowPrefab, _container);
                row.Setup(string.Format(_muteLabelFormat, peer.DisplayName));
                row.SetIsOnWithoutNotify(_muteList.IsMuted(clientId));
                row.OnToggled += isMuted => _muteList.SetMuted(clientId, isMuted);
                _muteRows.Add(row);
            }
        }

        private void HandleSettingsChanged(SettingsCategory category)
        {
            if (category == SettingsCategory.Audio) Refresh();
        }

        private void Refresh()
        {
            var values = _settings.Values;
            _masterRow.SetValueWithoutNotify(values.MasterVolume);
            _musicRow.SetValueWithoutNotify(values.MusicVolume);
            _sfxRow.SetValueWithoutNotify(values.SfxVolume);
            _uiRow.SetValueWithoutNotify(values.UiVolume);
            _voiceRow.SetValueWithoutNotify(values.VoiceVolume);
            _micRow.SetIsOnWithoutNotify(values.IsMicOn);
            _pushToTalkRow.SetIsOnWithoutNotify(values.IsPushToTalk);
        }

        private void OnDisable()
        {
            _settings.OnChanged -= HandleSettingsChanged;
            _muteList.OnPeersChanged -= RebuildMuteRows;
        }
    }
}
