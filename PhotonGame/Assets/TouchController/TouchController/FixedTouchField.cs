using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedTouchField : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
    public bool Pressed { get; private set; }

    [SerializeField] private float SensivityX = 4f;
    [SerializeField] private float SensivityY = 4f;

    public Transform transformPlayer;
    public Transform transformCamera;

    public Vector2 touchDist;

    private int pointerId;
    private Vector2 pointerOld;

    private float XMove;
    private float YMove;
    private float XRotation;

    public void SetData(Transform player, Transform camera)
    {
        transformPlayer = player;
        transformCamera = camera;
    }

    void Update()
    {
        if (transformCamera == null || transformPlayer == null)
        {
            return;
        }

        if (!Pressed)
        {
            return;
        }

        if (pointerId >= 0 && pointerId < Input.touches.Length)
        {
            touchDist = Input.touches[pointerId].position - pointerOld;
            pointerOld = Input.touches[pointerId].position;
        }
        else
        {
            touchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - pointerOld;
            pointerOld = Input.mousePosition;
        }

        Calculate();
        RotateCameraAndPlayer();
    }

    private void Calculate()
    {
        XMove = touchDist.x * SensivityX * Time.deltaTime;
        YMove = touchDist.y * SensivityY * Time.deltaTime;

        XRotation -= YMove;
        XRotation = Mathf.Clamp(XRotation, -30f, 50f);
    }

    private void RotateCameraAndPlayer()
    {
        transformCamera.localRotation = Quaternion.Euler(XRotation, 0, 0);
        transformPlayer.Rotate(Vector3.up * XMove);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        pointerId = eventData.pointerId;
        pointerOld = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}
