using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonNetworkPresenter
{
    private PhotonNetworkModel photonNetworkModel;
    private PhotonNetworkView photonNetworkView;

    public PhotonNetworkPresenter(PhotonNetworkModel photonNetworkModel, PhotonNetworkView photonNetworkView)
    {
        this.photonNetworkModel = photonNetworkModel;
        this.photonNetworkView = photonNetworkView;
    }

    public void Initialize()
    {
        ActivateEvents();

        photonNetworkView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        photonNetworkView.Dispose();
    }

    private void ActivateEvents()
    {
        photonNetworkView.OnChooseServer += photonNetworkModel.ConnectToRegion;
        photonNetworkView.OnChooseChannel += photonNetworkModel.JoinOrCreateRoom;
    }

    private void DeactivateEvents()
    {
        photonNetworkView.OnChooseServer -= photonNetworkModel.ConnectToRegion;
        photonNetworkView.OnChooseChannel -= photonNetworkModel.JoinOrCreateRoom;
    }
}
