using BaCon;
using System;
using UnityEngine;

public class TransitSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private TransitSceneUIRoot sceneRootViewPrefab;

    private UIRootView mainRootView;
    private DIContainer dIContainer;
    private TransitSceneUIRoot sceneRootView;
    private ViewContainer viewContainer;

    private PhotonChatPresenter photonChatPresenter;
    private PhotonNetworkPresenter photonNetworkPresenter;

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
        viewContainer = sceneRootView.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        photonNetworkPresenter = new PhotonNetworkPresenter(dIContainer.Resolve<PhotonNetworkModel>());
        photonNetworkPresenter.Initialize();

        photonChatPresenter = new PhotonChatPresenter(dIContainer.Resolve<PhotonChatModel>());
        photonChatPresenter.Initialize();

        //ActivateEvents();

        LoadSingleplayerScene();
    }

    private void ActivateEvents()
    {
        photonNetworkPresenter.OnConnectedEvent += photonChatPresenter.Connect;
        photonNetworkPresenter.OnDisconnectedEvent += LoadSingleplayerScene;

        photonChatPresenter.OnConnectedEvent += photonNetworkPresenter.JoinRandomOrCreateRoom;
        photonChatPresenter.OnDisconnectedEvent += LoadSingleplayerScene;

        photonNetworkPresenter.OnJoinedRoomEvent += LoadMultiplayerScene;
        photonNetworkPresenter.OnFailedJoinRoomEvent += LoadSingleplayerScene;
    }

    private void DeactivateEvents()
    {
        photonNetworkPresenter.OnConnectedEvent -= photonChatPresenter.Connect;
        photonNetworkPresenter.OnDisconnectedEvent -= LoadSingleplayerScene;

        photonChatPresenter.OnConnectedEvent -= photonNetworkPresenter.JoinRandomOrCreateRoom;
        photonChatPresenter.OnDisconnectedEvent -= LoadSingleplayerScene;

        photonNetworkPresenter.OnJoinedRoomEvent -= LoadMultiplayerScene;
        photonNetworkPresenter.OnFailedJoinRoomEvent -= LoadSingleplayerScene;
    }

    private void Dispose()
    {
        DeactivateEvents();

        photonNetworkPresenter?.Dispose();
        photonChatPresenter?.Dispose();
    }

    //private void Update()
    //{
    //    if (photonChatPresenter != null)
    //    {
    //        photonChatPresenter.Service();
    //    }
    //}

    private void OnDestroy()
    {
        Dispose();
    }

    #region Input

    public event Action OnLoadSingleplayerScene;
    public event Action OnLoadMultiplayerScene;

    private void LoadSingleplayerScene()
    {
        OnLoadSingleplayerScene?.Invoke();
    }

    private void LoadMultiplayerScene()
    {
        OnLoadMultiplayerScene?.Invoke();
    }

    #endregion
}
