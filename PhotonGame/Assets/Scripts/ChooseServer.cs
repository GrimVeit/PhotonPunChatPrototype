using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChooseServer : MonoBehaviour
{
    public UnityEvent OnChangeRegion;

    protected ChatPhotonInteractor chatPhotonInteractor;
    protected PhotonInteractor photonInteractor;

    public virtual void Initialize()
    {
        photonInteractor = Game.GetInteractor<PhotonInteractor>();
        chatPhotonInteractor = Game.GetInteractor<ChatPhotonInteractor>();
    }

    public virtual void SetRegion(string region)
    {
        OnChangeRegion?.Invoke();
        PlayerPrefs.SetString("RegionName", region);
        chatPhotonInteractor.Disconnect();
        photonInteractor.DisconnectServer();
    }
}
