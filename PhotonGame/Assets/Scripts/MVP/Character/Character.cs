using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterCamera characterCamera;
    [SerializeField] private CharacterMove characterMove;
    [SerializeField] private CharacterAnimator characterAnimator;

    public void Move(Vector2 vector)
    {
        characterMove.Move(vector);
    }

    public void Jump()
    {
        characterMove.Jump();
    }

    public void ActivateCharacterCamera()
    {
        characterCamera.ActivateCamera(true);
    }

    public void DeactivateCharacterCamera()
    {
        characterCamera.ActivateCamera(true);
    }
}
