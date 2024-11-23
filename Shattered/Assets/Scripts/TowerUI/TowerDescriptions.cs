using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerDescriptions : MonoBehaviour
{
    [SerializeField] GameObject descriptionMenu;
    [SerializeField] TextMeshProUGUI towerName;
    [SerializeField] TextMeshProUGUI towerDescription;

    public void DPSTower()
    {
        descriptionMenu.SetActive(true);
        towerName.text = "DPS Tower";
        towerDescription.text = "Shoots at enemies within range at regular intervals.";
    }

    public void SupportTower()
    {
        descriptionMenu.SetActive(true);
        towerName.text = "Support Tower";
        towerDescription.text = "Increases the fire rate of you and nearby dps towers.";
    }

    public void GamblingTower()
    {
        descriptionMenu.SetActive(true);
        towerName.text = "Gambling Tower";
        towerDescription.text = "50/50 chance to kill all enemies, or destory all towers.";
    }

    public void DisableMenu()
    {
        descriptionMenu.SetActive(false);
    }
}
