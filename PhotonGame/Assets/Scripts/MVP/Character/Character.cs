using UnityEngine;

public class Character : MonoBehaviour
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
        characterCamera.ActivateCamera(true);
    }

    private float MaxValue(float a, float b)
    {
        float maxValue = Mathf.Abs(a);
        if (Mathf.Abs(b) > maxValue)
            maxValue = Mathf.Abs(b);
        return maxValue;
    }
}
