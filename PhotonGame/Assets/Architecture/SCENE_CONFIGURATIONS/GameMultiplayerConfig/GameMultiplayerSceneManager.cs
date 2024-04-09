using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMultiplayerSceneManager : SceneManagerBase
{
    public override void InitSceneMap()
    {
        this.sceneConfigsMap[GameMultiplayerSceneConfig.SCENE_NAME] = new GameMultiplayerSceneConfig();
    }
}
