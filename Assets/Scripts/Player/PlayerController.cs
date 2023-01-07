using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constructs;

public class PlayerController : MonoBehaviour {

    #region Fields

    [SerializeField] private PlayerUI _playerUI;

    [SerializeField] private SpriteRenderer _baseRenderer;
    [SerializeField] private SpriteRenderer _headRenderer;

    [SerializeField] private ConstructData _heldData;

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

    #endregion

    private void Update() {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = worldPosition;
    }

    public void UpdateCursor(ConstructData data) {
        HeldData = data;
        
        BaseRenderer.sprite = HeldData.Sprites.Base;
        HeadRenderer.sprite = HeldData.Sprites.Head;
    }
}
