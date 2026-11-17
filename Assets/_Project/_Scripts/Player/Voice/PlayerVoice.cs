using KBCore.Refs;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.Voice;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.Player.Voice
{
    // Proximity voice: the owner sends its captured voice to the server, which relays it to everyone allowed to hear it,
    // and every other instance plays it from this player's Voice source (3D while alive, 2D for ghosts and spectators).
    // The living are heard by everyone; the eliminated only by the eliminated.
    [RequireComponent(typeof(PlayerController), typeof(PlayerLifeState), typeof(InputReader))]
    public class PlayerVoice : NetworkBehaviour
    {
        // the streaming clip loops forever, so its length only sets how often Unity asks for more
        private const int ClipLengthInSeconds = 1;
        private const int MonoChannels = 1;

        // injected by PlayerController.Awake together with the rest of the player
        [Inject] private readonly IVoiceChat _voiceChat;
        [Inject] private readonly VoiceMuteList _muteList;
        [Inject] private readonly GameSettingsService _gameSettings;
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private VoiceSettings _settings;

        // Server only
        private readonly List<ulong> _listenerBuffer = new();
        private VoicePlaybackBuffer _playbackBuffer;
        private AudioClip _clip;
        // Owner only
        private InputAction _pushToTalkAction;
        private bool _isRecording;
        private float _nextReadTime;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            _audioSource.playOnAwake = false;
            _audioSource.loop = true;
            _audioSource.rolloffMode = AudioRolloffMode.Linear;
            _audioSource.minDistance = _settings.MinDistanceInMeters;
            _audioSource.maxDistance = _settings.MaxDistanceInMeters;

            if (IsOwner)
            {
                _pushToTalkAction = _inputReader.Actions != null ? _inputReader.Actions.FindAction(_settings.PushToTalkActionName) : null;
                if (_pushToTalkAction == null) EUtils.Logger.LogWarning($"[PlayerVoice] No '{_settings.PushToTalkActionName}' input action; push to talk never sends.");
                return;
            }

            _sessionDirectory.OnSessionChanged += HandleSessionChanged;
            _muteList.Register(OwnerClientId, GetDisplayName());
        }

        // Owner only: records while the mic is allowed, and sends what Steam captured on a short interval
        private void Update()
        {
            if (!IsSpawned || !IsOwner) return;

            ToggleRecording(ShouldRecord());
            if (!_voiceChat.IsAvailable || Time.unscaledTime < _nextReadTime) return;

            _nextReadTime = Time.unscaledTime + _settings.ReadIntervalInSeconds;
            // read even after recording stops, so the end of a sentence still goes out
            if (!_voiceChat.TryReadCompressed(out byte[] compressed)) return;

            if (compressed.Length > _settings.MaxUnreliablePayloadBytes) SendVoiceReliableRpc(compressed);
            else SendVoiceUnreliableRpc(compressed);

            if (_settings.IsLoopbackOn) PlayVoice(compressed, _settings.LoopbackSpatialBlend);
        }

        private bool ShouldRecord()
        {
            var values = _gameSettings.Values;
            if (!_voiceChat.IsAvailable || !values.IsMicOn) return false;

            return !values.IsPushToTalk || (_pushToTalkAction != null && _pushToTalkAction.IsPressed());
        }

        private void ToggleRecording(bool isRecording)
        {
            if (_isRecording == isRecording) return;

            _isRecording = isRecording;
            _voiceChat.SetRecording(isRecording);
        }

        [Rpc(SendTo.Server, Delivery = RpcDelivery.Unreliable, InvokePermission = RpcInvokePermission.Owner)]
        private void SendVoiceUnreliableRpc(byte[] compressed) => RelayVoice(compressed);

        [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Owner)]
        private void SendVoiceReliableRpc(byte[] compressed) => RelayVoice(compressed);

        // Server only: everyone but the speaker, and only the eliminated when the speaker is eliminated
        private void RelayVoice(byte[] compressed)
        {
            if (compressed == null || compressed.Length == 0) return;

            bool isSpeakerDead = _lifeState.IsEliminated;
            _listenerBuffer.Clear();
            foreach (ulong clientId in NetworkManager.ConnectedClientsIds)
            {
                if (clientId == OwnerClientId) continue;
                if (isSpeakerDead && !IsEliminated(clientId)) continue;

                _listenerBuffer.Add(clientId);
            }

            if (_listenerBuffer.Count == 0) return;

            var target = RpcTarget.Group(_listenerBuffer, RpcTargetUse.Temp);
            if (compressed.Length > _settings.MaxUnreliablePayloadBytes) PlayVoiceReliableRpc(compressed, isSpeakerDead, target);
            else PlayVoiceUnreliableRpc(compressed, isSpeakerDead, target);
        }

        // a player still joining has no session yet and counts as living
        private bool IsEliminated(ulong clientId) =>
            _sessionDirectory.TryGetSession(clientId, out var session) && session.LifeState == LifeState.Eliminated;

        [Rpc(SendTo.SpecifiedInParams, Delivery = RpcDelivery.Unreliable, InvokePermission = RpcInvokePermission.Server)]
        private void PlayVoiceUnreliableRpc(byte[] compressed, bool isSpeakerDead, RpcParams rpcParams) => PlayRemoteVoice(compressed, isSpeakerDead);

        [Rpc(SendTo.SpecifiedInParams, InvokePermission = RpcInvokePermission.Server)]
        private void PlayVoiceReliableRpc(byte[] compressed, bool isSpeakerDead, RpcParams rpcParams) => PlayRemoteVoice(compressed, isSpeakerDead);

        private void PlayRemoteVoice(byte[] compressed, bool isSpeakerDead)
        {
            if (IsOwner || _muteList.IsMuted(OwnerClientId)) return;
            PlayVoice(compressed, isSpeakerDead ? _settings.DeadSpatialBlend : _settings.LivingSpatialBlend);
        }

        private void PlayVoice(byte[] compressed, float spatialBlend)
        {
            if (!_voiceChat.TryDecompress(compressed, out ArraySegment<byte> pcm)) return;
            if (!TryStartPlayback()) return;

            _audioSource.spatialBlend = spatialBlend;
            _playbackBuffer.WritePcm16(pcm.Array, pcm.Offset, pcm.Count);
        }

        // the clip and buffer wait for the first voice, since the sample rate is the codec's
        private bool TryStartPlayback()
        {
            if (_clip == null)
            {
                int sampleRate = _voiceChat.SampleRate;
                if (sampleRate <= 0) return false;

                _playbackBuffer = new(Mathf.CeilToInt(sampleRate * _settings.MaxBufferedInSeconds), Mathf.CeilToInt(sampleRate * _settings.StartBufferInSeconds));
                _clip = AudioClip.Create(nameof(PlayerVoice), sampleRate * ClipLengthInSeconds, MonoChannels, sampleRate, true, _playbackBuffer.Read);
                _audioSource.clip = _clip;
            }

            if (!_audioSource.isPlaying) _audioSource.Play();
            return true;
        }

        private void HandleSessionChanged(PlayerSession session)
        {
            if (session.ClientId != OwnerClientId) return;
            _muteList.Register(OwnerClientId, GetDisplayName());
        }

        private string GetDisplayName()
        {
            if (_sessionDirectory.TryGetSession(OwnerClientId, out var session) && !session.DisplayName.IsEmpty) return session.DisplayName.ToString();
            return string.Format(_settings.UnknownPeerNameFormat, OwnerClientId);
        }

        private void StopPlayback()
        {
            if (_audioSource != null) _audioSource.Stop();
            _playbackBuffer?.Clear();
        }

        public override void OnNetworkDespawn()
        {
            StopPlayback();
            if (IsOwner)
            {
                ToggleRecording(false);
                _pushToTalkAction = null;
                return;
            }

            _sessionDirectory.OnSessionChanged -= HandleSessionChanged;
            _muteList.Unregister(OwnerClientId);
        }

        public override void OnDestroy()
        {
            if (_clip != null) Destroy(_clip);
            base.OnDestroy();
        }
    }
}
