using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Constructs;
using Library.Inventories;
using TMPro;
using UnityEngine.Events;
using Random = UnityEngine.Random;


public class ConstructItem : MonoBehaviour, IStorable {
    #region Fields

    [ReadOnly] [SerializeField] private ConstructData _targetConstructData;

    [SerializeField] private SpriteRenderer _baseRenderer;
    [SerializeField] private SpriteRenderer _headRenderer;
    [SerializeField] private TextMeshProUGUI _costText;

    [SerializeField] private Button _purchaseButton;

    [SerializeField] private string _id;

    [SerializeField] private int _price;

    #endregion

    #region Properties
    
    public ConstructData TargetConstructData {
        get => _targetConstructData;
        private set => _targetConstructData = value;
    }

    public SpriteRenderer BaseRenderer {
        get => _baseRenderer;
    }

    public SpriteRenderer HeadRenderer {
        get => _headRenderer;
    }

    public TextMeshProUGUI CostText {
        get => _costText; 
        set => _costText = value;
    }

    public Button PurchaseButton {
        get => _purchaseButton;
    }

    public string Id {
        get => _id;
        set => _id = value;
    }

    public int Price {
        get => _price;
        private set => _price = value;
    }

    #endregion

    #region Events

    public UnityEvent<ConstructItem> OnPurchaseConstructItem;

    #endregion

    public void Start() {
        TargetConstructData = GameManager.Singleton.Constructor.RandomConstructData();

        Price = (int)(TargetConstructData.Cost * (GameManager.Singleton.ShopManager.PriceMultiplier));
        Debug.Log(GameManager.Singleton.ShopManager.PriceMultiplier);
        CostText.text = Price.ToString();
        
        BaseRenderer.sprite = TargetConstructData.Sprites.Head;
        BaseRenderer.sortingOrder = 2;

        HeadRenderer.sprite = TargetConstructData.Sprites.Base;
        HeadRenderer.sortingOrder = 1;
        
        PurchaseButton.onClick.AddListener(() => {
            OnPurchaseConstructItem.Invoke(this);
            Debug.Log(GameManager.Singleton.ShopManager.PriceMultiplier);
        });
    }

    private void Update() {
        Price = (int)(TargetConstructData.Cost * (GameManager.Singleton.ShopManager.PriceMultiplier));
        CostText.text = Price.ToString();
    }
}
