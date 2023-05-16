using System;
using System.Linq;
using UnityEngine.UIElements;

public class InventoryView
{
    private InventorySystem _inventorySystem;
    private VisualElement _inventoryTreeAsset;

    private InputFieldWrapper _inputFieldWrapper;
    private InventoryUIWrapper _inventoryUIWrapper;

    public InventoryView(InventorySystem inventorySystem, VisualElement inventoryTreeAsset)
    {
        _inventorySystem = inventorySystem;
        _inventoryTreeAsset = inventoryTreeAsset;

        CreateWrappers();

        PopulateView();
        BindViewEventsToSystem();
    }

    private void CreateWrappers()
    {
        _inputFieldWrapper = new InputFieldWrapper();
        _inventoryUIWrapper = new InventoryUIWrapper();
    }

    private void PopulateView()
    {
        RefreshUI(_inventorySystem.ActiveTab?.Config.ItemConfigs);
    }

    private void BindViewEventsToSystem()
    {
        BindInputField();
    }

    private void BindInputField()
    {
        _inputFieldWrapper.OnInputChanged += newInput =>
            RefreshUI(FindMatchingItems(_inventorySystem.ActiveTab.Config.ItemConfigs, newInput));
    }

    private void RefreshUI(InventoryItemConfig[] items)
    {
        _inventoryUIWrapper.ClearAllItems();

        if (items == null)
            return;
        
        _inventoryUIWrapper.SetItems(items);
    }

    private InventoryItemConfig[] FindMatchingItems(InventoryItemConfig[] items, string prompt) =>
        string.IsNullOrEmpty(prompt) ?
            items :
            items.Where(item => item.Name.StartsWith(prompt, StringComparison.OrdinalIgnoreCase))
                .ToArray();
}