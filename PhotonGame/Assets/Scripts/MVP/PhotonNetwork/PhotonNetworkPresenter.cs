using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class PhotonNetworkPresenter
{
    private PhotonNetworkModel photonNetworkModel;
    private PhotonNetworkView photonNetworkView;

    public PhotonNetworkPresenter(PhotonNetworkModel photonNetworkModel, PhotonNetworkView photonNetworkView)
    {
        this.photonNetworkModel = photonNetworkModel;
        this.photonNetworkView = photonNetworkView;
    }

    public void Initialize()
    {
        ActivateEvents();

        photonNetworkView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        photonNetworkView.Dispose();
    }

    private void ActivateEvents()
    {
        photonNetworkView.OnSelectServer += photonNetworkModel.SelectRegion;
        photonNetworkView.OnChooseChannel += photonNetworkModel.JoinOrCreateRoom;
    }

    private void DeactivateEvents()
    {
        photonNetworkView.OnSelectServer -= photonNetworkModel.SelectRegion;
        photonNetworkView.OnChooseChannel -= photonNetworkModel.JoinOrCreateRoom;
    }

    #region Methods

    public void LeaveRoom()
    {
        photonNetworkModel.LeaveRoom();
    }
    public void LoadLevel(int scene)
    {
        photonNetworkModel.LoadLevel(scene);
    }

    public void ConnectUsingSettings()
    {
        photonNetworkModel.ConnectUsingSettings();
    }

    public void ConnectToBestServer()
    {
        photonNetworkModel.ConnectToBestServer();
    }

    public void ConnectToRegion(string region)
    {
        photonNetworkModel.ConnectToRegion(region);
    }

    public void DisconnectServer()
    {
        photonNetworkModel.DisconnectServer();
    }

    public void CreateRoom(string name, byte maxCountPlayers = 5)
    {
        photonNetworkModel.CreateRoom(name, maxCountPlayers);
    }

    public void JoinOrCreateRoom(string name, byte maxCountPlayer = 5)
    {
        photonNetworkModel.JoinOrCreateRoom(name, maxCountPlayer);
    }

    public void JoinRandomRoom()
    {
        photonNetworkModel.JoinRandomRoom();
    }

    public void JoinRandomOrCreateRoom(byte maxCountPlayers = 5)
    {
        photonNetworkModel.JoinRandomOrCreateRoom(maxCountPlayers);
    }

    public void JoinRandomOrCreateRoom()
    {
        photonNetworkModel.JoinRandomOrCreateRoom(5);
    }

    public void JoinRoom(string name)
    {
        photonNetworkModel.JoinRoom(name);
    }

    #endregion

    #region Events

    public event Action<DisconnectCause> OnDisconnectedEvent_Cause
    {
        add { photonNetworkModel.OnDisconnectedEvent_Cause += value; }
        remove { photonNetworkModel.OnDisconnectedEvent_Cause -= value; }
    }

    public event Action<List<RoomInfo>> OnRoomListUpdateEvent
    {
        add { photonNetworkModel.OnRoomListUpdateEvent += value; }
        remove { photonNetworkModel.OnRoomListUpdateEvent += value; }
    }

    public event Action OnConnectedEvent
    {
        add { photonNetworkModel.OnConnectedEvent += value; }
        remove { photonNetworkModel.OnConnectedEvent -= value; }
    }

    public event Action OnDisconnectedEvent
    {
        add { photonNetworkModel.OnDisconnectedEvent += value; }
        remove { photonNetworkModel.OnDisconnectedEvent -= value; }
    }

    public event Action OnCreatedRoomEvent
    {
        add { photonNetworkModel.OnCreatedRoomEvent += value; }
        remove { photonNetworkModel.OnCreatedRoomEvent -= value; }
    }

    public event Action OnFailedCreateRoomEvent
    {
        add { photonNetworkModel.OnFailedCreateRoomEvent += value; }
        remove { photonNetworkModel.OnFailedCreateRoomEvent -= value; }
    }

    public event Action OnJoinedRoomEvent
    {
        add { photonNetworkModel.OnJoinedRoomEvent += value; }
        remove { photonNetworkModel.OnJoinedRoomEvent -= value; }
    }

    public event Action OnFailedJoinRoomEvent
    {
        add { photonNetworkModel.OnFailedJoinRoomEvent += value; }
        remove { photonNetworkModel.OnFailedJoinRoomEvent -= value; }
    }

    public event Action OnFailedJoinRandomRoomEvent
    {
        add { photonNetworkModel.OnFailedJoinRandomRoomEvent += value; }
        remove { photonNetworkModel.OnFailedJoinRandomRoomEvent -= value; }
    }

    public event Action OnJoinLobbyEvent
    {
        add { photonNetworkModel.OnJoinLobbyEvent += value; }
        remove { photonNetworkModel.OnJoinLobbyEvent -= value; }
    }

    public event Action OnLeftLobbyEvent
    {
        add { photonNetworkModel.OnJoinLobbyEvent += value; }
        remove { photonNetworkModel.OnJoinLobbyEvent -= value; }
    }

    public event Action OnLeftRoomEvent
    {
        add { photonNetworkModel.OnLeftRoomEvent += value; }
        remove { photonNetworkModel.OnLeftRoomEvent -= value; }
    }

    public event Action OnSelectRegion
    {
        add { photonNetworkModel.OnSelectRegion += value; }
        remove { photonNetworkModel.OnSelectRegion -= value; }
    }

    #endregion
}
