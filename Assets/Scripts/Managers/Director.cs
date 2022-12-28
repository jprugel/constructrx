using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Director : MonoBehaviour {
    //Fields
    [SerializeField] private List<Enemy> _spawnables;
    [SerializeField] private List<Transform> _spawners;
    [SerializeField] private List<Enemy> _spawned;

    [SerializeField] private int _baseBudget;
    [ReadOnly] [SerializeField] private int _currentBudget;
    
    [ReadOnly] [SerializeField] private int _wave;
    [SerializeField] private float _waveBudgetMultiplier;
    
    [ReadOnly] [SerializeField] private float _timeElapsed;
    [SerializeField] private float _timeBudgetMultiplier;
    
    //Events
    [SerializeField] public UnityEvent<Enemy> OnEnemySpawn;
    [SerializeField] public UnityEvent<Enemy> OnEnemyDeath;

    [SerializeField] public UnityEvent OnWaveStart;
    [SerializeField] public UnityEvent OnWaveStop;

    public IEnumerator Wave() {
        _currentBudget = CalculateBudget();
        _wave++;
        while (_currentBudget > 0) {
            int enemyIndex = Random.Range(0, _spawnables.Count);
            yield return null;
            int spawnIndex = Random.Range(0, _spawners.Count);
            yield return null;
            Vector3 spawnPosition = (Vector3)Random.insideUnitCircle;
            Enemy enemy = Instantiate(
                _spawnables[enemyIndex],
                _spawners[spawnIndex].position + spawnPosition,
                Quaternion.identity
            );
            OnEnemySpawn?.Invoke(enemy);
            _spawned.Add(enemy);
            _currentBudget -= enemy.Cost;
        }
    }

    private int CalculateBudget() {
        float waveMultiplierTotal = _wave * _waveBudgetMultiplier;
        float timeMultiplierTotal = _timeElapsed * _timeBudgetMultiplier;
        float currentBudget = Mathf.Pow(
            _baseBudget,
            (1 + waveMultiplierTotal + timeMultiplierTotal)
        );
        return (int) currentBudget;
    }
}
