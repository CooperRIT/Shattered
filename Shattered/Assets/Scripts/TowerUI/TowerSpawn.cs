using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawn : MonoBehaviour
{

    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject intrusctionsUI;

    [SerializeField] List<GameObject> towerPrefab = new List<GameObject>();
    [SerializeField] GameObject interactionBlock;

    [SerializeField] TextMeshProUGUI currencyText;
    [SerializeField] TextMeshProUGUI towerMenuCurrencyText;

    [SerializeField] TextMeshProUGUI nextWaveText;

    FloatEvent placeHolder = new FloatEvent();

    int currentCurrency => GameManager.instance.Currency;

    PlayerSettings playerSettings;

    [SerializeField] VoidEventChannel onFirstDpsTower_EventChannel;
    bool isFirstDpsTower = true;
    [SerializeField] VoidEventChannel onFirstSupportTower_EventChannel;
    bool isFirstSupportTower = true;

    // Update is called once per frame
    void Awake()
    {
        UpdateCurrencyText(placeHolder);
        playerSettings = GetComponent<PlayerSettings>();
    }

    public void SpawnTower(TowerInformation tower)
    {
        if (currentCurrency < tower.currencyValue)
        {
            return;
        }

        if(isFirstDpsTower && tower.towerIndex == 0)
        {
            onFirstDpsTower_EventChannel.CallEvent(new());
            isFirstDpsTower = false;
        }
        if (isFirstSupportTower && tower.towerIndex == 1)
        {
            onFirstSupportTower_EventChannel.CallEvent(new());
            isFirstSupportTower = false;
        }

        BaseTowerAI towerAI = Instantiate(towerPrefab[tower.towerIndex], interactionBlock.transform.position, Quaternion.identity).transform.GetChild(0).GetComponent<BaseTowerAI>();
        GameManager.instance.Currency -= tower.currencyValue;
        UpdateCurrencyText(placeHolder);
        towerAI.InteractionPoint = interactionBlock;
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
        playerSettings.ReappleSens();
    }

    public void OnOpenMenu(GameObjectEvent ctx)
    {
        if (pauseUI.activeSelf || intrusctionsUI.activeSelf)
        {
            return;
        }

        Debug.Log("hello");
        interactionBlock = ctx.GameObjectRef;
        towerMenuCurrencyText.text = currencyText.text;
        OnMenutActivate();
        playerSettings.ZeroSens();
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
