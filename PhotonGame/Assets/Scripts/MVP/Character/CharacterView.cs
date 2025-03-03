using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : View
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private TouchField touchField;
    [SerializeField] private Button buttonJump;

    private Character character;

    public void Initialize()
    {
        joystick.OnStartMove += HandleStartMoveJoystick;
        joystick.OnMove += HandleMoveJoystick;
        joystick.OnEndMove += HandleEndMoveJoystick;

        touchField.OnStartTouch += HandleStartTouch;
        touchField.OnEndTouch += HandleEndTouch;

        buttonJump.onClick.AddListener(Jump);
    }

    public void Dispose()
    {
        joystick.OnStartMove -= HandleStartMoveJoystick;
        joystick.OnMove -= HandleMoveJoystick;
        joystick.OnEndMove -= HandleEndMoveJoystick;

        touchField.OnStartTouch -= HandleStartTouch;
        touchField.OnEndTouch -= HandleEndTouch;

        buttonJump.onClick.RemoveListener(Jump);
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

    public void Jump()
    {
        if(character == null) return;

        character.Jump();
    }

    public void Rotate(Vector2 vector)
    {
        if (character == null) return;

        character.Rotate(vector);
    }

    #region Input

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

    #endregion
}
