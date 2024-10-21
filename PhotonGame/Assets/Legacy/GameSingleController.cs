using Lessons.Architecture;
using UnityEngine;
using UnityEngine.Events;

public class GameSingleController : MonoBehaviour
{
    public UnityEvent OnChangeRoom;
    public UnityEvent OnPlayGame;
    public UnityEvent OnExitGame;

    private RoomInteractor roomInteractor;
    private PhotonInteractor photonInteractor;
    private CharacterInteractor characterInteractor;
    public void Initialize()
    {
        roomInteractor = Game.GetInteractor<RoomInteractor>();
        characterInteractor = Game.GetInteractor<CharacterInteractor>();

        roomInteractor.SpawnRandomRoom();
    }

    public void PlayGame()
    {
        OnPlayGame?.Invoke();
        characterInteractor.SpawnLocalCharacter();
    }

    public void ExitGame()
    {
        OnExitGame?.Invoke();
        characterInteractor.DestroyLocalCharacter();
    }

    private void ChangeLocalRoom()
    {
        OnChangeRoom?.Invoke();
    }

    public void ChooseRandomChannel()
    {
        if (!photonInteractor.IsConnected)
        {
            ChangeLocalRoom();
            return;
        }
    }
}
