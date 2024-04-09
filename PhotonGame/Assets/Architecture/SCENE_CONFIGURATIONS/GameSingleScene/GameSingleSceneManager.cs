using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleSceneManager : SceneManagerBase
{
    public override void InitSceneMap()
    {
        this.sceneConfigsMap[GameSingleSceneConfig.SCENE_NAME] = new GameSingleSceneConfig();
    }
}
