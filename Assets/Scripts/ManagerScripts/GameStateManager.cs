using Unity.Cinemachine;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] public Messages messages;
    [SerializeField] public PlayerInput playerInput;
    [SerializeField] public GameManager gameManager;
    [SerializeField] public CinemachineCamera dieRollCam;
    [SerializeField] public CinemachineCamera overheadCam;
    [SerializeField] public CameraPositionsSO cameraPositions;

    [SerializeField] private Die die1Script;
    [SerializeField] private Die die2Script;

    public bool PlayerInputed { get; private set; }

    public bool dieStopped { get; set; }
    public bool allHorsesScratched { get; set; }

    public bool Change { get; private set; }

    
    public GameStateBase currentState;
    public RollingDieState rollingDieState = new RollingDieState();
    public ScratchHorseState scratchHorseState = new ScratchHorseState();
    public MovingHorseState movingHorseState = new MovingHorseState();
    private void Start()
    {
        playerInput = FindAnyObjectByType<PlayerInput>();
        gameManager = FindAnyObjectByType<GameManager>();
        messages = FindAnyObjectByType<Messages>();
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

    public void UpdatePlayerInputed()
    {
        PlayerInputed = true;
    }

    public void ResetPlayerInputed()
    {
        PlayerInputed = false;
    }

    public void AllHorsesScratched()
    {
        allHorsesScratched = true;
    }

    public void TimeToChange()
    {
        Change = true;
    }

    public void TimeToStay()
    {
        Change = false;
    }
}
