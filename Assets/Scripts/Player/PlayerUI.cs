using System;
using System.Collections;
using System.Collections.Generic;
using Library.Inventories;
using UnityEngine;

public class PlayerUI : MonoBehaviour {
    #region Fields

    [SerializeField] private List<PlayerConstructItem> _playerConstructItems; 

    #endregion

    #region Properties

    public List<PlayerConstructItem> PlayerConstructItems {
        get => _playerConstructItems;
    }

    #endregion

    #region MonoBehaviour Implementations

    private void OnEnable() {
        Player.Singleton.PlayerConstructItems.OnStorageUpdate += UpdateUI;
    }

    private void OnDisable() {
        Player.Singleton.PlayerConstructItems.OnStorageUpdate -= UpdateUI;
    }

    #endregion

    #region Methods

    private void UpdateUI(ConstructItem item) {
        
    }

    #endregion
}
