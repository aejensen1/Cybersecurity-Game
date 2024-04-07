using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGuardNPC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RobotGuard;
    public Animator animator;
    public Animator aiGizmo;
    public Player MyPlayer;
    public GameObject GrayGate;
    public GameObject BlueGate;

    void Start()
    {
        animator = RobotGuard.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPlayer.progression == 5)
        {
            if (animator.GetBool("RobotGuardContact") && Input.GetKeyDown(KeyCode.E))
            {
                RobotGuard.GetComponent<DialogueTrigger>().TriggerDialogue(1);
                GrayGate.GetComponent<GrayGate>().ActivateGate(); // Close gray gate to prevent the player from going back
            }
        }
        if (MyPlayer.progression == 7)
        {
            if (animator.GetBool("RobotGuardContact") && Input.GetKeyDown(KeyCode.E))
            {
                RobotGuard.GetComponent<DialogueTrigger>().TriggerDialogue(2);
                BlueGate.GetComponent<BlueGate>().DeactivateGate(); // Open blue gate after dialogue
                aiGizmo.SetInteger("BodySlide", 0); // Reset the terminal once dialogue is over
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) // Triggers when player touches robot guard
    {
        if (MyPlayer.progression < 8)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("RobotGuardContact", true);
                Debug.Log("touching RobotGuard");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) // Triggers when player stops touching robot guard
    {
        if (MyPlayer.progression < 8)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("RobotGuardContact", false);
                Debug.Log("not touching RobotGuard");
            }
        }
    }
}
