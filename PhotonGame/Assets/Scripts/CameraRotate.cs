using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float speedRotate;
    private void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                float rotate = transform.localEulerAngles.y + touch.deltaPosition.x * speedRotate * Time.deltaTime;
                transform.localEulerAngles = new Vector3(0, rotate, 0);
            }
        }
    }
}
