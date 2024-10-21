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
    private PhotonChatPresenter photonChatPresenter;
    private CharacterSpawnerPresenter characterSpawnerPresenter;
    private CharacterPresenter characterPresenter;

    public void Run(DIContainer dIContainer)
    {
        this.dIContainer = dIContainer;
        mainRootView = this.dIContainer.Resolve<UIRootView>();
        sceneRootView = Instantiate(sceneRootViewPrefab);
        mainRootView.AttachSceneUI(sceneRootView.gameObject, Camera.main);

        Initialize();
    }

    private void Initialize()
    {
        ActivateEvents();

        photonNetworkPresenter = new PhotonNetworkPresenter
            (dIContainer.Resolve<PhotonNetworkModel>(), 
            viewContainer.GetView<PhotonNetworkView>());
        photonNetworkPresenter.Initialize();

        photonChatPresenter = new PhotonChatPresenter
            (dIContainer.Resolve<PhotonChatModel>(),
            viewContainer.GetView<PhotonChatView>());
        photonChatPresenter.Initialize();

        characterSpawnerPresenter = new CharacterSpawnerPresenter
            (new CharacterSpawnerModel(characters, transforms), 
            viewContainer.GetView<CharacterSpawnerView>());
        characterPresenter.Initialize();

        characterPresenter = new CharacterPresenter
            (new CharacterModel(), 
            viewContainer.GetView<CharacterView>());
        characterPresenter.Initialize();
    }

    private void ActivateEvents()
    {
        ActivateTransitEvents();

        sceneRootView.OnClickToOpenGamePanel += characterSpawnerPresenter.SpawnLocalCharacter;
        sceneRootView.OnClickToOpenMenuPanelFromGamePanel += characterSpawnerPresenter.DestroyLocalCharacter;
    }

    private void DeactivateEvents()
    {
        DeactivateTransitEvents();

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
        OnLoadTransitScene?.Invoke();
    }

    #endregion
}
