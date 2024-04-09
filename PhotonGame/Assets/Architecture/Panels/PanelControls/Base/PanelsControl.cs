using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsControl : MonoBehaviour
{
    [SerializeField] protected TransitionPanel transitionPanel;

    protected Panel panel;

    public virtual void Initialize()
    {
        transitionPanel.Initialize();
    }

    public void OpenPanel(Panel panel)
    {
        if (this.panel != null)
        {
            this.panel.ClosePanel();
            this.panel = null;
        }

        this.panel = panel;
        this.panel.OpenPanel();
    }

    public void OpenNewPanel(Panel panel)
    {
        panel.OpenPanel();
    }

    public void CloseNewPanel(Panel panel)
    {
        panel.ClosePanel();
    }

}
