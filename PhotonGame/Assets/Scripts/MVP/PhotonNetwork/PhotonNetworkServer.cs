using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PhotonNetworkServer
{
    public event Action<ServerRegion> OnChooseServer;

    [SerializeField] private ServerRegion region;
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
        OnChooseServer?.Invoke(region);
    }
}

public enum ServerRegion
{
    Asia, //Asia, - Singapore
    Au, //Australia, - Sydney
    Cae, //Canada, East - Montreal
    Eu, //Europe, - Amsterdam
    Hk, //Hong Kong
    In, //India, - Chennai
    Jp, //Japan, Tokyo
    Za, //South Africa, - Johannesburg
    Sa, //South America, - Sao Paulo 
    Kr, //South Korea, - Seoul
    Tr, //Turkey, - Istanbul
    Uae, //United Arab Emirates, - Dubai
    Us, //USA East, - Washington D.C.
    Usw, //USA West, - San Jose
    Ussc, //USA South Central, - Dallas
    Ru, //Russia
    Local
}
