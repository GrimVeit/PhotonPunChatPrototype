using System;
using UnityEngine;

public class JoystickInputSystemPresenter
{
    private readonly JoystickInputSystemModel _model;
    private readonly JoystickInputSystemView _view;

    public JoystickInputSystemPresenter(JoystickInputSystemModel model, JoystickInputSystemView view)
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
        _view.OnStartMove += _model.StartMove;
        _view.OnMove += _model.SetDirection;
        _view.OnEndMove += _model.EndMove;
    }

    private void DeactivateEvents()
    {
        _view.OnStartMove -= _model.StartMove;
        _view.OnMove -= _model.SetDirection;
        _view.OnEndMove -= _model.EndMove;
    }

    #region Input

    public event Action OnStartMove
    {
        add => _model.OnStartMove += value;
        remove => _model.OnStartMove -= value;
    }

    public event Action<Vector2> OnMove
    {
        add => _model.OnMove += value;
        remove => _model.OnMove -= value;
    }

    public event Action OnEndMove
    {
        add => _model.OnEndMove += value;
        remove => _model.OnEndMove -= value;
    }

    #endregion
}
