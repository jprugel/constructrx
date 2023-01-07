using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Constructs;
using UnityEngine.Events;

public class ConstructItem : Item {
    
    #region Fields

    [ReadOnly] [SerializeField] private ConstructData _data;

    [SerializeField] private SpriteRenderer _baseRenderer;
    [SerializeField] private SpriteRenderer _headRenderer;

    #endregion

    #region Properties

    public ConstructData Data {
        get => _data;
        private set => _data = value;
    }

    public SpriteRenderer BaseRenderer {
        get => _baseRenderer;
    }

    public SpriteRenderer HeadRenderer {
        get => _headRenderer;
    }

    #endregion

    #region Events

    public UnityEvent OnInitialized;

    #endregion

    public void Initialize(ConstructData data) {
        Data = data;

        Cost = Data.Cost;

        BaseRenderer.sprite = Data.Sprites.Base;
        HeadRenderer.sprite = Data.Sprites.Head;
        
        OnInitialized?.Invoke();
    }
}
