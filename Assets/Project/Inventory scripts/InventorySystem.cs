using System;
using System.Collections.Generic;
using System.Linq;

public class InventorySystem
{
    private InventorySystemTab[] _tabs;
    private InventorySystemTab _activeTab;

    public InventorySystemTab ActiveTab => _activeTab;

    public event Action OnActiveTabChanged;

    public InventorySystem(InventoryTabConfig[] tabsConfigs, int activeTabIndex = 0)
    {
        _tabs = CreateTabsFromConfig(tabsConfigs);
        
        if (_tabs.Length > 0)
            _activeTab = _tabs[activeTabIndex];
    }

    public void SetTab(Type tabType)
    {
        var selected = _tabs.First(x => x.GetType() == tabType);

        if (selected == _activeTab)
            return;

        _activeTab = selected;
        OnActiveTabChanged?.Invoke();
    }

    private InventorySystemTab[] CreateTabsFromConfig(InventoryTabConfig[] tabConfigs) =>
        tabConfigs.Select(x => new InventorySystemTab(x.Name, CreateItemsFromConfig(x.ItemConfigs), x))
            .ToArray();

    private InventorySystemItem[] CreateItemsFromConfig(InventoryItemConfig[] configs) =>
        configs.Select(x => new InventorySystemItem(x.Name, x.InitialQuantity, x))
            .ToArray();
}