using UnityEngine;

public class SingleplayerSceneRootView : SceneRootView
{
    [SerializeField] private GamePanel_SingleScene gamePanel;
    [SerializeField] private MenuPanel_SingleScene menuPanel;
    [SerializeField] private SettingsPanel_SingleScene settingsPanel;
    [SerializeField] private ChooseServerPanel_SingleScene chooseServerPanel;

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    public void ActivateMenuPanel()
    {
        ActivatePanel(menuPanel); 
    }
}
