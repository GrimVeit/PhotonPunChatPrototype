using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionPanel : MovePanel
{
    [SerializeField] private float timeOffset;

    private int sceneNumber;

    public override void DeactivatePanel()
    {
        if (tween != null) { tween.Kill(); }

        tween = panel.transform.DOLocalMove(from, time).OnComplete(() => 
        {
            panel.SetActive(false);
        } );
        animationInteractor.CanvasGroupAlpha(canvasGroup, 1, 0, time);
    }
    public override void ActivatePanel()
    {
        if (tween != null) { tween.Kill(); }
        PlaySound();
        panel.SetActive(true);
        tween = panel.transform.DOLocalMove(to, time).OnComplete(() => 
        {
            
            
        } );
        animationInteractor.CanvasGroupAlpha(canvasGroup, 0, 1, time);
    }

    public void LoadSceneNumber(int value)
    {
        sceneNumber = value;
        Invoke(nameof(LoadScene), timeOffset);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    protected override void PlaySound()
    {
        //audioInteractor.PlayEffectSound("Whoosh");
    }
}
