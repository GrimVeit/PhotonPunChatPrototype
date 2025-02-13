using System.Collections;
using System.Collections.Generic;
using BaCon;
using UnityEngine;

public class GameState : IGlobalState
{
    private DIContainer container;

    private IGlobalStateMachineControl control;

    private SingleplayerSceneRootView sceneRoot;
    private CharacterSpawnerPresenter characterSpawnerPresenter;
    private CharacterPresenter characterPresenter;
    private PhotonChatPresenter photonChatPresenter;

    public GameState(DIContainer container, IGlobalStateMachineControl control)
    {
        this.container = container;
        this.control = control;

        sceneRoot = this.container.Resolve<SingleplayerSceneRootView>();
        characterSpawnerPresenter = this.container.Resolve<CharacterSpawnerPresenter>();
        characterPresenter = this.container.Resolve<CharacterPresenter>();
        photonChatPresenter = this.container.Resolve<PhotonChatPresenter>();
    }

    public void EnterState()
    {
        Debug.Log("ACTIVATE STATE --- GAME MENU STATE");

        sceneRoot.OnClickToOpenMenuPanelFromGamePanel += ChangeStateToMenu;
        characterSpawnerPresenter.OnSpawnCharacter += characterPresenter.SetCharacter;

        characterSpawnerPresenter.SpawnLocalCharacter();

        sceneRoot.ActivateGamePanel();
    }

    public void ExitState()
    {
        Debug.Log("DEACTIVATE STATE --- GAME MENU STATE");

        sceneRoot.OnClickToOpenMenuPanelFromGamePanel -= ChangeStateToMenu;
        characterSpawnerPresenter.OnSpawnCharacter -= characterPresenter.SetCharacter;

        characterSpawnerPresenter.DestroyLocalCharacter();
    }

    private void ChangeStateToMenu()
    {
        control.SetState(control.GetState<GameMenuState>());
    }
}
