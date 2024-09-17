using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomPanel : MovePanel
{
    public UnityEvent OnStartOpenPanel;
    public UnityEvent OnStartClosePanel;
    public UnityEvent OnCompleteOpenPanel;
    public UnityEvent OnCompleteClosePanel;

    [SerializeField] private Button button;
    public override void ActivatePanel()
    {
        OnStartOpenPanel?.Invoke();
        if (tween != null) { tween.Kill(); }
        tween = panel.transform.DOLocalMove(to, time).OnComplete(()=>
        {

            button.onClick.RemoveListener(ActivatePanel);
            button.onClick.AddListener(DeactivatePanel);

            OnCompleteOpenPanel?.Invoke();
        });
        animationInteractor.CanvasGroupAlpha(canvasGroup, 0, 1, time);
    }

    public override void DeactivatePanel()
    {
        OnStartClosePanel?.Invoke();
        if (tween != null) { tween.Kill(); }
        tween = panel.transform.DOLocalMove(from, time).OnComplete(() =>
        {
            button.onClick.RemoveListener(DeactivatePanel);
            button.onClick.AddListener(ActivatePanel);

            OnCompleteClosePanel?.Invoke();
        });
        animationInteractor.CanvasGroupAlpha(canvasGroup, 1, 0, time);
    }
}
