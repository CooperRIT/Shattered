using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Cooper - Too early to comment on right now, can't wait to see it fully implimented

    // Variables
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject towerUI;
    [SerializeField] GameObject instructionsUI;
    [SerializeField] GameObject upgradeUI;

    public void Pause()
    {
        if(towerUI.activeSelf || instructionsUI.activeSelf || upgradeUI.activeSelf)
        {
            return;
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        menuUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        menuUI.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
//This allows you to check if we are in the unity editor without causing build errors
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
