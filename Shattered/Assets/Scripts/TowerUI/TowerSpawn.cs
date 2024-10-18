using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawn : MonoBehaviour
{

    [SerializeField] GameObject menuUI;
    [SerializeField] List<GameObject> towerPrefab = new List<GameObject>();
    [SerializeField] GameObject interactionBlock;

    [SerializeField] TextMeshProUGUI currencyText;
    [SerializeField] TextMeshProUGUI towerMenuCurrencyText;

    [SerializeField] TextMeshProUGUI nextWaveText;

    FloatEvent placeHolder = new FloatEvent();

    int tempTowerValue = 5;

    int currentCurrency => GameManager.instance.Currency;

    // Update is called once per frame
    void Awake()
    {
        UpdateCurrencyText(placeHolder);
    }

    public void SpawnTower(int towerIndex)
    {
        if (currentCurrency < tempTowerValue)
        {
            return;
        }

        Instantiate(towerPrefab[towerIndex], interactionBlock.transform.position, Quaternion.identity);
        GameManager.instance.Currency -= tempTowerValue;
        UpdateCurrencyText(placeHolder);
        interactionBlock.SetActive(false);
        ButtonUsed();
    }

    public void ButtonUsed()
    {
        // Hide the cursor and lock it to the center of the screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Hide and deactivate the menu
        menuUI.SetActive(false);
    }

    public void OnOpenMenu(GameObjectEvent ctx)
    {
        Debug.Log("hello");
        interactionBlock = ctx.GameObjectRef;
        towerMenuCurrencyText.text = currencyText.text;
        OnMenutActivate();
    }

    void OnMenutActivate()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        menuUI.SetActive(true); // Show the menu screen
    }

    public void UpdateCurrencyText(FloatEvent ctx)
    {
        Invoke(nameof(CurrencyUpdate), .1f);
    }

    public void DisplayWaveText(VoidEvent ctx)
    {
        nextWaveText.enabled = !nextWaveText.enabled;
    }

    void CurrencyUpdate()
    {
        currencyText.text = $"<b>Currency:</b> {currentCurrency}";
        towerMenuCurrencyText.text = currencyText.text;
    }
}
