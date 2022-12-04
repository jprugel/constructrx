using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    [SerializeField] private Vector3 _mousePosition;

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ConstructManager _constructManager;

    [SerializeField] private Construct _coreConstruct;
    private InputAction _buildCore;

    private void Awake() {
        _buildCore = _playerInput.actions["Build Core"];
        
        _buildCore.started += BuildCore;
    }

    private void BuildCore(InputAction.CallbackContext context) {
        if (_constructManager.CoreIsBuilt) {
            Debug.Log($"Core is already built!");
            return;
        }
        _constructManager.BuildConstruct(_coreConstruct, _mousePosition);
        _constructManager.CoreIsBuilt = true;
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
