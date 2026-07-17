using Project.Assets._Project._Scripts.DI;
using Project.Assets._Project._Scripts.Player;
using Reflex.Attributes;
using System;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Inject] private readonly UIManager _uiManager;
        [Inject] private readonly Camera _mainCamera;
        [Inject] private readonly GameplayCamera _gameplayCamera;
        private void Awake()
        {
            ToggleCamera(false);
            PlayerController.OnPlayerSpawned += HandlePlayerSpawn;
            _uiManager.OnHostStart += HandleHostStart;
            _uiManager.OnClientStart += HandleClientStart;
        }

        private void HandlePlayerSpawn(PlayerController player)
        {
            ToggleCamera(true);
        }

        private void ToggleCamera(bool isGameplayCamera)
        {
            Camera gameplayCam = _gameplayCamera;
            if (isGameplayCamera)
            {
                _mainCamera.gameObject.SetActive(false);
                gameplayCam.gameObject.SetActive(true);
            }
            else
            {
                gameplayCam.gameObject.SetActive(false);
                _mainCamera.gameObject.SetActive(true);
            }
        }

        private void HandleClientStart()
        {
            NetworkManager.Singleton.StartClient();
            _uiManager.ToggleServerStarterUI(false);
        }

        private void HandleHostStart()
        {
            NetworkManager.Singleton.StartHost();
            _uiManager.ToggleServerStarterUI(false);
        }
    }
}
