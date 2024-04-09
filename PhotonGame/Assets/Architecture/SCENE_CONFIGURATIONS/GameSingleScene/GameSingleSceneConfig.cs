using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleSceneConfig : SceneConfig
{
    public const string SCENE_NAME = "GameSingleScene";
    public override string sceneName => SCENE_NAME;

    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsMap = new Dictionary<Type, Interactor>();

        //CreateInteractor<SettingsInteractor>(interactorsMap);
        //CreateInteractor<NotificationInteractor>(interactorsMap);
        CreateInteractor<PanelAnimationInteractor>(interactorsMap);
        CreateInteractor<RoomInteractor>(interactorsMap);
        CreateInteractor<CharacterInteractor>(interactorsMap);
        CreateInteractor<PhotonInteractor>(interactorsMap);
        CreateInteractor<ChatPhotonInteractor>(interactorsMap);

        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();

        //CreateRepository<SettingsRepository>(repositoriesMap);
        CreateRepository<CharacterRepository>(repositoriesMap);

        return repositoriesMap;
    }
}
