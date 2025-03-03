using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterModel
{
    public event Action<Vector2> OnMove;
    public event Action<Vector2> OnRotate;

    private IEnumerator coroutineMove;
    private IEnumerator coroutineRotate;

    private Vector3 moveDirection;
    private Vector2 rotateDirection;

    private bool isActiveMove = false;
    private bool isActiveRotate = false;

    #region Move

    public void SetDirection(Vector2 vector)
    {
        moveDirection = vector;
    }

    public void ActivateMove()
    {
        isActiveMove = true;

        if(coroutineMove != null)
            Coroutines.Stop(coroutineMove);

        coroutineMove = MoveCoroutine();
        Coroutines.Start(coroutineMove);
    }

    public void DeactivateMove()
    {
        isActiveMove = false;

        if (coroutineMove != null)
            Coroutines.Stop(coroutineMove);

        OnMove?.Invoke(Vector3.zero);
    }

    private IEnumerator MoveCoroutine()
    {
        while (isActiveMove)
        {
            OnMove?.Invoke(moveDirection);
            yield return null;
        }
    }

    #endregion

    #region Rotate

    public void ActivateRotate(int pointerId, Vector3 pointerOld)
    {
        isActiveRotate = true;

        if(coroutineRotate != null)
            Coroutines.Stop(coroutineRotate);

        coroutineRotate = RotateCoroutine(pointerId, pointerOld);
        Coroutines.Start(coroutineRotate);
    }

    public void DeactivateRotate()
    {
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

    #endregion

}
