using Unity.Cinemachine;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    [SerializeField] public CinemachineCamera cinemachineCamera;
    [SerializeField] public CameraPositionsSO cameraPositions;

    [SerializeField] private Die die1Script;
    [SerializeField] private Die die2Script;

    public bool dieStopped { get; set; }

    
    private GameStateBase currentState;
    public RollingDieState rollingDieState = new RollingDieState();
    public ScratchHorseState scratchHorseState = new ScratchHorseState();
    public MovingHorseState movingHorseState = new MovingHorseState();
    private void Start()
    {
        
        currentState = rollingDieState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        if (die1Script.IsStopped && die2Script.IsStopped) { dieStopped = true; }
        currentState.UpdateState(this);
    }

    public void SwitchState(GameStateBase gameState) 
    {
        currentState = gameState;
        currentState.EnterState(this);
    }

}
