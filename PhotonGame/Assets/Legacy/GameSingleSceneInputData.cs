using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleSceneInputData : InputData
{
    [SerializeField] private GameSpawner gameSpawner;

    private CharacterInteractor characterInteractor;
    private RoomInteractor roomInteractor;
    public override void Initialize()
    {
        base.Initialize();

        roomInteractor = Game.GetInteractor<RoomInteractor>();
        characterInteractor = Game.GetInteractor<CharacterInteractor>();


        roomInteractor.SetSpawner(gameSpawner);
        characterInteractor.SetSpawner(gameSpawner);
    }
}
