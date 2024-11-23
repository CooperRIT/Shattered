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
    [SerializeField] GameObject upgradeUI;

    [SerializeField] List<GameObject> towerPrefab = new List<GameObject>();
    [SerializeField] GameObject placementPosition;

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

    [SerializeField] VoidEventChannel onChooseDpsTower_EventChannel;
    [SerializeField] VoidEventChannel onChooseSupportTower_EventChannel;
    [SerializeField] VoidEventChannel onChooseGamblingTower_EventChannel;
    [SerializeField] VoidEventChannel onDisableDescriptionMenu_EventChannel;

    //dynamic placing
    [SerializeField] Material towerMaterial;
    [SerializeField] Material placingMaterial;
    GameObject tempTower;
    MeshRenderer tempTowerMeshRenderer;
    TowerInformation tempTowerInformation;
    Collider tempTowerCollider;
    [SerializeField] VoidEventChannel onEnterPlacementMode_EventChannel;

    [SerializeField] GameObject placingControls;

    // Update is called once per frame
    void Awake()
    {
        UpdateCurrencyText(placeHolder);
        playerSettings = GetComponent<PlayerSettings>();
    }

    /*public void SpawnTower(TowerInformation tower)
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
    }*/

    


    public void ButtonUsed()
    {
        // Hide the cursor and lock it to the center of the screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Hide and deactivate the menu
        menuUI.SetActive(false);
        playerSettings.ReappleSens();
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

    //Dynamic Placing Version

    public void SpawnTower(VoidEvent ctx)
    {
        if (isFirstDpsTower && tempTowerInformation.towerIndex == 0)
        {
            onFirstDpsTower_EventChannel.CallEvent(new());
            isFirstDpsTower = false;
        }
        if (isFirstSupportTower && tempTowerInformation.towerIndex == 1)
        {
            onFirstSupportTower_EventChannel.CallEvent(new());
            isFirstSupportTower = false;
        }
        GameManager.instance.Currency -= tempTowerInformation.currencyValue;
        tempTowerMeshRenderer.material = towerMaterial;
        tempTower.transform.parent = null;
        tempTowerCollider.enabled = true;
        UpdateCurrencyText(placeHolder);
        tempTower = null;
        placingControls.SetActive(false);
        onDisableDescriptionMenu_EventChannel.CallEvent(new());
    }

    public void CancelPlacement(VoidEvent ctx)
    {
        ButtonUsed();
        placingControls.SetActive(false);
        if(tempTower == null)
        {
            return;
        }
        Destroy(tempTower);
    }

    public void SelectTower(TowerInformation tower)
    {
        if (currentCurrency < tower.currencyValue)
        {
            return;
        }
        
        switch (tower.towerIndex)
        {
            case 0:
                onChooseDpsTower_EventChannel.CallEvent(new());
                break;
            case 1:
                onChooseSupportTower_EventChannel.CallEvent(new());
                break;
            case 2:
                onChooseGamblingTower_EventChannel.CallEvent(new());
                break;
        }

        placingControls.SetActive(true);

        onEnterPlacementMode_EventChannel.CallEvent(new());

        tempTower = Instantiate(towerPrefab[tower.towerIndex], placementPosition.transform.position, Quaternion.identity);
        tempTowerMeshRenderer = tempTower.GetComponent<MeshRenderer>();

        towerMaterial = tempTowerMeshRenderer.material;
        tempTowerMeshRenderer.material = placingMaterial;

        tempTower.transform.parent = placementPosition.transform;
        tempTowerInformation = tower;

        tempTowerCollider = tempTower.GetComponent<Collider>();
        tempTowerCollider.enabled = false;

        ButtonUsed();
    }

    public void OnOpenMenu(GameObjectEvent ctx)
    {
        if (pauseUI.activeSelf || intrusctionsUI.activeSelf || upgradeUI.activeSelf)
        {
            return;
        }

        Debug.Log("hello");
        placementPosition = ctx.GameObjectRef;
        towerMenuCurrencyText.text = currencyText.text;
        OnMenutActivate();
        playerSettings.ZeroSens();
    }
}
