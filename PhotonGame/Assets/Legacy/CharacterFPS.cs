using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFPS : MonoBehaviour, ICharacter
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private AnimatorCharacter animateCharacter;
    [SerializeField] private Transform transformPlayer;
    [SerializeField] private Camera camera_m;

    public Transform TransformPlayer => transformPlayer;
    public Transform TransformCamera => camera_m.transform;
    public AnimatorCharacter AnimateCharacter => animateCharacter;
    public CharacterController CharacterController => characterController;
}

interface ICharacter
{
    Transform TransformPlayer { get; }
    Transform TransformCamera { get; }
    AnimatorCharacter AnimateCharacter { get; }
    CharacterController CharacterController { get; }
}
