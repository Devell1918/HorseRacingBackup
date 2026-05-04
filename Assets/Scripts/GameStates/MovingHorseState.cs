using Unity.Cinemachine;
using UnityEngine;

public class MovingHorseState : GameStateBase
{
    public override void EnterState(GameStateManager gamestateManager) 
    {
        gamestateManager.playerInput.DisableControls();
        Debug.Log("Entered move horse State");
        gamestateManager.overheadCam.gameObject.SetActive(true);
        gamestateManager.gameManager.MoveAHorse(gamestateManager.gameManager.DieAdded);
    }
           
    public override void UpdateState(GameStateManager gamestateManager) 
    {
        if (gamestateManager.PlayerRolledScratched)
        {
            gamestateManager.overheadCam.gameObject.SetActive(false);
            gamestateManager.ScratchedHorseAlertReset();
            gamestateManager.SwitchState(gamestateManager.scratchHorseState);
            
        } else if (gamestateManager.HorseStoppedMoving)
        {
            gamestateManager.ResetHorseStoppedMovingAlert();
            gamestateManager.overheadCam.gameObject.SetActive(false);
            gamestateManager.SwitchState(gamestateManager.rollingDieState);
        }
    }

}
