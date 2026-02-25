using UnityEngine;
using System.Security.Cryptography;
using NUnit.Framework;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject horsePrefab;

    [SerializeField] public List<PositionsSO> horsePositions = new List<PositionsSO>();

    private void Start()
    {
        RollDice();
        SpawnHorses();
    }
    public void SpawnHorses()
    {
        for(int i = 0; i <= 10 ; i++)
        {
            GameObject newHorse = Instantiate(horsePrefab);
            Movement newMovement = newHorse.GetComponent<Movement>();
            newMovement.PositionsSO = horsePositions[i];


        }
    }

    public void RollDice() 
    {
        int die1 = RandomNumberGenerator.GetInt32(1, 6);
        int die2 = RandomNumberGenerator.GetInt32(1, 6);

        Debug.Log(die1 + die2);
    }
}
