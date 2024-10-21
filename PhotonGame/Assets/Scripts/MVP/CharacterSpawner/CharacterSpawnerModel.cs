using Photon.Pun;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawnerModel
{
    public event Action<Character> OnSpawnCharacter;
    public event Action OnDestroyCharacter;

    public List<Character> characters = new List<Character>();
    public List<Transform> transforms = new List<Transform>();

    private Character currentCharacter;

    public CharacterSpawnerModel(List<Character> characters, List<Transform> transforms)
    {
        this.characters = characters;
        this.transforms = transforms;
    }

    public void SpawnMultiplayerCharacter()
    {
        int index = GetRandomCharacterIndex();
        GameObject characterObject = PhotonNetwork.Instantiate(characters[index].name, GetRandomTransform().position, characters[index].transform.rotation);
        currentCharacter = characterObject.GetComponent<Character>();
        OnSpawnCharacter?.Invoke(currentCharacter);
    }

    public void SpawnLocalCharacter()
    {
        int index = GetRandomCharacterIndex();
        Character character = UnityEngine.Object.Instantiate(characters[index], GetRandomTransform().position, characters[index].transform.rotation);
        currentCharacter = character;
        OnSpawnCharacter?.Invoke(currentCharacter);
    }

    public void DestroyLocalCharacter()
    {
        if (currentCharacter == null) return;

        UnityEngine.Object.Destroy(currentCharacter);
        OnDestroyCharacter?.Invoke();
    }

    public void DestroyMultiplayerCharacter()
    {
        if (currentCharacter == null) return;

        PhotonNetwork.Destroy(currentCharacter.gameObject);
    }

    private int GetRandomCharacterIndex()
    {
        int index = UnityEngine.Random.Range(0, characters.Count);
        return index;
    }

    private Transform GetRandomTransform()
    {
        int index = UnityEngine.Random.Range(0, transforms.Count);
        return transforms[index];
    }
}
