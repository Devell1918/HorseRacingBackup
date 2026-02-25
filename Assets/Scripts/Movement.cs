using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private PositionsSO positionSO;
    [SerializeField] private string nameOfHorse;
    public PositionsSO PositionsSO { get { return positionSO; } set { positionSO = value; } }
    public string NameOFHorse{ get { return nameOfHorse; } set { nameOfHorse = value; } }

    [SerializeField] float moveTime = 1;
    int position = 0;

    public bool moveForwardBool = false;
    private bool isMoving = false;

    private void Awake()
    {
        
    }

    private void Start()
    {
        InitializePosition();
    }

    private void Update()
    {
        
        if (moveForwardBool & (position < positionSO.maxPositions & !isMoving))
        {
            StartCoroutine(MoveForwardCoroutine());
            
        }
    }

    public void InitializePosition()
    {
        transform.position = positionSO.startPosition;
    }
    public IEnumerator MoveForwardCoroutine()
    {
        isMoving = true;
        moveForwardBool = false;
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, positionSO.avaliblePositions[position].z);
        Vector3 startPosition = transform.position;
        float elapsed = 0;


        while (elapsed <= moveTime) 
        {
            float t = elapsed / moveTime;
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
        transform.position = targetPosition;
        
        isMoving = false;
        position ++;

    }

    private void OnContinue(InputValue inputValue)
    {
        Debug.Log("continue");
        moveForwardBool = true;

        
    }


}
