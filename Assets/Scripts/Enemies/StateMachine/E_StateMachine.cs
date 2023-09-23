using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_StateMachine
{
    public E_State currentState { get; private set; }
    public void Initialized(E_State newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    public void ChangeState(E_State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
