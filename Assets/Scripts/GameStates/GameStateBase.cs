using Unity.Cinemachine;
using UnityEngine;

public abstract class GameStateBase
{

    public abstract void EnterState(GameStateManager gamestateManager);

    public abstract void UpdateState(GameStateManager gamestateManager);


}