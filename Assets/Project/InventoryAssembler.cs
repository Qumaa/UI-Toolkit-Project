using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryAssembler : MonoBehaviour
{
    [SerializeField] private UIDocument _inventoryBase;
    [SerializeField] private VisualTreeAsset _inventoryUIPanel;
    [SerializeField] private VisualTreeAsset _inventoryPreviewPanel;
    [SerializeField] private VisualTreeAsset _inventoryCell;

    #region Constants

    // base names
    private const string _BASE_INVENTORY_CONTAINER_ELEMENT = "inventory-container";
    private const string _INVENTORY_UI_CONTAINER_ELEMENT = "ui-panel-container";
    private const string _INVENTORY_PREVIEW_CONTAINER_ELEMENT = "preview-panel-container";

    // ui names
    
    // preview names
    
    // cell names

    #endregion

    private void Start()
    {
        AssembleInventory();
    }

    private void AssembleInventory()
    {
        var inventoryContainer = _inventoryBase.rootVisualElement;

        var uiContainer = AssembleUIContainer(inventoryContainer);
        var previewContainer = AssemblePreviewContainer(inventoryContainer);

        _inventoryUIPanel.CloneTree(uiContainer);
        _inventoryPreviewPanel.CloneTree(previewContainer);
    }

    private VisualElement AssemblePreviewContainer(VisualElement inventoryContainer)
    {
        return inventoryContainer.Q(_INVENTORY_PREVIEW_CONTAINER_ELEMENT);
    }

    private VisualElement AssembleUIContainer(VisualElement inventoryContainer)
    {
        return inventoryContainer.Q(_INVENTORY_UI_CONTAINER_ELEMENT);
    }
}

public class InventoryCellWrapper
{
    private readonly InventoryCell _cell;

    public InventoryCellWrapper(InventoryCell cell)
    {
        _cell = cell;
    }

    public int Quantity
    {
        get => ParseQuantityLabel();
        set => UpdateQuantityLabel(value);
    }

    private int ParseQuantityLabel() =>
        string.IsNullOrEmpty(_cell.QuantityLabel.text) ?
            0 :
            int.Parse(_cell.QuantityLabel.text);

    private void UpdateQuantityLabel(int quantity)
    {
        if (quantity <= 0)
        {
            _cell.QuantityLabel.text = null;
            return;
        }

        _cell.QuantityLabel.text = quantity.ToString();
    }
}
