using UnityEngine;

public class TokenDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Horse"))
        {
            Destroy(gameObject);
        }
    }

}
