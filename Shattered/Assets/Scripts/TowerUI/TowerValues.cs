using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TowerInformation
{
    public int currencyValue;
    public int towerIndex;
}

public class TowerValues : MonoBehaviour
{
    [SerializeField] TowerSpawn towerSpawn;
    [SerializeField] TowerInformation towerInformation;


    public void OnSpawnTower()
    {
        towerSpawn.SpawnTower(towerInformation);
    }
}
