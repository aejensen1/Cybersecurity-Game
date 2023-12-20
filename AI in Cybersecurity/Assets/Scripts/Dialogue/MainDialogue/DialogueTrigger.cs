using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue dialogue2;

    public Player MyPlayer;

    public void TriggerDialogue()
    {
        if (MyPlayer.progression == 7 || MyPlayer.progression == 11 || MyPlayer.progression == 14 || MyPlayer.progression == 15)
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue2);
        else
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
