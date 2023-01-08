using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerCurrency : MonoBehaviour {
    
    #region Fields

    [SerializeField] private float _currencyCount;

    #endregion
    
    #region Properties

    public float CurrencyCount {
        get => _currencyCount;
        private set => _currencyCount = value; 
    }
    
    #endregion

    #region Methods

    public bool SpendCurrency(int amount) {
        if (amount > CurrencyCount) return false;
        CurrencyCount -= amount;
        return true;
    }

    #endregion

}
