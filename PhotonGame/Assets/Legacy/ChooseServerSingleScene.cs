using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseServerSingleScene : ChooseServer
{
    public override void SetRegion(string region)
    {
        OnChangeRegion?.Invoke();
        PlayerPrefs.SetString("RegionName", region);
        SceneManager.LoadScene(1);
    }
}
