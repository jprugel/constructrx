using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHead : MonoBehaviour {
    //Fields
    private Vector3 _startingPosition;
    private Vector3 _stoppingPosition;
    private float _rotationProgress;
    
    [SerializeField] private float _rotationSpeed;
    //Properties
    
    //MonoBehaviour implementations
    //Methods
    private void RotationMethod() {
        //Create a vector to the target
        Vector3 vectorToTarget = _stoppingPosition - transform.position;
        //Convert this to an angle
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        //Rotate around axis
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //Rotate!
        transform.rotation = Quaternion.Slerp(transform.rotation, q, _rotationSpeed * Time.deltaTime);
    }
}
