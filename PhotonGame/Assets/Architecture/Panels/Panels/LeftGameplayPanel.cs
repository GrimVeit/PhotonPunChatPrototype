using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftGameplayPanel : CustomPanel
{
    [SerializeField] private Image image;
    //[SerializeField] private ScoreUI scoreUI;
    //[SerializeField] private GameInventory inventory;
    Tween tweenArrow;

    public override void Initialize()
    {
        base.Initialize();

        //scoreUI.Initialize();
        //inventory.Initialize();
    }

    public override void ActivatePanel()
    {
        if (tweenArrow != null) { tweenArrow.Kill(); }
        tweenArrow = image.transform.DOLocalRotate(new Vector3(0, 0, 180), time);

        base.ActivatePanel();
    }

    public override void DeactivatePanel()
    {
        if (tweenArrow != null) { tweenArrow.Kill(); }
        tweenArrow = image.transform.DOLocalRotate(Vector3.zero, time);

        base.DeactivatePanel();
    }
}
