using System;
using System.Collections;
using System.Collections.Generic;
using Library.Inventories;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {
    #region Fields

    [SerializeField] private Storage<ConstructItem> _constructItems;

    #endregion

    #region Properties

    public Storage<ConstructItem> ConstructItems {
        get => _constructItems;
    }

    #endregion

    #region MonoBehaviour Implementations
    
    

    #endregion
}
