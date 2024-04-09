using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameMultiplayerPanelsControl : PanelsControl
{
    [SerializeField] private Panel menuPanel;
    [SerializeField] private Panel gamePanel;
    [SerializeField] private Panel settingsPanel;
    [SerializeField] private Panel chooseChannelPanel;
    [SerializeField] private Panel chooseServerPanel;
    [SerializeField] private Panel chatPanel;

    public override void Initialize()
    {
        base.Initialize();

        menuPanel.Initialize();
        gamePanel.Initialize();
        settingsPanel.Initialize();
        chooseChannelPanel.Initialize();
        chooseServerPanel.Initialize();
        chatPanel.Initialize();

        panel = transitionPanel;
        OpenPanel(menuPanel);
    }
}
