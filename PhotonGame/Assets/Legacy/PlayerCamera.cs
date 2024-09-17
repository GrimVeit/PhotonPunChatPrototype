using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCamera : MonoBehaviourPunCallbacks
{
    [SerializeField] private Camera cameraPlayer;

    private void Awake()
    {
        if (!photonView.IsMine)
        {
            ActivateCamera(false);
        }
    }

    public void ActivateCamera(bool activate)
    {
        cameraPlayer.gameObject.SetActive(activate);
    }
}
