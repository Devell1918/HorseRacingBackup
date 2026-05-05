using Unity.Cinemachine;
using UnityEngine;

public class RollingDieState : GameStateBase
{
    private float timer;
    private bool timerStarted;
    private float timeAllowedBeforeReset = 5f;
    private bool resetNeeded;
    public override void EnterState(GameStateManager gamestateManager)
    {
        timer = 0f;
        
        gamestateManager.dieRollCam.gameObject.SetActive(true);
        gamestateManager.ResetPlayerInputed();
        gamestateManager.playerInput.EnableControls();
        gamestateManager.messages.SetMessage("");
        Debug.Log("Entered Roll Die State");
        gamestateManager.gameManager.ResetDie();
        gamestateManager.dieStopped = false;
    }
    public override void UpdateState(GameStateManager gamestateManager)
    {
        
        if (timerStarted) { timer += Time.deltaTime; }


        if (gamestateManager.PlayerInputed)
        {
            if (resetNeeded) { Reset(gamestateManager); }
            else { 
                gamestateManager.gameManager.DropDie();
                gamestateManager.ResetPlayerInputed();
                gamestateManager.playerInput.DisableControls();
                StartTimer();
            }
        }

        //checks if dies has gotten stuck
        if (timer > timeAllowedBeforeReset)
        {
            AllowReset(gamestateManager);
        }

        if (gamestateManager.dieStopped)
        {
            ResetTimer();

            if (!gamestateManager.allHorsesScratched)
            {
                gamestateManager.SwitchState(gamestateManager.scratchHorseState);
            }
            else
            {
                gamestateManager.SwitchState(gamestateManager.movingHorseState);
            }

            
        }
    }

    private void AllowReset(GameStateManager gamestateManager)
    {
        gamestateManager.playerInput.EnableControls();
        gamestateManager.messages.SetMessage("Need A Reset? Press Space");
        resetNeeded = true;
    }
    private void Reset(GameStateManager gamestateManager) 
    {
        gamestateManager.messages.SetMessage("");
        gamestateManager.gameManager.ResetDie();
        gamestateManager.ResetPlayerInputed();
        resetNeeded = false; 
        timerStarted = false; 
        timer = 0f; 
    }
    private void StartTimer()
    {
        timerStarted = true;
    }
    private void ResetTimer()
    {
        timerStarted = false;
        timer = 0;
    }
}
