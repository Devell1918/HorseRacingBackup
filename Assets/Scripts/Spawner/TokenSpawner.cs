using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    [SerializeField] PositionsSO[] AllHorses = new PositionsSO[11];
    [SerializeField] GameObject chipPrefabBlack;
    [SerializeField] GameObject chipPrefabRed;
    [SerializeField] Transform tokens;
    private GameObject currentChip;
    private float yOffset = .045f;

    void Start()
    {
        currentChip = chipPrefabRed;

        for (int i = 0; i < AllHorses.Length; i++)
        {

            for (int j = 0; j < AllHorses[i].maxPositions; j++)
            {
                Vector3 spawnPosition = new Vector3(AllHorses[i].avaliblePositions[j].x, yOffset, AllHorses[i].avaliblePositions[j].z);
                float yrot = Random.Range(0, 360);
                Instantiate(currentChip, spawnPosition, Quaternion.Euler(-90, yrot, 0), tokens);

            }
            if (currentChip == chipPrefabRed)
            {
                currentChip = chipPrefabBlack;
            }

            else
            {
                currentChip = chipPrefabRed;
            }
        }
    }


}
