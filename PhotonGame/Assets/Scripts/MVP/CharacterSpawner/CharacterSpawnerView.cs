using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawnerView : View
{
    [SerializeField] private Button buttonSpawn;
    [SerializeField] private Button buttonDestroy;

    public void Initialize()
    {
        buttonSpawn.onClick.AddListener(HandlerClickToSpawnButton);
        buttonDestroy.onClick.AddListener(HandlerClickToDestroyButton);
    }

    public void Dispose()
    {
        buttonSpawn.onClick.RemoveListener(HandlerClickToSpawnButton);
        buttonDestroy.onClick.RemoveListener(HandlerClickToDestroyButton);
    }

    #region Input

    public event Action OnClickToSpawnButton;
    public event Action OnClickToDestroyButton;

    private void HandlerClickToSpawnButton()
    {
        OnClickToSpawnButton?.Invoke();
    }

    private void HandlerClickToDestroyButton()
    {
        OnClickToDestroyButton?.Invoke();
    }

    #endregion
}
