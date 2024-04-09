using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Chat.Demo;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void OnGetMessageAction(string channelName, object[] messages);

namespace Lessons.Architecture
{
    public class ChatPhotonInteractor : Interactor
    {
        public ChatEvents Events;
        private ChatClient chatClient;
        //public event OnGetMessageAction OnGetMessageEvent;
        //public event Action OnConnectedEvent;
        //public event Action OnDisconnectedEvent;
        //public event Action OnSubscribedEvent;
        //public event Action OnUnsubscribedEvent;

        private ChatAppSettings chatAppSettings;
        private IGameChat gameChat;

        private List<string> rooms = new List<string>();

        public static int ID = 0;
        public int ID_Current;

        public override void Initialize()
        {
            ID += 1;
            ID_Current = ID;

            base.Initialize();

            if (PhotonChatNetwork.ChatClient == null || PhotonChatNetwork.ChatEvents == null)
            {
                Debug.Log("СОЗДАНИЕ");
                PhotonChatNetwork.Initialize();
            }

            chatClient = PhotonChatNetwork.ChatClient;
            Events = PhotonChatNetwork.ChatEvents;

            //chatClient = PhotonChatNetwork.ChatClient;
            //Debug.Log(chatClient != null);
            //Events = PhotonChatNetwork.ChatEvents;
            //Debug.Log(Events != null);

            //Debug.Log("Подписка");
            //Events.OnConnectedEvent += OnConnectedEvent;
            //Events.OnDisconnectedEvent += OnDisconnectedEvent;
            //Events.OnSubscribedEvent += OnSubscribedEvent;
            //Events.OnUnsubscribedEvent += OnUnsubscribedEvent;
            //Events.OnGetMessageEvent += OnGetMessageEvent;

        }

        public void SetData(IGameChat gameChat)
        {
            this.gameChat = gameChat;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            Debug.Log("Отписка");
            //Events.OnConnectedEvent -= OnConnectedEvent;
            //Events.OnDisconnectedEvent -= OnDisconnectedEvent;
            //Events.OnSubscribedEvent -= OnSubscribedEvent;
            //Events.OnUnsubscribedEvent -= OnUnsubscribedEvent;
            //Events.OnGetMessageEvent -= OnGetMessageEvent;
        }

        #region ChatClient

        public void Connect()
        {
            chatAppSettings = PhotonNetwork.PhotonServerSettings.AppSettings.GetChatSettings();
            //chatAppSettings.FixedRegion = region;
            //Debug.Log($"Подключение к {chatClient.ChatRegion}");
            chatClient.ConnectUsingSettings(PhotonNetwork.PhotonServerSettings.AppSettings.GetChatSettings());
        }

        public void Disconnect()
        {
            chatClient.Disconnect();
        }

        public void SendPublishMessage(string message)
        {
            chatClient.PublishMessage(PhotonNetwork.CurrentRoom.Name, message);
        }

        public void SendPublishMessageOnChatFromUser(string playerName, string message)
        {
            chatClient.PublishMessage(PhotonNetwork.CurrentRoom.Name, $"{playerName}: {message}");
        }

        public void SendPublishMessageOnJoinRoom(string playerName)
        {
            chatClient.PublishMessage(PhotonNetwork.CurrentRoom.Name, $"{playerName} вступил в игру");
        }

        public void SendPublishMessageOnExitRoom(string playerName)
        {
            chatClient.PublishMessage(PhotonNetwork.CurrentRoom.Name, $"{playerName} покинул игру");
        }

        public void Service()
        {
            chatClient.Service();
        }

        public void Subscribe()
        {
            rooms.Add(PhotonNetwork.CurrentRoom.Name);
            Debug.Log(rooms[0]);
            chatClient.Subscribe(rooms.ToArray());
        }

        public void Unsubscribe()
        {
            chatClient.Unsubscribe(rooms.ToArray());
            rooms.Clear();
        }

        #endregion

        #region GameChat

        public void ActivateChat()
        {
            gameChat.ActivateChat();
        }

        public void DiactivateChat()
        {
            gameChat.DiactivateChat();
        }

        public void OpenChat()
        {
            gameChat.OpenChat();
        }

        public void CloseChat()
        {
            gameChat.CloseChat();
        }

        #endregion

    }
}

public interface IGameChat
{
    void ActivateChat();
    void DiactivateChat();
    void OpenChat();
    void CloseChat();
}
