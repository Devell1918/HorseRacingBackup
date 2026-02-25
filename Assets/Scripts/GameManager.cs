using UnityEngine;
using System.Security.Cryptography;
using NUnit.Framework;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject horsePrefab;

    [SerializeField] public List<PositionsSO> horsePositions = new List<PositionsSO>();
    [SerializeField] public List<GameObject> horses = new List<GameObject>();

    private void Start()
    {
        SpawnHorses();
        InvokeRepeating("RollDice", 1f, 1f);
    }
    public void SpawnHorses()
    {
        for(int i = 0; i <= 10 ; i++)
        {
            GameObject newHorse = Instantiate(horsePrefab);
            
            horses.Add(newHorse);

            Movement newMovement = newHorse.GetComponent<Movement>();
            newMovement.PositionsSO = horsePositions[i];

            //name horse
            int horseNumber = i + 2;
            newMovement.NameOFHorse = horseNumber.ToString();


        }
    }

    public void RollDice() 
    {
        int die1 = RandomNumberGenerator.GetInt32(1, 7);
        int die2 = RandomNumberGenerator.GetInt32(1, 7);

        int horseRolledIndex = (die1 + die2) - 2;  //-2 is to account for their being no player 1 and starting at 0

        Movement newMovement = horses[horseRolledIndex].GetComponent<Movement>();
        newMovement.moveForwardBool = true;

        Debug.Log(horseRolledIndex);
        Debug.Log(newMovement.NameOFHorse);
    }
}
