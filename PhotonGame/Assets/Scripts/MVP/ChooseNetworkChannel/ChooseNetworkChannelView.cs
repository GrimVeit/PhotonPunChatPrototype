using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseNetworkChannelView : View
{
    public event Action<string> OnChooseChannel;

    [SerializeField] private TMP_InputField channelInputField;
    [SerializeField] private Button channelSubmit;

    public void Initialize()
    {
        //channelSubmit.onClick.AddListener(HandlerClickToSubmitChannel);
    }

    public void Dispose()
    {
        //channelSubmit.onClick.RemoveListener(HandlerClickToSubmitChannel);
    }

    #region Input

    private void HandlerClickToSubmitChannel()
    {
        string channel = channelInputField.text;

        OnChooseChannel?.Invoke(channel);
    }

    #endregion
}
