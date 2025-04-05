using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform transformCamera;
    [SerializeField] private Transform transformPlayer;
    [SerializeField] private float speedJump;
    [SerializeField] private float speedMove;

    [SerializeField] private float SensivityX = 4f;
    [SerializeField] private float SensivityY = 4f;
    private float XMove;
    private float YMove;
    private float XRotation;

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

    public void Rotate(Vector2 vector)
    {
        XMove = vector.x * SensivityX * Time.deltaTime;
        YMove = vector.y * SensivityY * Time.deltaTime;

        XRotation -= YMove;
        XRotation = Mathf.Clamp(XRotation, -30f, 50f);

        transformCamera.localRotation = Quaternion.Euler(XRotation, 0, 0);
        transformPlayer.Rotate(Vector3.up * XMove);
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
        moveDirection.y -= 9.81f * Time.deltaTime;
        characterController.Move(Time.deltaTime * moveDirection);
    }
}
