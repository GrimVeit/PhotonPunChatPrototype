using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseServerPanel : MovePanel
{
    [SerializeField] private ChooseServer chooseServer;
    public override void Initialize()
    {
        base.Initialize();
        chooseServer.Initialize();
    }
}
