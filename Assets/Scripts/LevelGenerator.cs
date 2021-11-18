using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelPart_1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnLevelPart(new Vector3(0, -13));
        SpawnLevelPart(new Vector3(-10, -8));
    }

    private void SpawnLevelPart(Vector3 spawnPosition){
        Instantiate(levelPart_1, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
