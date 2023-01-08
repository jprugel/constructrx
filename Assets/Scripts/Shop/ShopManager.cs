using UnityEngine;
using Library.Inventories;
using Unity.VisualScripting;
using UnityEngine.Events;

public class ShopManager : MonoBehaviour {

    #region Reference Fields

    [Header("References")] 
    [SerializeField] private PlayerCurrency _playerCurrency;
    [SerializeField] private PlayerInventory _playerInventory;
    

    [SerializeField] private Constructor _constructor;

    [SerializeField] private Canvas _shop;

    #endregion

    #region Fields

    [SerializeField] private Storage<ConstructItem> _constructItems;

    [ReadOnly] [SerializeField] private int _numberOfItemsPurchased;
    [SerializeField] private float _priceCoefficient;
    [ReadOnly] [SerializeField] private float _priceModifier;

    #endregion

    #region Reference Properties

    public PlayerCurrency PlayerCurrency {
        get => _playerCurrency;
    }

    public PlayerInventory PlayerInventory {
        get => _playerInventory;
    }

    public Constructor Constructor {
        get => _constructor;
    }

    public Canvas Shop {
        get => _shop;
    }

    #endregion

    #region Properties

    public Storage<ConstructItem> ConstructItems {
        get => _constructItems;
    }

    public int NumberOfItemsPurchased {
        get => _numberOfItemsPurchased;
        private set => _numberOfItemsPurchased = value;
    }

    public float PriceCoefficient {
        get => _priceCoefficient;
    }

    public float PriceModifier {
        get => _priceModifier;
        private set => _priceModifier = Mathf.Clamp(value, 0f, float.MaxValue);
    }

    #endregion

    #region Events

    public UnityEvent OnPurchaseEvent;

    #endregion

    #region MonoBehaviour Implementations

    private void OnEnable() {
        Shop.gameObject.SetActive(true);

        PriceModifier = 1 + NumberOfItemsPurchased * PriceCoefficient;
        
        
        foreach (ConstructItem item in ConstructItems) {
            item.Initialize(
                Constructor.RandomConstructData()
            );
        }
    }

    private void OnDisable() {
        if (Shop.IsDestroyed()) return;
        Shop.gameObject.SetActive(false);
    }

    #endregion

    #region Methods

    public void PurchaseItem(Item item) {
        if (!PlayerCurrency.SpendCurrency(item.Cost)) return;

        NumberOfItemsPurchased++;
        PriceModifier = 1 + NumberOfItemsPurchased * PriceCoefficient;

        if (item is ConstructItem) {
            ConstructItems.TransferStorable(PlayerInventory.ConstructItems, (ConstructItem) item);
            ConstructItem citem = (ConstructItem)item;
            citem.Initialize(
                GameManager.Singleton.Constructor.RandomConstructData()
            );
        }

        OnPurchaseEvent?.Invoke();
    }

    #endregion
}
