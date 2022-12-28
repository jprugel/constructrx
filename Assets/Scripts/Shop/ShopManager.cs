using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {
    /*
     * Shop manager should handle initializing shop offerings. In version 0.1.0, the goal is to have the shop offer 3
     * construct based items.
     */

    //All items related to construct items.
    [SerializeField] private ConstructItem _constructItemPrefab;
    [ReadOnly] [SerializeField] private List<ConstructItem> _constructItems;
    [SerializeField] private List<Transform> _constructItemSpawnPositions;
    [SerializeField] private Transform _constructItemsChild;

    private void Start() {
        for (int a = 0; a <= _constructItemSpawnPositions.Count; a++) {
            _constructItems.Add(Instantiate(
                _constructItemPrefab,
                _constructItemSpawnPositions[a].position,
                Quaternion.identity
            ));
            
            _constructItems[a].transform.SetParent(_constructItemsChild);
        }
    }
}
