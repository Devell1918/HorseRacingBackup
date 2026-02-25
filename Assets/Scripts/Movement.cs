using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private PositionsSO positionSO;
    public PositionsSO PositionsSO { get { return positionSO; } set { positionSO = value; } }

    [SerializeField] float moveSpeed;
    [SerializeField] float moveTime = 1;
    int position = 0;

    private bool moveForwardBool = false;
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
        Vector3 targetPosition = positionSO.avaliblePositions[position];
        Vector3 startPosition = transform.position;
        Debug.Log(startPosition);
        Debug.Log(targetPosition);
        float elapsed = 0;


        while (elapsed <= moveTime) 
        {
            float t = elapsed / moveTime;
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
        transform.position = positionSO.avaliblePositions[position];
        
        isMoving = false;
        position ++;

    }

    private void OnContinue(InputValue inputValue)
    {
        Debug.Log("continue");
        moveForwardBool = true;

        
    }


}
