using System;

public class PhotonChatPresenter
{
    private PhotonChatModel photonChatModel;

    public PhotonChatPresenter(PhotonChatModel photonChatModel)
    {
        this.photonChatModel = photonChatModel;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    #region Methods

    public void Connect()
    {
        photonChatModel.Connect();
    }

    public void Disconnect()
    {
        photonChatModel.Disconnect();
    }

    public void SendPublishMessage(string channelName, string message)
    {
        photonChatModel.SendPublishMessage(channelName, message);
    }

    public void Service()
    {
        photonChatModel.Service();
    }

    public void SubscribeToChat()
    {
        photonChatModel.SubscribeToChat();
    }

    public void UnsubscribeToChat()
    {
        photonChatModel.UnsubscribeToChat();
    }

    #endregion

    #region Events

    public event OnGetMessageAction OnGetMessageEvent
    {
        add { photonChatModel.OnGetMessageEvent += value; }
        remove { photonChatModel.OnGetMessageEvent -= value; }
    }

    public event Action OnConnectedEvent
    {
        add { photonChatModel.OnConnectedEvent += value; }
        remove { photonChatModel.OnConnectedEvent -= value; }
    }

    public event Action OnDisconnectedEvent
    {
        add { photonChatModel.OnDisconnectedEvent += value; }
        remove { photonChatModel.OnDisconnectedEvent -= value; }
    }

    public event Action OnSubscribedEvent
    {
        add { photonChatModel.OnSubscribedEvent += value; }
        remove { photonChatModel.OnSubscribedEvent -= value; }
    }

    public event Action OnUnsubscribedEvent
    {
        add { photonChatModel.OnUnsubscribedEvent += value; }
        remove { photonChatModel.OnUnsubscribedEvent -= value; }
    }

    #endregion
}
