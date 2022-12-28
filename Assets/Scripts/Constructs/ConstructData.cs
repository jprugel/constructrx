using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "constructdata", menuName = "Construct Data")]
public class ConstructData : ScriptableObject {
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    
    [SerializeField] private Sprite _baseSprite;
    [SerializeField] private Sprite _headSprite;

    [SerializeField] private Sprite _projectileSprite;

    public string Name {
        get => _name;
    }

    public string Description {
        get => _description;
    }

    public Sprite BaseSprite {
        get => _baseSprite;
    }

    public Sprite HeadSprite {
        get => _headSprite;
    }

    public Sprite ProjectileSprite {
        get => _projectileSprite;
    }
}
