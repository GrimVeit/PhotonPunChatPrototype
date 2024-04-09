using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public static event Action OnGameInitializedEvent;
    public static event Action OnGameDestroyEvent;
    public static SceneManagerBase sceneManager { get; private set; }

    public static void Run(SceneManagerBase sceneManagerBase)
    {
        sceneManager = sceneManagerBase;
        Coroutines.StartRoutine(InitializeGameRoutine());
    }

    public static void Exit()
    {
        Coroutines.StartRoutine(DestroyGameRoutine());
    }

    private static IEnumerator InitializeGameRoutine()
    {
        sceneManager.InitSceneMap();
        yield return sceneManager.LoadCurrentSceneAsync();
        OnGameInitializedEvent?.Invoke();
    }

    private static IEnumerator DestroyGameRoutine()
    {
        yield return sceneManager.DestroyCurrentSceneAsync();
        OnGameDestroyEvent?.Invoke();
    }

    public static T GetInteractor<T>() where T : Interactor
    {
        return sceneManager.GetInteractor<T>();
    }

    public static T GetRepository<T>() where T : Repository
    {
        return sceneManager.GetRepository<T>();
    }
}
