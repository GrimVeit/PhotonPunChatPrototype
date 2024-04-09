using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScenePanelsControl : PanelsControl
{
    [SerializeField] private Panel choiceMainPointPanel;
    [SerializeField] private Panel choiceOtherPointPanel_1;
    [SerializeField] private Panel choiceOtherPointPanel_2;

    public override void Initialize()
    {
        base.Initialize();

        //PlaneDetection.OnFoundPlanes += OnFoundPlanes;
        //PlaneDetection.OnFoundZeroPosition += OnFoundZeroPos;

        choiceMainPointPanel.Initialize();
        choiceOtherPointPanel_1.Initialize();
        choiceOtherPointPanel_2.Initialize();

        OpenPanel(choiceMainPointPanel);
    }

    //private void OnFoundPlanes()
    //{
    //    OpenPanel(choicePlacePanel);
    //    //PlaneDetection.OnFoundPlanes -= OnFoundPlanes;
    //}
    //private void OnFoundZeroPos()
    //{
    //    OpenPanel(choiceARTargetPanel);
    //    //PlaneDetection.OnFoundZeroPosition -= OnFoundZeroPos;
    //}
}
