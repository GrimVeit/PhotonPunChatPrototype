using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Lessons.Architecture;
using Photon.Realtime;
using UnityEngine.Events;
using ExitGames.Client.Photon;

public class PhotonEventsMultiplayerScene : MonoBehaviour
{
    public UnityEvent OnJoinRoomFailedEvent;

    private PhotonInteractor photonInteractor;
    public void Initialize()
    {
        photonInteractor = Game.GetInteractor<PhotonInteractor>();

        photonInteractor.OnDisconnectedEvent += OnDisconnected;
        photonInteractor.OnFailedJoinRoomEvent += OnJoinRoomFailed;
        photonInteractor.OnJoinedRoomEvent += OnJoinedRoom;
    }

    public void OnJoinRoomFailed()
    {
        OnJoinRoomFailedEvent?.Invoke();
    }

    public void OnJoinedRoom()
    {
        photonInteractor.LoadLevel(3);
    }


    public void OnDisconnected()
    {
        photonInteractor.LoadLevel(1);
        //SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    private void OnDestroy()
    {
        photonInteractor.OnDisconnectedEvent -= OnDisconnected;
        photonInteractor.OnFailedJoinRoomEvent -= OnJoinRoomFailed;
        photonInteractor.OnJoinedRoomEvent -= OnJoinedRoom;
    }
}
