using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player Info")]
    [SerializeField] Transform player;

    public Transform Player { get { return player; } }

    private GameObject playerCamera;

    [SerializeField] GameObject overheadCamera;

    [SerializeField] float startingPlayerSens;

    public static GameManager instance;

    [Header("Enemy Info")]
    [SerializeField] float enemySpawnCount;
    float enemyIncreasingCount = 5;
    [SerializeField] float currentEnemyCount;
    float enemySpawnTimer = 1;
    [SerializeField] int currency = 35;
    int currentWave;

    WaitForSeconds enemySpawnTimer_wfs;

    [SerializeField] Transform spawnPosition;
    [SerializeField] List<Transform> endPositions = new List<Transform>();

    [SerializeField] GameObject enemyPrefab;

    [SerializeField] VoidEventChannel onEndWave_EventChannel;

    [SerializeField] VoidEventChannel onFirstWave_EventChannel;
    bool isFirstWave = true;

    float maxHealth = 3;
    int waveCounter = 0;
    int probability = 7;

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
        playerCamera = Camera.main.gameObject;
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
        if (isFirstWave)
        {
            onFirstWave_EventChannel.CallEvent(new());
            isFirstWave = false;
        }
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
        waveCounter++;
        enemySpawnCount += enemyIncreasingCount;
        enemyIncreasingCount += 3;
        //if (Random.Range(0, 10) >= 5)
        //{
        //    if(Random.Range(0,15) >= 14)
        //    {
        //        maxHealth += 5;
        //    }
        //    else
        //    {
        //        maxHealth += 1;
        //    }        
        //}

        if(waveCounter % 3 == 0)
        {
            maxHealth += 2;
            probability -= 1;

            if(probability <= 0)
            {
                probability = 1;
            }
        }

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
        for(int i = 0; i < enemySpawnCount; i++)
        {
            EnemyAI enemy = Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity).GetComponent<EnemyAI>();
            enemy.OnSpawn(endPositions[Random.Range(0,2)]);
            if(Random.Range(0,10) >= probability)
            {
                enemy.Health = Random.Range(maxHealth - 2, maxHealth);
            }
            yield return enemySpawnTimer_wfs;
        }
    }


    public void OnEnemyDeath(FloatEvent ctx)
    {
        // Increment the currency and display the updated value
        currency += (int)ctx.FloatValue;
        //currencyText.text = "Currency: " + currency.ToString();

        currentEnemyCount--;
        if(currentEnemyCount <= 0)
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


    public void ChangeCamera()
    {
        playerCamera.SetActive(overheadCamera.activeSelf);
        overheadCamera.SetActive(!playerCamera.activeSelf);
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

    public float StartingPlayerSens
    {
        get { return startingPlayerSens; }
    }
}
