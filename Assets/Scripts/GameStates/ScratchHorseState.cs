using Unity.Cinemachine;
using UnityEngine;

public class ScratchHorseState : GameStateBase
{
    public override void EnterState(GameStateManager gamestateManager) 
    {
        Debug.Log("Switched to Scratch State");
        gamestateManager.overheadCam.gameObject.SetActive(true);
        gamestateManager.gameManager.StartScratch();
    }

    public override void UpdateState(GameStateManager gamestateManager) 
    {

    }

}
