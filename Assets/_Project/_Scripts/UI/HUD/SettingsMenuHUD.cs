using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Settings shell: tabs, one page per category, reset (behind a confirm) and back. Changes apply at once and are saved on close.
    // The confirm is the menus canvas' shared dialog, so it has to sit above this menu in the hierarchy.
    public class SettingsMenuHUD : MonoBehaviour
    {
        [Inject] private readonly SettingsMenuState _state;
        [Inject] private readonly GameSettingsService _settings;
        [Inject] private readonly KeybindService _keybinds;
        [Inject] private readonly MenuButtonInput _menuButtons;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private OptionList _tabList;
        [SerializeField] private Button _resetButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private List<SettingsTab> _tabs = new();
        [SerializeField] private ConfirmDialog _confirmDialog;
        // {0} is the tab's label
        [SerializeField] private string _resetMessageFormat = "Reset all {0} settings to their defaults?";
        [SerializeField] private string _resetConfirmLabel = "Reset";
        [SerializeField] private string _resetCancelLabel = "Cancel";

        private readonly List<(int id, string label)> _tabBuffer = new();
        private readonly List<List<Selectable>> _navigationRows = new();
        private int _currentTab;
        // the dialog is shared, so this menu only reacts to the questions it asked; the tab is kept in case it changes
        private bool _isAskingReset;
        private int _resetTab;

        private void Start()
        {
            _state.OnOpenChanged += HandleOpenChanged;
            _state.OnBackRequested += HandleBackRequested;
            _confirmDialog.OnClosed += HandleConfirmClosed;
            _tabList.OnOptionClicked += ShowTab;
            _menuButtons.OnTabStepped += HandleTabStepped;
            _resetButton.onClick.AddListener(AskToReset);
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
                // after the hide, so the closing confirm doesn't hand focus back to this menu
                if (_isAskingReset) _confirmDialog.Close();
            }
        }

        private void ShowTab(int index)
        {
            if (index < 0 || index >= _tabs.Count) return;

            _currentTab = index;
            _tabList.Select(index);
            for (int i = 0; i < _tabs.Count; i++) _tabs[i].Page.SetActive(i == index);
            LinkNavigation();
        }

        // LB/RB walk the tabs round, and the focus goes to the new tab because the old page's rows just turned off
        private void HandleTabStepped(int step)
        {
            if (!_panel.IsShown || _tabs.Count == 0 || _isAskingReset) return;

            ShowTab((_currentTab + step + _tabs.Count) % _tabs.Count);
            _tabList.FocusSelected();
        }

        // tabs, then the page's rows, then reset and back; the page's first row goes up to the open tab.
        // The page builds its rows when it turns on, so this runs after SetActive and settles its layout first.
        private void LinkNavigation()
        {
            _navigationRows.Clear();
            var tabRow = new List<Selectable>();
            _tabList.AddSelectables(tabRow);
            _navigationRows.Add(tabRow);

            var page = _tabs[_currentTab].Page.transform;
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_tabList.transform);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)page);
            EUtils.UI.AddNavigationRows(page, _navigationRows);
            bool hasPageRows = _navigationRows.Count > 1;

            _navigationRows.Add(new List<Selectable> { _resetButton, _backButton });
            EUtils.UI.LinkNavigation(_navigationRows);

            var openTab = _tabList.GetSelectedSelectable();
            if (hasPageRows && openTab != null) EUtils.UI.SetNavigationUp(_navigationRows[1], openTab);
        }

        // back closes this menu's confirm before the menu
        private void HandleBackRequested()
        {
            if (_isAskingReset) _confirmDialog.Close();
            else Close();
        }

        private void AskToReset()
        {
            _resetTab = _currentTab;
            _isAskingReset = true;
            _confirmDialog.Open(string.Format(_resetMessageFormat, _tabs[_resetTab].Label), ResetAskedTab, _resetConfirmLabel, _resetCancelLabel);
        }

        private void HandleConfirmClosed()
        {
            if (!_isAskingReset) return;

            _isAskingReset = false;
            if (_panel.IsShown) _resetButton.Select();
        }

        private void ResetAskedTab()
        {
            var category = _tabs[_resetTab].Category;
            if (category == SettingsCategory.Controls) _keybinds.ResetAll();
            else _settings.ResetCategory(category);
        }

        private void Close() => _state.ToggleOpen(false);

        private void OnDestroy()
        {
            _state.OnOpenChanged -= HandleOpenChanged;
            _state.OnBackRequested -= HandleBackRequested;
            _confirmDialog.OnClosed -= HandleConfirmClosed;
            _tabList.OnOptionClicked -= ShowTab;
            _menuButtons.OnTabStepped -= HandleTabStepped;
            _resetButton.onClick.RemoveListener(AskToReset);
            _backButton.onClick.RemoveListener(Close);
        }
    }
}
