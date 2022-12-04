using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detector : MonoBehaviour {
    //Fields
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] public UnityEvent OnEnemiesUpdate;
    [SerializeField] private CircleCollider2D _detectionArea;
    private float _detectionRange;
    //Properties
    public float DetectionRange {
        get => _detectionRange;
        set => _detectionRange = value;
    }
    //MonoBehaviour implementations
    private void Awake() {
        _enemies = new List<Enemy>();
    }

    private void Start() {
        _detectionArea.radius = _detectionRange;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.TryGetComponent(out Enemy enemy)) {
            _enemies.Add(enemy);
            enemy.OnEnemyDeath.AddListener(RemoveEnemyOnDeath);
            OnEnemiesUpdate?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.TryGetComponent(out Enemy enemy)) {
            _enemies.Remove(enemy);
            OnEnemiesUpdate?.Invoke();
        }
    }
    //Methods
    private void RemoveEnemyOnDeath(Enemy enemy) {
        _enemies.Remove(enemy);
        OnEnemiesUpdate?.Invoke();
    }

    public bool TryGetEnemy(out Enemy enemy) {
        enemy = null;
        if (_enemies.Count >= 1) {
            enemy = _enemies[0];
            return true;
        }
        return false;
    }
}
