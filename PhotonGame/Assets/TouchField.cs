using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        OnStartTouch?.Invoke(eventData.pointerId, eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnEndTouch?.Invoke();
    }

    public event Action<int, Vector3> OnStartTouch;
    public event Action OnEndTouch;
}
