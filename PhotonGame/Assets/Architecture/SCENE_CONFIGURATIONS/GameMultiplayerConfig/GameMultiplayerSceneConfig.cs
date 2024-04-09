using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMultiplayerSceneConfig : SceneConfig
{
    public const string SCENE_NAME = "GameMultiplayerScene";
    public override string sceneName => SCENE_NAME;


    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        interactorsMap = new Dictionary<Type, Interactor>();

        //CreateInteractor<SettingsInteractor>(interactorsMap);
        //CreateInteractor<NotificationInteractor>(interactorsMap);
        CreateInteractor<PanelAnimationInteractor>(interactorsMap);
        CreateInteractor<RoomInteractor>(interactorsMap);
        CreateInteractor<CharacterInteractor>(interactorsMap);
        CreateInteractor<PhotonInteractor>(interactorsMap);
        CreateInteractor<ChatPhotonInteractor>(interactorsMap);
        CreateInteractor<PlayerInteractor>(interactorsMap);

        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();

        //CreateRepository<SettingsRepository>(repositoriesMap);
        CreateRepository<PlayerRepository>(repositoriesMap);
        CreateRepository<CharacterRepository>(repositoriesMap);

        return repositoriesMap;
    }

    public override void DestroyAllInteractors()
    {
        DestroyInteractor<ChatPhotonInteractor>(interactorsMap);
    }
}
