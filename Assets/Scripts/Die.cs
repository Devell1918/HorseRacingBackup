using UnityEngine;

public class Die : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameManager gameManager;

    public int landedOn = 0;


    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    public void UpdateDie(int number)
    {
        landedOn = number;
        gameManager.UpdateCurrentDieNumber(number);
    }

}
