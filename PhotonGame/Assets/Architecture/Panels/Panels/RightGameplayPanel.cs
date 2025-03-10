using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightGameplayPanel : CustomPanel
{
    [SerializeField] private Image image;
    [SerializeField] private Coins coins;
    Tween tweenArrow;

    public override void Initialize()
    {
        base.Initialize();
        coins.Initialize();
    }

    public override void ActivatePanel()
    {
        if (tweenArrow != null) { tweenArrow.Kill(); }
        //audioInteractor.PlayEffectSound("OpenOther");
        tweenArrow = image.transform.DOLocalRotate(new Vector3(0, 0, 180), time);

        base.ActivatePanel();
    }

    public override void DeactivatePanel()
    {
        if (tweenArrow != null) { tweenArrow.Kill(); }
        //audioInteractor.PlayEffectSound("OpenMain");
        tweenArrow = image.transform.DOLocalRotate(Vector3.zero, time);

        base.DeactivatePanel();
    }
}
