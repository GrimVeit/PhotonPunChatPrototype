using UnityEngine;

public class SceneRootView : MonoBehaviour
{
    private protected Panel currentPanel;

    private protected void ActivatePanel(Panel panel)
    {
        currentPanel?.DeactivatePanel();

        currentPanel = panel;
        currentPanel.ActivatePanel();
    }

    private protected void DeactivatePanel()
    {
        currentPanel.DeactivatePanel();
    }

    private protected void ActivateOtherPanel(Panel panel)
    {
        panel.ActivatePanel();
    }

    private protected void DeactivateOtherPanel(Panel panel)
    {
        panel.DeactivatePanel();
    }
}
