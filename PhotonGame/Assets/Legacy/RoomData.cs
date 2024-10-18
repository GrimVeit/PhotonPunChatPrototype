using Photon.Pun;
using TMPro;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDataRoom;
    [SerializeField] private TextMeshProUGUI textCountPlayers;

    private string gameVersion;
    private string gameServerRegion;
    private string maxCountPlayers;
    private string currentCountPlayers;
    private string roomName;

    public void Initialize()
    {
        gameVersion = Application.version;
        gameServerRegion = PhotonNetwork.CloudRegion;
        maxCountPlayers = PhotonNetwork.CurrentRoom.MaxPlayers.ToString();
        currentCountPlayers = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
        roomName = PhotonNetwork.CurrentRoom.Name;
    }

    private void Update()
    {
        if (PhotonNetwork.InRoom) 
        {
            textDataRoom.text = $"{gameVersion} ver., {gameServerRegion} server, [{roomName}] channel, {PhotonNetwork.GetPing()} ping";
        }
    }
}
