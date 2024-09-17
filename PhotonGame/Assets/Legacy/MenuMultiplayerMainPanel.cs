using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMultiplayerMainPanel : MovePanel
{
    [SerializeField] private ChooseNicknameAndColor chooseNicknameAndColor;
    [SerializeField] private ChooseRandomChannel randomChannel;
    public override void Initialize()
    {
        base.Initialize();
        randomChannel.Initialize();
        chooseNicknameAndColor.Initialize();
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();
    }
}
