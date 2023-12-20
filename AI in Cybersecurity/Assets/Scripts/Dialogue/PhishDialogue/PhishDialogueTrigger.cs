using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhishDialogueTrigger : MonoBehaviour
{
    
    public PhishDialogue phishDialogue;

    public void PhishTriggerDialogue()
    {
        FindObjectOfType<PhishDialogueManager>().StartPhishDialogue(phishDialogue);
    }
    
}
