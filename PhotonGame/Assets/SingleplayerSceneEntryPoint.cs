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

    private PhotonChatPresenter photonChatPresenter;
    private CharacterSpawnerPresenter characterSpawnerPresenter;
    private CharacterPresenter characterPresenter;

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

        characterPresenter = new CharacterPresenter
            (new CharacterModel(), 
            viewContainer.GetView<CharacterView>());
        characterPresenter.Initialize();

        dIContainer.RegisterInstance(photonNetworkPresenter);
        dIContainer.RegisterInstance(photonChatPresenter);
        dIContainer.RegisterInstance(chooseNetworkServerPresenter);
        dIContainer.RegisterInstance(chooseNetworkChannelPresenter);
        dIContainer.RegisterInstance(characterSpawnerPresenter);
        dIContainer.RegisterInstance(characterPresenter);

        ActivateEvents();

        gameStateMachine = new GameStateMachine(dIContainer);
        gameStateMachine.Initialize();
    }

    private void ActivateEvents()
    {
        ActivateTransitEvents();

        chooseNetworkServerPresenter.OnChooseServer += photonNetworkPresenter.ChangeServer;
        chooseNetworkChannelPresenter.OnChooseChannel += photonNetworkPresenter.JoinOrCreateRoom;

        sceneRootView.OnClickToOpenGamePanel += characterSpawnerPresenter.SpawnLocalCharacter;
        sceneRootView.OnClickToOpenMenuPanelFromGamePanel += characterSpawnerPresenter.DestroyLocalCharacter;
    }

    private void DeactivateEvents()
    {
        DeactivateTransitEvents();

        chooseNetworkServerPresenter.OnChooseServer -= photonNetworkPresenter.ChangeServer;
        chooseNetworkChannelPresenter.OnChooseChannel -= photonNetworkPresenter.JoinOrCreateRoom;

        sceneRootView.OnClickToOpenGamePanel += characterSpawnerPresenter.SpawnLocalCharacter;
        sceneRootView.OnClickToOpenMenuPanelFromGamePanel += characterSpawnerPresenter.DestroyLocalCharacter;
    }

    private void ActivateTransitEvents()
    {
        photonNetworkPresenter.OnSelectRegion += LoadTransitScene;

        sceneRootView.OnClickToOpenGamePanel += sceneRootView.ActivateGamePanel;
        sceneRootView.OnClickToOpenSettingsPanel += sceneRootView.ActivateSettingsPanel;
        sceneRootView.OnClickToOpenChooseServerPanel += sceneRootView.ActivateChooseServerPanel;

        sceneRootView.OnClickToOpenMenuPanelFromGamePanel += sceneRootView.ActivateMenuPanel;
        sceneRootView.OnClickToOpenMenuPanelFromSettingsPanel += sceneRootView.ActivateMenuPanel;
        sceneRootView.OnClickToOpenMenuPanelFromChooseServerPanel += sceneRootView.ActivateMenuPanel;
    }

    private void DeactivateTransitEvents()
    {
        photonNetworkPresenter.OnSelectRegion -= LoadTransitScene;

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
        characterPresenter.Dispose();
    }

    #region Input

    public event Action OnLoadSingleplayerScene;
    public event Action OnLoadTransitScene;

    private void LoadSingleplayerScene()
    {
        OnLoadSingleplayerScene?.Invoke();
    }

    private void LoadTransitScene()
    {
        //OnLoadTransitScene?.Invoke();
    }

    #endregion
}
