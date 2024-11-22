using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject controlsMenu;
    [SerializeField] GameObject instructorDialogue;
    [SerializeField] GameObject kelderDialogue;

    public void StartGame()
    {
        StartCoroutine(StartDialogue());
    }

    public void MenuSwap(GameObject menu)
    {
        mainMenu.SetActive(!(mainMenu.activeSelf));
        menu.SetActive(!(menu.activeSelf));
    }

    public void QuitGame()
    {
        Application.Quit(); // For a build
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private IEnumerator StartDialogue()
    {
        mainMenu.SetActive(false);
        instructorDialogue.SetActive(true);

        yield return new WaitForSeconds(10);

        kelderDialogue.SetActive(true);

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("SampleScene");
    }
}
