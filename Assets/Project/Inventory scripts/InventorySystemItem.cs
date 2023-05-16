public class InventorySystemItem
{
    private string _name;
    private int _quantity;
    private InventoryItemConfig _config;

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    public string Name => _name;

    public InventoryItemConfig Config => _config;

    public InventorySystemItem(string name, int quantity, InventoryItemConfig config)
    {
        _name = name;
        _quantity = quantity;
        _config = config;
    }
}