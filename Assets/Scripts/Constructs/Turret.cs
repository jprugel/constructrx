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

    [SerializeField] private Enemy _target;
    
    
    [SerializeField] private float _range;
    //Properties
    //MonoBehaviour implementation
    private void Awake() {
        DetectorAwake();
    }

    //Methods
    private void DetectorAwake() {
        _detector.DetectionRange = _range;
        
        _detector.OnEnemiesUpdate.AddListener(TargetUpdate);
    }

    private void TargetUpdate() {
        if (_detector.TryGetEnemy(out _target)) {
            _head.Target = _target;
        }
    }
}
