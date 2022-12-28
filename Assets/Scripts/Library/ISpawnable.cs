using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnable {
    public int Cost { get; set; }
    public int Reward { get; set; }

    public ISpawnable SpawnAt(Vector3 position);
}
