using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chat : MonoBehaviour
{
    [SerializeField] private PrefabMessage prefabMessage;
    [SerializeField] private Transform content;
    [SerializeField] private TMP_InputField inputMessage;

    private ChatPhotonInteractor chatPhotonInteractor;

    public void Initialize()
    {
        chatPhotonInteractor = Game.GetInteractor<ChatPhotonInteractor>();
        chatPhotonInteractor.Events.OnGetMessageEvent += OnGetMessageAction;
        Debug.Log(chatPhotonInteractor.ID_Current);
    }

    public void SendMessageChat()
    {
        chatPhotonInteractor.SendPublishMessage(inputMessage.text);
    }

    private void OnGetMessageAction(string channelName, object[] messages)
    {
        //Debug.Log("отпкаьлоплщопппаопапоаопапаопалпрорпошщпаоаооплтпотопащтазптои");
        for (int i = 0; i < messages.Length; i++)
        {
            PrefabMessage prefabObj = Instantiate(prefabMessage, content);
            prefabObj.SetData(messages[i].ToString());
        }
    }

    private void OnDestroy()
    {
        chatPhotonInteractor.Events.OnGetMessageEvent -= OnGetMessageAction;
    }
}
