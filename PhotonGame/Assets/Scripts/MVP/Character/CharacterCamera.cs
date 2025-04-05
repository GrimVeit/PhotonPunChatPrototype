using Photon.Pun;
using UnityEngine;

public class CharacterCamera : MonoBehaviourPunCallbacks
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
