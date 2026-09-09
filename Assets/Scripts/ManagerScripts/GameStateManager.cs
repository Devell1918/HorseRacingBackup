using Unity.Cinemachine;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] public Messages messages;
    [SerializeField] public PlayerInput playerInput;
    [SerializeField] public GameManager gameManager;
    [SerializeField] public CinemachineCamera dieRollCam;
    [SerializeField] public CinemachineCamera overheadCam;
    [SerializeField] public CinemachineCamera sideCamera;

    [SerializeField] private Die die1Script;
    [SerializeField] private Die die2Script;

    //workinprogress
    public bool victoryAchieved;

    public bool PlayerInputed { get; private set; }

    public bool dieStopped { get; set; }
    public bool allHorsesScratched { get; set; }

    public bool PlayerRolledScratched { get; private set; }
    public bool HorseStoppedMoving { get; private set; }


    public GameStateBase currentState;
    public OpeningState openState = new OpeningState();
    public RollingDieState rollingDieState = new RollingDieState();
    public ScratchHorseState scratchHorseState = new ScratchHorseState();
    public MovingHorseState movingHorseState = new MovingHorseState();
    public VictoryState victoryState = new VictoryState();
    private void Start()
    {
        playerInput = FindAnyObjectByType<PlayerInput>();
        gameManager = FindAnyObjectByType<GameManager>();
        messages = FindAnyObjectByType<Messages>();
        currentState = openState;
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

    public void ScratchedHorseAlert()
    {
        PlayerRolledScratched = true;
    }

    public void ScratchedHorseAlertReset()
    {
        PlayerRolledScratched = false;
    }

    public void HorseStoppedMovingAlert()
    {
        HorseStoppedMoving = true;
    }

    public void ResetHorseStoppedMovingAlert()
    {
        HorseStoppedMoving = false;
    }

    public void TriggerVictory()
    {
        victoryAchieved = true;
    }
}
