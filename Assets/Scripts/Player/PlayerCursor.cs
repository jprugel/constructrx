using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour {

    #region Fields
    
    [ReadOnly] [SerializeField] private Vector2 _cursorPosition;
    [SerializeField] private Texture2D _cursorTexture;

    #endregion

    #region Properties

    public Vector2 CursorPosition {
        get => _cursorPosition;
        private set => _cursorPosition = value;
    }

    public Texture2D CursorTexture {
        get => _cursorTexture;
    }

    #endregion

    private void Awake() {
        
        //Cursor.SetCursor(CursorTexture);
        
    }

    private void Update() {

        Vector2 mousePosition = Input.mousePosition;
        CursorPosition = Camera.main.ScreenToWorldPoint(mousePosition);

    }
}
