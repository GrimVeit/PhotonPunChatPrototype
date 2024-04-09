using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhotonConnect
{
    public void ConnectToRegion(string region);
    public void ConnectToBestServer();
    public void ConnectUsingSettings();
    public void DisconnectServer();
}

public interface IPhotonJoinOrCreateRoom
{
    public void CreateRoom(string name, byte maxCountPlayer = 5);
    public void JoinRoom(string roomName);
    public void JoinRandomOrCreateRoom(byte maxCountPlayer = 5);
    public void JoinOrCreateRoom(string name, byte maxCountPlayer = 5);
    public void JoinRandomRoom();
}
