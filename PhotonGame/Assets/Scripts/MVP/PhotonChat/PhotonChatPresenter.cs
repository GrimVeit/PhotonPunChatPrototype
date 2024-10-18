using System;

public class PhotonChatPresenter
{
    private PhotonChatModel photonChatModel;
    private PhotonChatView photonChatView;

    public PhotonChatPresenter(PhotonChatModel photonChatModel, PhotonChatView photonChatView)
    {
        this.photonChatModel = photonChatModel;
        this.photonChatView = photonChatView;
    }

    public void Initialize()
    {
        ActivateEvents();

        photonChatView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        photonChatView.Dispose();
    }

    private void ActivateEvents()
    {
        
    }

    private void DeactivateEvents()
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
