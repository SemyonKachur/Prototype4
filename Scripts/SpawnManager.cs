using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float randomRange = 9.0f;
    public int enemyCount;
    public int waweNumber = 1;

    void Start()
    {
        SpawnEnemyWawe(waweNumber);
        Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waweNumber++;
            SpawnEnemyWawe(waweNumber);
            Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        float spawnPositionX = Random.Range(-randomRange, randomRange);
        float spawnPositionZ = Random.Range(-randomRange, randomRange);
        Vector3 randomPosition = new Vector3(spawnPositionX, 0.5f, spawnPositionZ);
        return randomPosition;
    }
    
    private void SpawnEnemyWawe(int enemyToSpawn)
    {
        for(int i = 0; i< enemyToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
    }
}
