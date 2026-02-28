using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("References (Fetched in Code)")]
    [SerializeField] PlayerInput playerInput;

    [Header("References")]
    [SerializeField] GameObject horsePrefab;
    [SerializeField] Transform horsesTransform;

    [Header("Lists")]
    [SerializeField] public List<PositionsSO> horsePositions = new List<PositionsSO>();
    [SerializeField] public List<GameObject> horses = new List<GameObject>();
    [SerializeField] private List<GameObject> validHorses = new List<GameObject>();
    [SerializeField] public List<GameObject> scratchedHorses = new List<GameObject>();

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    private void Start()
    {
        SpawnHorses();
        StartCoroutine(ScratchCoroutine());

        validHorses = new List<GameObject>(horses);

        //InvokeRepeating("RollDice", 1f, 1f);

    }
    private void SpawnHorses()
    {
        for(int i = 0; i <= 10 ; i++)
        {
            GameObject newHorse = Instantiate(horsePrefab, horsesTransform);
            
            horses.Add(newHorse);
            validHorses.Add(newHorse);

            Movement newMovement = newHorse.GetComponent<Movement>();
            newMovement.PositionsSO = horsePositions[i];

            //name horse
            int horseNumber = i + 2;
            newMovement.NameOfHorse = horseNumber.ToString();
            newHorse.name = "Horse " + horseNumber.ToString();


        }
    }

    private void ScratchHorse(int scratchNumber)  //move to scratch?
    {
        bool isValid = false;
        int scratchedHorseIndex = -1;

        while (!isValid)
        {
            int die1 = RollDice();
            int die2 = RollDice();                                      //change this out with my dice roll

            scratchedHorseIndex = (die1 + die2) - 2;

            if (!scratchedHorses.Contains(horses[scratchedHorseIndex]))
            {
                isValid = true;
            }
            else
            {
                Debug.Log("That Horse has already been scratched");
            }

        }

        Scratch scratchOfHorse = horses[scratchedHorseIndex].GetComponent<Scratch>();
        Movement movementOfScratchedHorse = horses[scratchedHorseIndex].GetComponent<Movement>();
        movementOfScratchedHorse.scratched = true;
        scratchOfHorse.ScratchHorse(scratchNumber); //this scratchHorse is of the Scratch Script
        scratchedHorses.Add(horses[scratchedHorseIndex]);
        validHorses.Remove(horses[scratchedHorseIndex]);

    }

    public int RollDice() //delete later
    {
        int die = RandomNumberGenerator.GetInt32(1, 7);

        return die;


    }

    private IEnumerator ScratchCoroutine() //rename or delete later
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

        playerInput.controlsEnabled = true;
    }

    public void MoveAHorse(int dieAdded)
    {


        int horseToMoveIndex = dieAdded - 2;

        Movement newMovement = horses[horseToMoveIndex].GetComponent<Movement>();
        newMovement.CommandHorseForward();
    }


}
