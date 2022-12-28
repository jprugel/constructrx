using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Storage<TStorable> where TStorable : IStorable {
    private List<TStorable> _storables;
}

public interface IStorable {
    public int Count { get; set; }
}
