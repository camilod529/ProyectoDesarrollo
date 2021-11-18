using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 10f;

    [SerializeField] private Transform levelPart_1;
    [SerializeField] private Transform enemy_1;
    [SerializeField] private Transform enemy_2;
    [SerializeField] private Transform enemy_3;
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform player;

    private Vector3 lastEndPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastEndPosition = levelPart_Start.Find("FinalPos").position;
        int startingSpawnLevelParts = 2;
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
        spawnPosition = new Vector3(NextFloat(-2, 2), NextFloat((float)-0.7,(float) 0.5) + spawnPosition.y);
        Transform levelPartTransform = Instantiate(levelPart_1, spawnPosition, Quaternion.identity);

        if(NextFloat(0, 3) < 1)
        {
            System.Random random = new System.Random();
            int auxInt = random.Next(3);
            Debug.Log(auxInt);
            switch (auxInt)
            {
                case 0:
                    spawnPosition = new Vector3(NextFloat(-4, 4), NextFloat((float)-0.7,(float) 0.5) + spawnPosition.y);
                    Instantiate(enemy_1, spawnPosition, Quaternion.identity);
                    break;
                case 1:
                    spawnPosition = new Vector3(NextFloat(-4, 4), NextFloat((float)-0.7,(float) 0.5) + spawnPosition.y);
                    Instantiate(enemy_2, spawnPosition, Quaternion.identity);
                    break;
                default:
                    spawnPosition = new Vector3(NextFloat(-4, 4), NextFloat((float)-0.7,(float) 0.5) + spawnPosition.y);
                    Instantiate(enemy_3, spawnPosition, Quaternion.identity);
                    break;
            }

        }

        return levelPartTransform;
    }
    
    static float NextFloat(float min, float max){
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
}
