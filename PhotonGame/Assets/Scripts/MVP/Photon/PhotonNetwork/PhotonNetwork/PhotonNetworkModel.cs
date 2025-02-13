using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PhotonNetworkModel : IConnectionCallbacks, IMatchmakingCallbacks
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

    public event Action OnSelectRegion;

    private readonly RoomOptions roomOptions = new();
    private string selectRegion;

    public void LeaveRoom()
    {
        Debug.Log("����� �� �������");
        PhotonNetwork.LeaveRoom();
    }
    public void LoadLevel(int scene)
    {
        Debug.Log("�������� ����� " + scene);
        PhotonNetwork.LoadLevel(scene);
    }

    public void ConnectUsingSettings()
    {
        Debug.Log("����������� � ������� � ������������� ��������");
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ConnectToBestServer()
    {
        Debug.Log("����������� � ������� �������");
        PhotonNetwork.ConnectToBestCloudServer();
    }

    public void ConnectToRegion(string region)
    {
        Debug.Log("����������� � " + region);
        PhotonNetwork.ConnectToRegion(region);
    }

    public void SelectRegion(ServerRegion serverRegion)
    {
        switch (serverRegion)
        {
            case ServerRegion.Asia:
                selectRegion = "asia";
                break;

            case ServerRegion.Au:
                selectRegion = "au";
                break;

            case ServerRegion.Cae:
                selectRegion = "cae";
                break;

            case ServerRegion.Eu:
                selectRegion = "eu";
                break;

            case ServerRegion.Hk:
                selectRegion = "hk";
                break;

            case ServerRegion.In:
                selectRegion = "in";
                break;

            case ServerRegion.Jp:
                selectRegion = "jp";
                break;

            case ServerRegion.Kr:
                selectRegion = "kr";
                break;

            case ServerRegion.Ru:
                selectRegion = "ru";
                break;

            case ServerRegion.Sa:
                selectRegion = "sa";
                break;

            case ServerRegion.Tr:
                selectRegion = "tr";
                break;

            case ServerRegion.Uae:
                selectRegion = "uae";
                break;

            case ServerRegion.Us:
                selectRegion = "us";
                break;

            case ServerRegion.Ussc:
                selectRegion = "ussc";
                break;

            case ServerRegion.Usw:
                selectRegion = "usw";
                break;

            case ServerRegion.Za:
                selectRegion = "za";
                break;
        }

        OnSelectRegion?.Invoke();
    }

    public void ConnectToChooseRegion()
    {
        PhotonNetwork.ConnectToRegion(selectRegion);
    }

    public void DisconnectServer()
    {
        Debug.Log("���������� �� �������");
        PhotonNetwork.Disconnect();
    }

    public void CreateRoom(string name, byte maxCountPlayers = 5)
    {
        roomOptions.MaxPlayers = maxCountPlayers;
        Debug.Log($"�������� ������� - {name}");
        PhotonNetwork.CreateRoom(name, roomOptions);
    }

    public void JoinOrCreateRoom(string name, byte maxCountPlayer = 5)
    {
        roomOptions.MaxPlayers = maxCountPlayer;
        Debug.Log($"������������� ��� �������� ������� - {name}");
        PhotonNetwork.JoinOrCreateRoom(name, roomOptions, null);
    }

    public void JoinOrCreateRoom(string name)
    {
        roomOptions.MaxPlayers = 5;
        Debug.Log($"������������� ��� �������� ������� - {name}");
        PhotonNetwork.JoinOrCreateRoom(name, roomOptions, null);
    }

    public void JoinRandomRoom()
    {
        Debug.Log("������������� � ��������� �������");
        PhotonNetwork.JoinRandomRoom();
    }

    public void JoinRandomOrCreateRoom(byte maxCountPlayers = 5)
    {
        roomOptions.MaxPlayers = maxCountPlayers;
        Debug.Log("������������� � ��������� ������� ��� � �����");
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
