using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private int _currency;
    [SerializeField]

    public int Currency {
        get => _currency;
        set => _currency = value;
    }

    private void Start() {
        GameManager.Singleton.Director.OnEnemyDeath.AddListener((enemy) => {
            Currency += enemy.Reward;
        });
        
        GameManager.Singleton.Director.OnWaveStart.AddListener(() => {
            Currency += Currency % 10;
        });
    }
}
