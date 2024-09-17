using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhotonChatView : MonoBehaviour
{
    public Action<string> OnSubmitMessage;

    [SerializeField] private ChatView chatView;


    public void Initialize()
    {
        chatView.OnSubmitMessage += HandlerClickToSubmitMessageButton;
    }

    public void Dispose()
    {
        chatView.OnSubmitMessage -= HandlerClickToSubmitMessageButton;
    }

    public void GetMessage(object[] messages)
    {
        chatView.GetMessage(messages);
    }

    #region Input

    private void HandlerClickToSubmitMessageButton(string message)
    {
        OnSubmitMessage?.Invoke(message);
    }

    #endregion
}
