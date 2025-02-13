using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseNetworkServerView : View
{
    public event Action<ServerRegion> OnChooseServer;

    [SerializeField] private List<PhotonNetworkServer> photonNetworkServers = new List<PhotonNetworkServer>();

    public void Initialize()
    {
        for (int i = 0; i < photonNetworkServers.Count; i++)
        {
            photonNetworkServers[i].OnChooseServer += ChooseServer;
            photonNetworkServers[i].Initialize();
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < photonNetworkServers.Count; i++)
        {
            photonNetworkServers[i].OnChooseServer -= ChooseServer;
            photonNetworkServers[i].Dispose();
        }
    }

    #region Input

    private void ChooseServer(ServerRegion region)
    {
        OnChooseServer?.Invoke(region);
    }

    #endregion
}
