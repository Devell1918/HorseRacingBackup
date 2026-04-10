using UnityEngine;

[CreateAssetMenu(fileName = "GameStatsSO", menuName = "Scriptable Objects/GameStatsSO")]
public class GameStatsSO : ScriptableObject
{
    [Header("References")]



    [SerializeField] public Vector3 die1SpawnPos = new Vector3(0, 2, 9f);
    [SerializeField] public Vector3 die2SpawnPos = new Vector3(0, 6, 9);



}
