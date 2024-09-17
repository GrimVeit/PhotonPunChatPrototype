using Lessons.Architecture;
using UnityEngine;

public abstract class PhotonConnect : MonoBehaviour
{
    protected PhotonInteractor photonInteractor;
    protected ChatPhotonInteractor chatPhotonInteractor;

    public virtual void Initialize()
    {
        photonInteractor = Game.GetInteractor<PhotonInteractor>();
        chatPhotonInteractor = Game.GetInteractor<ChatPhotonInteractor>();
    }
}
