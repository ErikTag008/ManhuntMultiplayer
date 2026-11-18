using Project.Assets._Project._Scripts.Cosmetics;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Lobby Customize screen: a tab per slot, the slot's items with their price or state, the points balance and one
    // action for the picked item (buy, then equip). It covers the lobby menu; Back or the pause key returns to it.
    public class CustomizeMenuHUD : MonoBehaviour
    {
        [Inject] private readonly LobbyMenuState _state;
        [Inject] private readonly CosmeticProfileService _profile;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private OptionList _slotList;
        [SerializeField] private OptionList _itemList;
        [SerializeField] private TMP_Text _pointsText;
        [SerializeField] private Button _actionButton;
        [SerializeField] private TMP_Text _actionButtonLabel;
        [SerializeField] private Button _backButton;
        // says why a purchase was refused; empty otherwise
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private string _catcherWeaponLabel = "Catcher weapon";
        [SerializeField] private string _catcherOutfitLabel = "Catcher outfit";
        [SerializeField] private string _runnerOutfitLabel = "Runner outfit";
        // {0} is the item name, {1} its price, "Owned" or "Equipped"
        [SerializeField] private string _itemLabelFormat = "{0}  <size=70%>{1}</size>";
        // {0} is the price
        [SerializeField] private string _priceFormat = "{0} points";
        [SerializeField] private string _ownedLabel = "Owned";
        [SerializeField] private string _equippedLabel = "Equipped";
        // {0} is the balance
        [SerializeField] private string _pointsFormat = "{0} points";
        // {0} is the price
        [SerializeField] private string _buyFormat = "Buy ({0})";
        [SerializeField] private string _equipLabel = "Equip";
        [SerializeField] private string _equippedActionLabel = "Equipped";
        // {0} is how many more points are needed
        [SerializeField] private string _notEnoughPointsFormat = "You need {0} more points";

        private readonly List<(int id, string label)> _optionBuffer = new();
        private readonly List<CosmeticItem> _items = new();
        private readonly List<List<Selectable>> _navigationRows = new();
        private CosmeticSlot _currentSlot = CosmeticSlot.CatcherWeapon;
        private CosmeticItem _pickedItem;

        private void Start()
        {
            _state.OnCustomizeOpenChanged += HandleCustomizeOpenChanged;
            _profile.OnChanged += HandleProfileChanged;
            _slotList.OnOptionClicked += HandleSlotClicked;
            _itemList.OnOptionClicked += HandleItemClicked;
            _actionButton.onClick.AddListener(UsePickedItem);
            _backButton.onClick.AddListener(Close);

            _optionBuffer.Clear();
            _optionBuffer.Add(((int)CosmeticSlot.CatcherWeapon, _catcherWeaponLabel));
            _optionBuffer.Add(((int)CosmeticSlot.CatcherOutfit, _catcherOutfitLabel));
            _optionBuffer.Add(((int)CosmeticSlot.RunnerOutfit, _runnerOutfitLabel));
            _slotList.Build(_optionBuffer);
            ShowSlot(_currentSlot);
            HandleCustomizeOpenChanged(_state.IsCustomizeOpen);
        }

        private void HandleCustomizeOpenChanged(bool isOpen)
        {
            if (isOpen == _panel.IsShown) return;

            if (isOpen)
            {
                // starts on the equipped item, with the balance as it is now
                ShowSlot(_currentSlot);
                _panel.Show();
                _slotList.FocusSelected();
            }
            else
            {
                _panel.Hide();
            }
        }

        private void HandleSlotClicked(int slotId) => ShowSlot((CosmeticSlot)slotId);

        private void ShowSlot(CosmeticSlot slot)
        {
            _currentSlot = slot;
            _slotList.Select((int)slot);
            _profile.Catalog.CopyItems(slot, _items);

            _optionBuffer.Clear();
            foreach (var item in _items) _optionBuffer.Add((item.Id, GetItemLabel(item)));
            _itemList.Build(_optionBuffer);

            PickItem(_profile.GetEquipped(slot));
            LinkNavigation();
        }

        private void HandleItemClicked(int itemId)
        {
            var item = _items.Find(candidate => candidate.Id == itemId);
            if (item != null) PickItem(item);
        }

        private void PickItem(CosmeticItem item)
        {
            _pickedItem = item;
            _itemList.Select(item != null ? item.Id : CosmeticProfile.NoItem);
            ShowMessage(string.Empty);
            RefreshDetails();
        }

        // Buy when not owned yet, equip when owned; the profile refuses what isn't allowed
        private void UsePickedItem()
        {
            if (_pickedItem == null) return;

            if (_profile.IsOwned(_pickedItem))
            {
                _profile.TryEquip(_pickedItem);
                return;
            }

            if (_profile.CheckPurchase(_pickedItem) == PurchaseResult.NotEnoughPoints)
            {
                ShowMessage(string.Format(_notEnoughPointsFormat, _pickedItem.Price - _profile.Points));
                return;
            }

            _profile.TryBuy(_pickedItem);
        }

        private void HandleProfileChanged()
        {
            foreach (var item in _items) _itemList.ChangeLabel(item.Id, GetItemLabel(item));
            ShowMessage(string.Empty);
            RefreshDetails();
        }

        private void RefreshDetails()
        {
            _pointsText.text = string.Format(_pointsFormat, _profile.Points);
            _actionButtonLabel.text = GetActionLabel(_pickedItem);
        }

        private string GetItemLabel(CosmeticItem item) => string.Format(_itemLabelFormat, item.DisplayName, GetItemStatus(item));

        private string GetItemStatus(CosmeticItem item)
        {
            if (_profile.IsEquipped(item)) return _equippedLabel;
            return _profile.IsOwned(item) ? _ownedLabel : string.Format(_priceFormat, item.Price);
        }

        private string GetActionLabel(CosmeticItem item)
        {
            if (item == null) return string.Empty;
            if (_profile.IsEquipped(item)) return _equippedActionLabel;
            return _profile.IsOwned(item) ? _equipLabel : string.Format(_buyFormat, item.Price);
        }

        private void ShowMessage(string message)
        {
            if (_messageText != null) _messageText.text = message;
        }

        // tabs, then one row per item, then the action and back; the first item goes up to the open tab
        private void LinkNavigation()
        {
            _navigationRows.Clear();
            var slotRow = new List<Selectable>();
            _slotList.AddSelectables(slotRow);
            _navigationRows.Add(slotRow);

            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_slotList.transform);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_itemList.transform);
            _itemList.AddSelectableRows(_navigationRows);
            bool hasItemRows = _navigationRows.Count > 1;

            _navigationRows.Add(new List<Selectable> { _actionButton, _backButton });
            EUtils.UI.LinkNavigation(_navigationRows);

            var openTab = _slotList.GetSelectedSelectable();
            if (hasItemRows && openTab != null) EUtils.UI.SetNavigationUp(_navigationRows[1], openTab);
        }

        private void Close() => _state.ToggleCustomizeOpen(false);

        private void OnDestroy()
        {
            _state.OnCustomizeOpenChanged -= HandleCustomizeOpenChanged;
            _profile.OnChanged -= HandleProfileChanged;
            _slotList.OnOptionClicked -= HandleSlotClicked;
            _itemList.OnOptionClicked -= HandleItemClicked;
            _actionButton.onClick.RemoveListener(UsePickedItem);
            _backButton.onClick.RemoveListener(Close);
        }
    }
}
