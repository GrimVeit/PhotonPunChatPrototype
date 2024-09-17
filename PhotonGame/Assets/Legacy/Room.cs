using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour, IPositions
{
    [SerializeField] private List<Transform> transforms = new();

    public List<Transform> TransformsSpawn => transforms;
}

interface IPositions
{
    public List<Transform> TransformsSpawn { get; }
}
