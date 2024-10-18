using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel_SingleScene : MovePanel
{
    [SerializeField] private Button buttonOpenChooseServerPanel;
    [SerializeField] private Button buttonOpenGamePanel;
    [SerializeField] private Button buttonOpenShopPanel;
    [SerializeField] private Button buttonOpenSettingsPanel;

    public override void Initialize()
    {
        base.Initialize();

        buttonOpenChooseServerPanel.onClick.AddListener(HandlerClickToOpenChoosePanel);
        buttonOpenGamePanel.onClick.AddListener(HandlerClickToOpenGamePanel);
        buttonOpenSettingsPanel.onClick.AddListener(HandlerClickToOpenSettingsPanel);
        buttonOpenShopPanel.onClick.AddListener(HandlerClickToOpenShopPanel);
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonOpenChooseServerPanel.onClick.RemoveListener(HandlerClickToOpenChoosePanel);
        buttonOpenGamePanel.onClick.RemoveListener(HandlerClickToOpenGamePanel);
        buttonOpenSettingsPanel.onClick.RemoveListener(HandlerClickToOpenSettingsPanel);
        buttonOpenShopPanel.onClick.RemoveListener(HandlerClickToOpenShopPanel);
    }

    #region Input

    public event Action OnClickToOpenChooseServerPanel;
    public event Action OnClickToOpenGamePanel;
    public event Action OnClickToOpenShopPanel;
    public event Action OnClickToOpenSettingsPanel;

    private void HandlerClickToOpenChoosePanel()
    {
        OnClickToOpenChooseServerPanel?.Invoke();
    }

    private void HandlerClickToOpenGamePanel()
    {
        OnClickToOpenGamePanel?.Invoke();
    }

    private void HandlerClickToOpenShopPanel()
    {
        OnClickToOpenShopPanel?.Invoke();
    }

    private void HandlerClickToOpenSettingsPanel()
    {
        OnClickToOpenSettingsPanel?.Invoke();
    }

    #endregion
}
