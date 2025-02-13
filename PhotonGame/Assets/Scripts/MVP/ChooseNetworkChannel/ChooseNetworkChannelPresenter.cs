using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseNetworkChannelPresenter
{
    private ChooseNetworkChannelModel model;
    private ChooseNetworkChannelView view;

    public ChooseNetworkChannelPresenter(ChooseNetworkChannelModel model, ChooseNetworkChannelView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        view.OnChooseChannel += model.ChooseChannel;
    }

    private void DeactivateEvents()
    {
        view.OnChooseChannel -= model.ChooseChannel;
    }

    #region Input

    public event Action<string> OnChooseChannel
    {
        add { model.OnChooseChannel += value; }
        remove { model.OnChooseChannel -= value; }
    }

    #endregion
}
