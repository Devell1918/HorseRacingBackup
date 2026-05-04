using UnityEngine;

public class PlayerRolledAScratchedHorseState : GameStateBase
{
    public override void EnterState(GameStateManager gamestateManager)
    {
        //find a way to get the horse number and which scrath postion he is in into the message
        gamestateManager.messages.SetMessage("That Horse is Scratched! Pay in");
    }

    public override void UpdateState(GameStateManager gamestateManager)
    {
        if (gamestateManager.playerInput)
        {
            gamestateManager.SwitchState(gamestateManager.rollingDieState);
        }
    }

}
