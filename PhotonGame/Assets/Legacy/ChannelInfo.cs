using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChannelInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textNameChannel;
    [SerializeField] private TextMeshProUGUI textPlayersCount;

    public void SetData(string nameChannel, string currentPlayersCount, string maxPlayersCount)
    {
        textNameChannel.text = nameChannel;
        textPlayersCount.text = currentPlayersCount + "/" + maxPlayersCount;
    }
}
