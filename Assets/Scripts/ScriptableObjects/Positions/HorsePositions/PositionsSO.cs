using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PositionsSO", menuName = "Scriptable Objects/PositionsSO")]
public class PositionsSO : ScriptableObject
{
    private string nameOfHorse;
    [SerializeField] public int maxPositions;

    [SerializeField] public Vector3 startPosition;

    [SerializeField] public List<Vector3> avaliblePositions = new List<Vector3>();
}
