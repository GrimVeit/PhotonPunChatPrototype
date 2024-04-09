using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSinglePanelsControl : PanelsControl
{
    [SerializeField] private Panel menuPanel;
    [SerializeField] private Panel gamePanel;
    [SerializeField] private Panel settingsPanel;
    [SerializeField] private Panel chooseServerPanel;

    public override void Initialize()
    {
        base.Initialize();

        menuPanel.Initialize();
        gamePanel.Initialize();
        settingsPanel.Initialize();
        chooseServerPanel.Initialize();

        panel = transitionPanel;
        OpenPanel(menuPanel);
    }
}
