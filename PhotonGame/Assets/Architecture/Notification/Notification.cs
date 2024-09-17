using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notification : MovePanel
{
    [SerializeField] private TextMeshProUGUI textHand;
    [SerializeField] private TextMeshProUGUI textDescription;
    public override void Initialize()
    {
        base.Initialize();
        from = gameObject.transform.localPosition;
    }

    public void SetText(string textHand, string textDescription)
    {
        this.textHand.text = textHand;
        this.textDescription.text = textDescription;

    }

    public override void DeactivatePanel()
    {
        if (tween != null) { tween.Kill(); }

        tween = transform.DOLocalMove(from, time).OnComplete(() => 
        {
            tween.Kill();
            Destroy(gameObject);
        });
        animationInteractor.CanvasGroupAlpha(canvasGroup, 1, 0, time);
    }

    public override void ActivatePanel()
    {
        if (tween != null) { tween.Kill(); }

        panel.SetActive(true);
        tween = transform.DOLocalMove(from + new Vector3(-175, 0, 0), time).OnComplete(() =>
        {
            Invoke(nameof(DeactivatePanel), 2);
        });
        animationInteractor.CanvasGroupAlpha(canvasGroup, 0, 1, time);
    }
}
