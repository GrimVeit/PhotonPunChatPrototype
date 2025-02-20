using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speedJump;
    [SerializeField] private float speedMove;

    private Vector3 moveDirection = Vector3.zero;

    public void Move(Vector2 vector)
    {
        Debug.Log(vector);

        moveDirection = characterController.transform.right * vector.x + characterController.transform.forward * vector.y;
        moveDirection = transform.TransformDirection(moveDirection) * speedMove;
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
