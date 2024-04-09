using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class ChooseRandomChannel : MonoBehaviourPunCallbacks
{
    public UnityEvent OnChangeChannel;

    private PhotonInteractor photonInteractor;

    public void Initialize()
    {
        photonInteractor = Game.GetInteractor<PhotonInteractor>();
    }

    public void JoinRandomOrCreateRoom()
    {
        OnChangeChannel?.Invoke();
        photonInteractor.LeaveRoom();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Подключение успешно");
        photonInteractor.JoinRandomOrCreateRoom();

    }
}
