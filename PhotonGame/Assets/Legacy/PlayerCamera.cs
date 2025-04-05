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
        if (!photonView.IsMine)
        {
            cameraPlayer.gameObject.SetActive(activate);
        }
        else
        {
            cameraPlayer.gameObject.SetActive(activate);
        }
    }
}
