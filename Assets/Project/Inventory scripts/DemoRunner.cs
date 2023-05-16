using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DemoRunner : MonoBehaviour
{
    [Header("View")] [SerializeField] private UIDocument _inventoryBase;
    [SerializeField] private VisualTreeAsset _inventoryUIPanel;
    [SerializeField] private VisualTreeAsset _inventoryPreviewPanel;

    [Space] [Header("Configs")] [SerializeField]
    private InventoryTabConfig[] _tabs;

    private InventorySystem _inventorySystem;
    private InventoryView _inventoryView;

    private const string _INVENTORY_UI_CONTAINER_ELEMENT = "ui-panel-container";
    private const string _INVENTORY_PREVIEW_CONTAINER_ELEMENT = "preview-panel-container";

    private void Start()
    {
        _inventorySystem = new InventorySystem(_tabs);
        _inventoryView = new InventoryView(_inventorySystem, AssembleInventory());
    }

    private VisualElement AssembleInventory()
    {
        var inventoryContainer = _inventoryBase.rootVisualElement;

        var uiContainer = AssembleUIContainer(inventoryContainer);
        var previewContainer = AssemblePreviewContainer(inventoryContainer);

        _inventoryUIPanel.CloneTree(uiContainer);
        _inventoryPreviewPanel.CloneTree(previewContainer);

        return inventoryContainer;
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

public class InventoryUIWrapper
{
    private Stack<InventoryCellWrapper> _cellsPool;
    private List<InventoryCellWrapper> _activeCells;

    public void ClearAllItems()
    {
        foreach(var cell in _activeCells)
            _cellsPool.Push(cell);
        
        _activeCells.Clear();
    }

    public void SetItems(InventoryItemConfig[] items)
    {
        throw new NotImplementedException();
    }

    public InventoryCellWrapper CellFactory() =>
        _cellsPool.TryPop(out var popped) ? 
            popped : 
            new InventoryCellWrapper(new InventoryCell());
}

public class InputFieldWrapper
{
    public event Action<string> OnInputChanged;
}