using System.Collections;
using System.Collections.Generic;
using Library.Inventories;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour, IStorable {
    public string Id { get; set; }
    public int Cost { get; set; }
}
