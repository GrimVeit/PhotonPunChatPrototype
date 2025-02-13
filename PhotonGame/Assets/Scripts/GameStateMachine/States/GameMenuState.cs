using System.Collections;
using System.Collections.Generic;
using BaCon;
using UnityEngine;

public class GameMenuState : IGlobalState
{
    private DIContainer container;

    private IGlobalStateMachineControl control;

    private SingleplayerSceneRootView sceneRoot;

    public GameMenuState(DIContainer container, IGlobalStateMachineControl control)
    {
        this.container = container;
        this.control = control;

        sceneRoot = this.container.Resolve<SingleplayerSceneRootView>();
    }

    public void EnterState()
    {
        Debug.Log("ACTIVATE STATE --- GAME MENU STATE");

        sceneRoot.OnClickToOpenGamePanel += ChangeStateToGame;

        sceneRoot.ActivateMenuPanel();
    }

    public void ExitState()
    {
        Debug.Log("DEACTIVATE STATE --- GAME MENU STATE");

        sceneRoot.OnClickToOpenGamePanel -= ChangeStateToGame;
    }

    private void ChangeStateToGame()
    {
        control.SetState(control.GetState<GameState>());
    }
}
