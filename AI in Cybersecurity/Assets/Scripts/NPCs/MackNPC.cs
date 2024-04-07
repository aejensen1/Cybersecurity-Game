using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MackNPC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mack;
    public Animator animator;
    public Player MyPlayer;
    public GameObject RedGate;
    public GameObject GreenGate;

    void Start()
    {
        animator = Mack.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPlayer.progression < 3)
        {
            if (animator.GetBool("MackContact") && Input.GetKeyDown(KeyCode.E))
            {
                Mack.GetComponent<DialogueTrigger>().TriggerDialogue(1);
                MyPlayer.progression = 2;
                RedGate.GetComponent<RedGate>().ActivateGate(); // Close red gate when dialogue is over to prevent going back
                GreenGate.GetComponent<GreenGate>().DeactivateGate(); // Open green gate when dialogue is over
            }
        }
        else if (MyPlayer.progression == 4)
        {
            if (animator.GetBool("MackContact") && Input.GetKeyDown(KeyCode.E))
            {
                Mack.GetComponent<DialogueTrigger>().TriggerDialogue(2); // NPC indicates where orange gate opened
                animator.SetBool("RoombotContact", false);
                GreenGate.GetComponent<GreenGate>().ActivateGate(); // Close green gate when dialogue is over to prevent going back
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) //triggers when player touches something
    {
        if (MyPlayer.progression < 3 || MyPlayer.progression == 4)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("MackContact", true);
                Debug.Log("touching Mack");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) //triggers when player touches something
    {
        if (MyPlayer.progression < 3 || MyPlayer.progression == 4)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("MackContact", false);
                Debug.Log("not touching Mack");
            }
        }
    }
}
