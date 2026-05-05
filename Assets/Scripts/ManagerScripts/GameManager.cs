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
    [SerializeField] GameStateManager gameStateManager;
    [SerializeField] GameObject horsePrefab;
    [SerializeField] Transform horsesTransform;
    [SerializeField] GameStatsSO gameStatsSO;
    [SerializeField] Transform die1Transform;
    [SerializeField] Transform die2Transform;
    [SerializeField] private Rigidbody die1rb;
    [SerializeField] private Rigidbody die2rb;
    [SerializeField] public Messages messages;
    //put in numberr reader[SerializeField] private 
    private Die die1Script;
    private Die die2Script;



    [Header("Lists")]
    [SerializeField] public List<PositionsSO> horsePositions = new List<PositionsSO>();
    [SerializeField] public List<GameObject> horses = new List<GameObject>();
    [SerializeField] private List<GameObject> validHorses = new List<GameObject>();
    [SerializeField] public List<GameObject> scratchedHorses = new List<GameObject>();

    [Header("Variables")]
    [SerializeField] private int currentDie1Number;
    [SerializeField] private int currentDie2Number;

    private int horsesScratched = 0;
    public int DieAdded { get; private set; }

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    private void Start()
    {
        //grab reference
        gameStateManager = FindAnyObjectByType<GameStateManager>();
        die1Script = die1Transform.GetComponent<Die>();
        die2Script = die2Transform.GetComponent<Die>();


        SpawnHorses();
        //StartCoroutine(ScratchCoroutine());

        validHorses = new List<GameObject>(horses);



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

    private void ScratchHorse()  //move to scratch?
    {

        horsesScratched ++;

        if (horsesScratched > 4 ) { Debug.Log("All Horses Scratched"); return; }

        int scratchedHorseIndex = -1;


        int die1 = currentDie1Number;
        int die2 = currentDie2Number;

        scratchedHorseIndex = (die1 + die2) - 2;

        if (scratchedHorses.Contains(horses[scratchedHorseIndex]))
        {
            Debug.Log("That Horse has already been scratched");
            messages.SetMessage("Horse " + (scratchedHorseIndex + 2) + " has already been scratched");
            playerInput.EnableControls();
            // subtract horsesScratched
            horsesScratched --;
            return;
        }


        

        Scratch scratchOfHorse = horses[scratchedHorseIndex].GetComponent<Scratch>();
        Movement movementOfScratchedHorse = horses[scratchedHorseIndex].GetComponent<Movement>();
        movementOfScratchedHorse.scratched = true;
        scratchOfHorse.ScratchHorse(horsesScratched); //this scratchHorse is of the Scratch Script
        scratchedHorses.Add(horses[scratchedHorseIndex]);
        validHorses.Remove(horses[scratchedHorseIndex]);


        if (horsesScratched == 1)             //updates text
        {
            messages.SetMessage("Horse " + (scratchedHorseIndex + 2) + " Is The First Horse Scratched");
        }
        else if (horsesScratched == 2) 
        {
            messages.SetMessage("Horse " + (scratchedHorseIndex + 2) + " Is The Second Horse Scratched");
        }
        else if (horsesScratched == 3)
        {
            messages.SetMessage("Horse " + (scratchedHorseIndex + 2) + " Is The Third Horse Scratched");
        }
        else if (horsesScratched == 4)
        {
            messages.SetMessage("Horse " + (scratchedHorseIndex + 2) + " Is The Fourth Horse Scratched");
            gameStateManager.AllHorsesScratched();
        }

    }

    public void StartScratch()
    {
        StartCoroutine(ScratchCoroutine());
    }


    private IEnumerator ScratchCoroutine() //rename or delete later
    {
        yield return new WaitForSeconds(1.8f);

        ScratchHorse();
        


        playerInput.EnableControls();
    }

    public void MoveAHorse(int dieAdded)
    {
        int horseToMoveIndex = dieAdded - 2;

        Movement newMovement = horses[horseToMoveIndex].GetComponent<Movement>();
        newMovement.CommandHorseForward();
    }



    public void UpdateCurrentDieNumber(int number)
    {
        Debug.Log("you rolled a " + number); 
        if (currentDie1Number == 0) { currentDie1Number = number; }
        else if (currentDie1Number != 0) { currentDie2Number = number; }

        DieAdded = currentDie1Number + currentDie2Number;
    }

    public void ResetDie()
    {
        if (die1Script == null || die2Script == null) { return; }
        //Reset Numbers
        currentDie1Number = 0;
        currentDie2Number = 0;
        die1Script.ResetLandedOn();
        die2Script.ResetLandedOn();


        //initial position
        die1Script.IsStopped = false;
        die2Script.IsStopped = false;
        die1rb.useGravity = false;
        die2rb.useGravity = false;
        die1rb.GetComponent<Spin>().enabled = true;
        die2rb.GetComponent<Spin>().enabled = true;
        die1Transform.position = gameStatsSO.die1SpawnPos;
        die2Transform.position = gameStatsSO.die2SpawnPos;

        //rotate so they aren't the same

        die1Transform.Rotate(Vector3.forward);
        die2Transform.Rotate(Vector3.up);
    }

    public void DropDie()
    {
        die1rb.useGravity = true;
        die2rb.useGravity = true;

        die1rb.GetComponent<Spin>().enabled = false;
        die2rb.GetComponent<Spin>().enabled = false;
    }

    public void ScratchedHorseAlert()
    {
        gameStateManager.ScratchedHorseAlert();
    }

    public void HorseStoppedMovingAlert()
    {
        gameStateManager.HorseStoppedMovingAlert();
    }

    public void TriggerVictory()
    {
        gameStateManager.TriggerVictory();
    }
}
