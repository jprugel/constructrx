using System.Collections;
using System.Collections.Generic;
using Constructs;
using UnityEngine;
using Random = UnityEngine.Random;

public class Constructor : MonoBehaviour {
    [SerializeField] private Construct _constructPrefab;

    [SerializeField] private List<ConstructData> _constructDatas;

    public List<ConstructData> ConstructDatas {
        get => _constructDatas;
    }

    public ConstructData RandomConstructData() {
        return ConstructDatas[Random.Range(0, ConstructDatas.Count)];
    }
}
