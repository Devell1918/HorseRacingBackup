using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [Header("References (Fetched in Code")]
    GameManager gameManager;


    [Header("References")]
    [SerializeField] private Rigidbody die1rb;
    [SerializeField] private Rigidbody die2rb;
    [SerializeField] GameStatsSO gameStatsSO;

    public bool controlsEnabled = true;
    public bool dropped = false;


    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void OnContinue(InputValue inputValue)
    {
        if(!controlsEnabled) { return; }            //don't let this happen again
        DropDie();
        Debug.Log("You took a turn");
    }

    private void OnReset(InputValue inputValue) //debugging
    {
        if(!controlsEnabled) { return; }
        gameManager.ResetDie();

        Debug.Log("Reset Pressed");
    }

    private void DropDie()
    {
        die1rb.useGravity = true;
        die2rb.useGravity = true;
    }
}
