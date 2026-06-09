using UnityEngine;

public class VictoryState : GameStateBase
{
    public override void EnterState(GameStateManager gamestateManager)
    {
        Debug.Log("Victory!!!!");
        gamestateManager.messages.SetMessage("Victory!!");
        gamestateManager.playerInput.DisableControls();
    }

    public override void UpdateState(GameStateManager gamestateManager)
    {
        
    }
}
