using BaCon;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private LoadSceneUIRoot loadSceneUIRootPrefab;
    private DIContainer sceneDIContainer;
    private UIRootView rootView;

    private LoadSceneUIRoot loadSceneUIRoot;
    //private ViewC

    private PhotonChatPresenter photonChatPresenter;
    private PhotonNetworkPresenter photonNetworkPresenter;

    public void Run(DIContainer dIContainer)
    {
        sceneDIContainer = dIContainer;
        rootView = dIContainer.Resolve<UIRootView>();

        loadSceneUIRoot = Instantiate(loadSceneUIRootPrefab);
        loadSceneUIRoot.Initialize();
        rootView.AttachSceneUI(loadSceneUIRoot.gameObject, Camera.main);

        //photonNetworkPresenter = new PhotonNetworkPresenter(new PhotonNetworkModel(), vi)

        loadSceneUIRoot.Activate();
    }

    #region Input

    public event Action OnGoToSingleScene;
    public event Action OnGoToMultiplayerScene;

    #endregion
}
