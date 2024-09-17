using UnityEngine;

public class ChatPanel : Panel
{
    [SerializeField] private Chat chat;

    public override void Initialize()
    {
        base.Initialize();
        chat.Initialize();
    }
}
