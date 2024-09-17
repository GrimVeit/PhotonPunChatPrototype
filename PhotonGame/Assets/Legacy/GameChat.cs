using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameChat : MonoBehaviour, IGameChat
{
    [SerializeField] private TMP_InputField inputMessage;
    [SerializeField] private Button buttonSendMessage;

    public void ActivateChat()
    {
        inputMessage.gameObject.SetActive(true);
        buttonSendMessage.gameObject.SetActive(true);
    }

    public void DiactivateChat()
    {
        inputMessage.gameObject.SetActive(false);
        buttonSendMessage.gameObject.SetActive(false);
    }

    public void CloseChat()
    {
        gameObject.SetActive(false);
    }

    public void OpenChat()
    {
        gameObject.SetActive(true);
    }
}
