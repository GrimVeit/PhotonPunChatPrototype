using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonNetworkServer : MonoBehaviour
{
    public event Action<string> OnChooseServer;

    [SerializeField] private string serverID;
    [SerializeField] private Button serverButton;

    public void Initialize()
    {
        serverButton.onClick.AddListener(HandlerClickToServer);
    }

    public void Dispose()
    {
        serverButton.onClick.RemoveListener(HandlerClickToServer);
    }

    private void HandlerClickToServer()
    {
        OnChooseServer?.Invoke(serverID);
    }
}
