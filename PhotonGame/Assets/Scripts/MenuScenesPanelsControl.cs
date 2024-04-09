using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScenesPanelsControl : PanelsControl
{
    public override void Initialize()
    {
        base.Initialize();

        transitionPanel.ClosePanel();
    }

}
