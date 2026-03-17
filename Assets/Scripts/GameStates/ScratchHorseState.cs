using Unity.Cinemachine;
using UnityEngine;

public class ScratchHorseState : GameStateBase
{
    public override void EnterState(GameStateManager gamestateManager) 
    {
        Debug.Log("Switched to Scratch State");
        gamestateManager.cinemachineCamera.ForceCameraPosition(gamestateManager.cameraPositions.scratchedPosition, gamestateManager.cameraPositions.scratchedRotation);
    }

    public override void UpdateState(GameStateManager gamestateManager) 
    {

    }

}
