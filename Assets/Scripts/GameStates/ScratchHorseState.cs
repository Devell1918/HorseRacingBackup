using Unity.Cinemachine;
using UnityEngine;

public class ScratchHorseState : GameStateBase
{
    public override void EnterState(GameStateManager gamestateManager) 
    {
        Debug.Log("Entered scratch horse State");
        gamestateManager.overheadCam.gameObject.SetActive(true);
        gamestateManager.gameManager.StartScratch();
    }

    public override void UpdateState(GameStateManager gamestateManager) 
    {
        if (gamestateManager.PlayerInputed)
        {
            gamestateManager.overheadCam.gameObject.SetActive(false);
            
            gamestateManager.SwitchState(gamestateManager.rollingDieState);
        }
    }

}
