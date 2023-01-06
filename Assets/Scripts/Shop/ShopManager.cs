using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Library.Inventories;
using UnityEngine.Events;

public class ShopManager : MonoBehaviour {
    
    #region Fields
    
    [Header("Construct Item Info")]
    [SerializeField] private ConstructItem _constructItemPrefab;
    [SerializeField] private List<RectTransform> _constructItemTargets;
    [SerializeField] private Canvas _constructItemCanvas;
    [SerializeField] private Storage<ConstructItem> _constructItems;

    [Header("Price Data")]
    [SerializeField] private int NumberOfPurchasedItems = 0;
    [SerializeField] private float CostCoefficient = 1.1f;
    [SerializeField] private float _priceMultiplier;
    
    [Header("Events")]
    [SerializeField] public UnityEvent OnPurchaseEvent;
    
    #endregion

    public ConstructItem ConstructItemPrefab {
        get => _constructItemPrefab;
    }

    public List<RectTransform> ConstructItemTargets {
        get => _constructItemTargets;
    }

    public Canvas ConstructItemCanvas {
        get => _constructItemCanvas;
    }

    public Storage<ConstructItem> ConstructItems {
        get => _constructItems;
        private set => _constructItems = value;
    }

    public float PriceMultiplier {
        get => _priceMultiplier;
        private set => _priceMultiplier = value;
    }

    private void Start() {
        PriceMultiplier = 1 + (NumberOfPurchasedItems * CostCoefficient);
        
        GenerateConstructItems();
    }

    private void GenerateConstructItems() {
        for (int i = 0; i < ConstructItemTargets.Count; i++) {
            ConstructItem item = Instantiate(
                ConstructItemPrefab,
                ConstructItemTargets[i].position,
                Quaternion.identity,
                ConstructItemCanvas.transform
            );

            ConstructItems.AddStorable(
                item
            );

            item.OnPurchaseConstructItem.AddListener((data) => {
                ConstructItems.TransferStorable(Player.Singleton.PlayerConstructItems, data);

                NumberOfPurchasedItems++;
                PriceMultiplier = 1 + (NumberOfPurchasedItems * CostCoefficient);
            });
        }
    }
}
