using UnityEngine;
using System.Security.Cryptography;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject horsePrefab;

    [SerializeField] public List<PositionsSO> horsePositions = new List<PositionsSO>();
    [SerializeField] public List<GameObject> horses = new List<GameObject>();
    [SerializeField] public List<GameObject> validHorses = new List<GameObject>();
    [SerializeField] public List<GameObject> scratchedHorses = new List<GameObject>();

    private void Start()
    {
        SpawnHorses();
        StartCoroutine(ScratchCoroutine());

        //InvokeRepeating("RollDice", 1f, 1f);
    }
    private void SpawnHorses()
    {
        for(int i = 0; i <= 10 ; i++)
        {
            GameObject newHorse = Instantiate(horsePrefab);
            
            horses.Add(newHorse);
            validHorses.Add(newHorse);

            Movement newMovement = newHorse.GetComponent<Movement>();
            newMovement.PositionsSO = horsePositions[i];

            //name horse
            int horseNumber = i + 2;
            newMovement.NameOfHorse = horseNumber.ToString();


        }
    }

    private void ScratchHorse(int scratchNumber)
    {
        int die1 = RollDice();
        int die2 = RollDice();

        int scratchedHorseIndex = (die1 + die2) - 2;

        Scratch scratchOfHorse = horses[scratchedHorseIndex].GetComponent<Scratch>();
        Movement movementOfScratchedHorse = horses[scratchedHorseIndex].GetComponent<Movement>();
        movementOfScratchedHorse.scratched = true;
        scratchOfHorse.ScratchHorse(scratchNumber); //this scratchHorse is of the Scratch Script

    }

    public int RollDice() 
    {
        int die = RandomNumberGenerator.GetInt32(1, 7);

        return die;


    }

    private IEnumerator ScratchCoroutine()
    {
        yield return new WaitForSeconds(1);

        ScratchHorse(1);

        yield return new WaitForSeconds(1);

        ScratchHorse(2);

        yield return new WaitForSeconds(1);

        ScratchHorse(3);

        yield return new WaitForSeconds(1);

        ScratchHorse(4);

        yield return new WaitForSeconds(1);

        InvokeRepeating("MoveAHorse", 1, 1);
    }

    private void MoveAHorse()
    {
        int die1 = RollDice();
        int die2 = RollDice();

        int horseToMoveIndex = (die1 + die2) - 2;

        Movement newMovement = horses[horseToMoveIndex].GetComponent<Movement>();
        newMovement.moveForwardBool = true;
    }
}
