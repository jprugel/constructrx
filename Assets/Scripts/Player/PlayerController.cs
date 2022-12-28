using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    [SerializeField] private Vector3 _mousePosition;

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ConstructManager _constructManager;

    public Construct Construct;
    private InputAction _buildCore;

    private void Awake() {
        _buildCore = _playerInput.actions["Build Construct"];
        
        _buildCore.started += BuildConstruct;
    }

    private void BuildConstruct(InputAction.CallbackContext context) {
        Instantiate(
            Construct,
            _mousePosition,
            Quaternion.identity
        );
    }

    private void Update() {
        _mousePosition = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Input.mousePosition.x, 
                Input.mousePosition.y,
                9
            )
        );
    }
}
