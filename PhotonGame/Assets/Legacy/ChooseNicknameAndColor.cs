using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseNicknameAndColor : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputFieldNickname;
    [SerializeField] private TextMeshProUGUI textNickname;
    [SerializeField] private Button ChangeNameButton;
    [SerializeField] private Button ChangeColorButton;

    private PlayerInteractor playerInteractor;

    public void Initialize()
    {
        playerInteractor = Game.GetInteractor<PlayerInteractor>();

        //Debug.Log(playerInteractor.PlayerName);
        //Debug.Log(playerInteractor.PlayerNameColor);

        textNickname.text = playerInteractor.PlayerName;
        textNickname.color = playerInteractor.PlayerNameColor;

        playerInteractor.onChangedNameColor += ChangingColorVisualise;
        playerInteractor.onChangedName += ChangingNicknameVisualise;

        ChangeNameButton.onClick.AddListener(ChangeName);
        ChangeColorButton.onClick.AddListener(ChangeColor);
    }

    private void OnDestroy()
    {
        playerInteractor.onChangedNameColor -= ChangingColorVisualise;
        playerInteractor.onChangedName -= ChangingNicknameVisualise;
    }

    private void ChangingColorVisualise(Color color)
    {
        textNickname.color = color;
    }

    private void ChangingNicknameVisualise(string name)
    {
        textNickname.text = name;
    }

    private void ChangeColor()
    {
        playerInteractor.SetColor(this, Random.ColorHSV());
    }

    private void ChangeName()
    {
        playerInteractor.SetName(this, inputFieldNickname.text);
    }
}
