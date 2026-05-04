using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    [SerializeField] PositionsSO[] AllHorses = new PositionsSO[11];
    [SerializeField] GameObject tokenPrefab;
    [SerializeField] Transform tokens;
    void Start()
    {
        for (int i = 0; i < AllHorses.Length; i++)
        {
            for(int j = 0; j < AllHorses[i].maxPositions; j++)
            {
                Instantiate(tokenPrefab, AllHorses[i].avaliblePositions[j], Quaternion.identity, tokens );
                
            }
        }
    }


}
