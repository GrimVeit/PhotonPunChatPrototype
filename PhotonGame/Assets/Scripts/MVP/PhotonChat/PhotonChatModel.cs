using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Chat.Demo;
using Photon.Pun;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PhotonChatModel : IChatClientListener
{
    public event OnGetMessageAction OnGetMessageEvent;
    public event Action OnConnectedEvent;
    public event Action OnDisconnectedEvent;
    public event Action OnSubscribedEvent;
    public event Action OnUnsubscribedEvent;

    private ChatAppSettings chatAppSettings;
    private ChatClient chatClient;
    private List<string> rooms = new List<string>();

    public void Initialize()
    {
        chatClient = new ChatClient(this);
    }

    #region Methods

    #region ChatClient

    public void Connect()
    {
        chatAppSettings = PhotonNetwork.PhotonServerSettings.AppSettings.GetChatSettings();
        //chatAppSettings.FixedRegion = region;
        //Debug.Log($"Подключение к {chatClient.ChatRegion}");
        chatClient.ConnectUsingSettings(PhotonNetwork.PhotonServerSettings.AppSettings.GetChatSettings());

        //chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues("Л"))
    }

    public void Disconnect()
    {
        chatClient.Disconnect();
    }

    public void SendPublishMessage(string channelName, string message)
    {
        chatClient.PublishMessage(channelName, message);
    }

    public void Service()
    {
        chatClient.Service();
    }

    public void SubscribeToChat()
    {
        rooms.Add(PhotonNetwork.CurrentRoom.Name);
        Debug.Log(rooms[0]);
        chatClient.Subscribe(rooms.ToArray());
    }

    public void UnsubscribeToChat()
    {
        chatClient.Unsubscribe(rooms.ToArray());
        rooms.Remove(PhotonNetwork.CurrentRoom.Name);
    }

    #endregion

    #endregion

    #region Events

    public void OnConnected()
    {
        Debug.Log("Событие коннекта");
        OnConnectedEvent?.Invoke();
    }

    public void OnDisconnected()
    {
        OnDisconnectedEvent?.Invoke();
        Debug.Log("Событие дисконнекта");
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        Debug.Log($"Событие при подписке канала на чат: {channels[0]}, {results[0]}");
        OnSubscribedEvent?.Invoke();
    }

    public void OnUnsubscribed(string[] channels)
    {
        Debug.Log("Событие при отписке канала на чат: " + channels[0]);
        OnUnsubscribedEvent?.Invoke();
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        Debug.Log("Событие при получении сообщения: " + messages[0].ToString());
        OnGetMessageEvent?.Invoke(channelName, messages);
    }





    public void OnPrivateMessage(string sender, object message, string channelName)
    {
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
    }

    public void OnUserSubscribed(string channel, string user)
    {
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
    }

    public void DebugReturn(DebugLevel level, string message)
    {
    }

    public void OnChatStateChange(ChatState state)
    {
    }

    #endregion
}
