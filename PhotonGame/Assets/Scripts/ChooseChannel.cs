using Lessons.Architecture;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ChooseChannel : MonoBehaviourPunCallbacks
{
    public UnityEvent OnChangeChannel;
    [SerializeField] private Transform content;
    [SerializeField] private ChannelInfo channelInfoPref;
    [SerializeField] private TMP_InputField roomName;

    private PhotonInteractor photonInteractor;
    private string nameChannel;

    public void Initialize()
    {
        photonInteractor = Game.GetInteractor<PhotonInteractor>();
    }

    public void JoinRandomOrCreateRoom()
    {
        OnChangeChannel?.Invoke();
        nameChannel = roomName.text;
        photonInteractor.LeaveRoom();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Подключение успешно");
        photonInteractor.JoinOrCreateRoom(nameChannel, 5);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        ClearList();
        GetList(roomList);
    }

    private void GetList(List<RoomInfo> rooms)
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            ChannelInfo channel = Instantiate(channelInfoPref, content);
            channel.SetData(rooms[i].Name, rooms[i].PlayerCount.ToString(), rooms[i].MaxPlayers.ToString());
        }
    }

    private void ClearList()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }
    }
}
