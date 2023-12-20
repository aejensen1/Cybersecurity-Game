using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryNPC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Jerry;
    public Animator animator;
    public Player MyPlayer;


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
                Jerry.GetComponent<DialogueTrigger>().TriggerDialogue();
                MyPlayer.progression = 9;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) //triggers when player touches something
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

    void OnTriggerExit2D(Collider2D other) //triggers when player touches something
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
