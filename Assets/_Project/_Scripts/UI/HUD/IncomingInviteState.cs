using Project.Assets._Project._Scripts.Networking;
using System;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Lobby invites waiting for an answer, shown one at a time, oldest first. The popup answers; a session handler acts on Accept.
    public class IncomingInviteState
    {
        private readonly List<LobbyInvite> _invites = new();

        // the invite on screen changed; false when none is left
        public event Action OnCurrentChanged;
        public event Action<LobbyInvite> OnAccepted;

        public bool HasCurrent => _invites.Count > 0;

        public bool TryGetCurrent(out LobbyInvite invite)
        {
            invite = HasCurrent ? _invites[0] : default;
            return HasCurrent;
        }

        // a second invite to the same lobby replaces the waiting one instead of queueing a duplicate
        public void Add(LobbyInvite invite)
        {
            int index = _invites.FindIndex(waiting => waiting.LobbyId == invite.LobbyId);
            if (index >= 0)
            {
                _invites[index] = invite;
                if (index == 0) OnCurrentChanged?.Invoke();
                return;
            }

            _invites.Add(invite);
            if (_invites.Count == 1) OnCurrentChanged?.Invoke();
        }

        public void Decline()
        {
            if (!HasCurrent) return;

            _invites.RemoveAt(0);
            OnCurrentChanged?.Invoke();
        }

        // joining another lobby answers every other waiting invite too
        public void Accept()
        {
            if (!TryGetCurrent(out var invite)) return;

            _invites.Clear();
            OnCurrentChanged?.Invoke();
            OnAccepted?.Invoke(invite);
        }
    }
}
