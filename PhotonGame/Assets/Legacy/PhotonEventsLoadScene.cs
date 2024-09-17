using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Chat;
using Lessons.Architecture;
using ExitGames.Client.Photon;

public class PhotonEventsLoadScene : MonoBehaviourPunCallbacks, IChatClientListener
{
    private PhotonInteractor photonInteractor;
    private ChatPhotonInteractor chatPhotonInteractor;
    public void Initialize()
    {
        photonInteractor = Game.GetInteractor<PhotonInteractor>();
        chatPhotonInteractor = Game.GetInteractor<ChatPhotonInteractor>();
    }

    #region PhotonPun2_EVENTS
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        SceneManager.LoadScene(2);
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        
        //chatPhotonInteractor.Connect();
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        photonInteractor.LoadLevel(3);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        SceneManager.LoadScene(2);
    }
    #endregion

    #region

    void IChatClientListener.OnConnected()
    {
        photonInteractor.JoinRandomOrCreateRoom(5);
    }

    public void DebugReturn(DebugLevel level, string message)
    {

    }

    public void OnDisconnected()
    {
        SceneManager.LoadScene(2);
    }

    public void OnChatStateChange(ChatState state)
    {

    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {

    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {

    }

    public void OnSubscribed(string[] channels, bool[] results)
    {

    }

    public void OnUnsubscribed(string[] channels)
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

    #endregion
}
