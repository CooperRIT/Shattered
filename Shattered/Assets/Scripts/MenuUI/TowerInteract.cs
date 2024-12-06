using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerInteract : MonoBehaviour
{
    [SerializeField] GameObject interactUI;
    [SerializeField] GameObject towerSpawnUI;
    [SerializeField] PlayerSettings playerSettings;
    [SerializeField] TowerSpawn towerSpawn;
    GameObject tempTower;

    //Upgrade Menu components
    [SerializeField] TextMeshProUGUI towerName;

    [SerializeField] TextMeshProUGUI upgradeText1;
    [SerializeField] TextMeshProUGUI upgradeText2;

    [SerializeField] TextMeshProUGUI upgradeCost1;
    [SerializeField] TextMeshProUGUI upgradeCost2;

    [SerializeField] Button upgradeButton1;
    [SerializeField] Button upgradeButton2;

    [SerializeField] TextMeshProUGUI currentUpgradeInfo1;
    [SerializeField] TextMeshProUGUI currentUpgradeInfo2;

    int statIncrease1 = 1;
    int statIncrease2 = 1;

    List<GameObject> disabledObjects = new List<GameObject>();


    void OnMenutActivate()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        interactUI.SetActive(true);

        foreach(GameObject obj in disabledObjects)
        {
            obj.SetActive(true);
        }
    }

    public void OpenMenu(GameObjectEvent ctx)
    {
        if (interactUI.activeSelf || towerSpawnUI.activeSelf)
        {
            return;
        }
        tempTower = ctx.GameObjectRef;
        playerSettings.ZeroSens();
        OnMenutActivate();
        try
        {
            Upgrades temp = ctx.GameObjectRef.transform.GetChild(0).GetComponent<BaseTowerAI>().Upgrades;
            AssignUpgradeMenuInformation(temp);
        }
        catch
        {
            Debug.Log("nope");
        }
    }

    void AssignUpgradeMenuInformation(Upgrades upgrades)
    {
        towerName.text = upgrades.TowerName;
        //Upgrade Stat 1 Assign
        if(upgrades.UpgradeTextOne == "NONE")
        {
            DisableMenuObjects(1);
            return;
        }

        
        UpdateUpgradeInformation(upgrades, 1);
        upgradeButton1.onClick.AddListener(() => CanUpgrade(upgrades, 1));
        upgradeButton1.onClick.AddListener(() => UpdateUpgradeInformation(upgrades, 1));

        //Upgrade Stat 2 Assign
        if(upgrades.UpgradeTextTwo == "NONE")
        {
            DisableMenuObjects(2);
            return;
        }
        upgradeCost2.text = upgrades.UpgradePriceTwo.ToString();
        UpdateUpgradeInformation(upgrades, 2);
        upgradeButton2.onClick.AddListener(() => CanUpgrade(upgrades, 2));
        upgradeButton2.onClick.AddListener(() => UpdateUpgradeInformation(upgrades, 2));

    }

    /// <summary>
    /// 1 for full disable
    /// 2 for only second set of disable
    /// </summary>
    /// <param name="disableType"></param>
    void DisableMenuObjects(int disableType)
    {
        switch(disableType)
        {
            case 1:
                upgradeText1.gameObject.SetActive(false);

                upgradeCost1.gameObject.SetActive(false);

                upgradeButton1.gameObject.SetActive(false);

                currentUpgradeInfo1.gameObject.SetActive(false);

                disabledObjects.Add(upgradeText1.gameObject);
                disabledObjects.Add(upgradeCost1.gameObject);
                disabledObjects.Add(upgradeButton1.gameObject);
                disabledObjects.Add(currentUpgradeInfo1.gameObject);
                goto case 2;

            case 2:
                upgradeText2.gameObject.SetActive(false);

                upgradeCost2.gameObject.SetActive(false);

                upgradeButton2.gameObject.SetActive(false);

                currentUpgradeInfo2.gameObject.SetActive(false);

                disabledObjects.Add(upgradeText2.gameObject);
                disabledObjects.Add(upgradeCost2.gameObject);
                disabledObjects.Add(upgradeButton2.gameObject);
                disabledObjects.Add(currentUpgradeInfo2.gameObject);
                break;
        }
    }


    void UpdateUpgradeInformation(Upgrades upgrades, int buttonIndex)
    {

        if(buttonIndex == 1)
        {
            currentUpgradeInfo1.text = $"Current {upgrades.UpgradeTextOne}: {upgrades.UpgradableStats.UpgradableStatOne}";
            if (upgrades.UpgradableStats.UpgradableStatOne == upgrades.UpgradableStats.MaxUpgradeStatOne)
            {
                upgradeText1.text = "Max";
                disabledObjects.Add(upgradeCost1.gameObject);
                upgradeCost1.gameObject.SetActive(false);
            }
            else
            {
                upgradeText1.text = upgrades.UpgradeTextOne;
                upgradeCost1.text = upgrades.UpgradePriceOne.ToString();
            }
        }
        else
        {
            currentUpgradeInfo2.text = $"Current {upgrades.UpgradeTextTwo}: {upgrades.UpgradableStats.UpgradableStatTwo}";
            if (upgrades.UpgradableStats.UpgradableStatTwo == upgrades.UpgradableStats.MaxUpgradeStatTwo)
            {
                upgradeText2.text = "Max";
                disabledObjects.Add(upgradeCost2.gameObject);
                upgradeCost2.gameObject.SetActive(false);
            }
            else
            {
                upgradeText2.text = upgrades.UpgradeTextTwo;
                upgradeCost2.text = upgrades.UpgradePriceTwo.ToString();
            }
        }
    }

    public void ButtonUsed()
    {
        // Hide the cursor and lock it to the center of the screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Hide and deactivate the menu

        interactUI.SetActive(false);
        playerSettings.ReappleSens();
    }

    public void OnMenuClose()
    {
        upgradeButton1.onClick.RemoveAllListeners();
        upgradeButton2.onClick.RemoveAllListeners();
    }

    void CanUpgrade(Upgrades upgrades, int upgradeIndex)
    {
        if(upgradeIndex == 1)
        {
            if(GameManager.instance.Currency < upgrades.UpgradePriceOne)
            {
                return;
            }
            if (!upgrades.AbleToUpgradeLogicD(1))
            {
                Debug.Log("cant upgrade");
                return;
            }
            GameManager.instance.Currency -= upgrades.UpgradePriceOne;
            upgrades.UpgradeLogicOneUE(statIncrease1);
        }
        else
        {
            if (GameManager.instance.Currency < upgrades.UpgradePriceTwo)
            {
                return;
            }
            if (!upgrades.AbleToUpgradeLogicD(2))
            {
                return;
            }
            GameManager.instance.Currency -= upgrades.UpgradePriceTwo;
            upgrades.UpgradeLogicTwoUE(statIncrease2);
        }
        towerSpawn.CurrencyUpdate();
    }

    public void DestroyTower()
    {
        Destroy(tempTower);
        ButtonUsed();
    }
}
