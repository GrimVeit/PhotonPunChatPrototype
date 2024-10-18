using UnityEngine;

public class PhotonTransitionConnect : PhotonConnect
{
    private string nameServer;
    public override void Initialize()
    {
        base.Initialize();

        nameServer = PlayerPrefs.GetString("RegionName", "eu");

        if (nameServer == "SingleMode")
        {
            photonInteractor.LoadLevel(2);
            return;
        }

        photonInteractor.OnConnectedEvent += ConnectChat;
        photonInteractor.OnDisconnectedEvent += LoadSingle;

        chatPhotonInteractor.Events.OnConnectedEvent += JoinRandomRoom;
        chatPhotonInteractor.Events.OnDisconnectedEvent += LoadSingle;

        photonInteractor.OnJoinedRoomEvent += LoadMultiplayer;
        photonInteractor.OnFailedJoinRoomEvent += LoadSingle;

        photonInteractor.ConnectToRegion(nameServer);
    }

    private void Update()
    {
        if (chatPhotonInteractor != null)
        {
            chatPhotonInteractor.Service();
        }
    }

    private void LoadSingle()
    {
        photonInteractor.LoadLevel(2);
    }

    private void LoadMultiplayer()
    {
        photonInteractor.LoadLevel(3);
    }

    private void ConnectChat()
    {
        Debug.Log("Подключение к серверу чата");
        chatPhotonInteractor.Connect();
    }

    private void JoinRandomRoom()
    {
        Debug.Log("Поиск рандомной комнаты");
        photonInteractor.JoinRandomOrCreateRoom(5);
    }

    private void OnDestroy()
    {
        photonInteractor.OnConnectedEvent -= ConnectChat;
        photonInteractor.OnDisconnectedEvent -= LoadSingle;

        chatPhotonInteractor.Events.OnConnectedEvent -= JoinRandomRoom;
        chatPhotonInteractor.Events.OnDisconnectedEvent -= LoadSingle;

        photonInteractor.OnJoinedRoomEvent -= LoadMultiplayer;
        photonInteractor.OnFailedJoinRoomEvent -= LoadSingle;
    }
}
