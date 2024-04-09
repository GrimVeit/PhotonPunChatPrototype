using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterSpawner
{
    public void SetPlayer(int value);
    public void SpawnLocalCharacter();
    public void SpawnMultiplayerCharacter();
    public void DestroyLocalCharacter();
    public void DestroyMultiplayerCharacter();
}
