using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //Singleton
    private static GameManager s_singleton;

    [SerializeField] private GameStateManager _gameStateManager;
    [SerializeField] private Director _director;
    [SerializeField] private Constructor _constructor;
        
    //Properties
    public static GameManager Singleton {
        get => s_singleton;
    }
        
    public GameStateManager GameStateManager {
        get => _gameStateManager;
    }
        
    public Director Director {
        get => _director;
    }
        
    public Constructor Constructor {
        get => _constructor;
    }
    
    //MonoBehaviours implementations
    private void Awake() {
        // Checks if _singleton is null, if its not then it destroys this game object.
        if(ReferenceEquals(s_singleton, null)) s_singleton = this;
        else Destroy(this.gameObject);
    }
        
    private void Start() {
        _gameStateManager.Initialize();
    }
}
