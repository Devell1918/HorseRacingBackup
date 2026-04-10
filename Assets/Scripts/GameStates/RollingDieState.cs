using Unity.Cinemachine;
using UnityEngine;

public class RollingDieState : GameStateBase
{
    public override void EnterState(GameStateManager gamestateManager)
    {
        gamestateManager.ResetPlayerInputed();
        gamestateManager.playerInput.EnableControls();
        gamestateManager.messages.SetMessage("");
        Debug.Log("Entered Roll Die State");
        gamestateManager.gameManager.ResetDie();
        gamestateManager.dieStopped = false;
    }
    public override void UpdateState(GameStateManager gamestateManager)
    {
        if (gamestateManager.PlayerInputed)
        {
            gamestateManager.gameManager.DropDie();
            gamestateManager.ResetPlayerInputed();
            gamestateManager.playerInput.DisableControls();
        }

        if (gamestateManager.dieStopped)
        {
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
}
