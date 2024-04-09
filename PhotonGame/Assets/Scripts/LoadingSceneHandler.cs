using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceneHandler : Handler
{
    protected override void Awake()
    {
        Game.Run(new LoadingSceneManager());
        base.Awake();
    }

    protected override void OnGameInitialized()
    {
        base.OnGameInitialized();
    }
}
