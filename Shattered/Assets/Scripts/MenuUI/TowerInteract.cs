using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerInteract : MonoBehaviour
{
    [SerializeField] GameObject interactUI;
    [SerializeField] PlayerSettings playerSettings;
    GameObject tempTower;

    void OnMenutActivate()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        interactUI.SetActive(true);
    }

    public void OpenMenu(GameObjectEvent ctx)
    {
        tempTower = ctx.GameObjectRef;
        playerSettings.ZeroSens();
        OnMenutActivate();
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

    public void DestroyTower()
    {
        Destroy(tempTower);
        ButtonUsed();
    }
}
