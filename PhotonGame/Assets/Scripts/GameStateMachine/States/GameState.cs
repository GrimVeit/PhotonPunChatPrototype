using System.Collections;
using System.Collections.Generic;
using BaCon;
using UnityEngine;

public class GameState : IGlobalState
{
    private readonly DIContainer _container;

    private readonly IGlobalStateMachineControl _globalStateMachineProvider;

    private readonly SingleplayerSceneRootView _sceneRoot;
    private readonly PhotonChatPresenter _photonChatPresenter;
    private readonly CharacterSpawnerPresenter _characterSpawnerPresenter;
    private readonly CharacterMoveRotatePresenter _characterMoveRotatePresenter;
    private readonly CharacterCameraPresenter _characterCameraPresenter;
    private readonly JoystickInputSystemPresenter _joystickInputSystemPresenter;
    private readonly TouchRotationInputSystemPresenter _touchRotationInputSystemPresenter;

    public GameState(DIContainer container, IGlobalStateMachineControl control)
    {
        _container = container;
        _globalStateMachineProvider = control;

        _sceneRoot = _container.Resolve<SingleplayerSceneRootView>();
        _characterSpawnerPresenter = _container.Resolve<CharacterSpawnerPresenter>();
        _characterMoveRotatePresenter = _container.Resolve<CharacterMoveRotatePresenter>();
        _characterCameraPresenter = _container.Resolve<CharacterCameraPresenter>();
        _joystickInputSystemPresenter = _container.Resolve<JoystickInputSystemPresenter>();
        _touchRotationInputSystemPresenter = _container.Resolve<TouchRotationInputSystemPresenter>();
        _photonChatPresenter = _container.Resolve<PhotonChatPresenter>();
    }

    public void EnterState()
    {
        Debug.Log("ACTIVATE STATE --- GAME MENU STATE");

        _sceneRoot.OnClickToOpenMenuPanelFromGamePanel += ChangeStateToMenu;
        _characterSpawnerPresenter.OnSpawnCharacter += _characterMoveRotatePresenter.SetCharacter;
        _characterSpawnerPresenter.OnSpawnCharacter += _characterCameraPresenter.SetCharacter;
        _joystickInputSystemPresenter.OnMove += _characterMoveRotatePresenter.Move;
        _touchRotationInputSystemPresenter.OnRotate += _characterMoveRotatePresenter.Rotate;

        _characterSpawnerPresenter.SpawnLocalCharacter();
        _characterCameraPresenter.ActivateCamera();

        _sceneRoot.ActivateGamePanel();
    }

    public void ExitState()
    {
        Debug.Log("DEACTIVATE STATE --- GAME MENU STATE");


        _sceneRoot.OnClickToOpenMenuPanelFromGamePanel -= ChangeStateToMenu;
        _characterSpawnerPresenter.OnSpawnCharacter -= _characterMoveRotatePresenter.SetCharacter;
        _characterSpawnerPresenter.OnSpawnCharacter -= _characterCameraPresenter.SetCharacter;
        _joystickInputSystemPresenter.OnMove -= _characterMoveRotatePresenter.Move;
        _touchRotationInputSystemPresenter.OnRotate -= _characterMoveRotatePresenter.Rotate;

        _characterSpawnerPresenter.DestroyLocalCharacter();
        _characterCameraPresenter.DeactivateCamera();
    }

    private void ChangeStateToMenu()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<GameMenuState>());
    }
}
