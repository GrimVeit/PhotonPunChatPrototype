using System;
using System.Collections;
using UnityEngine;

public class CharacterModel
{
    public event Action<Vector2> OnMove;

    private IEnumerator coroutineMove;

    private Vector3 moveDirection;

    private bool isActiveMove = false;


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
}
