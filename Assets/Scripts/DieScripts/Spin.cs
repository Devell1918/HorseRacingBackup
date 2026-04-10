using UnityEngine;

public class Spin : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float maxRotationSpeed;
    [SerializeField] float minRotationSpeed;

    [Header("Dependencies (Fetched in Code)" )]
    [SerializeField] PlayerInput playerInput;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

    }

    private void Start()
    {
        playerInput = FindAnyObjectByType<PlayerInput>();
    }

    private void FixedUpdate()
    {
        if (!playerInput.dropped)
        {
            SpinDie();

        }
    }
    private void SpinDie()
    {

        float rotationSpeedz = GenerateRandomFloat(minRotationSpeed, maxRotationSpeed);
        float rotationSpeedy = GenerateRandomFloat(minRotationSpeed, maxRotationSpeed);


        rb.AddTorque(transform.up * rotationSpeedy);
        rb.AddTorque(transform.forward * rotationSpeedz);

    }

    private float GenerateRandomFloat(float min, float max)
    {
        float random = Random.Range(min, max);
        return random;

    }
}
