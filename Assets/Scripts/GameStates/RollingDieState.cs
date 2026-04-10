using Unity.Cinemachine;
using UnityEngine;

public class RollingDieState : GameStateBase
{
    public override void EnterState(GameStateManager gamestateManager)
    {
        gamestateManager.dieRollCam.ForceCameraPosition(gamestateManager.cameraPositions.rollingDiePosition,gamestateManager.cameraPositions.rollingDieRotation);
    }
    public override void UpdateState(GameStateManager gamestateManager)
    {
        if (gamestateManager.dieStopped)
        {
            gamestateManager.SwitchState(gamestateManager.scratchHorseState);
        }
    }
}
