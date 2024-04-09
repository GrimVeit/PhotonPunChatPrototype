using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseChannelPanel : MovePanel
{
    [SerializeField] private ChooseChannel chooseChannel;
    public override void Initialize()
    {
        base.Initialize();
        chooseChannel.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
    }
}
