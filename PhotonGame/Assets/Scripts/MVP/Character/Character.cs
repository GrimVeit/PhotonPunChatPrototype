using UnityEngine;

public class Character : MonoBehaviour, ICharacterMoveRotateProvider, ICharacterCameraProvider
{
    [SerializeField] private CharacterCamera characterCamera;
    [SerializeField] private CharacterMove characterMove;
    [SerializeField] private CharacterAnimator characterAnimator;

    public void Move(Vector2 vector)
    {
        characterMove.Move(vector);

        Animate(MaxValue(vector.x, vector.y));
    }

    public void Rotate(Vector2 vector)
    {
        characterMove.Rotate(vector);
    }

    public void Jump()
    {
        characterMove.Jump();
    }

    public void Animate(float value)
    {
        characterAnimator.PlayAnimation(value);
    }

    public void ActivateCharacterCamera()
    {
        characterCamera.ActivateCamera(true);
    }

    public void DeactivateCharacterCamera()
    {
        characterCamera.ActivateCamera(false);
    }

    private float MaxValue(float a, float b)
    {
        float maxValue = Mathf.Abs(a);
        if (Mathf.Abs(b) > maxValue)
            maxValue = Mathf.Abs(b);
        return maxValue;
    }
}

public interface ICharacterCameraProvider
{
    void ActivateCharacterCamera();
    void DeactivateCharacterCamera();
}

public interface ICharacterMoveRotateProvider
{
    void Move(Vector2 vector);
    void Rotate(Vector2 vector);
}
