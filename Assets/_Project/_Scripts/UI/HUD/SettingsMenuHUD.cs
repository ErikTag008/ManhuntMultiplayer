using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Settings shell: tabs, one page per category, reset and back. Changes apply at once and are saved on close.
    public class SettingsMenuHUD : MonoBehaviour
    {
        [Inject] private readonly SettingsMenuState _state;
        [Inject] private readonly GameSettingsService _settings;
        [Inject] private readonly KeybindService _keybinds;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private OptionList _tabList;
        [SerializeField] private Button _resetButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private List<SettingsTab> _tabs = new();

        private readonly List<(int id, string label)> _tabBuffer = new();
        private int _currentTab;

        private void Start()
        {
            _state.OnOpenChanged += HandleOpenChanged;
            _tabList.OnOptionClicked += ShowTab;
            _resetButton.onClick.AddListener(ResetCurrentTab);
            _backButton.onClick.AddListener(Close);

            _tabBuffer.Clear();
            for (int i = 0; i < _tabs.Count; i++) _tabBuffer.Add((i, _tabs[i].Label));
            _tabList.Build(_tabBuffer);
            ShowTab(_currentTab);
            HandleOpenChanged(_state.IsOpen);
        }

        private void HandleOpenChanged(bool isOpen)
        {
            if (isOpen == _panel.IsShown) return;

            if (isOpen)
            {
                _panel.Show();
                _tabList.FocusSelected();
            }
            else
            {
                _keybinds.CancelRebind();
                _settings.Save();
                _panel.Hide();
            }
        }

        private void ShowTab(int index)
        {
            if (index < 0 || index >= _tabs.Count) return;

            _currentTab = index;
            _tabList.Select(index);
            for (int i = 0; i < _tabs.Count; i++) _tabs[i].Page.SetActive(i == index);
        }

        private void ResetCurrentTab()
        {
            var category = _tabs[_currentTab].Category;
            if (category == SettingsCategory.Controls) _keybinds.ResetAll();
            else _settings.ResetCategory(category);
        }

        private void Close() => _state.ToggleOpen(false);

        private void OnDestroy()
        {
            _state.OnOpenChanged -= HandleOpenChanged;
            _tabList.OnOptionClicked -= ShowTab;
            _resetButton.onClick.RemoveListener(ResetCurrentTab);
            _backButton.onClick.RemoveListener(Close);
        }
    }
}
