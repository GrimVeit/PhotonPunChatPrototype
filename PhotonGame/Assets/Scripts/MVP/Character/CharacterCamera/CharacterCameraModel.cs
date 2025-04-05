using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCameraModel
{
    private ICharacterCameraProvider _characterCameraProvider;

    public void SetCharacter(ICharacterCameraProvider characterCameraProvider)
    {
        _characterCameraProvider = characterCameraProvider;
    }

    public void ActivateCamera()
    {
        if(_characterCameraProvider == null) return;

        _characterCameraProvider.ActivateCharacterCamera();
    }

    public void DeactivateCamera()
    {
        if (_characterCameraProvider == null) return;

        _characterCameraProvider.DeactivateCharacterCamera();
    }
}
