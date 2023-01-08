using System;
using System.Collections;
using System.Collections.Generic;
using Library.Inventories;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {
    #region Fields

    [SerializeField] private Storage<ConstructItem> _constructItems;

    [Header("Currency Management")] 
    [SerializeField] private int _currencyCount;

    #endregion

    #region Properties

    public Storage<ConstructItem> ConstructItems {
        get => _constructItems;
    }

    public int CurrencyCount {
        get => _currencyCount;
        private set => _currencyCount = value;
    }

    #endregion

    #region MonoBehaviour Implementations
    
    

    #endregion

    #region Methods

    public bool SpendCurrency(int amount) {
        if (amount > CurrencyCount) return false;
        CurrencyCount -= amount;
        return true;
    }

    #endregion
}
