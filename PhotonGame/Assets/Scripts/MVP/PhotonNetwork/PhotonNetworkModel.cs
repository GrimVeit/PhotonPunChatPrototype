using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PhotonNetworkModel
{
    public event Action<DisconnectCause> OnDisconnectedEvent_Cause;
    public event Action<List<RoomInfo>> OnRoomListUpdateEvent;

    public event Action OnConnectedEvent;
    public event Action OnDisconnectedEvent;
    public event Action OnCreatedRoomEvent;
    public event Action OnFailedCreateRoomEvent;
    public event Action OnJoinedRoomEvent;
    public event Action OnFailedJoinRoomEvent;
    public event Action OnFailedJoinRandomRoomEvent;
    public event Action OnJoinLobbyEvent;
    public event Action OnLeftLobbyEvent;
    public event Action OnLeftRoomEvent;

    private readonly RoomOptions roomOptions = new();

    public void LeaveRoom()
    {
        Debug.Log("Выход из комнаты");
        PhotonNetwork.LeaveRoom();
    }
    public void LoadLevel(int scene)
    {
        Debug.Log("Загрузка сцены " + scene);
        PhotonNetwork.LoadLevel(scene);
    }

    public void ConnectUsingSettings()
    {
        Debug.Log("Подключение к серверу с использование настроек");
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ConnectToBestServer()
    {
        Debug.Log("Подключение к лучшему серверу");
        PhotonNetwork.ConnectToBestCloudServer();
    }

    public void ConnectToRegion(string region)
    {
        Debug.Log("Подключение к " + region);
        PhotonNetwork.ConnectToRegion(region);
    }

    public void DisconnectServer()
    {
        Debug.Log("Отключение от сервера");
        PhotonNetwork.Disconnect();
    }

    public void CreateRoom(string name, byte maxCountPlayers = 5)
    {
        roomOptions.MaxPlayers = maxCountPlayers;
        Debug.Log($"Создание комнаты - {name}");
        PhotonNetwork.CreateRoom(name, roomOptions);
    }

    public void JoinOrCreateRoom(string name, byte maxCountPlayer = 5)
    {
        roomOptions.MaxPlayers = maxCountPlayer;
        Debug.Log($"Присоединение или создание комнаты - {name}");
        PhotonNetwork.JoinOrCreateRoom(name, roomOptions, null);
    }

    public void JoinOrCreateRoom(string name)
    {
        roomOptions.MaxPlayers = 5;
        Debug.Log($"Присоединение или создание комнаты - {name}");
        PhotonNetwork.JoinOrCreateRoom(name, roomOptions, null);
    }

    public void JoinRandomRoom()
    {
        Debug.Log("Присоединение к рандомной комнате");
        PhotonNetwork.JoinRandomRoom();
    }

    public void JoinRandomOrCreateRoom(byte maxCountPlayers = 5)
    {
        roomOptions.MaxPlayers = maxCountPlayers;
        Debug.Log("Присоединение к рандомной комнате или к новой");
        PhotonNetwork.JoinRandomOrCreateRoom(roomOptions: roomOptions);
    }

    public void JoinRoom(string name)
    {
        PhotonNetwork.JoinRoom(name);
    }

    #region Events

    public void OnConnectedToMaster()
    {
        OnConnectedEvent?.Invoke();
    }

    public void OnConnected()
    {

    }

    public void OnDisconnected(DisconnectCause cause)
    {
        OnDisconnectedEvent?.Invoke();
        OnDisconnectedEvent_Cause?.Invoke(cause);
    }

    public void OnCreatedRoom()
    {
        OnCreatedRoomEvent?.Invoke();
    }

    public void OnJoinedRoom()
    {
        OnJoinedRoomEvent?.Invoke();
    }

    public void OnCreateRoomFailed(short returnCode, string message)
    {
        OnFailedCreateRoomEvent?.Invoke();
    }

    public void OnJoinRandomFailed(short returnCode, string message)
    {
        OnFailedJoinRandomRoomEvent?.Invoke();
    }

    public void OnJoinRoomFailed(short returnCode, string message)
    {
        OnJoinedRoomEvent?.Invoke();
    }

    public void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        OnRoomListUpdateEvent?.Invoke(roomList);
    }

    public void OnJoinedLobby()
    {
        OnJoinLobbyEvent?.Invoke();
    }

    public void OnLeftLobby()
    {
        OnLeftLobbyEvent?.Invoke();
    }

    public void OnLeftRoom()
    {
        OnLeftRoomEvent?.Invoke();
    }

    public void OnFriendListUpdate(List<FriendInfo> friendList)
    {

    }

    public void OnRegionListReceived(RegionHandler regionHandler)
    {

    }

    public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
    {

    }

    public void OnCustomAuthenticationFailed(string debugMessage)
    {

    }


    #endregion
}
