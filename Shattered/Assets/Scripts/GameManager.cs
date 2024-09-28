using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform player;

    public Transform Player { get { return player; } }

    public static GameManager instance;

    float enemySpawnCount;
    float enemyIncreasingCount;
    float currentEnemyCount;
    float enemySpawnTimer = 3;
    float currency = 0;

    WaitForSeconds enemySpawnTimer_wfs;

    [SerializeField] Transform spawnPosition;
    [SerializeField] Transform endPosition;

    [SerializeField] GameObject enemyPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance != this && instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }

        enemySpawnTimer_wfs = new WaitForSeconds(enemySpawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnStartAttackPhase()
    {
        StartCoroutine(SpawnWave());
    }

    void LoadNextAttackPhase()
    {
        enemySpawnCount += enemyIncreasingCount;
    }

    void OnStartBuildPhase()
    {

    }

    IEnumerator SpawnWave()
    {
        for(int i = 0; i < enemySpawnCount; i++)
        {

        }
    }

    public void OnEnemyDeath(FloatEvent ctx)
    {
        currency += ctx.FloatValue;
        currentEnemyCount--;
    }
}
