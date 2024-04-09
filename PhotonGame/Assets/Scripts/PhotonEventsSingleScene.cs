using UnityEngine;
using UnityEngine.SceneManagement;
using Lessons.Architecture;

public class PhotonEventsSingleScene : MonoBehaviour
{
    private PhotonInteractor photonInteractor;

    public void Initialize()
    {
        photonInteractor = Game.GetInteractor<PhotonInteractor>();

        photonInteractor.OnConnectedEvent += OnConnectedToMaster;
        photonInteractor.OnDisconnectedEvent += OnDisconnected;
        photonInteractor.OnJoinedRoomEvent += OnJoinedRoom;
    }

    public void OnConnectedToMaster()
    {
        photonInteractor.JoinRandomOrCreateRoom();
    }

    public void OnDisconnected()
    {
        photonInteractor.LoadLevel(2);
    }

    public void OnJoinedRoom()
    {
        photonInteractor.LoadLevel(3);
    }

    private void OnDestroy()
    {
        photonInteractor.OnConnectedEvent -= OnConnectedToMaster;
        photonInteractor.OnDisconnectedEvent -= OnDisconnected;
        photonInteractor.OnJoinedRoomEvent -= OnJoinedRoom;
    }

}
