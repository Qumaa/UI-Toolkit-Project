using UnityEngine;

[CreateAssetMenu(menuName = "Project/Tab Config", fileName = "New Inventory Tab Config")]
public class InventoryTabConfig : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private InventoryItemConfig[] _itemConfigs;

    public Sprite Icon => _icon;
    public string Name => _name;
    public InventoryItemConfig[] ItemConfigs => _itemConfigs;
}