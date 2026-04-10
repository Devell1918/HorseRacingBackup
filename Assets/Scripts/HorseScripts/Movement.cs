using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("References (Fetched in Code")]
    [SerializeField] AudioSource audioSource;

    [Header("References")]
    [SerializeField] private PositionsSO positionSO;
    [SerializeField] private GameStatsSO gameStatsSO;
    [SerializeField] private GameManager gameManager;

    [Header("Variables")]
    [SerializeField] private string nameOfHorse;


    public PositionsSO PositionsSO { get { return positionSO; } set { positionSO = value; } }
    public string NameOfHorse{ get { return nameOfHorse; } set { nameOfHorse = value; } }

    [SerializeField] float moveSpeed = 1;
    int position = 0;

    public bool scratched = false;                  //set some properties
    private bool isMoving = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        InitializePosition();
    }



    public void InitializePosition()
    {
        transform.position = positionSO.startPosition;
    }
    public IEnumerator MoveForwardCoroutine()
    {
        isMoving = true;

        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, positionSO.avaliblePositions[position].z);
        Vector3 startPosition = transform.position;

        audioSource.Play();

        while (transform.position.z < targetPosition.z) 
        {
            transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
        audioSource.Stop();

        gameManager.TimeToChange();
        isMoving = false;
        position ++;

    }

    public void CommandHorseForward()
    {
        if ( (position < positionSO.maxPositions & !isMoving) & !scratched)
        {
            StartCoroutine(MoveForwardCoroutine());
            
        }
        else if (scratched)
        {
            gameManager.messages.SetMessage("That Horse is Scratched, Command Denied");
            Debug.Log("That Horse is Scratched, Command Denied");
            gameManager.TimeToChange();
        }
        else if (isMoving)
        {
            Debug.Log("That Horse is Moving, Command Denied");
        }
        else if (position >= positionSO.maxPositions)
        {
            Debug.Log("That Horse has Finished!");
        }

    }




}
