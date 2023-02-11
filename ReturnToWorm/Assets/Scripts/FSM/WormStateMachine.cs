using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormStateMachine : MonoBehaviour
{
    public WormState currentState;

    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    public void ChangeState(WormState newState)
    {

        if (!currentState.Exit()) { return; }

        currentState = newState;
        currentState.Enter();
    }

    protected virtual WormState GetInitialState()
    {
        return null;
    }
}
