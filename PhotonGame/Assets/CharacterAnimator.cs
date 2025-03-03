using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private const string blend = "Blend";

    public void PlayAnimation(float blendValue)
    {
        animator.SetFloat(blend, blendValue);
    }
}
