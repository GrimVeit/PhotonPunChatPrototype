using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speedJump;
    [SerializeField] private float speedMove;

    private Vector3 moveDirection = Vector3.zero;

    public void Move(Vector3 vector)
    {
        moveDirection = transform.TransformDirection(vector) * speedMove;
        characterController.Move(moveDirection);
    }
    public void Jump()
    {
        if (characterController.isGrounded)
        {
            moveDirection.y = speedJump;
        }
    }
}
