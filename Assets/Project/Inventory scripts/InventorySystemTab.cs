public class InventorySystemTab
{
    private string _name;
    private InventorySystemItem[] _items;
    private InventoryTabConfig _config;

    public string Name => _name;
    public InventorySystemItem[] Items => _items;
    public InventoryTabConfig Config => _config;

    public InventorySystemTab(string name, InventorySystemItem[] items, InventoryTabConfig config)
    {
        _name = name;
        _items = items;
        _config = config;
    }
}