using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Cooper - Too early to comment on right now, can't wait to see it fully implimented

    // Variables
    [SerializeField] GameObject menuUI;
    private bool isPaused = false;
    void Update()
    {
        if (true == false) // Putting a pin in this for now, will come back
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void Resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
