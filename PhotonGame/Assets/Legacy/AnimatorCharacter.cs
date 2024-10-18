using UnityEngine;

public class AnimatorCharacter : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private const string blend = "Blend";

    public void PlayAnimation(float blendValue)
    {
        animator.SetFloat(blend, blendValue);
    }
}
