using UnityEngine;

[CreateAssetMenu(fileName = "CameraPositionsSO", menuName = "Scriptable Objects/CameraPositionsSO")]
public class CameraPositionsSO : ScriptableObject
{
    public Vector3 rollingDiePosition = new Vector3(3.5f, 8.5f, -8.5f);
    public Quaternion rollingDieRotation = Quaternion.Euler(new Vector3(50f, -90f, 0f));

    public Vector3 scratchedPosition = new Vector3(7f, 17f, -8.5f);
    public Quaternion scratchedRotation = Quaternion.Euler(new Vector3(50f, -90f, 0f));
}
