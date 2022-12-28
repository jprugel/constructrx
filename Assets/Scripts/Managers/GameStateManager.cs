using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {
    //Fields
    private GameState _currentState;
    private ShopState _shopState = new ShopState();
    private SetupState _setupState = new SetupState();
    private WaveState _waveState = new WaveState();
    
    
    //MonoBehaviour implementation
    public void Initialize() {
        _currentState = _shopState;
        
        GameManager.Singleton.Director.OnWaveStop.AddListener(() => {
            SwitchState(_shopState);
        });
    }
    
    //Methods
    private void SwitchState(GameState state) {
        _currentState.ExitState();
        _currentState = state;
        _currentState.EnterState();
    }
}

public abstract class GameState {
    internal abstract void EnterState();

    internal abstract void UpdateState();

    internal abstract void ExitState();
}

public class ShopState : GameState {
    internal override void EnterState() {
        throw new System.NotImplementedException();
    }

    internal override void UpdateState() {
        throw new System.NotImplementedException();
    }

    internal override void ExitState() {
        throw new System.NotImplementedException();
    }
}

public class SetupState : GameState {
    internal override void EnterState() {
        throw new System.NotImplementedException();
    }

    internal override void UpdateState() {
        throw new System.NotImplementedException();
    }

    internal override void ExitState() {
        throw new System.NotImplementedException();
    }
}

public class WaveState : GameState {
    internal override void EnterState() {
        throw new System.NotImplementedException();
    }

    internal override void UpdateState() {
        throw new System.NotImplementedException();
    }

    internal override void ExitState() {
        throw new System.NotImplementedException();
    }
}
