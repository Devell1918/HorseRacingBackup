using Unity.VisualScripting;
using UnityEngine;

public class Die : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameManager gameManager;

    private Rigidbody rb;

    private int landedOn = 0;

    public int LandedOn { get {return landedOn;} private set { landedOn = value; } }
    public bool IsStopped { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    public void UpdateDie(int number)
    {
        landedOn = number;
        gameManager.UpdateCurrentDieNumber(number);
    }



    public void ResetLandedOn()
    {
        landedOn = 0;
    }

}
