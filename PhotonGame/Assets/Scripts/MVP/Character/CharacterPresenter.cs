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

        characterView.OnStartTouch += characterModel.ActivateRotate;
        characterView.OnEndTouch += characterModel.DeactivateRotate;

        characterModel.OnMove += characterView.Move;
        characterModel.OnRotate += characterView.Rotate;
    }

    private void DeactivateEvents()
    {
        characterView.OnStartMove -= characterModel.ActivateMove;
        characterView.OnMove -= characterModel.SetDirection;
        characterView.OnEndMove -= characterModel.DeactivateMove;

        characterView.OnStartTouch -= characterModel.ActivateRotate;
        characterView.OnEndTouch -= characterModel.DeactivateRotate;

        characterModel.OnMove -= characterView.Move;
        characterModel.OnRotate -= characterView.Rotate;
    }

    #region Input

    public void SetCharacter(Character character)
    {
        characterView.SetCharacter(character);
    }

    #endregion
}
