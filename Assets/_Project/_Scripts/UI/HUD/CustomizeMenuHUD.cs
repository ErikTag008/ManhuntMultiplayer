using Project.Assets._Project._Scripts.Cosmetics;
using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Lobby Customize screen: a tab per slot, the slot's items as picture tiles with their price or state, a turnable
    // preview of the picked item on its team's model, the points balance and one action for the picked item (buy,
    // then equip). It covers the lobby menu; Back or the pause key returns to it.
    public class CustomizeMenuHUD : MonoBehaviour
    {
        [Inject] private readonly LobbyMenuState _state;
        [Inject] private readonly CosmeticProfileService _profile;
        [Inject] private readonly ICosmeticPreview _preview;
        [Inject] private readonly MenuButtonInput _menuButtons;
        [Inject] private readonly SettingsMenuState _settingsMenu;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private OptionList _slotList;
        [SerializeField] private OptionList _itemList;
        // its fixed column count sets the gamepad navigation rows
        [SerializeField] private GridLayoutGroup _itemGrid;
        [SerializeField] private CoverImage _previewImage;
        // keeps the preview at the view's aspect, so nothing of the model is cropped
        [SerializeField] private AspectRatioFitter _previewFitter;
        [SerializeField] private DragRotateArea _previewRotateArea;
        // the picked item's name and state, above the preview
        [SerializeField] private TMP_Text _itemNameText;
        [SerializeField] private TMP_Text _pointsText;
        [SerializeField] private Button _actionButton;
        [SerializeField] private TMP_Text _actionButtonLabel;
        [SerializeField] private Button _backButton;
        // says why a purchase was refused; empty otherwise
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private string _catcherWeaponLabel = "Catcher weapon";
        [SerializeField] private string _catcherOutfitLabel = "Catcher outfit";
        [SerializeField] private string _runnerOutfitLabel = "Runner outfit";
        // the picked item's title: {0} is the item name, {1} its price, "Owned" or "Equipped"
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
        // the slot tabs in their on-screen order, for LB/RB stepping
        private readonly List<CosmeticSlot> _slotOrder = new() { CosmeticSlot.CatcherWeapon, CosmeticSlot.CatcherOutfit, CosmeticSlot.RunnerOutfit };
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
            _previewRotateArea.OnRotated += HandlePreviewRotated;
            _menuButtons.OnTabStepped += HandleTabStepped;

            _optionBuffer.Clear();
            foreach (var slot in _slotOrder) _optionBuffer.Add(((int)slot, GetSlotLabel(slot)));
            _slotList.Build(_optionBuffer);
            ShowSlot(_currentSlot);
            HandleCustomizeOpenChanged(_state.IsCustomizeOpen);
        }

        private void HandleCustomizeOpenChanged(bool isOpen)
        {
            if (isOpen == _panel.IsShown) return;

            if (isOpen)
            {
                // starts on the equipped item facing front, with the balance as it is now
                _preview.ResetRotation();
                _preview.ToggleShown(true);
                var view = _preview.View;
                _previewFitter.aspectRatio = (float)view.width / view.height;
                _previewImage.ChangeTexture(view);
                ShowSlot(_currentSlot);
                _panel.Show();
                _slotList.FocusSelected();
            }
            else
            {
                _panel.Hide();
                _preview.ToggleShown(false);
            }

            _previewRotateArea.ToggleInput(isOpen);
        }

        private void HandleSlotClicked(int slotId) => ShowSlot((CosmeticSlot)slotId);

        // LB/RB walk the slot tabs round while this screen is up (and no settings menu is over it), and the focus follows
        private void HandleTabStepped(int step)
        {
            if (!_panel.IsShown || _settingsMenu.IsOpen) return;

            int current = Mathf.Max(0, _slotOrder.IndexOf(_currentSlot));
            ShowSlot(_slotOrder[(current + step + _slotOrder.Count) % _slotOrder.Count]);
            _slotList.FocusSelected();
        }

        private string GetSlotLabel(CosmeticSlot slot) => slot switch
        {
            CosmeticSlot.CatcherWeapon => _catcherWeaponLabel,
            CosmeticSlot.CatcherOutfit => _catcherOutfitLabel,
            _ => _runnerOutfitLabel
        };

        private void ShowSlot(CosmeticSlot slot)
        {
            _currentSlot = slot;
            _slotList.Select((int)slot);
            _profile.Catalog.CopyItems(slot, _items);

            _optionBuffer.Clear();
            foreach (var item in _items) _optionBuffer.Add((item.Id, GetItemStatus(item)));
            _itemList.Build(_optionBuffer);
            foreach (var item in _items) _itemList.ChangePreview(item.Id, _preview.GetThumbnail(item));

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
            _preview.Show(item);
            ShowMessage(string.Empty);
            RefreshDetails();
        }

        private void HandlePreviewRotated(float degrees) => _preview.Rotate(degrees);

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
            foreach (var item in _items) _itemList.ChangeLabel(item.Id, GetItemStatus(item));
            // an equip in another slot also changes what the preview model wears
            _preview.Show(_pickedItem);
            ShowMessage(string.Empty);
            RefreshDetails();
        }

        private void RefreshDetails()
        {
            _pointsText.text = string.Format(_pointsFormat, _profile.Points);
            _actionButtonLabel.text = GetActionLabel(_pickedItem);
            _itemNameText.text = _pickedItem != null ? string.Format(_itemLabelFormat, _pickedItem.DisplayName, GetItemStatus(_pickedItem)) : string.Empty;
        }

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

        // tabs, then the item grid row by row, then the action and back; the first item row goes up to the open tab
        private void LinkNavigation()
        {
            _navigationRows.Clear();
            var slotRow = new List<Selectable>();
            _slotList.AddSelectables(slotRow);
            _navigationRows.Add(slotRow);

            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_slotList.transform);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_itemGrid.transform);
            _itemList.AddSelectableRows(_navigationRows, Mathf.Max(1, _itemGrid.constraintCount));
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
            _previewRotateArea.OnRotated -= HandlePreviewRotated;
            _menuButtons.OnTabStepped -= HandleTabStepped;
        }
    }
}
