using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static float Countdown { get; private set; } = 2;

    [SerializeField] GameObject[] enemyTypes;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float timeBetweenWaves = 5f;
    GameObject spawnType;
    int waveIndex = 1;
    int difficultyIndex;


    private void Update()
    {
        if (GameManager.Instance.IsGameOver)
            return;

        if (Countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            Countdown = timeBetweenWaves;
        }

        Countdown -= Time.deltaTime;

        Countdown = Mathf.Clamp(Countdown, 0f, Mathf.Infinity);
    }

    private IEnumerator SpawnWave()
    {
        GameManager.Instance.Rounds++;

        int tempDifficultyIndex = difficultyIndex;
        
        for (int i = 0; i < waveIndex; i++)
        {

            if (tempDifficultyIndex > 2)
            {
                spawnType = enemyTypes[enemyTypes.Length - 1];
            }
            else if (tempDifficultyIndex < 0)
            {
                tempDifficultyIndex = 0;
            }
            else
            {
                spawnType = enemyTypes[tempDifficultyIndex];
            }

            Instantiate(spawnType, spawnPoint.position, spawnPoint.rotation);

            yield return new WaitForSeconds(0.5f);
            tempDifficultyIndex--;
        }
        waveIndex++;
        difficultyIndex++;
    }
}
