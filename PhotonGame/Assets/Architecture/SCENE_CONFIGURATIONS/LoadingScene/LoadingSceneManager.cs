using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceneManager : SceneManagerBase
{
    public override void InitSceneMap()
    {
        this.sceneConfigsMap[LoadingSceneConfig.SCENE_NAME] = new LoadingSceneConfig();
    }
}
