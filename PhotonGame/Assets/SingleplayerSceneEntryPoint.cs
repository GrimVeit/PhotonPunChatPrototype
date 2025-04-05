using BaCon;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SingleplayerSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private SingleplayerSceneRootView sceneRootViewPrefab;

    [SerializeField] private List<Character> characters = new List<Character>();
    [SerializeField] private List<Transform> transforms = new List<Transform>();

    private UIRootView mainRootView;
    private DIContainer dIContainer;
    private SingleplayerSceneRootView sceneRootView;
    private ViewContainer viewContainer;

    private PhotonNetworkPresenter photonNetworkPresenter;
    private ChooseNetworkServerPresenter chooseNetworkServerPresenter;
    private ChooseNetworkChannelPresenter chooseNetworkChannelPresenter;

    private JoystickInputSystemPresenter joystickInputSystemPresenter;
    private TouchRotationInputSystemPresenter touchRotationInputSystemPresenter;

    private PhotonChatPresenter photonChatPresenter;
    private CharacterSpawnerPresenter characterSpawnerPresenter;

    private CharacterMoveRotatePresenter characterMoveRotatePresenter;
    private CharacterCameraPresenter characterCameraPresenter;

    private GameStateMachine gameStateMachine;

    public void Run(DIContainer dIContainer)
    {
        this.dIContainer = dIContainer;
        mainRootView = this.dIContainer.Resolve<UIRootView>();
        sceneRootView = Instantiate(sceneRootViewPrefab);
        sceneRootView.Initialize();
        mainRootView.AttachSceneUI(sceneRootView.gameObject, Camera.main);

        viewContainer = sceneRootView.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        this.dIContainer.RegisterInstance(sceneRootView);

        Initialize();
    }

    private void Initialize()
    {
        joystickInputSystemPresenter = new JoystickInputSystemPresenter
            (new JoystickInputSystemModel(), 
            viewContainer.GetView<JoystickInputSystemView>());
        joystickInputSystemPresenter.Initialize();

        touchRotationInputSystemPresenter = new TouchRotationInputSystemPresenter
            (new TouchRotationInputSystemModel(), 
            viewContainer.GetView<TouchRotationInputSystemView>());
        touchRotationInputSystemPresenter.Initialize();

        photonNetworkPresenter = new PhotonNetworkPresenter
            (dIContainer.Resolve<PhotonNetworkModel>());
        photonNetworkPresenter.Initialize();

        photonChatPresenter = new PhotonChatPresenter
            (dIContainer.Resolve<PhotonChatModel>());
        photonChatPresenter.Initialize();

        chooseNetworkServerPresenter = new ChooseNetworkServerPresenter
            (new ChooseNetworkServerModel(), 
            viewContainer.GetView<ChooseNetworkServerView>());
        chooseNetworkServerPresenter.Initialize();

        chooseNetworkChannelPresenter = new ChooseNetworkChannelPresenter
            (new ChooseNetworkChannelModel(), 
            viewContainer.GetView<ChooseNetworkChannelView>());
        chooseNetworkChannelPresenter.Initialize();

        characterSpawnerPresenter = new CharacterSpawnerPresenter
            (new CharacterSpawnerModel(characters, transforms), 
            viewContainer.GetView<CharacterSpawnerView>());
        characterSpawnerPresenter.Initialize();

        characterMoveRotatePresenter = new CharacterMoveRotatePresenter(new CharacterMoveRotateModel());
        characterMoveRotatePresenter.Initialize();

        characterCameraPresenter = new CharacterCameraPresenter(new CharacterCameraModel());
        characterCameraPresenter.Initialize();

        dIContainer.RegisterInstance(joystickInputSystemPresenter);
        dIContainer.RegisterInstance(touchRotationInputSystemPresenter);
        dIContainer.RegisterInstance(photonNetworkPresenter);
        dIContainer.RegisterInstance(photonChatPresenter);
        dIContainer.RegisterInstance(chooseNetworkServerPresenter);
        dIContainer.RegisterInstance(chooseNetworkChannelPresenter);
        dIContainer.RegisterInstance(characterSpawnerPresenter);
        dIContainer.RegisterInstance(characterMoveRotatePresenter);
        dIContainer.RegisterInstance(characterCameraPresenter);

        ActivateEvents();

        gameStateMachine = new GameStateMachine(dIContainer);
        gameStateMachine.Initialize();
    }

    private void ActivateEvents()
    {
        ActivateTransitEvents();

        chooseNetworkServerPresenter.OnChooseServer += photonNetworkPresenter.ChangeServer;
        chooseNetworkChannelPresenter.OnChooseChannel += photonNetworkPresenter.JoinOrCreateRoom;
    }

    private void DeactivateEvents()
    {
        DeactivateTransitEvents();

        chooseNetworkServerPresenter.OnChooseServer -= photonNetworkPresenter.ChangeServer;
        chooseNetworkChannelPresenter.OnChooseChannel -= photonNetworkPresenter.JoinOrCreateRoom;
    }

    private void ActivateTransitEvents()
    {
        //photonNetworkPresenter.OnSelectRegion += LoadTransitScene;

        sceneRootView.OnClickToOpenGamePanel += sceneRootView.ActivateGamePanel;
        sceneRootView.OnClickToOpenSettingsPanel += sceneRootView.ActivateSettingsPanel;
        sceneRootView.OnClickToOpenChooseServerPanel += sceneRootView.ActivateChooseServerPanel;

        sceneRootView.OnClickToOpenMenuPanelFromGamePanel += sceneRootView.ActivateMenuPanel;
        sceneRootView.OnClickToOpenMenuPanelFromSettingsPanel += sceneRootView.ActivateMenuPanel;
        sceneRootView.OnClickToOpenMenuPanelFromChooseServerPanel += sceneRootView.ActivateMenuPanel;
    }

    private void DeactivateTransitEvents()
    {
        //photonNetworkPresenter.OnSelectRegion -= LoadTransitScene;

        sceneRootView.OnClickToOpenGamePanel -= sceneRootView.ActivateGamePanel;
        sceneRootView.OnClickToOpenSettingsPanel -= sceneRootView.ActivateSettingsPanel;
        sceneRootView.OnClickToOpenChooseServerPanel -= sceneRootView.ActivateChooseServerPanel;

        sceneRootView.OnClickToOpenMenuPanelFromGamePanel -= sceneRootView.ActivateMenuPanel;
        sceneRootView.OnClickToOpenMenuPanelFromSettingsPanel -= sceneRootView.ActivateMenuPanel;
        sceneRootView.OnClickToOpenMenuPanelFromChooseServerPanel -= sceneRootView.ActivateMenuPanel;
    }


    private void OnDestroy()
    {
        Dispose();
    }

    private void Dispose()
    {
        DeactivateEvents();

        characterSpawnerPresenter.Dispose();
        characterMoveRotatePresenter.Dispose();
    }

    //#region Input

    //public event Action OnLoadSingleplayerScene;
    //public event Action OnLoadTransitScene;

    //private void LoadSingleplayerScene()
    //{
    //    OnLoadSingleplayerScene?.Invoke();
    //}

    //private void LoadTransitScene()
    //{
    //    OnLoadTransitScene?.Invoke();
    //}

    //#endregion
}
