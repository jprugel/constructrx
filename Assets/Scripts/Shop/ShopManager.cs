using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Library.Inventories;
using UnityEngine.Events;

public class ShopManager : MonoBehaviour {

    #region Reference Fields

    [Header("References")] 
    [SerializeField] private Player _player;

    #endregion

    #region Fields

    [SerializeField] private Storage<ConstructItem> _constructItems;

    [ReadOnly] [SerializeField] private int _numberOfItemsPurchased;
    [SerializeField] private float _priceCoefficient;
    [ReadOnly] [SerializeField] private float _priceModifier;

    #endregion

    #region Reference Properties

    public Player Player {
        get => _player;
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

    private void Start() {
        PriceModifier = 1 + NumberOfItemsPurchased * PriceCoefficient;
        
        foreach (ConstructItem item in ConstructItems) {
            item.Initialize(
                GameManager.Singleton.Constructor.RandomConstructData()
            );
        }
    }

    #endregion

    #region Methods

    public void PurchaseItem(Item item) {
        NumberOfItemsPurchased++;
        PriceModifier = 1 + NumberOfItemsPurchased * PriceCoefficient;

        if (item is ConstructItem) {
            ConstructItems.TransferStorable(Player.ConstructItems, (ConstructItem) item);
            ConstructItem citem = (ConstructItem)item;
            citem.Initialize(
                GameManager.Singleton.Constructor.RandomConstructData()
            );
        }

        OnPurchaseEvent?.Invoke();
    }

    #endregion
}
