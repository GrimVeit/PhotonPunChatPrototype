using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCameraPresenter
{
    private readonly CharacterCameraModel _model;

    public CharacterCameraPresenter(CharacterCameraModel model)
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

    public void SetCharacter(ICharacterCameraProvider characterCameraProvider)
    {
        _model.SetCharacter(characterCameraProvider);
    }

    public void ActivateCamera()
    {
        _model.ActivateCamera();
    }

    public void DeactivateCamera()
    {
        _model.DeactivateCamera();
    }

    #endregion
}
