using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScenePanelsControl : PanelsControl
{
    [SerializeField] private PhotonConnect photonConnect;
    public override void Initialize()
    {
        base.Initialize();

        photonConnect.Initialize();
    }
}
