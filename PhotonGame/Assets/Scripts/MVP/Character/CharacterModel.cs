using System;
using UnityEngine;

public class CharacterModel
{
    public event Action<Vector3> OnMove;
    public void Move(Vector3 vector)
    {
        OnMove?.Invoke(vector);
    }
}
