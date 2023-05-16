using UnityEngine;

[CreateAssetMenu(menuName = "Project/Item Config", fileName = "New Inventory Item Config")]
public class InventoryItemConfig : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private int _initialQuantity;

    public Sprite Icon => _icon;
    public string Name => _name;
    public int InitialQuantity => _initialQuantity;

    private void OnValidate()
    {
        _initialQuantity = Mathf.Max(_initialQuantity, 1);
    }
}