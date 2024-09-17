using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatView : MonoBehaviour
{
    public event Action<string> OnSubmitMessage;

    [SerializeField] private PrefabMessage prefabMessage;
    [SerializeField] private Transform content;
    [SerializeField] private TMP_InputField inputMessage;
    [SerializeField] private Button submitMessageButton;

    public void Initialize()
    {
        submitMessageButton.onClick.AddListener(HandlerClickToSubmitMessageButton);
    }

    public void Dispose()
    {
        submitMessageButton.onClick.RemoveListener(HandlerClickToSubmitMessageButton);
    }

    public void GetMessage(object[] messages)
    {
        for (int i = 0; i < messages.Length; i++)
        {
            PrefabMessage prefabObj = Instantiate(prefabMessage, content);
            prefabObj.SetData(messages[i].ToString());
        }
    }

    #region Input

    private void HandlerClickToSubmitMessageButton()
    {
        string message = inputMessage.text;
        OnSubmitMessage?.Invoke(message);

    }

    #endregion
}
