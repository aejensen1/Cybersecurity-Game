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


    void Start()
    {
        animator = RobotGuard.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPlayer.progression == 5 || MyPlayer.progression == 7)
        {
            if (animator.GetBool("RobotGuardContact") && Input.GetKeyDown(KeyCode.E))
            {
                RobotGuard.GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) //triggers when player touches something
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

    void OnTriggerExit2D(Collider2D other) //triggers when player touches something
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
