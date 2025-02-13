using System;

public class ChooseNetworkServerPresenter
{
    private ChooseNetworkServerModel model;
    private ChooseNetworkServerView view;

    public ChooseNetworkServerPresenter(ChooseNetworkServerModel model, ChooseNetworkServerView view)
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
        view.OnChooseServer += model.ChooseServer;
    }

    private void DeactivateEvents()
    {
        view.OnChooseServer -= model.ChooseServer;
    }

    #region Input

    public event Action<ServerRegion> OnChooseServer
    {
        add { model.OnChooseServer += value; }
        remove { model.OnChooseServer -= value; }
    }

    #endregion
}
