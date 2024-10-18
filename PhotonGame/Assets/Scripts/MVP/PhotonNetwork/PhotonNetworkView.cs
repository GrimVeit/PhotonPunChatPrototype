using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhotonNetworkView : View
{
    public event Action<string> OnChooseChannel;
    public event Action<ServerRegion> OnChooseServer;

    [SerializeField] private List<PhotonNetworkServer> photonNetworkServers = new List<PhotonNetworkServer>();

    //[SerializeField] private TMP_InputField channelInputField;
    //[SerializeField] private Button channelSubmit;

    public void Initialize()
    {
        for (int i = 0; i < photonNetworkServers.Count; i++)
        {
            photonNetworkServers[i].OnChooseServer += ChooseServer;
            photonNetworkServers[i].Initialize();
        }

        //channelSubmit.onClick.AddListener(HandlerClickToSubmitChannel);
    }

    public void Dispose()
    {
        for (int i = 0; i < photonNetworkServers.Count; i++)
        {
            photonNetworkServers[i].OnChooseServer -= ChooseServer;
            photonNetworkServers[i].Dispose();
        }

        //channelSubmit.onClick.RemoveListener(HandlerClickToSubmitChannel);
    }

    #region Input

    private void ChooseServer(ServerRegion region)
    {
        OnChooseServer?.Invoke(region);
    }

    //private void HandlerClickToSubmitChannel()
    //{
    //    string channel = channelInputField.text;

    //    OnChooseChannel?.Invoke(channel);
    //}

    #endregion
}
