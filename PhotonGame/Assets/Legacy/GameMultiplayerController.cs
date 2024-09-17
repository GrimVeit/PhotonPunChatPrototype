using Lessons.Architecture;
using UnityEngine;
using UnityEngine.Events;

public class GameMultiplayerController : MonoBehaviour
{
    public UnityEvent OnChangeRoom;
    public UnityEvent OnPlayGame;
    public UnityEvent OnExitGame;

    private CharacterInteractor characterInteractor;
    private ChatPhotonInteractor chatInteractor;

    public void Initialize()
    {
        characterInteractor = Game.GetInteractor<CharacterInteractor>();
        chatInteractor = Game.GetInteractor<ChatPhotonInteractor>();
        Debug.Log(chatInteractor.ID_Current);

        chatInteractor.Subscribe();
    }

    public void PlayGame()
    {
        OnPlayGame?.Invoke();
        characterInteractor.SpawnMultiplayerCharacter();
        chatInteractor.SendPublishMessageOnJoinRoom("Некто");
        chatInteractor.ActivateChat();
    }

    public void ExitGame()
    {
        OnExitGame?.Invoke();
        characterInteractor.DestroyMultiplayerCharacter();
        chatInteractor.SendPublishMessageOnExitRoom("Некто");
        chatInteractor.DiactivateChat();
    }

    private void Update()
    {
        if (chatInteractor != null)
        {
            chatInteractor.Service();
        }
    }

    private void OnDestroy()
    {
        chatInteractor.Unsubscribe();
    }
}
