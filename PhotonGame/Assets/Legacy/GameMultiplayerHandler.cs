using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMultiplayerHandler : Handler
{
    [SerializeField] private PhotonEventsMultiplayerScene photonEventsMultiplayerScene;
    [SerializeField] private InputData inputData;
    [SerializeField] private GameMultiplayerController gameController;
    [SerializeField] private RoomData roomData;
    protected override void Awake()
    {
        Game.Run(new GameMultiplayerSceneManager());
        base.Awake();
    }

    protected override void OnGameInitialized()
    {
        base.OnGameInitialized();

        gameController.Initialize();
        inputData.Initialize();
        photonEventsMultiplayerScene.Initialize();
        roomData.Initialize();
    }
}
