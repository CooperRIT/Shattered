using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform player;

    public Transform Player { get { return player; } }

    public static GameManager instance;

    [SerializeField] float enemySpawnCount;
    float enemyIncreasingCount = 5;
    [SerializeField] float currentEnemyCount;
    float enemySpawnTimer = 3;
    int currency = 7;
    int currentWave;

    WaitForSeconds enemySpawnTimer_wfs;

    [SerializeField] Transform spawnPosition;
    [SerializeField] List<Transform> endPositions = new List<Transform>();

    [SerializeField] GameObject enemyPrefab;

    [SerializeField] VoidEventChannel onEndWave_EventChannel;

    // Properties

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
        /*if(prevCurrency != currency)
        {
            currencyText.text = "Currency: " + currency.ToString();
            prevCurrency = currency;
        }*/
    }

    [ContextMenu("Start Wave")]
    public void OnStartAttackPhase(VoidEvent ctx)
    {
        if(currentEnemyCount != 0)
        {
            return;
        }
        LoadNextAttackPhase();
        OnWaveEnd();
        StartCoroutine(SpawnWave());
    }

    void DecreaseTimer()
    {
        if(enemySpawnTimer <= .25f)
        {
            return;
        }
        enemySpawnTimer -= .25f;
        enemySpawnTimer_wfs = new WaitForSeconds(enemySpawnTimer);

    }


    void LoadNextAttackPhase()
    {
        enemySpawnCount += enemyIncreasingCount;
        DecreaseTimer();
        currentEnemyCount = enemySpawnCount;

    }

    void OnWaveEnd()
    {
        onEndWave_EventChannel.CallEvent(new());
    }

    void OnStartBuildPhase()
    {

    }

    IEnumerator SpawnWave()
    {
        Debug.Log("spawn wave");
        for(int i = 0; i < enemySpawnCount; i++)
        {
            EnemyAI enemy = Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity).GetComponent<EnemyAI>();
            enemy.OnSpawn(endPositions[Random.Range(0,2)]);
            yield return enemySpawnTimer_wfs;
        }
    }

    float lastFrameCount = -1;
    public void OnEnemyDeath(FloatEvent ctx)
    {
        if(lastFrameCount == Time.frameCount)
        {
            return;
        }


        lastFrameCount = Time.frameCount;
        // Increment the currency and display the updated value
        currency += (int)ctx.FloatValue;
        //currencyText.text = "Currency: " + currency.ToString();

        currentEnemyCount--;
        if(currentEnemyCount == 0)
        {
            OnWaveEnd();
            Debug.Log("Wave Over");
        }
    }

    //Restarts scene on death
    public void OnMainTowerDeath(VoidEvent ctx)
    {
        SceneManager.LoadScene(0);
    }

    public int Currency
    {
        get { return currency; }
        set { currency = value; }
    }

    public int CurrentWave
    {
        get { return currentWave; }
    }
}
