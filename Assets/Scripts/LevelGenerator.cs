using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 10f;

    [SerializeField] private Transform levelPart_1;
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform player;

    private Vector3 lastEndPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastEndPosition = levelPart_Start.Find("FinalPos").position;
        int startingSpawnLevelParts = 5;
        for (int i=0; i<startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if(Vector3.Distance(player.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("FinalPos").position;
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform randomAux = levelPart_1;
        spawnPosition = spawnPosition + new Vector3(NextFloat(-2, 2), NextFloat((float)-0.4,(float) 0.2));
        Transform levelPartTransform = Instantiate(levelPart_1, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
    
    static float NextFloat(float min, float max){
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
}
