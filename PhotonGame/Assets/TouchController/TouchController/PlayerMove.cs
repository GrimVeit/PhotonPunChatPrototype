using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    [SerializeField] private Joystick joystick;
    [SerializeField] private float gravity;
    [SerializeField] private float speedMove = 5f;
    [SerializeField] private float jumpSpeed;

    public AnimatorCharacter animateCharacter;
    public CharacterController controller;

    private Vector3 moveDirection;

    public void SetData(AnimatorCharacter animateCharacter, CharacterController characterController)
    {
        this.animateCharacter = animateCharacter;
        this.controller = characterController;
    }

    void Update()
    {
        if(controller == null || animateCharacter == null)
        {
            return;
        }
        if (controller.isGrounded)
        {
            moveDirection = controller.transform.right * joystick.Horizontal + controller.transform.forward * joystick.Vertical;
            moveDirection = transform.TransformDirection(moveDirection) * speedMove;
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(Time.deltaTime * moveDirection);
        animateCharacter.PlayAnimation(MaxValue(joystick.Horizontal, joystick.Vertical));
    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            moveDirection.y = jumpSpeed;
            controller.Move(Time.deltaTime * moveDirection);
        }
    }

    private float MaxValue(float a, float b)
    {
        float maxValue = Mathf.Abs(a);
        if (Mathf.Abs(b) > maxValue)
            maxValue = Mathf.Abs(b);
        return maxValue;
    }
}
