using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [Header("References (Fetched in Code")]
    GameManager gameManager;
    GameStateManager gameStateManager;


    [Header("References")]

    [SerializeField] GameStatsSO gameStatsSO;

    private bool controlsEnabled = true;
    public bool dropped = false;

    public bool ControlsEnabled { get { return controlsEnabled; } private set { controlsEnabled = value; } }

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        gameStateManager = FindAnyObjectByType<GameStateManager>();
    }

    private void OnContinue(InputValue inputValue)
    {
        if(!controlsEnabled) { return; }            //don't let this happen again

        gameStateManager.UpdatePlayerInputed();


        Debug.Log("You took a turn");
    }

    private void OnReset(InputValue inputValue) //debugging
    {
        if(!controlsEnabled) { return; }
        gameManager.ResetDie();

        Debug.Log("Reset Pressed");
    }

    private void OnExit(InputValue inputValue)
    {
        Application.Quit();
        Debug.Log("Pressed Exit");
    }

    public void EnableControls()
    {
        ControlsEnabled = true;
    }

    public void DisableControls()
    {
        ControlsEnabled = false;
    }

}
