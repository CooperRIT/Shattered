using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] GameObject instructorDialogue;
    [SerializeField] GameObject kelderDialogue;

    public void StartGame()
    {
        StartCoroutine(StartDialogue());
    }

    public void Controls()
    {
        SceneManager.LoadScene("ControlsScene");
    }

    public void QuitGame()
    {
        Application.Quit(); // For a build
        //UnityEditor.EditorApplication.isPlaying = false; // For the editor
    }

    private IEnumerator StartDialogue()
    {
        mainMenu.SetActive(false);
        dialoguePanel.SetActive(true);
        instructorDialogue.SetActive(true);

        yield return new WaitForSeconds(10);

        kelderDialogue.SetActive(true);

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("SampleScene");
    }
}
