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

        characterView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        characterView.Dispose();
    }

    private void ActivateEvents()
    {
        characterView.OnStartMove += characterModel.ActivateMove;
        characterView.OnMove += characterModel.SetDirection;
        characterView.OnEndMove += characterModel.DeactivateMove;

        characterModel.OnMove += characterView.Move;
    }

    private void DeactivateEvents()
    {
        characterView.OnStartMove -= characterModel.ActivateMove;
        characterView.OnMove -= characterModel.SetDirection;
        characterView.OnEndMove -= characterModel.DeactivateMove;

        characterModel.OnMove -= characterView.Move;
    }

    #region Input

    public void SetCharacter(Character character)
    {
        characterView.SetCharacter(character);
    }

    #endregion
}
