using System.Collections;
using System.Collections.Generic;
using BaCon;
using UnityEngine;

public class GameMenuState : IGlobalState
{
    private DIContainer _container;

    private IGlobalStateMachineControl _globalStateMachineProvider;

    private SingleplayerSceneRootView _sceneRoot;

    public GameMenuState(DIContainer container, IGlobalStateMachineControl control)
    {
        _container = container;
        _globalStateMachineProvider = control;

        _sceneRoot = _container.Resolve<SingleplayerSceneRootView>();
    }

    public void EnterState()
    {
        Debug.Log("ACTIVATE STATE --- GAME MENU STATE");

        _sceneRoot.OnClickToOpenGamePanel += ChangeStateToGame;

        _sceneRoot.ActivateMenuPanel();
    }

    public void ExitState()
    {
        Debug.Log("DEACTIVATE STATE --- GAME MENU STATE");

        _sceneRoot.OnClickToOpenGamePanel -= ChangeStateToGame;
    }

    private void ChangeStateToGame()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<GameState>());
    }
}
