using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constructs;
using TMPro;
using UnityEngine.UI;

public class PriceHandler : MonoBehaviour {

    #region Fields

    [Header("Managers")]
    [SerializeField] private ShopManager _shopManager;
    
    [Header("Item")]
    [SerializeField] private Item _item;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private Button _purchaseButton;
    
    [SerializeField] private float _totalCost;

    #endregion

    #region Properties

    public ShopManager ShopManager {
        get => _shopManager;
    }

    public Item Item {
        get => _item;
    }

    public TextMeshProUGUI CostText {
        get => _costText;
    }

    public Button PurchaseButton {
        get => _purchaseButton;
    }

    public float TotalCost {
        get => _totalCost;
        private set => _totalCost = value;
    }

    #endregion

    private void Start() {
        //Simulation
        TotalCost = Item.Cost * ShopManager.PriceModifier;
        
        //Visual
        CostText.text = $"${TotalCost}";
        
        PurchaseButton.onClick.AddListener(() => {
            ShopManager.PurchaseItem(Item);
        });
        
        ShopManager.OnPurchaseEvent.AddListener(() => {
            //Simulation
            TotalCost = Item.Cost * ShopManager.PriceModifier;
        
            //Visual
            CostText.text = $"${TotalCost}";
        });
    }
}
