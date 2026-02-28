using UnityEngine;

public class Scratch : MonoBehaviour
{
    private float scratchPosition1 = -3;
    private float scratchPosition2 = -6;
    private float scratchPosition3 = -9;
    private float scratchPosition4 = -12;


    public void ScratchHorse(int positionInput)
    {
        switch (positionInput)
        {
            case 1:
                transform.position = new Vector3 (transform.position.x, transform.position.y, scratchPosition1);
                Debug.Log("Scratched horse " + gameObject.name + " in position 1");
                break;
            case 2:
                transform.position = new Vector3(transform.position.x, transform.position.y, scratchPosition2);
                Debug.Log("Scratched horse " + gameObject.name + " in position 2");
                break;
            case 3:
                transform.position = new Vector3(transform.position.x, transform.position.y, scratchPosition3);
                Debug.Log("Scratched horse " + gameObject.name + " in position 3");
                break;
            case 4:
                transform.position = new Vector3(transform.position.x, transform.position.y, scratchPosition4);
                Debug.Log("Scratched horse " + gameObject.name + " in position 4");
                break;
        }
    }
}
