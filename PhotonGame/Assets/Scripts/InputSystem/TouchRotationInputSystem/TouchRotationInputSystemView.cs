using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotationInputSystemView : View
{
    [SerializeField] private TouchField touchField;

    public void Initialize()
    {
        touchField.OnStartTouch += HandleStartTouch;
        touchField.OnEndTouch += HandleEndTouch;
    }

    public void Dispose()
    {
        touchField.OnStartTouch -= HandleStartTouch;
        touchField.OnEndTouch -= HandleEndTouch;
    }
    

    #region Rotate

    public event Action<int, Vector3> OnStartTouch;
    public event Action OnEndTouch;

    private void HandleStartTouch(int pointerId, Vector3 vectorOld)
    {
        OnStartTouch?.Invoke(pointerId, vectorOld);
    }

    private void HandleEndTouch()
    {
        OnEndTouch?.Invoke();
    }

    #endregion
}
