using BaCon;
using System;
using System.Collections;
using UnityEngine;

public class InitializeSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private InitializeSceneRootView sceneRootViewPrefab;
    [SerializeField] private float secondStart;

    private UIRootView mainRootView;
    private DIContainer dIContainer;
    private InitializeSceneRootView sceneRootView;
    private ViewContainer viewContainer;

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
        StartCoroutine(StartCoroutine());
    }

    private void Dispose()
    {

    }

    private IEnumerator StartCoroutine()
    {
        yield return new WaitForSecondsRealtime(secondStart);

        HandlerLoadTransitScene();

    }

    #region Input

    public event Action OnLoadTransitScene;

    private void HandlerLoadTransitScene()
    {
        Dispose();
        OnLoadTransitScene?.Invoke();
    }

    #endregion


}
