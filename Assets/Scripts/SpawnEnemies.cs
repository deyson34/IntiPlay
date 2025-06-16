using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnEnemies: MonoBehaviour
{
    public GameObject enemyPrefab;
    public float zRange = 5f;
    public float spawnInterval = 5f;
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }
    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            float randomZ = transform.position.z + Random.Range(-zRange, zRange);
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, randomZ);

            Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void Update()
    {
    
    }
}
