using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawn : MonoBehaviour
{
    // Variables
    public bool menuActive = false;

    [SerializeField] GameObject menuUI;

    // Properties
    public bool MenuActive
    {
        get => menuActive;
        set => menuActive = value;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the value has been changed to true (will happen in the interactble object's script)
        if (menuActive)
        {
            // Show the cursor and allow it to move about the screen
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            menuUI.SetActive(true); // Show the menu screen
        }
    }

    public void ButtonUsed()
    {
        // Hide the cursor and lock it to the center of the screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Hide and deactivate the menu
        menuUI.SetActive(false);
        menuActive = false;
    }
}
