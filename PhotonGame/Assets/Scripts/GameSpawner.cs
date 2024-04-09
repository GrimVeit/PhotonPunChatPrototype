using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawner : MonoBehaviour, IRoomSpawner, ICharacterSpawner
{
    [SerializeField]
    private Room RoomNow;
    public CharacterFPS Character { get; private set; }

    [Header("Room data")]
    [SerializeField] private Transform posSpawn;
    [SerializeField] private List<Room> rooms;

    [Header("Character data")]
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private FixedTouchField fixedTouchField;
    [SerializeField] private List<CharacterFPS> characters;

    private int playerID = 0;

    public void SetPlayer(int playerID)
    {
        this.playerID = playerID;
    }

    public void RandomRoomSpawner()
    {
        if (RoomNow != null)
        {
            Destroy(RoomNow.gameObject);
        }
        int randomIndex = Random.Range(0, rooms.Count);
        RoomNow = Instantiate(rooms[randomIndex], posSpawn.position, rooms[randomIndex].transform.rotation);
    }

    public void SpawnLocalCharacter()
    {
        Character = Instantiate(characters[playerID], RoomNow.TransformsSpawn[Random.Range(0, RoomNow.TransformsSpawn.Count)].position, characters[playerID].transform.rotation);

        playerMove.SetData(Character.AnimateCharacter, Character.CharacterController);
        fixedTouchField.SetData(Character.TransformPlayer, Character.TransformCamera);
    }

    public void DestroyLocalCharacter()
    {
        if (Character != null)
            Destroy(Character.gameObject);
    }

    public void SpawnMultiplayerCharacter()
    {
        GameObject characterObject = PhotonNetwork.Instantiate(characters[0].name, RoomNow.TransformsSpawn[Random.Range(0, RoomNow.TransformsSpawn.Count)].position, characters[playerID].transform.rotation);
        Character = characterObject.GetComponent<CharacterFPS>();

        playerMove.SetData(Character.AnimateCharacter, Character.CharacterController);
        fixedTouchField.SetData(Character.TransformPlayer, Character.TransformCamera);
    }

    public void DestroyMultiplayerCharacter()
    {
        if (Character != null)
            PhotonNetwork.Destroy(Character.gameObject);
    }
}
