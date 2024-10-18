using System;
using UnityEngine;
using UnityEngine.UI;

public class ChooseServerPanel_SingleScene : MovePanel
{
    [SerializeField] private Button buttonBackInMenuPanel;

    public override void Initialize()
    {
        base.Initialize();

        buttonBackInMenuPanel.onClick.AddListener(HandlerClickToBackInMenuPanel);
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonBackInMenuPanel.onClick.RemoveListener(HandlerClickToBackInMenuPanel);
    }

    #region Input

    public event Action OnClickToBackInMenuPanel;

    private void HandlerClickToBackInMenuPanel()
    {
        OnClickToBackInMenuPanel?.Invoke();
    }

    #endregion
}
