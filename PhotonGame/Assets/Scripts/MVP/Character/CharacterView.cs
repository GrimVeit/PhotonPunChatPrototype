using System;
using UnityEngine;

public class CharacterView : View
{
    [SerializeField] private Joystick joystick;

    private Character character;

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

    public void SetCharacter(Character character)
    {
        this.character = character;
    }

    public void Move(Vector2 vector)
    {
        if(character == null) return;

        character.Move(vector);
    }

    public void Rotate(Vector3 vector)
    {
        if (character == null) return;
    }

    #region Input

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
