using DG.Tweening;
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
    }
    public override void ActivatePanel()
    {
        if (tween != null) { tween.Kill(); }
        panel.SetActive(true);
        tween = panel.transform.DOLocalMove(to, time).OnComplete(() => 
        {
            
            
        } );
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
}
