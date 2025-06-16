using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEWaves : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float initialZRange = 5f;
    public float spawnInterval = 1f; // Menor intervalo para mostrar 1 a 1 por oleada
    private float currentZRange;

    public int maxEnemiesPerWave = 5;
    private int enemiesToSpawn;
    private int currentWave = 1;

    private bool isSpawning = false;

    void Start()
    {
        currentZRange = initialZRange;
        enemiesToSpawn = maxEnemiesPerWave;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isSpawning)
        {
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        isSpawning = true;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            float randomZ = transform.position.z + Random.Range(-currentZRange, currentZRange);
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, randomZ);

            Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);

            yield return new WaitForSeconds(spawnInterval);
        }

        currentWave++;
        enemiesToSpawn += 5;
        currentZRange += 2f;

        isSpawning = false;
    }
}
