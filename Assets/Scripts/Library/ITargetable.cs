using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetable {
    /*
     * This interface is for all game objects that can be targeted by other game objects.
     */
    public Vector3 GetPosition();
    public string GetTag();
}
