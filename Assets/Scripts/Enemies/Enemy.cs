using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable, IDetectable {
    //Fields
    [SerializeField] private int _cost;

    [SerializeField] private int _reward;
    
    [SerializeField] private int _health;

    //Properties
    public int Cost {
        get => _cost; 
        set => _cost = value;
    }

    public int Reward {
        get => _reward; 
        set => _reward = value;
    }
    //Fields
    
    //Properties
    //MonoBehaviour implementations
    //IDamageable implementations
    public void RecieveDamage(int damage) {
        _health -= damage;
        if (_health <= 0) {
            Destroy(gameObject);
            GameManager.Singleton.Director.OnEnemyDeath?.Invoke(this);
        }
    }
}
