using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlleyStrangerNPC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AlleyStranger;
    public Animator animator;
    public Player MyPlayer;
    public GameObject OrangeGate;
    public GameObject GrayGate;


    void Start()
    {
        animator = AlleyStranger.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPlayer.progression  < 6)
        {
            if (animator.GetBool("AlleyStrangerContact") && Input.GetKeyDown(KeyCode.E))
            {
                AlleyStranger.GetComponent<DialogueTrigger>().TriggerDialogue(1);
                MyPlayer.progression = 5;
                OrangeGate.GetComponent<OrangeGate>().ActivateGate(); // Close orange gate to prevent the player from going back
                GrayGate.GetComponent<GrayGate>().DeactivateGate(); // Open gray gate when dialogue is over
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) //triggers when player touches something
    {
        if (MyPlayer.progression < 6)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("AlleyStrangerContact", true);
                Debug.Log("touching AlleyStranger");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) //triggers when player touches something
    {
        if (MyPlayer.progression < 6)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("AlleyStrangerContact", false);
                Debug.Log("not touching AlleyStranger");
            }
        }
    }
}
