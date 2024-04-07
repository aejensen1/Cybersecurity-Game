using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MowerNPC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mower;
    public Animator animator;
    public Player MyPlayer;
    public GameObject OrangeGate;

    void Start()
    {
        animator = Mower.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPlayer.progression  < 4)
        {
            if (animator.GetBool("MowerContact") && Input.GetKeyDown(KeyCode.E))
            {
                Mower.GetComponent<DialogueTrigger>().TriggerDialogue(1);
                //Mower.GetComponent<PhishDialogueTrigger>().PhishTriggerDialogue();
                MyPlayer.progression = 3;
                OrangeGate.GetComponent<OrangeGate>().DeactivateGate(); // Open orange gate when dialogue is over
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) // Triggers when player touches mower
    {
        if (MyPlayer.progression < 4)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("MowerContact", true);
                Debug.Log("touching Mower");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) // Triggers when player stops touching mower
    {
        if (MyPlayer.progression < 4)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("MowerContact", false);
                Debug.Log("not touching Mower");
            }
        }
    }

    public void MowerNoInteract()
    {
        animator.SetBool("MowerContact", false);
    }
}
