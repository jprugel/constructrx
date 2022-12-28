using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "constructstats", menuName = "Construct Stats")]
public class ConstructStats : ScriptableObject {
    [SerializeField] private ConstructModifiers _constructModifiers;

    public ConstructModifiers ConstructModifiers {
        get => _constructModifiers;
    }
}
