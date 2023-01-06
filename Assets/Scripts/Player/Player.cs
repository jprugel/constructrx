using System;
using System.Collections;
using System.Collections.Generic;
using Library.Inventories;
using UnityEngine;

public class Player : MonoBehaviour {
    public static Player Singleton;
    [SerializeField] private int _currency;
    [SerializeField] private Storage<ConstructItem> _playerConstructItems;

    [SerializeField] private PlayerUI _playerUI;

    public int Currency {
        get => _currency;
        set => _currency = value;
    }

    public Storage<ConstructItem> PlayerConstructItems {
        get => _playerConstructItems;
    }

    public PlayerUI PlayerUI {
        get => _playerUI;
    }

    private void Start() {
        Singleton = this;
        
        
        
        GameManager.Singleton.Director.OnEnemyDeath.AddListener((enemy) => {
            Currency += enemy.Reward;
        });
        
        GameManager.Singleton.Director.OnWaveStart.AddListener(() => {
            Currency += Currency % 10;
        });
    }
}
