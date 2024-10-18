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

    private void Dispose()
    {
        characterSpawnerPresenter.Dispose();
        characterPresenter.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
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
