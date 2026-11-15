using KBCore.Refs;
using Reflex.Attributes;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Stations
{
    // An in-scene objective. During the hunt, an Up runner holding Interact in range who isn't rescuing raises its progress;
    // several runners don't stack, and progress is kept when they stop. Completing it cuts the round timer once.
    // The server owns progress and completion; every instance plays the working loop.
    [RequireComponent(typeof(AudioSource))]
    public class Station : NetworkBehaviour
    {
        [Inject] private readonly StationSettings _settings;
        [Inject] private readonly StationDirectory _directory;
        [Inject] private readonly SpawnedPlayerDirectory _spawnedPlayers;
        [Inject] private readonly HuntPhase _huntPhase;
        [Inject] private readonly IRoundTimer _roundTimer;
        [SerializeField, Self] private AudioSource _audioSource;
        // the station's look while unfinished; swapped for the completed look if one is set
        [SerializeField] private GameObject _model;
        [SerializeField] private GameObject _completedModel;

        // 0..1
        private readonly NetworkVariable<float> _progress = new();
        private readonly NetworkVariable<bool> _isBeingWorked = new();
        private readonly NetworkVariable<bool> _isCompleted = new();

        public float Progress => _progress.Value;
        public bool IsBeingWorked => _isBeingWorked.Value;
        public bool IsCompleted => _isCompleted.Value;
        public bool IsWorkable => IsSpawned && !_isCompleted.Value && _huntPhase.IsActive;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            _isBeingWorked.OnValueChanged += HandleBeingWorkedChanged;
            _isCompleted.OnValueChanged += HandleCompletedChanged;
            _directory.Add(this);
            // the spawn values don't raise OnValueChanged
            RefreshActiveLoop();
            RefreshModel();
        }

        private void Update()
        {
            if (!IsSpawned || !IsServer) return;

            UpdateProgress();
        }

        public bool IsInRange(Vector3 position) =>
            (position - transform.position).sqrMagnitude <= _settings.InteractRange * _settings.InteractRange;

        // Server only
        private void UpdateProgress()
        {
            bool isBeingWorked = IsWorkable && IsAnyRunnerWorking();
            if (_isBeingWorked.Value != isBeingWorked) _isBeingWorked.Value = isBeingWorked;
            if (!isBeingWorked) return;

            float step = _settings.HoldDurationInSeconds > 0f ? Time.deltaTime / _settings.HoldDurationInSeconds : 1f;
            _progress.Value = Mathf.Clamp01(_progress.Value + step);
            if (_progress.Value >= 1f) Complete();
        }

        // Server only: a runner who is rescuing someone is busy with that instead
        private bool IsAnyRunnerWorking()
        {
            foreach (var player in _spawnedPlayers.Players)
            {
                if (player == null || player.Team != Team.Runner || !player.LifeState.IsUp) continue;
                if (!player.TryGetComponent(out PlayerRescue rescue) || !rescue.IsInteractHeld || rescue.IsRescuing) continue;
                if (IsInRange(player.transform.position)) return true;
            }

            return false;
        }

        // Server only
        private void Complete()
        {
            _isBeingWorked.Value = false;
            _isCompleted.Value = true;

            float appliedCutInSeconds = 0f;
            _roundTimer?.TryCutRoundTime(_settings.TimeCutInSeconds, _settings.MinRemainingInSeconds, out appliedCutInSeconds);
            NotifyCompletedRpc(appliedCutInSeconds);
        }

        // a one-off message for the HUD flash; the completed count itself comes from the synced flag
        [Rpc(SendTo.Everyone, InvokePermission = RpcInvokePermission.Server)]
        private void NotifyCompletedRpc(float appliedCutInSeconds) => _directory.NotifyCompleted(this, appliedCutInSeconds);

        private void HandleBeingWorkedChanged(bool _, bool __) => RefreshActiveLoop();

        private void HandleCompletedChanged(bool _, bool __) => RefreshModel();

        private void RefreshActiveLoop()
        {
            var clip = _settings.ActiveLoopSFX;
            if (!_isBeingWorked.Value || clip == null)
            {
                if (_audioSource.isPlaying) _audioSource.Stop();
                return;
            }

            if (_audioSource.isPlaying) return;

            _audioSource.clip = clip;
            _audioSource.volume = _settings.ActiveLoopSFXVolume;
            _audioSource.loop = true;
            _audioSource.Play();
        }

        private void RefreshModel()
        {
            if (_completedModel == null) return;

            _completedModel.SetActive(_isCompleted.Value);
            if (_model != null) _model.SetActive(!_isCompleted.Value);
        }

        public override void OnNetworkDespawn()
        {
            _isBeingWorked.OnValueChanged -= HandleBeingWorkedChanged;
            _isCompleted.OnValueChanged -= HandleCompletedChanged;
            _directory.Remove(this);
            _audioSource.Stop();
        }
    }
}
