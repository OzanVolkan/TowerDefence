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
            GameManager.Instance.Win(waveIndex);

            if (GameManager.Instance.LevelRound == waveIndex)
                return;

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

            GameObject e = Instantiate(spawnType, spawnPoint.position, spawnPoint.rotation);
            GameManager.Instance.CurrentEnemies.Add(e);

            yield return new WaitForSeconds(0.5f);
            tempDifficultyIndex--;
        }
        waveIndex++;
        difficultyIndex++;
    }
}
