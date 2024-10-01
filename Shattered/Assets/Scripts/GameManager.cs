using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform player;

    public Transform Player { get { return player; } }

    public static GameManager instance;

    float enemySpawnCount;
    float enemyIncreasingCount = 5;
    [SerializeField] float currentEnemyCount;
    float enemySpawnTimer = 3;
    float currency = 5;
    float prevCurrency = 0;

    WaitForSeconds enemySpawnTimer_wfs;

    [SerializeField] Transform spawnPosition;
    [SerializeField] Transform endPosition;

    [SerializeField] GameObject enemyPrefab;

    [SerializeField] TextMeshProUGUI currencyText;

    // Properties
    public float Currency
    {
        get => currency;
        set => currency = value;
    }

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
        if(prevCurrency != currency)
        {
            currencyText.text = "Currency: " + currency.ToString();
            prevCurrency = currency;
        }
    }

    [ContextMenu("Start Wave")]
    public void OnStartAttackPhase()
    {
        currentEnemyCount = enemySpawnCount;
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
            EnemyAI enemy = Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity).GetComponent<EnemyAI>();
            enemy.OnSpawn(endPosition);
            yield return enemySpawnTimer_wfs;
        }
    }

    public void OnEnemyDeath(FloatEvent ctx)
    {
        // Increment the currency and display the updated value
        currency += ctx.FloatValue;
        currencyText.text = "Currency: " + currency.ToString();

        currentEnemyCount--;
        if(currentEnemyCount == 0)
        {
            Debug.Log("Wave Over");
        }
    }
}
