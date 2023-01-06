using System.Collections;
using System.Collections.Generic;
using Constructs;
using UnityEngine;

public class Construct : MonoBehaviour {
    #region Fields

    [Header("Scriptable Objects")] 
    [SerializeField] private ConstructData _base;

    [Header("Visual Data")] 
    [SerializeField] private SpriteRenderer _baseRenderer;
    [SerializeField] private SpriteRenderer _headRenderer;
    
    [Header("Current Statistics")]
    [ReadOnly] [SerializeField] private ConstructStat _stat;
    
    #endregion Fields

    #region Properties

    public ConstructData Base {
        get => _base;
    }

    public SpriteRenderer BaseRenderer {
        get => _baseRenderer;
        private set => _baseRenderer = value;
    }

    public SpriteRenderer HeadRenderer {
        get => _headRenderer;
        private set => _headRenderer = value;
    }

    public ConstructStat Stat {
        get => _stat;
        private set => _stat = value;
    }
    
    #endregion Properties

    private void Start() {
        SetupConstruct();
    }

    private void SetupConstruct() {
        BaseRenderer.sprite = Base.Sprites.Base;
        BaseRenderer.sortingOrder = 0;
        
        HeadRenderer.sprite = Base.Sprites.Head;
        HeadRenderer.sortingOrder = 1;

        Stat = Base.Stat;
    }
}
