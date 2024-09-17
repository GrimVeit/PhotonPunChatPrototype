using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Chat;
using Lessons.Architecture;

public class PhotonChatConnect : MonoBehaviour
{
    private ChatPhotonInteractor chatInteractor;

    public void Initialize()
    {
        //chatInteractor = Game.GetInteractor<ChatPhotonInteractor>();
        //chatInteractor.Connect();
    }
}
