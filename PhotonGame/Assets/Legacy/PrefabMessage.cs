using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrefabMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void SetData(string message)
    {
        text.text = message;
    }
}
