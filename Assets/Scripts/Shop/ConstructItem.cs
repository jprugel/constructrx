using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructItem : MonoBehaviour {
    
    //Fields
    [ReadOnly] [SerializeField] private Construct _targetConstruct;
    [SerializeField] private Transform _spawnPosition;
    [ReadOnly] [SerializeField] private Construct _spawnedConstruct;

    [SerializeField] private Button _purchaseButton;
    
    //Properties
    public Button PurchaseButton {
        get => _purchaseButton;
    }

    //MonoBehaviour implementation
    private void Start() {
        GenerateConstruct();
    }
    
    //Methods
    private void GenerateConstruct() {
        //_targetConstruct = GameManager.Singleton.Constructor.RandomConstruct();

        _spawnedConstruct = Instantiate(
            _targetConstruct,
            _spawnPosition.position,
            Quaternion.identity
        );
        
        _spawnedConstruct.transform.SetParent(transform);
    }
}
