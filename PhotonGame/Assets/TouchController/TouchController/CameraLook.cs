using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Vector2 LockAxis;

    [SerializeField] private float Sensivity = 40f;

    [SerializeField] private Transform transformPlayer;
    [SerializeField] private Transform transformCamera;

    private float XMove;
    private float YMove;
    private float XRotation;
    public void SetCamera(Transform transformCamera, Transform transformPlayer)
    {
        this.transformCamera = transformCamera;
        this.transformPlayer = transformPlayer;
    }
    
    public void UpdateLook()
    {
        if(transformCamera == null || transformPlayer == null)
        {
            return;
        }

        XMove = LockAxis.x * Sensivity * Time.deltaTime;
        YMove = LockAxis.y * Sensivity * Time.deltaTime;
        XRotation -= YMove;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(XRotation,0,0);
        transformPlayer.Rotate(Vector3.up * XMove);
    }
}
