
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Lessons.Architecture;

public class PhotonRegionConnect : PhotonConnect
{
    public void ConnectToServer()
    {
        string nameServer = PlayerPrefs.GetString("RegionName", "eu");

        if(nameServer == "SingleMode")
        {
            photonInteractor.LoadLevel(2);
            return;
        }

        photonInteractor.ConnectToRegion(nameServer);
    }
}
