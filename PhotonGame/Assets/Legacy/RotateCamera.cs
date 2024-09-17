using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private Vector2 touchStartPos;
    public float rotationSpeed;
    public CinemachineFreeLook freeLook;

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDelta = touch.position - touchStartPos;

                float rotX = -touchDelta.y * rotationSpeed * Time.deltaTime;
                float rotY = touchDelta.x * rotationSpeed * Time.deltaTime;

                freeLook.m_XAxis.Value += rotY;
                freeLook.m_YAxis.Value += rotX;
            }
        }
    }
}
