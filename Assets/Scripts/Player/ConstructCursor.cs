using System;
using System.Collections;
using System.Collections.Generic;
using Constructs;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConstructCursor : MonoBehaviour {

    #region Fields

    [SerializeField] private Player _player;

    [SerializeField] private Vector2 _cursorPosition;

    [SerializeField] private ConstructData _data;
    [SerializeField] private Construct _constructPrefab;

    [SerializeField] private SpriteRenderer _baseRenderer;
    [SerializeField] private SpriteRenderer _headRenderer;

    #endregion

    #region Properties

    public Player Player {
        get => _player;
    }

    public Vector2 CursorPosition {
        get => _cursorPosition;
        private set => _cursorPosition = value;
    }

    public ConstructData Data {
        get => _data;
        private set => _data = value;
    }

    public Construct ConstructPrefab {
        get => _constructPrefab;
    }

    public SpriteRenderer BaseRenderer {
        get => _baseRenderer;
    }

    public SpriteRenderer HeadRenderer {
        get => _headRenderer;
    }

    #endregion

    private void Update() {

        Vector2 mousePosition = Input.mousePosition;
        CursorPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        CursorPosition = new Vector2(
            Mathf.Round(CursorPosition.x * 2) / 2,
            Mathf.Round(CursorPosition.y * 2) / 2
        );
        
        transform.position = CursorPosition;

        if (Mouse.current.leftButton.wasPressedThisFrame) {
            PlaceConstruct();
        }

    }

    public void Initialize(ConstructData data) {

        Data = data;

        BaseRenderer.sprite = Data.Sprites.Base;
        HeadRenderer.sprite = Data.Sprites.Head;
    }

    private void PlaceConstruct() {
        Construct construct = Instantiate(
            ConstructPrefab,
            CursorPosition,
            Quaternion.identity,
            transform.parent
        );
        
        construct.Initialize(Data);
        
        Destroy(gameObject);
    }
}
