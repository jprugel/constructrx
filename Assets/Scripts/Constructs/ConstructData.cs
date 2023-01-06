using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Constructs {
    
    #region Construct Data
    [CreateAssetMenu(fileName = "constructData", menuName = "Construct Data")]
    public class ConstructData : ScriptableObject {
        [SerializeField] private ConstructSprites _sprites;
        [SerializeField] private ConstructStat _stat;

        [SerializeField] private int _cost;

        public ConstructSprites Sprites {
            get => _sprites;
        }

        public ConstructStat Stat {
            get => _stat;
        }

        public int Cost {
            get => _cost;
        }
    }
    #endregion

    #region ConstructStat
    [Serializable]
    public class ConstructStat {
        [SerializeField] private float _damage;

        public float Damage {
            get => _damage;
        }
    }
    #endregion ConstructStat
    
    #region ConstructSprites
    [Serializable]
    public class ConstructSprites {
        [SerializeField] private Sprite _base;
        [SerializeField] private Sprite _head;

        public Sprite Base {
            get => _base;
        }

        public Sprite Head {
            get => _head;
        }
    }
    #endregion ConstructSprites
}
