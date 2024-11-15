using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueBox;
    [SerializeField] GameObject dialoguePanel;

    public void ClearDialogueBox()
    {
        dialogueBox.text = "";
        dialoguePanel.SetActive(false);
    }

    public void OnFirstWave()
    {
        dialoguePanel.SetActive(true);
        dialogueBox.text = "Kelder: The devils that were called of the Northern Empire assailed friend and fo alike.";
        Invoke("ClearDialogueBox", 5);
    }

    public void OnFirstAttack()
    {
        dialoguePanel.SetActive(true);
        dialogueBox.text = "Kelder: I cast... MAGIC!";
        Invoke("ClearDialogueBox", 2);
    }

    public void OnFirstDpsTower()
    {
        dialoguePanel.SetActive(true);
        dialogueBox.text = "Kelder: The Northern Empire unlashede the hordes of Hell using... Demon-ology.";
        Invoke("ClearDialogueBox", 5);
    }

    public void OnFirstSupportTower()
    {
        dialoguePanel.SetActive(true);
        dialogueBox.text = "Kelder: The Holy Kingdom of Ethshar called on the gods to push back the devils.";
        Invoke("ClearDialogueBox", 5);
    }
}
