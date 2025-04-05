using BaCon;
using System.Collections;
using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint : MonoBehaviour
{
    private static GameEntryPoint instance;
    private UIRootView rootView;
    private Coroutines coroutines;

    private readonly DIContainer mainGameContainer = new DIContainer();
    private DIContainer currentSceneContainer;

    public GameEntryPoint()
    {
        coroutines = new GameObject("[Coroutines]").AddComponent<Coroutines>();
        Object.DontDestroyOnLoad(coroutines.gameObject);

        var prefabUIRoot = Resources.Load<UIRootView>("UIRootView");
        rootView = Instantiate(prefabUIRoot);
        Object.DontDestroyOnLoad(rootView.gameObject);
        mainGameContainer.RegisterInstance(rootView);

        PhotonNetworkModel photonNetworkModel = new PhotonNetworkModel();
        mainGameContainer.RegisterInstance(photonNetworkModel);

        PhotonChatModel photonChatModel = new PhotonChatModel();
        photonChatModel.Initialize();
        mainGameContainer.RegisterInstance(photonChatModel);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Autorun()
    {
        GlobalGameSettings();

        instance = new GameEntryPoint();
        instance.Run();

    }

    private static void GlobalGameSettings()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Run()
    {
#if UNITY_EDITOR

        //var sceneName = SceneManager.GetActiveScene().name;

        //if (sceneName == Scenes.MAIN_MENU)
        //{
        //    coroutines.StartCoroutine(LoadAndStartMainMenu());
        //    return;
        //}

        //if (sceneName == Scenes.MINI_GAME)
        //{
        //    coroutines.StartCoroutine(LoadAndStartSceneMiniGame());
        //    return;
        //}

        //if (sceneName == Scenes.SLOT_1)
        //{
        //    coroutines.StartCoroutine(LoadAndStartSceneSlots1());
        //    return;
        //}

        //if (sceneName == Scenes.SLOT_2)
        //{
        //    coroutines.StartCoroutine(LoadAndStartSceneSlots2());
        //    return;
        //}

        //if (sceneName == Scenes.SLOT_3)
        //{
        //    coroutines.StartCoroutine(LoadAndStartSceneSlots3());
        //    return;
        //}

        //if (sceneName == Scenes.SLOT_4)
        //{
        //    coroutines.StartCoroutine(LoadAndStartSceneSlots4());
        //    return;
        //}

        //if (sceneName == Scenes.BOOT)
        //{
        //    return;
        //}

#endif

        coroutines.StartCoroutine(LoadAndStartTransitScene());
    }

    private IEnumerator LoadAndStartInitializeScene()
    {
        yield return new WaitForSeconds(0.3f);
        yield return LoadScene(Scenes.Boot);
        yield return LoadScene(Scenes.Initialize);

        currentSceneContainer = new DIContainer(mainGameContainer);
        var sceneEntryPoint = FindObjectOfType<InitializeSceneEntryPoint>();
        sceneEntryPoint.Run(currentSceneContainer);
        sceneEntryPoint.OnLoadTransitScene += ()=> coroutines.StartCoroutine(LoadAndStartTransitScene());

        yield return new WaitForSeconds(0.2f);
    }

    private IEnumerator LoadAndStartTransitScene()
    {
        rootView.SetLoadScreen(1);

        yield return rootView.ShowLoadingScreen();

        currentSceneContainer?.Dispose();

        yield return new WaitForSeconds(0.3f);
        yield return LoadScene(Scenes.Boot);
        yield return LoadScene(Scenes.Load);
        yield return new WaitForSeconds(0.2f);

        currentSceneContainer = new DIContainer(mainGameContainer);
        var sceneEntryPoint = Object.FindObjectOfType<TransitSceneEntryPoint>();
        sceneEntryPoint.OnLoadSingleplayerScene += () => coroutines.StartCoroutine(LoadAndStartSingleplayerScene());
        sceneEntryPoint.OnLoadMultiplayerScene += () => coroutines.StartCoroutine(LoadAndStartMultiplayerScene());
        sceneEntryPoint.Run(currentSceneContainer);

        yield return rootView.HideLoadingScreen();
    }

    private IEnumerator LoadAndStartSingleplayerScene()
    {
        rootView.SetLoadScreen(1);

        yield return rootView.ShowLoadingScreen();

        currentSceneContainer?.Dispose();

        yield return new WaitForSeconds(0.3f);
        yield return LoadScene(Scenes.Single);
        yield return new WaitForSeconds(0.2f);

        currentSceneContainer = new DIContainer(mainGameContainer);
        var sceneEntryPoint = Object.FindObjectOfType<SingleplayerSceneEntryPoint>();
        //sceneEntryPoint.OnLoadSingleplayerScene += () => coroutines.StartCoroutine(LoadAndStartSingleplayerScene());
        //sceneEntryPoint.OnLoadTransitScene += () => coroutines.StartCoroutine(LoadAndStartMultiplayerScene());
        sceneEntryPoint.Run(currentSceneContainer);

        yield return rootView.HideLoadingScreen();
    }

    private IEnumerator LoadAndStartMultiplayerScene()
    {
        rootView.SetLoadScreen(1);

        yield return rootView.ShowLoadingScreen();

        currentSceneContainer?.Dispose();

        yield return new WaitForSeconds(0.3f);
        yield return LoadScene(Scenes.Multiplayer);
        yield return new WaitForSeconds(0.2f);

        currentSceneContainer = new DIContainer(mainGameContainer);
        var sceneEntryPoint = Object.FindObjectOfType<MultiplayerSceneEntryPoint>();
        //sceneEntryPoint.OnLoadSingleplayerScene += () => coroutines.StartCoroutine(LoadAndStartSingleplayerScene());
        //sceneEntryPoint.OnLoadMultiplayerScene += () => coroutines.StartCoroutine(LoadAndStartMultiplayerScene());
        sceneEntryPoint.Run(currentSceneContainer);

        yield return rootView.HideLoadingScreen();
    }


    private IEnumerator LoadScene(string scene)
    {
        Debug.Log("Загрузка сцены - " + scene);
        yield return SceneManager.LoadSceneAsync(scene);
    }
}
