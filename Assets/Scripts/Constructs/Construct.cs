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
        private set => _base = value;
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

    #region Methods

    public void Initialize(ConstructData data) {
        Base = data;
        
        BaseRenderer.sprite = Base.Sprites.Base;
        HeadRenderer.sprite = Base.Sprites.Head;

        Stat = Base.Stat;
    }

    #endregion
}
