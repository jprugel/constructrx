using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Constructs;
using UnityEngine.Events;

public class PlayerConstructItem : MonoBehaviour {
    #region Fields
    
    [Header("Construct Data")]
    [ReadOnly] [SerializeField] private ConstructData _data;
    
    [Header("Sprite Renderers")]
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

    public UnityEvent OnDataUpdate;

    #endregion
    
    #region MonoBehaviour Implementation

    private void Start() {
        OnDataUpdate.AddListener(() => {
            BaseRenderer.sprite = Data.Sprites.Base;
            HeadRenderer.sprite = Data.Sprites.Head;
        });
    }

    #endregion
    
    #region Methods

    public void UpdateData(ConstructData data) {
        Data = data;
        OnDataUpdate?.Invoke();
    }
    
    #endregion
}
