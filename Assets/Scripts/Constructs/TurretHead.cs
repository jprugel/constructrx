using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretHead : MonoBehaviour, IRotatable {
    /*
     * The goal of this class is to turn towards a target, and let the Construct know when it is aligned
     */
    
    //Fields
    [SerializeField] private Detector _detector;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _progress;
    private Transform _target;
    private bool _aligned;

    //Properties
    public bool Aligned {
        get => _aligned; 
        set => _aligned = value;
    }
    
    //Events
    public UnityEvent OnAlignment;

    public void TurretHeadAwake() {
        _detector.OnDetectorUpdate.AddListener(TryRotateTowards);
    }

    private void TryRotateTowards() {
        if (_detector.TryGetEnemy(out Enemy enemy)) {
            _target = enemy.transform;
            StartCoroutine(RotateTowards());
        }
    }

    public IEnumerator RotateTowards() {
        Quaternion startRotation = transform.rotation;
        Vector3 vectorToTarget = _target.position - transform.position;
        //Convert this to an angle
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        //Convert the angle to a quaternion
        Quaternion stopRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        float timeElapsed = 0f;
        float maxDuration = 3f;
        while (_progress < 1f) {
            //Rotate!
            _progress = timeElapsed / maxDuration;
            transform.rotation = Quaternion.Slerp(startRotation, stopRotation, _progress);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        Aligned = true;
        OnAlignment?.Invoke();
    }
}
