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

        Vector3 forward = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
        Vector3 right = Vector3.ProjectOnPlane(transform.right, Vector3.up);

        moveDirection = right * vector.x + forward * vector.y;
        moveDirection *= speedMove;

        characterController.Move(moveDirection);
    }
    public void Jump()
    {
        if (characterController.isGrounded)
        {
            moveDirection.y = speedJump;
        }
    }

    private void Update()
    {
        moveDirection.y -= 2 * Time.deltaTime;
        characterController.Move(Time.deltaTime * moveDirection);
    }
}
