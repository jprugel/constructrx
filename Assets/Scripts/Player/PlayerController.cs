using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constructs;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    #region Fields

    [SerializeField] private PlayerUI _playerUI;

    [SerializeField] private SpriteRenderer _baseRenderer;
    [SerializeField] private SpriteRenderer _headRenderer;

    [SerializeField] private ConstructData _heldData;

    [SerializeField] private Construct _constructPrefab;

    #endregion

    #region Properties

    public PlayerUI PlayerUI {
        get => _playerUI;
    }

    public SpriteRenderer BaseRenderer {
        get => _baseRenderer;
    }

    public SpriteRenderer HeadRenderer {
        get => _headRenderer;
    }

    public ConstructData HeldData {
        get => _heldData;
        private set => _heldData = value;
    }

    public Construct ConstructPrefab {
        get => _constructPrefab;
    }

    #endregion

    private void Update() {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(
            Mathf.Round(worldPosition.x * 2) / 2,
            Mathf.Round(worldPosition.y * 2) / 2
        );

        if (Mouse.current.leftButton.isPressed && !ReferenceEquals(HeldData, null)) {
            PlaceConstruct(HeldData);
        }
    }

    public void UpdateCursor(ConstructData data) {
        HeldData = data;
        
        BaseRenderer.sprite = HeldData.Sprites.Base;
        HeadRenderer.sprite = HeldData.Sprites.Head;
    }

    public void ClearCursor() {
        HeldData = null;

        BaseRenderer.sprite = null;
        HeadRenderer.sprite = null;
    }

    public void PlaceConstruct(ConstructData data) {
        Construct construct = Instantiate(
            ConstructPrefab,
            transform.position,
            Quaternion.identity
        );

        construct.Initialize(data);
        
        ClearCursor();
    }
}
