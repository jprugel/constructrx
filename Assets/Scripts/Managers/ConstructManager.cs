using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConstructManager : MonoBehaviour {
    [SerializeField] private List<Construct> _constructs;

    public bool CoreIsBuilt;

    public List<Construct> Constructs {
        get => _constructs;
        set => _constructs = value;
    }

    public void Awake() {
        CoreIsBuilt = false;
    }

    public Construct BuildConstruct(Construct construct, Vector3 position) {
        Construct result;
        
        position = new Vector3(
            Mathf.Round(position.x),
            Mathf.Round(position.y),
            position.z
        );

        result = Instantiate(
            construct,
            position,
            Quaternion.identity
        );
        
        _constructs.Add(result);

        return result;
    }
    
}
