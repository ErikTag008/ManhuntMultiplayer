using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // One entry of a lobby list: name, host, map, players and ping/region texts on a button that reports its index
    public class LobbyListRow : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _hostText;
        [SerializeField] private TMP_Text _mapText;
        [SerializeField] private TMP_Text _playersText;
        [SerializeField] private TMP_Text _pingText;

        public event Action<int> OnClicked;

        private int _index;

        public int Index => _index;
        public Selectable Selectable => _button;

        private void Awake() => _button.onClick.AddListener(HandleClicked);

        public void Setup(int index, string lobbyName, string hostName, string mapName, string players, string ping)
        {
            _index = index;
            _nameText.text = lobbyName;
            _hostText.text = hostName;
            _mapText.text = mapName;
            _playersText.text = players;
            _pingText.text = ping;
        }

        public void ToggleInteractable(bool isInteractable) => _button.interactable = isInteractable;

        private void HandleClicked() => OnClicked?.Invoke(_index);

        private void OnDestroy() => _button.onClick.RemoveListener(HandleClicked);
    }
}
