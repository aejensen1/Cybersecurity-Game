using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryNPC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Jerry;
    public Animator animator;
    public Player MyPlayer;
    public GameObject BlueGate;
    public GameObject YellowGate;

    void Start()
    {
        animator = Jerry.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPlayer.progression  < 10)
        {
            if (animator.GetBool("JerryContact") && Input.GetKeyDown(KeyCode.E))
            {
                Jerry.GetComponent<DialogueTrigger>().TriggerDialogue(1);
                MyPlayer.progression = 9;
                BlueGate.GetComponent<BlueGate>().ActivateGate(); // Close blue gate to prevent the player from going back
                YellowGate.GetComponent<YellowGate>().DeactivateGate(); // Open yellow gate after dialogue
            }
        }
        else if (MyPlayer.progression == 11)
        {
            if (animator.GetBool("JerryContact") && Input.GetKeyDown(KeyCode.E))
            {
                Jerry.GetComponent<DialogueTrigger>().TriggerDialogue(2);
                animator.SetBool("JerryContact", false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) // Triggers when player touches Jerry
    {
        if (MyPlayer.progression < 10)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("JerryContact", true);
                Debug.Log("touching Jerry");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) // Triggers when player stops touching Jerry
    {
        if (MyPlayer.progression < 10)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("JerryContact", false);
                Debug.Log("not touching Jerry");
            }
        }
    }
}
