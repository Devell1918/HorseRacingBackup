using Unity.Cinemachine;
using UnityEngine;

public class MovingHorseState : GameStateBase
{
    public override void EnterState(GameStateManager gamestateManager) 
    {
        Debug.Log("Entered move horse State");
        gamestateManager.overheadCam.gameObject.SetActive(true);
        gamestateManager.gameManager.MoveAHorse(gamestateManager.gameManager.DieAdded);
    }
           
    public override void UpdateState(GameStateManager gamestateManager) 
    {
        if (gamestateManager.Change)
        {
            gamestateManager.overheadCam.gameObject.SetActive(false);
            gamestateManager.TimeToStay();
            gamestateManager.SwitchState(gamestateManager.rollingDieState);
            
        }
    }

}
