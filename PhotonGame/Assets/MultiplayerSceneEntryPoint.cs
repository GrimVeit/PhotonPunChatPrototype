using BaCon;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerSceneEntryPoint : MonoBehaviour
{
    public void Run(DIContainer currentSceneContainer)
    {

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
