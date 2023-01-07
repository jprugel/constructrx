using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour {

    #region Reference Fields

    [Header("References")] 
    [SerializeField] private Player _player;
    
    
    

    #endregion

    #region Fields

    [SerializeField] private List<ConstructItem> _constructItems;

    #endregion

    #region Reference Properties

    public Player Player {
        get => _player;
    }

    #endregion

    #region Properties

    public List<ConstructItem> ConstructItems {
        get => _constructItems;
    }

    #endregion

    private void OnEnable() {

        Player.ConstructItems.OnStorageUpdate += UpdateUI;

    }

    private void OnDisable() {

        Player.ConstructItems.OnStorageUpdate -= UpdateUI;

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
