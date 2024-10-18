using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPresenter
{
    private CharacterModel characterModel;
    private CharacterView characterView;

    public CharacterPresenter(CharacterModel characterModel, CharacterView characterView)
    {
        this.characterModel = characterModel;
        this.characterView = characterView;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        characterView.OnMove += characterModel.Move;

        characterModel.OnMove += characterView.Move;
    }

    private void DeactivateEvents()
    {
        characterView.OnMove -= characterModel.Move;

        characterModel.OnMove -= characterView.Move;
    }

    #region Input

    public void SetCharacter(Character character)
    {
        characterView.SetCharacter(character);
    }

    #endregion
}
