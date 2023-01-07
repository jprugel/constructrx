using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constructs;
using TMPro;
using UnityEngine.UI;

public class PriceHandler : MonoBehaviour {

    #region Fields

    [SerializeField] private Item _item;
    [SerializeField] private TextMeshProUGUI _costText;
    [ReadOnly] [SerializeField] private ShopManager _shopManager;
    [SerializeField] private Button _purchaseButton;

    #endregion

    #region Properties

    public Item Item {
        get => _item;
    }

    public TextMeshProUGUI CostText {
        get => _costText;
    }

    public ShopManager ShopManager {
        get => _shopManager;
        private set => _shopManager = value;
    }

    public Button PurchaseButton {
        get => _purchaseButton;
    }

    #endregion

    private void Start() {
        ShopManager = GameManager.Singleton.ShopManager;

        PurchaseButton.onClick.AddListener(() => {
            ShopManager.PurchaseItem(Item);
        });

        if (Item is ConstructItem) {
            ConstructItem item = (ConstructItem)Item;
            item.OnInitialized.AddListener(() => {
                CostText.text = $"{(int)(Item.Cost * ShopManager.PriceModifier)}";
            });
        }
        
        ShopManager.OnPurchaseEvent.AddListener(() => {
            CostText.text = $"{(int)(Item.Cost * ShopManager.PriceModifier)}";
        });
    }
}
