using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : Construct, IDamageable {
    [SerializeField] private int _health;
    
    public void RecieveDamage(int damage) {
        _health -= damage;
        if (_health <= 0f) {
            throw new NotImplementedException();
        }
    }
}
