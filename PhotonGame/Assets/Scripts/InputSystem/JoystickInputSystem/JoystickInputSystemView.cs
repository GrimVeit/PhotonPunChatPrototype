using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInputSystemView : View
{
    [SerializeField] private Joystick joystick;

    public void Initialize()
    {
        joystick.OnStartMove += HandleStartMoveJoystick;
        joystick.OnMove += HandleMoveJoystick;
        joystick.OnEndMove += HandleEndMoveJoystick;
    }

    public void Dispose()
    {
        joystick.OnStartMove -= HandleStartMoveJoystick;
        joystick.OnMove -= HandleMoveJoystick;
        joystick.OnEndMove -= HandleEndMoveJoystick;
    }

    #region Move

    public event Action OnStartMove;
    public event Action<Vector2> OnMove;
    public event Action OnEndMove;

    private void HandleStartMoveJoystick()
    {
        OnStartMove?.Invoke();
    }

    private void HandleMoveJoystick(Vector2 vector)
    {
        OnMove?.Invoke(vector);
    }

    private void HandleEndMoveJoystick()
    {
        OnEndMove?.Invoke();
    }

    #endregion
}
