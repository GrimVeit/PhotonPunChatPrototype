using System;
using UnityEngine;

public class TouchRotationInputSystemPresenter
{
    private readonly TouchRotationInputSystemModel _model;
    private readonly TouchRotationInputSystemView _view;

    public TouchRotationInputSystemPresenter(TouchRotationInputSystemModel model, TouchRotationInputSystemView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        _view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _view.Dispose();
    }

    private void ActivateEvents()
    {
        _view.OnStartTouch += _model.ActivateRotate;
        _view.OnEndTouch += _model.DeactivateRotate;
    }

    private void DeactivateEvents()
    {

        _view.OnStartTouch -= _model.ActivateRotate;
        _view.OnEndTouch -= _model.DeactivateRotate;
    }

    #region Input

    public event Action OnStartRotate
    {
        add => _model.OnStartRotate += value;
        remove => _model.OnStartRotate -= value;
    }

    public event Action<Vector2> OnRotate
    {
        add => _model.OnRotate += value;
        remove => _model.OnRotate -= value;
    }

    public event Action OnEndRotate
    {
        add => _model.OnEndRotate += value;
        remove => _model.OnEndRotate -= value;
    }

    #endregion
}
