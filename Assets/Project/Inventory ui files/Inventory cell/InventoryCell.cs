using UnityEditor;
using UnityEngine.UIElements;

public class InventoryCell : VisualElement
{
    // inspector
    public int initialQuantity { get; set; }

    private const string _INITIAL_QUANTITY_FIELD_NAME = "initial-quantity";
    private const string _ITEM_NAME_FIELD_NAME = "item-name";
    private const int _DEFAULT_INITIAL_QUANTITY = 1;
    
    // logic
    public Image Icon { get; set; }
    public Label NameLabel { get; set; }
    public Label QuantityLabel { get; set; }
    
    private const string _CELL_DOCUMENT_PATH = "Assets/Project/Inventory ui files/Inventory cell/Inventory cell document.uxml";
    private const string _ICON_ELEMENT_NAME = "cell-icon";
    private const string _ICON_CONTAINER_ELEMENT_NAME = "cell-icon-container";
    private const string _NAME_LABEL_ELEMENT_NAME = "cell-name-label";
    private const string _QUANTITY_LABEL_ELEMENT_NAME = "cell-quantity-label";
    private const string _ICON_STYLE_CLASS = "cell-icon";

    public InventoryCell()
    {
        var document = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(_CELL_DOCUMENT_PATH);

        document.CloneTree(this);

        Icon = new Image { name = _ICON_ELEMENT_NAME };
        Icon.AddToClassList(_ICON_STYLE_CLASS);
        this.Q(_ICON_CONTAINER_ELEMENT_NAME).Add(Icon);
        
        NameLabel = this.Q<Label>(_NAME_LABEL_ELEMENT_NAME);
        
        QuantityLabel = this.Q<Label>(_QUANTITY_LABEL_ELEMENT_NAME);
        QuantityLabel.text = initialQuantity.ToString();
    }

    public new class UxmlFactory : UxmlFactory<InventoryCell, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        private UxmlIntAttributeDescription _initialQuantity = 
            new UxmlIntAttributeDescription { name = _INITIAL_QUANTITY_FIELD_NAME, defaultValue = _DEFAULT_INITIAL_QUANTITY };
        
        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var cell = ve as InventoryCell;

            cell.initialQuantity = _initialQuantity.GetValueFromBag(bag, cc);
        }
    }
}
