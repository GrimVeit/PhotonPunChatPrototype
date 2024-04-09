using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleHandler : Handler
{
    [SerializeField] private InputData inputData;
    [SerializeField] private GameSingleController gameController;
    protected override void Awake()
    {
        Game.Run(new GameSingleSceneManager());
        base.Awake();
    }

    protected override void OnGameInitialized()
    {
        inputData.Initialize();
        gameController.Initialize();
        base.OnGameInitialized();
    }
}
