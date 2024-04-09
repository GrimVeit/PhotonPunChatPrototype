using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneConfig : SceneConfig
{
    public const string SCENE_NAME = "LoadScene";
    public override string sceneName => SCENE_NAME;

    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsMap = new Dictionary<Type, Interactor>();

        CreateInteractor<PanelAnimationInteractor>(interactorsMap);
        CreateInteractor<PhotonInteractor>(interactorsMap);
        CreateInteractor<ChatPhotonInteractor>(interactorsMap);

        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoryMap = new Dictionary<Type, Repository>();

        return repositoryMap;
    }
}
