using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Networking
{
    // Friends' profile pictures, loaded once per friend for the app's lifetime and shared by every screen that shows them
    public class FriendAvatarCache : IDisposable
    {
        private readonly IConnectionService _connectionService;
        private readonly Dictionary<ulong, Texture2D> _avatars = new();
        private readonly HashSet<ulong> _loadingIds = new();
        private readonly CancellationTokenSource _lifetimeCTS = new();

        // the friend's avatar finished loading; TryGetAvatar now returns it
        public event Action<ulong> OnAvatarLoaded;

        public FriendAvatarCache(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        // false while the avatar is still loading or the friend has none; a load starts on the first ask, and a failed one on the next
        public bool TryGetAvatar(ulong friendId, out Texture2D avatar)
        {
            if (_avatars.TryGetValue(friendId, out avatar)) return true;

            if (_loadingIds.Add(friendId)) Load(friendId, _lifetimeCTS.Token).Forget();
            return false;
        }

        private async UniTaskVoid Load(ulong friendId, CancellationToken token)
        {
            Texture2D avatar = null;
            try
            {
                avatar = await _connectionService.LoadFriendAvatar(friendId, token);
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (Exception exception)
            {
                EUtils.Logger.LogWarning($"[FriendAvatarCache] Avatar of {friendId} failed to load: {exception.Message}");
            }
            finally
            {
                _loadingIds.Remove(friendId);
            }

            if (avatar == null) return;
            if (token.IsCancellationRequested)
            {
                UnityEngine.Object.Destroy(avatar);
                return;
            }

            _avatars[friendId] = avatar;
            OnAvatarLoaded?.Invoke(friendId);
        }

        public void Dispose()
        {
            _lifetimeCTS.Cancel();
            _lifetimeCTS.Dispose();
            foreach (var avatar in _avatars.Values)
            {
                if (avatar != null) UnityEngine.Object.Destroy(avatar);
            }
            _avatars.Clear();
        }
    }
}
