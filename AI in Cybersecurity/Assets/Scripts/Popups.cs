using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popups : MonoBehaviour
{
    public Animator anim;
    public GameObject Dialogue;
    // Start is called before the first frame update
    void Start()
    {
        anim = Dialogue.GetComponent<Animator>();
        Dialogue.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestDialogue()
    {
        Dialogue.GetComponent<Canvas>().enabled = false;
    }

    public void ShowDialogue()
    {
        Dialogue.GetComponent<Canvas>().enabled = true;
    }
}
