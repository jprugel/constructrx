using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construct : MonoBehaviour {
    #region Fields
    
    [Header("ScriptableObjects")]
    
    [SerializeField] private ConstructData _data;
    [SerializeField] private ConstructStats _stats;
    
    [Header("Target Fields")]
    [ReadOnly] [SerializeField] private string _name;
    [ReadOnly] [SerializeField] private string _description;

    [Header("References to children")] 
    [ReadOnly] [SerializeField] private SpriteRenderer _baseSpriteRenderer;
    [ReadOnly] [SerializeField] private SpriteRenderer _headSpriteRenderer;

    [Header("Statistic Fields")] 
    [ReadOnly] [SerializeField] private int _damage;
    [ReadOnly] [SerializeField] private int _firerate;
    [ReadOnly] [SerializeField] private int _critChance;
    [ReadOnly] [SerializeField] private int _critMulti;

    [ReadOnly] [SerializeField] private int _range;
    [ReadOnly] [SerializeField] private int _speed;
    
    #endregion Fields

    #region Properties
    public ConstructData Data {
        get => _data;
    }

    public ConstructStats Stats {
        get => _stats;
    }

    public string Name {
        get => _name;
        private set => _name = value;
    }

    public string Description {
        get => _description;
        private set => _description = value;
    }

    public SpriteRenderer BaseSpriteRenderer {
        get => _baseSpriteRenderer;
        private set => _baseSpriteRenderer = value;
    }

    public SpriteRenderer HeadSpriteRenderer {
        get => _headSpriteRenderer;
        private set => _headSpriteRenderer = value;
    }

    public int Damage {
        get => _damage;
        private set => _damage = value;
    }

    public int FireRate {
        get => _firerate;
        private set => _firerate = value;
    }

    public int CritChance {
        get => _critChance;
        private set => _critChance = value;
    }

    public int CritMulti {
        get => _critMulti;
        private set => _critMulti = value;
    }

    public int Range {
        get => _range;
        private set => _range = value;
    }

    public int Speed {
        get => _speed;
        private set => _speed = value;
    }
    
    #endregion

    private void Start() {
        SetupConstruct();
    }

    private void SetupConstruct() {
        Name = Data.Name;
        Description = Data.Description;
        
        BaseSpriteRenderer.sprite = Data.BaseSprite;
        HeadSpriteRenderer.sprite = Data.HeadSprite;

        Damage = Stats.ConstructModifiers.Damage;
        FireRate = Stats.ConstructModifiers.Firerate;
        CritChance = Stats.ConstructModifiers.CritChance;
        CritMulti = Stats.ConstructModifiers.CritMulti;

        Range = Stats.ConstructModifiers.Range;
        Speed = Stats.ConstructModifiers.Speed;
    }
}
