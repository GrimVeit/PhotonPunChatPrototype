using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneManager : SceneManagerBase
{
    public override void InitSceneMap()
    {
        this.sceneConfigsMap[LoadSceneConfig.SCENE_NAME] = new LoadSceneConfig();
    }
}
