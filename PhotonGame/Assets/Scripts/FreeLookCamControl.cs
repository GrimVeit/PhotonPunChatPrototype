using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FreeLookCamControl : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    [Range(0, 5)] private float sensative;
    [SerializeField] private CinemachineFreeLook freeLook;
    string strMouseX = "Mouse X", strMouseY = "Mouse Y";
    Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(image.rectTransform, eventData.position, eventData.enterEventCamera, out _))
        {
            freeLook.m_XAxis.m_InputAxisName = strMouseX;
            freeLook.m_YAxis.m_InputAxisName = strMouseY;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        freeLook.m_XAxis.m_InputAxisName = null;
        freeLook.m_YAxis.m_InputAxisName = null;

        freeLook.m_XAxis.m_InputAxisValue = 0;
        freeLook.m_YAxis.m_InputAxisValue = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
}
