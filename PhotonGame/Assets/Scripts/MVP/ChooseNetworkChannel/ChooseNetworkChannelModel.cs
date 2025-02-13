using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseNetworkChannelModel
{
    public event Action<string> OnChooseChannel;

    public void ChooseChannel(string channel)
    {
        OnChooseChannel?.Invoke(channel);
    }
}
