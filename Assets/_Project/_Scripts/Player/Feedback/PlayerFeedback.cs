using KBCore.Refs;
using Project.Assets._Project._Scripts.Player.Abilities;
using Project.Assets._Project._Scripts.Player.Drops;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Feedback
{
    // Plays this player's knock, shield block, rescue, bleed-out, drop pickup and ability use feedback on every instance:
    // a 3D sound from the player (routed through the source's mixer group) and an optional particle burst at the body.
    [RequireComponent(typeof(PlayerLifeState), typeof(PlayerDropEffects), typeof(PlayerAbility))]
    public class PlayerFeedback : ValidatedMonoBehaviour
    {
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private PlayerDropEffects _dropEffects;
        [SerializeField, Self] private PlayerAbility _ability;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private PlayerFeedbackData _data;
        // bursts spawn this high above the player's feet, around the chest
        [SerializeField] private float _vfxHeight = 1f;

        private void Awake()
        {
            _lifeState.OnKnocked += HandleKnocked;
            _lifeState.OnRevived += HandleRevived;
            _lifeState.OnBledOut += HandleBledOut;
            _dropEffects.OnEffectTaken += HandleEffectTaken;
            _dropEffects.OnShieldBlocked += HandleShieldBlocked;
            _ability.OnAbilityUsed += HandleAbilityUsed;
        }

        private void HandleKnocked() => Play(_data.Knocked);

        private void HandleRevived() => Play(_data.Revived);

        private void HandleBledOut() => Play(_data.BledOut);

        private void HandleShieldBlocked() => Play(_data.ShieldBlocked);

        private void HandleEffectTaken(DropEffectData effect) => Play(effect.IsGood ? _data.GoodDropTaken : _data.BadDropTaken);

        private void HandleAbilityUsed(AbilityData ability) => Play(ability.UseFeedback.HasContent ? ability.UseFeedback : _data.AbilityUsed);

        private void Play(FeedbackCue cue)
        {
            var clip = cue.PickClip();
            if (clip != null)
            {
                _audioSource.pitch = cue.PickPitch();
                _audioSource.PlayOneShot(clip, cue.Volume);
            }

            if (cue.VfxPrefab == null || (_lifeState.IsOwner && !cue.IsVfxShownToOwner)) return;

            Instantiate(cue.VfxPrefab, transform.position + Vector3.up * _vfxHeight, Quaternion.identity);
        }

        private void OnDestroy()
        {
            _lifeState.OnKnocked -= HandleKnocked;
            _lifeState.OnRevived -= HandleRevived;
            _lifeState.OnBledOut -= HandleBledOut;
            _dropEffects.OnEffectTaken -= HandleEffectTaken;
            _dropEffects.OnShieldBlocked -= HandleShieldBlocked;
            _ability.OnAbilityUsed -= HandleAbilityUsed;
        }
    }
}
