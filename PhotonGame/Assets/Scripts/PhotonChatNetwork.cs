using UnityEngine;
using Photon.Chat;
using ExitGames.Client.Photon;
using System;

public static class PhotonChatNetwork
{
    public static ChatClient ChatClient { get; private set; } = null;
    public static ChatEvents ChatEvents { get; private set; } = null;

    public static void Initialize()
    {
        ChatEvents = new ChatEvents();
        ChatClient = new ChatClient(ChatEvents);
    }
}

public class ChatEvents : IChatClientListener
{
    public event OnGetMessageAction OnGetMessageEvent;
    public event Action OnConnectedEvent;
    public event Action OnDisconnectedEvent;
    public event Action OnSubscribedEvent;
    public event Action OnUnsubscribedEvent;

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

    #region Others

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
