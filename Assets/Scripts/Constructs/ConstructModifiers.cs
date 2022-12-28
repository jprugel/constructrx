using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConstructModifiers {
    
    #region  Fields
    
    [Header("Direct D.P.S. modifiers")]
    [SerializeField] private int _damage;
    [SerializeField] private int _firerate;
    [SerializeField] private int _critChance;
    [SerializeField] private int _critMulti;
    
    
    [Header("Other modifiers")]
    [SerializeField] private int _range;
    [SerializeField] private int _speed;

    #endregion

    #region Properties

    public int Damage {
        get => _damage;
    }

    public int Firerate {
        get => _firerate;
    }

    public int CritChance {
        get => _critChance;
    }

    public int CritMulti {
        get => _critMulti;
    }

    public int Range {
        get => _range;
    }

    public int Speed {
        get => _speed;
    }
    
    #endregion

}
