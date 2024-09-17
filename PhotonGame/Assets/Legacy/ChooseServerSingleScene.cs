using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Lessons.Architecture;

public class ChooseServerSingleScene : ChooseServer
{
    public override void SetRegion(string region)
    {
        OnChangeRegion?.Invoke();
        PlayerPrefs.SetString("RegionName", region);
        SceneManager.LoadScene(1);
    }
}
