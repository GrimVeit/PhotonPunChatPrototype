using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Joystick joystick;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform cameraTransform;

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(joystick.Horizontal, 0f, joystick.Vertical).normalized;
        moveDirection = Vector3.ProjectOnPlane(moveDirection, Vector3.up).normalized;
        if(moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            characterController.transform.rotation = Quaternion.RotateTowards(characterController.transform.rotation,
                toRotation, Time.deltaTime * rotateSpeed);
        }
        Vector3 moveDirect = cameraTransform.TransformDirection(moveDirection);
        characterController.Move(moveSpeed * Time.deltaTime * moveDirect);
    }
}
