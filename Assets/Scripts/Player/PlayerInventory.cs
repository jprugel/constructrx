using System.Collections;
using System.Collections.Generic;
using Library.Inventories;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    #region Fields

    [SerializeField] private Storage<ConstructItem> _constructItems;

    #endregion

    #region MyRegion

    public Storage<ConstructItem> ConstructItems {
        get => _constructItems;
    }

    #endregion
}
