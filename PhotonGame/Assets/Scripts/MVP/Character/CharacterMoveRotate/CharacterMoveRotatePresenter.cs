using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveRotatePresenter
{
    private readonly CharacterMoveRotateModel _model;

    public CharacterMoveRotatePresenter(CharacterMoveRotateModel model)
    {
        _model = model;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    #region Input

    public void SetCharacter(ICharacterMoveRotateProvider characterMoveRotateProvider)
    {
        _model.SetCharacter(characterMoveRotateProvider);
    }

    public void Move(Vector2 vector)
    {
        _model.Move(vector);
    }

    public void Rotate(Vector2 vector)
    {
        _model.Rotate(vector);
    }

    #endregion
}
