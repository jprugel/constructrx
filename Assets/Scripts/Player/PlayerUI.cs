using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour {

    #region Reference Fields

    [Header("References")] 
    [SerializeField] private PlayerInventory _playerInventory;
    
    #endregion

    #region Fields

    [SerializeField] private List<ConstructItem> _constructItems;

    #endregion

    #region Reference Properties

    public PlayerInventory PlayerInventory {
        get => _playerInventory;
    }

    #endregion

    #region Properties

    public List<ConstructItem> ConstructItems {
        get => _constructItems;
    }

    #endregion

    private void OnEnable() {
        
        PlayerInventory.ConstructItems.OnStorageUpdate += UpdateUI;
        
    }

    private void OnDisable() {
        
        PlayerInventory.ConstructItems.OnStorageUpdate -= UpdateUI;

    }

    private void UpdateUI(ConstructItem item) {

        foreach (ConstructItem constructItem in ConstructItems) {

            if (ReferenceEquals(constructItem.Data, null)) {
                
                constructItem.Initialize(item.Data);
                return;

            }

        }
        
    }
}
