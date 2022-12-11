using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable, IDetectable {
    //Fields
    [SerializeField] private int _health;

    [SerializeField] public UnityEvent<Enemy> OnEnemyDeath;
    //Properties
    //MonoBehaviour implementations
    //IDamageable implementations
    public void RecieveDamage(int damage) {
        _health -= damage;
        if (_health <= 0) {
            Destroy(gameObject);
            OnEnemyDeath?.Invoke(this);
        }
    }
}
