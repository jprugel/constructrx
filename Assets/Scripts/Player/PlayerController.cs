using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    #region Fields

    [SerializeField] private PlayerInput _playerInput;
    
    private InputAction _toggleShopAction;
    [SerializeField] private ShopManager _shopManager;

    #endregion

    #region Properties

    public PlayerInput PlayerInput {
        get => _playerInput;
    }

    public InputAction ToggleShopAction {
        get => _toggleShopAction;
        private set => _toggleShopAction = value;
    }

    public ShopManager ShopManager {
        get => _shopManager;
    }

    #endregion

    private void Start() {

        ToggleShopAction = PlayerInput.actions["Toggle Shop"];

    }

    private void Update() {
        
        if (ToggleShopAction.triggered) ToggleShop();
        
    }

    private void ToggleShop() {
        ShopManager.gameObject.SetActive(!ShopManager.gameObject.activeSelf);
    }
}
