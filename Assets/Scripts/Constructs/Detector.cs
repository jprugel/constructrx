using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(CircleCollider2D))]
public class Detector : MonoBehaviour {
    //Fields
    [SerializeField] private CircleCollider2D _collider2D;
    [SerializeField] private float _radius;

    [SerializeField] private List<Enemy> _enemies;
    
    //Properties
    public float Radius {
        get => _radius;
        set => _radius = value;
    }
    
    //Events
    public UnityEvent OnDetectorUpdate;

    //MonoBehaviour implementations
    private void Awake() {
        _collider2D.radius = _radius;
        
        OnDetectorUpdate?.Invoke();
    }

    //Methods
    public void OnTriggerEnter2D(Collider2D col) {
        if (col.TryGetComponent(out Enemy enemy)) {
            _enemies.Add(enemy);
            OnDetectorUpdate?.Invoke();
        }
    }
    
    private void OnTriggerExit2D(Collider2D col) {
        if (col.TryGetComponent(out Enemy enemy)) {
            _enemies.Add(enemy);
            OnDetectorUpdate?.Invoke();
        }
    }

    public bool TryGetEnemy(out Enemy enemy) {
        enemy = null;
        if (_enemies.Count < 1) return false;
        enemy = _enemies[0];
        return true;
    }
}
