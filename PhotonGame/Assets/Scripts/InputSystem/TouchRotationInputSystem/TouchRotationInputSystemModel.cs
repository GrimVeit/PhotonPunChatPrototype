using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TouchRotationInputSystemModel
{
    public event Action OnStartRotate;
    public event Action<Vector2> OnRotate;
    public event Action OnEndRotate;

    private bool isActiveRotate;
    private IEnumerator coroutineRotate;
    private Vector2 rotateDirection;

    public void ActivateRotate(int pointerId, Vector3 pointerOld)
    {
        OnStartRotate?.Invoke();

        isActiveRotate = true;

        if (coroutineRotate != null)
            Coroutines.Stop(coroutineRotate);

        coroutineRotate = RotateCoroutine(pointerId, pointerOld);
        Coroutines.Start(coroutineRotate);
    }

    public void DeactivateRotate()
    {
        OnEndRotate?.Invoke();

        if (coroutineRotate != null)
            Coroutines.Stop(coroutineRotate);
    }

    private IEnumerator RotateCoroutine(int pointerId, Vector2 pointerOld)
    {
        while (isActiveRotate)
        {
            if (pointerId >= 0 && pointerId < Input.touches.Length)
            {
                rotateDirection = Input.touches[pointerId].position - pointerOld;
                pointerOld = Input.touches[pointerId].position;
            }
            else
            {
                rotateDirection = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - pointerOld;
                pointerOld = Input.mousePosition;
            }

            OnRotate?.Invoke(rotateDirection);
            yield return null;
        }
    }
}
