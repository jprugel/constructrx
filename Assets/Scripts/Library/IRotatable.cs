using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotatable {
    public bool Aligned {
        get;
        set;
    }
    public IEnumerator RotateTowards();
}
