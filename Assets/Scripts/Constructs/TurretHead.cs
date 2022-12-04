using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class TurretHead : MonoBehaviour, IRotatable {
    //Fields
    private ITargetable _target;
    private float _rotationProgress;
    
    [SerializeField] private float _rotationSpeed;
    //Properties
    public ITargetable Target {
        get => _target;
        set => _target = value;
    }
    //MonoBehaviour implementations

    private void Start() {
        StartCoroutine(RotateTowards());
    }

    //Methods
    public IEnumerator RotateTowards() {
        for (;;) {
            //Create a vector to the target
            if (Object.ReferenceEquals(_target, null)) yield return null;
            Vector3 vectorToTarget = _target.GetPosition() - transform.position;
            //Convert this to an angle
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            //Rotate around axis
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            //Rotate!
            transform.rotation = Quaternion.Slerp(transform.rotation, q, _rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
