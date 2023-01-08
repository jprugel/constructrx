using System;
using System.Collections;
using System.Collections.Generic;
using Constructs;
using UnityEngine;
using UnityEngine.UI;

public class Grab : MonoBehaviour {

    #region Field References

    [Header("Local References")] 
    [SerializeField] private Button _grabButton;
    [SerializeField] private ConstructItem _constructItem;
    [SerializeField] private ConstructCursor _constructCursorPrefab;

    [Header("Global References")] 
    
    [SerializeField] private Player _player;
    

    #endregion

    #region Property References

    public Button GrabButton {
        get => _grabButton;
    }

    public ConstructData ConstructData {
        get => _constructItem.Data;
    }

    public ConstructCursor Cursor {
        get => _constructCursorPrefab;
    }

    public Player Player {
        get => _player;
    }

    #endregion

    private void Start() {
        
        GrabButton.onClick.AddListener(() => {

            ConstructCursor cursor = Instantiate(
                Cursor,
                Player.transform
            );
            
            cursor.Initialize(ConstructData);

        });
        
    }
}
