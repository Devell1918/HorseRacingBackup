using UnityEngine;

public class VictoryState : GameStateBase
{
    public override void EnterState(GameStateManager gamestateManager)
    {
        Debug.Log("Victory!!!!");
        gamestateManager.messages.SetMessage("Victor!!");
        gamestateManager.playerInput.DisableControls();
    }

    public override void UpdateState(GameStateManager gamestateManager)
    {
        throw new System.NotImplementedException();
    }
}
