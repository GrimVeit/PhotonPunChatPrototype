using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickInputSystemModel
{
    public event Action OnStartMove;
    public event Action<Vector2> OnMove;
    public event Action OnEndMove;

    private Vector3 moveDirection;
    private bool isActiveMove;
    private IEnumerator coroutineMove;

    #region Move

    public void SetDirection(Vector2 vector)
    {
        moveDirection = vector;
    }

    public void StartMove()
    {
        OnStartMove?.Invoke();

        isActiveMove = true;

        if (coroutineMove != null)
            Coroutines.Stop(coroutineMove);

        coroutineMove = MoveCoroutine();
        Coroutines.Start(coroutineMove);
    }

    public void EndMove()
    {
        OnEndMove?.Invoke();

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
}
