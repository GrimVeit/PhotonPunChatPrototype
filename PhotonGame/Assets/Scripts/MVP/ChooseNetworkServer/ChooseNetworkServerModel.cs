using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseNetworkServerModel
{
    public event Action<ServerRegion> OnChooseServer;

    public void ChooseServer(ServerRegion serverRegion)
    {
        OnChooseServer?.Invoke(serverRegion);
    }
}
