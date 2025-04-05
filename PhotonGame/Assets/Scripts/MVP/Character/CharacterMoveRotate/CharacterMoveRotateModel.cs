using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterMoveRotateModel
{
    private ICharacterMoveRotateProvider _characterMoveRotateProvider;

    public void SetCharacter(ICharacterMoveRotateProvider characterMoveRotateProvider)
    {
        _characterMoveRotateProvider = characterMoveRotateProvider;
    }

    public void Move(Vector2 vector)
    {
        if(_characterMoveRotateProvider == null) return;

        _characterMoveRotateProvider.Move(vector);
    }

    public void Rotate(Vector2 vector)
    {
        if( _characterMoveRotateProvider == null) return;

        _characterMoveRotateProvider.Rotate(vector);
    }

}
