using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    //Fields
    [SerializeField] private Vector3 _startingPosition;
    [SerializeField] private Vector3 _StoppingPosition;
    [SerializeField] private float _projectileProgress;

    private float _projectileSpeed;
    private int _projectileDamage;

    private LayerMask _layerMask;
    
    //Properties
    public Vector3 StartingPosition {
        get => _startingPosition;
        set => _startingPosition = value;
    }

    public Vector3 StoppingPosition {
        get => _StoppingPosition;
        set => _StoppingPosition = value;
    }

    public float ProjectileSpeed {
        get => _projectileSpeed;
        set => _projectileSpeed = value;
    }

    public int ProjectileDamage {
        get => _projectileDamage;
        set => _projectileDamage = value;
    }
    
    //MonoBehaviour implementations
    private void Awake() {
        StartCoroutine(InterpolatePosition());
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.TryGetComponent(out IDamageable damageable)) {
            damageable.RecieveDamage(_projectileDamage);
            Destroy(gameObject);
        }
    }

    //Methods
    private IEnumerator InterpolatePosition() {
        _projectileProgress = 0f;
        while (_projectileProgress < 1f) {
            _projectileProgress += Time.deltaTime * _projectileSpeed;
            transform.position = Vector3.Lerp(
                _startingPosition,
                _StoppingPosition,
                _projectileProgress
            );
            yield return null;
        }
        Destroy(gameObject);
    }
}
