using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneHandler : Handler
{
    protected override void Awake()
    {
        Game.Run(new LoadSceneManager());
        base.Awake();
    }
}
