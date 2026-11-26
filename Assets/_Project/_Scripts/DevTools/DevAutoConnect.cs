using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using System.Linq;
using System.Threading;
using Unity.Netcode;
using UnityEngine;
#if UNITY_EDITOR
using Unity.Multiplayer.PlayMode;
#endif

namespace Project.Assets._Project._Scripts.DevTools
{
    // Multiplayer Play Mode helper: the main Editor hosts, additional Editor instances join
    public class DevAutoConnect : MonoBehaviour
    {
        [Inject] private readonly IUIManager _uiManager;
        [SerializeField] private bool _isAutoConnectEnabled = true;
        [SerializeField] private float _clientJoinDelayInSeconds = 2f;

        private void Start()
        {
            // read in every build so development players don't warn about unused serialized fields
            if (!_isAutoConnectEnabled || !Application.isEditor) return;

            AutoConnect(_clientJoinDelayInSeconds, this.GetCancellationTokenOnDestroy()).Forget();
        }

#if UNITY_EDITOR
        private async UniTaskVoid AutoConnect(float clientJoinDelayInSeconds, CancellationToken token)
        {
            // wait one frame so MainMenuStarter has subscribed to the UI events
            await UniTask.Yield(cancellationToken: token);

            if (CurrentPlayer.IsMainEditor)
            {
                _uiManager.RaiseHostStart();
            }
            else
            {
                await UniTask.WaitForSeconds(clientJoinDelayInSeconds, cancellationToken: token);
                _uiManager.RaiseClientStart();
            }

            await UniTask.Yield(cancellationToken: token);
            LogNetworkConfig();
        }

        // Lets host and clients compare what Netcode hashes when it reports a NetworkConfig mismatch
        private static void LogNetworkConfig()
        {
            var networkManager = NetworkManager.Singleton;
            if (networkManager == null) return;

            var config = networkManager.NetworkConfig;
            var prefabHashes = string.Join(", ", config.Prefabs.NetworkPrefabOverrideLinks
                .OrderBy(link => link.Key)
                .Select(link => $"{link.Key}={(link.Value.Prefab != null ? link.Value.Prefab.name : "null")}"));

            EUtils.Logger.Log($"[DevAutoConnect] {(CurrentPlayer.IsMainEditor ? "Host" : "Client")} config hash {config.GetConfig(false)} | " +
                $"protocol {config.ProtocolVersion} tick {config.TickRate} approval {config.ConnectionApproval} " +
                $"samePrefabs {config.ForceSamePrefabs} sceneMgmt {config.EnableSceneManagement} " +
                $"varSafety {config.EnsureNetworkVariableLengthSafety} rpcHash {config.RpcHashSize} | prefabs [{prefabHashes}]");
        }
#else
        private UniTaskVoid AutoConnect(float clientJoinDelayInSeconds, CancellationToken token) => default;
#endif
    }
}
