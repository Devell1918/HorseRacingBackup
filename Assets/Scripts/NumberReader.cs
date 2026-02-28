using Unity.VisualScripting;
using UnityEngine;

public class NumberReader : MonoBehaviour
{
    


    [Header("References (Fetched in Code)")]
    Rigidbody rb;
    Die die;



    [SerializeField] int number;
    float stopThreshold = 0.1f;
    private bool dieStopped = false;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody>();
        die = GetComponentInParent<Die>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (rb.angularVelocity.sqrMagnitude < stopThreshold & rb.linearVelocity.sqrMagnitude < stopThreshold & other.CompareTag("Ground") & !dieStopped)
        {
            AssignDie();
        }
        
    }
    private void AssignDie()
    {
            die.landedOn = number;
            dieStopped = true;
            Debug.Log(number);

    }
}
