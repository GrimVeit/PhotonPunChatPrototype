using System;
using System.Collections;
using System.Collections.Generic;
using BaCon;
using UnityEngine;

public class GameStateMachine : IGlobalStateMachineControl
{
    private Dictionary<Type, IGlobalState> states = new Dictionary<Type, IGlobalState>();

    private IGlobalState currentState;

    public GameStateMachine(DIContainer container)
    {
        states[typeof(GameMenuState)] = new GameMenuState(container, this);
        states[typeof(GameState)] = new GameState(container, this);
    }

    public void Initialize()
    {
        SetState(GetState<GameMenuState>());
    }

    public void Dispose()
    {

    }

    public IGlobalState GetState<T>() where T : IGlobalState
    {
        return states[typeof(T)];
    }

    public void SetState(IGlobalState state)
    {
        currentState?.ExitState();

        currentState = state;
        currentState.EnterState();
    }
}

public interface IGlobalStateMachineControl
{
    public IGlobalState GetState<T>() where T : IGlobalState;
    public void SetState(IGlobalState state);
}
