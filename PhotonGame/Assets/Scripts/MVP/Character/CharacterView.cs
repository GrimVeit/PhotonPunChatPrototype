using System;
using UnityEngine;

public class CharacterView : View
{
    [SerializeField] private Joystick joystick;

    private Character character;

    public void Initialize()
    {
        joystick.OnMove += HandleJoystickMove;
    }

    public void Dispose()
    {
        joystick.OnMove -= HandleJoystickMove;
    }

    public void SetCharacter(Character character)
    {
        this.character = character;
    }

    public void Move(Vector3 vector)
    {
        if(character == null) return;

        character.Move(vector);
    }

    #region Input

    public event Action<Vector3> OnMove;

    private void HandleJoystickMove(Vector3 vector)
    {
        OnMove?.Invoke(vector);
    }

    #endregion
}
