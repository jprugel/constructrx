using System;
using System.Collections;
using System.Collections.Generic;
using Constructs;
using UnityEngine;
using UnityEngine.UI;

public class Grab : MonoBehaviour {

    #region Field References

    [Header("Local References")] 
    [SerializeField] private Button _grabButton;
    [SerializeField] private ConstructItem _constructItem;

    [Header("Global References")] 
    [SerializeField] private PlayerController _playerController;

    #endregion

    #region Property References

    public Button GrabButton {
        get => _grabButton;
    }

    public ConstructData ConstructData {
        get => _constructItem.Data;
    }

    public PlayerController PlayerController {
        get => _playerController;
    }

    #endregion

    private void Start() {
        
        GrabButton.onClick.AddListener(() => {
            
            PlayerController.UpdateCursor(ConstructData);
            
        });
        
    }
}
