using Unity.VisualScripting;
using UnityEngine;

public class NumberReader : MonoBehaviour
{

    [SerializeField] int number;

    [Header("References (Fetched in Code)")]
    Rigidbody rb;
    Die die;




    float stopThreshold = 0.1f;


    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody>();
        die = GetComponentInParent<Die>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (rb.angularVelocity.sqrMagnitude < stopThreshold & rb.linearVelocity.sqrMagnitude < stopThreshold & other.CompareTag("Ground") & !die.IsStopped)
        {
            die.UpdateDie(number);
            die.IsStopped = true;
        }
        
    }

}
