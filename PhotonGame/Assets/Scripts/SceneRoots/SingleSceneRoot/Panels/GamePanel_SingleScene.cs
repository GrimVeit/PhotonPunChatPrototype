using System;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel_SingleScene : MovePanel
{
    [SerializeField] private Button buttonBackToMenuPanel;

    public override void Initialize()
    {
        base.Initialize();

        buttonBackToMenuPanel.onClick.AddListener(HandlerClickToBackInMenuPanel);
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonBackToMenuPanel.onClick.RemoveListener(HandlerClickToBackInMenuPanel);
    }

    #region Input

    public event Action OnClickToBackInMenuPanel;

    private void HandlerClickToBackInMenuPanel()
    {
        OnClickToBackInMenuPanel?.Invoke();
    }

    #endregion
}
