using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Construct {
    //Fields
    [SerializeField] private Detector _detector;
    [SerializeField] private Transform _base;
    [SerializeField] private TurretHead _head;
    [SerializeField] private Transform _barrel;

    [SerializeField] private Transform _target;

    [SerializeField] private float _range;
    //Properties
    public Transform Target {
        get => _target;
        set => _target = value;
    }
    
    //MonoBehaviour implementation
    private void Awake() {
        //Detector Initialization
        _detector.Radius = _range;
        
        _detector.OnDetectorUpdate.AddListener(TargetUpdate);
        
        //Turret Head Initialization
    }

    //Methods

    private void TargetUpdate() {
        if (_detector.TryGetEnemy(out Enemy enemy)) {
            _target = enemy.transform;
            _head.Target = enemy;
        }
    }
}
