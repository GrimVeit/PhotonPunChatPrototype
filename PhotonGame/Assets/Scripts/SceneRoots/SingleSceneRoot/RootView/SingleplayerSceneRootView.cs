using System;
using UnityEngine;

public class SingleplayerSceneRootView : SceneRootView
{
    [SerializeField] private GamePanel_SingleScene gamePanel;
    [SerializeField] private MenuPanel_SingleScene menuPanel;
    [SerializeField] private SettingsPanel_SingleScene settingsPanel;
    [SerializeField] private ChooseServerPanel_SingleScene chooseServerPanel;

    public void Initialize()
    {
        ActivateEvents();

        gamePanel.Initialize();
        menuPanel.Initialize();
        settingsPanel.Initialize();
        chooseServerPanel.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        gamePanel.Dispose();
        menuPanel.Dispose();
        settingsPanel.Dispose();
        chooseServerPanel.Dispose();
    }

    public void ActivateMenuPanel()
    {
        ActivatePanel(menuPanel); 
    }

    public void ActivateGamePanel()
    {
        ActivatePanel(gamePanel);
    }

    public void ActivateSettingsPanel()
    {
        ActivatePanel(settingsPanel);
    }

    public void ActivateChooseServerPanel()
    {
        ActivatePanel(chooseServerPanel);
    }


    private void ActivateEvents()
    {
        menuPanel.OnClickToOpenGamePanel += HandlerClickToOpenGamePamel;
        menuPanel.OnClickToOpenSettingsPanel += HandlerClickToOpenSettingsPanel;
        menuPanel.OnClickToOpenChooseServerPanel += HandlerClickToOpenChooseServerPanel;

        gamePanel.OnClickToBackInMenuPanel += HandlerClickToOpenMenuPanelFromGamePanel;
        settingsPanel.OnClickToBackInMenuPanel += HandlerClickToOpenMenuPanelFromSettingsPanel;
        chooseServerPanel.OnClickToBackInMenuPanel += HandlerClickToOpenMenuPanelFromChooseServerPanel;
    }

    private void DeactivateEvents()
    {
        menuPanel.OnClickToOpenGamePanel -= HandlerClickToOpenGamePamel;
        menuPanel.OnClickToOpenSettingsPanel -= HandlerClickToOpenSettingsPanel;
        menuPanel.OnClickToOpenChooseServerPanel -= HandlerClickToOpenChooseServerPanel;

        gamePanel.OnClickToBackInMenuPanel -= HandlerClickToOpenMenuPanelFromGamePanel;
        settingsPanel.OnClickToBackInMenuPanel -= HandlerClickToOpenMenuPanelFromSettingsPanel;
        chooseServerPanel.OnClickToBackInMenuPanel -= HandlerClickToOpenMenuPanelFromChooseServerPanel;
    }

    #region Input

    public event Action OnClickToOpenGamePanel;
    public event Action OnClickToOpenSettingsPanel;
    public event Action OnClickToOpenChooseServerPanel;

    public event Action OnClickToOpenMenuPanelFromGamePanel;
    public event Action OnClickToOpenMenuPanelFromSettingsPanel;
    public event Action OnClickToOpenMenuPanelFromChooseServerPanel;

    private void HandlerClickToOpenGamePamel()
    {
        OnClickToOpenGamePanel?.Invoke();
    }

    private void HandlerClickToOpenSettingsPanel()
    {
        OnClickToOpenSettingsPanel?.Invoke();
    }

    private void HandlerClickToOpenChooseServerPanel()
    {
        OnClickToOpenChooseServerPanel?.Invoke();
    }

    private void HandlerClickToOpenMenuPanelFromGamePanel()
    {
        OnClickToOpenMenuPanelFromGamePanel?.Invoke();
    }

    private void HandlerClickToOpenMenuPanelFromSettingsPanel()
    {
        OnClickToOpenMenuPanelFromSettingsPanel?.Invoke();
    }

    private void HandlerClickToOpenMenuPanelFromChooseServerPanel()
    {
        OnClickToOpenMenuPanelFromChooseServerPanel?.Invoke();
    }

    #endregion
}
