using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicePlacePanel : Panel
{
    [SerializeField] private Animator animator;

    private const string KEY_ANIMATE = "isPlay";

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();
        animator.SetBool(KEY_ANIMATE, true);
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();
        animator.SetBool(KEY_ANIMATE, false);
    }
}
