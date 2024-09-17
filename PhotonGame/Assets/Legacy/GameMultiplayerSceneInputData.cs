using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMultiplayerSceneInputData : InputData
{
    [SerializeField] private GameSpawner gameSpawner;
    [SerializeField] private GameChat gameChat;

    private CharacterInteractor characterInteractor;
    private RoomInteractor roomInteractor;
    private ChatPhotonInteractor chatPhotonInteractor;
    public override void Initialize()
    {
        base.Initialize();

        roomInteractor = Game.GetInteractor<RoomInteractor>();
        characterInteractor = Game.GetInteractor<CharacterInteractor>();
        chatPhotonInteractor = Game.GetInteractor<ChatPhotonInteractor>();


        roomInteractor.SetSpawner(gameSpawner);
        characterInteractor.SetSpawner(gameSpawner);
        chatPhotonInteractor.SetData(gameChat);
    }
}
