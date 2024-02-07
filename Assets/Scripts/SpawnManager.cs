using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject boosterPrefab;
    private float spawnRange = 9.0f;
    public int enemySpawnAmount = 3;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        
        
    }
    void SpawnEnemy()
    {
        for (int i = 0; i < enemySpawnAmount; i++)
        {
            Instantiate(enemyPrefab, RandomSpawnPos(), enemyPrefab.transform.rotation);
            Instantiate(boosterPrefab, RandomSpawnPos(), boosterPrefab.transform.rotation);
        }
        enemySpawnAmount += 1;
      
    }
    private Vector3 RandomSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosY);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            SpawnEnemy();
        }
    }
}
